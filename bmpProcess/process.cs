using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows;

namespace bmpProcess
{
    //[StructLayout(LayoutKind.Sequential, Pack = 1)]
    //struct存在以4或8为标志进行字节对齐，需要用pack（2）限定对齐系数大小
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FileHader {
        public ushort   bfType;
        public uint    bfSize;
        public ushort   bfReserved1;
        public ushort   bfReserved2;
        public uint    bfOffBits;
    };

    public struct InfoHader {
        public uint biSize;
        public uint biWidth;
        public uint biHeight;
        public ushort   biPlanes;
        public ushort   biBitCount;
        public uint biCompression;
        public uint biSizeImage;
        public uint biXperlsPerMeter;
        public uint biYperlsPerMeter;
        public uint biClrUsed;
        public uint biCleImportant;

        public uint l_width;
        public uint channels;
        public uint length;
    };

    public class process
    {
        public FileStream fs;

        public FileHader fileHader;
        public InfoHader infoHader;
        public byte[] colorTable;
        public byte[] pixelData;
        int tag = 0;

        public process()
        { 
            
        }

        public void getData(FileStream filestream)
        {
            //this.filPath = fileString;
            //FileStream filestream = new FileStream(filPath,FileMode.Open);
            this.fs = filestream;
            fs.Seek(0, SeekOrigin.Begin);
            BinaryReader biReader = new BinaryReader(fs);
            Byte[] buff = new Byte[54];
            biReader.Read(buff, 0, 54);
            IntPtr fileHaderPtr = Marshal.AllocHGlobal(14);                     //给Ptr分配内存
            Marshal.Copy(buff, 0, fileHaderPtr, 14);                            //将buff中的字节复制到Ptr
            fileHader = (FileHader)Marshal.PtrToStructure(fileHaderPtr,typeof(FileHader));      //Ptr内存空间转换为结构体
            Marshal.FreeHGlobal(fileHaderPtr);                                  //释放Ptr

            IntPtr infoHaderPtr = Marshal.AllocHGlobal(52);
            Marshal.Copy(buff, 14, infoHaderPtr, 40);
            infoHader = (InfoHader)Marshal.PtrToStructure(infoHaderPtr, typeof(InfoHader));
            Marshal.FreeHGlobal(infoHaderPtr);
            infoHader.channels = (uint) infoHader.biBitCount / 8;
            infoHader.l_width = (infoHader.biWidth * infoHader.channels + 3) / 4 * 4;
            infoHader.length = infoHader.l_width * infoHader.biHeight;

			if (fileHader.bfOffBits == 54)
			{
                //fs.Seek(fileHader.bfOffBits,SeekOrigin.Begin);
                pixelData = new Byte[infoHader.length];      //给像素数据分配内存空间
                biReader.Read(pixelData ,0 , (int)infoHader.length);    //读取数据并存储
                colorTable = null;
			}
			else 
			{
                int clrTabLength = (int)fileHader.bfOffBits - 54;
                colorTable = new Byte[clrTabLength];
                biReader.Read(colorTable, 0, clrTabLength);
                pixelData = new Byte[infoHader.length];
                biReader.Read(pixelData, 0, (int)infoHader.length);
			}
            //filestream.Close();
        }

        public bool transToGray(out process outPic, int tag)
        {
            if (infoHader.channels != 3) 
            {
                outPic = new process();
                return false;
            }
            outPic = (process)this.MemberwiseClone();

            //FileHader fileHader = this.fileHader;
            //InfoHader infoHader = this.infoHader;

            //this.colorTable.CopyTo(outPic.colorTable, 0);
            int newLw = ((int)this.infoHader.biWidth + 3) / 4 * 4;
            uint newLength = (uint)(newLw * this.infoHader.biHeight);
            outPic.pixelData = new byte[newLength];
            outPic.colorTable = new byte[1024];

            for (int i = 0 ; i < 256; i++)
            {
                outPic.colorTable[i * 4] = (byte)i;
                outPic.colorTable[i * 4 + 1] = (byte)i;
                outPic.colorTable[i * 4 + 2] = (byte)i;
                outPic.colorTable[i * 4 + 3] = 0;
            }

            //修改一下，改成8位存储
            int fixNum = newLw - (int)infoHader.biWidth;
            for (uint h = 0, w = 0, i = 0; h < infoHader.biHeight ; h++) 
            {
		        Byte charTemp;
		        uint temp;
                uint grayIndex;
		        for (w = 0, i = 0; w < infoHader.biWidth; w++) {
                    grayIndex = i;
			        uint R = (uint)pixelData[h * infoHader.l_width + i];
			        uint G = (uint)pixelData[h * infoHader.l_width + i + 1];
			        uint B = (uint)pixelData[h * infoHader.l_width + i + 2];
			        i += 3;
			        temp = (R * 299 + G * 587 + B * 144 + 500) / 1000;
                    if (temp > 255) temp = 255;
			        charTemp = (Byte)(0xff & temp);
                    outPic.pixelData[h * newLw + w] = charTemp;
		        }

		        //补位
		        charTemp = 0xff;
		        for (uint j = 0; j < fixNum; j++) {
                    outPic.pixelData[h * newLw + w + j] = charTemp;
		        }
	        }


            outPic.fileHader.bfOffBits = (uint)1078;
            outPic.fileHader.bfSize = (uint)(54 +1024 + newLength);
            outPic.infoHader.biBitCount = (ushort)8;
            outPic.infoHader.biSizeImage = (uint)(newLength);
            outPic.infoHader.length = (uint)(newLength);
            outPic.infoHader.l_width = (uint)newLw;
            if (tag == 1)
            {
                outPic.toFileStream(this.fs.Name , 1);
            }
            return true;
        }

        public System.Drawing.Image ReturnPhoto(byte[] streamByte)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(streamByte);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            return img;
        }

        public static System.Drawing.Image ReturnPhoto(process inPic)
        {
            //结构体到字节数组
            IntPtr filePtr = Marshal.AllocHGlobal(14);
            Marshal.StructureToPtr(inPic.fileHader, filePtr, false);
            Byte[] fileBuff = new Byte[14];
            Marshal.Copy(filePtr, fileBuff, 0, 14);
            Marshal.FreeHGlobal(filePtr);

            IntPtr infoPtr = Marshal.AllocHGlobal(52);
            Marshal.StructureToPtr(inPic.infoHader, infoPtr, false);
            Byte[] infoBuff = new Byte[40];
            Marshal.Copy(infoPtr, infoBuff, 0, 40);
            Marshal.FreeHGlobal(infoPtr);

            List<byte> list = new List<byte>();
            list.AddRange(fileBuff);
            list.AddRange(infoBuff);

            if (inPic.fileHader.bfOffBits != 54)
            {

                list.AddRange(inPic.colorTable);
            }
            list.AddRange(inPic.pixelData);

            System.IO.MemoryStream ms = new System.IO.MemoryStream(list.ToArray());
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            return img;
        }

        private string getName(string inName)
        {
            int lastIndex = inName.LastIndexOf('.');
            int preIndex = inName.LastIndexOf('\\');
            return inName.Substring(preIndex + 1, lastIndex - preIndex - 1);
        }
        
        /// <summary>
        /// 第二个参数mode 1 为灰度图像 ， 2 3 4 5 依次为加减乘除
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="filename2"></param>
        /// <param name="mode"></param>
        // 第二个参数mode 1 为灰度图像 ， 2 3 4 5 依次为加减乘除
        private void toFileStream(string filename, string filename2, int mode)
        {
            string fname = getName(filename);
            string fname1 = getName(filename2);
            string outFileName;

            switch (mode)
            {
                //case 1:
                //    outFileName = "out//" + fname + "_toGray.bmp";
                //    break;
                case 1:
                    outFileName = "out//(" + fname +"_sum_" + fname1+").bmp";
                    break;
                case 2:
                    outFileName = "out//(" + fname + "_sub_" + fname1 + ").bmp";
                    break;
                case 3:
                    outFileName = "out//(" + fname + "_Mul_" + fname1 + ").bmp";
                    break;
                case 4:
                    outFileName = "out//(" + fname + "_Div_" + fname1 + ").bmp";
                    break;
                case 5:
                    outFileName = "out//(" + fname + "_And_" + fname1 + ").bmp";
                    break;
                case 6:
                    outFileName = "out//(" + fname + "_or_" + fname1 + ").bmp";
                    break;
                default:
                    outFileName = "out//" + fname + "_none.bmp";
                    break;
            }
            writeStream(outFileName);

        }

        private void toFileStream(string filename, int mode)
        {
            string fname = getName(filename);
            string outFileName;

            switch (mode)
            {
                case 1:
                    outFileName = "out//" + fname + "_toGray.bmp";
                    break;
                case 2:
                    outFileName = "out//" + fname + "_Not.bmp";
                    break;
                case 3:
                    outFileName = "out//" + fname + "_Move.bmp";
                    break;
                case 4:
                    outFileName = "out//" + fname + "_Spin.bmp";
                    break;
                case 5:
                    outFileName = "out//" + fname + "_Enlarge.bmp";
                    break;
                case 6:
                    outFileName = "out//" + fname + "_Narrow.bmp";
                    break;
                case 7:
                    outFileName = "out//" + fname + "_Mirror.bmp";
                    break;
                default:
                    outFileName = "out//" + fname + "_none.bmp";
                    break;
            }
            writeStream(outFileName);
        }
       
        /// <summary>
        /// 写入文件流
        /// </summary>
        /// <param name="outFileName"></param>
        //写入文件流
        private void writeStream(string outFileName)
        {
            try
            {
                if (!Directory.Exists("out//"))
                {
                    Directory.CreateDirectory("out//");
                }
                this.fs = new FileStream(outFileName, FileMode.OpenOrCreate);
            }
            catch (Exception e1)
            {
                int index = 0;
                index = outFileName.LastIndexOf('_');
                outFileName.Insert(index, tag.ToString());
                this.fs = new FileStream(outFileName, FileMode.OpenOrCreate);
                tag++;
            }
            //结构体到字节数组
            IntPtr filePtr = Marshal.AllocHGlobal(14);
            Marshal.StructureToPtr(this.fileHader, filePtr, false);
            Byte[] fileBuff = new Byte[14];
            Marshal.Copy(filePtr, fileBuff, 0, 14);
            Marshal.FreeHGlobal(filePtr);

            IntPtr infoPtr = Marshal.AllocHGlobal(52);
            Marshal.StructureToPtr(this.infoHader, infoPtr, false);
            Byte[] infoBuff = new Byte[40];
            Marshal.Copy(infoPtr, infoBuff, 0, 40);
            Marshal.FreeHGlobal(infoPtr);

            fs.Write(fileBuff, 0, 14);
            fs.Write(infoBuff, 0, 40);
            if (this.fileHader.bfOffBits != 54)
            {
                fs.Write(this.colorTable, 0, (int)(this.fileHader.bfOffBits - 54));
            }
            fs.Write(this.pixelData, 0, (int)this.infoHader.length);
        }

        /// <summary>
        /// 深拷贝对象
        /// </summary>
        /// <param name="inPic"></param>
        /// <param name="outPic"></param>
        //深拷贝对象
        private static void copy(process inPic , out process outPic)
        {
            outPic = (process)inPic.MemberwiseClone();
            if (outPic.fileHader.bfOffBits != 54)
            {
                outPic.colorTable = new byte[1024];
                Array.Copy(inPic.colorTable, outPic.colorTable, 1024);
                //outPic.colorTable =  (byte[])inPic.colorTable.Clone();
            }
            outPic.pixelData = new byte[outPic.infoHader.length];
            Array.Copy(inPic.pixelData, outPic.pixelData, (int)(outPic.infoHader.length));
        }

        /// <summary>
        /// 返回数组中值
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        //返回输入数组的中值
        private static byte getMidNum(byte[] array)
        {
            int size = array.Length;

            for (int i = 0; i < size; i++)
            {
                for (int j = i; j < size; j++)
                {
                    if (array[i] > array[j])
                    {
                        byte temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return (byte)array[size / 2];
        }

        //双目运算 mode 1,2,3,4分别表示加减乘除 , 5,6表示逻辑与、或运算
        public static bool doubOperator(process inPic1, process inPic2, out process outPic , int mode)
        {
            //大小不一致无法加减
            if (inPic1.infoHader.l_width != inPic2.infoHader.l_width && inPic1.infoHader.biHeight != inPic2.infoHader.biHeight)
            {
                outPic = new process();
                return false;
            }
            process.copy(inPic1, out outPic);

            for (int i = 0; i < inPic1.infoHader.length; i++)
            {
                int temp = 0;
                switch (mode)
                {
                    case 1:
                        temp = (inPic1.pixelData[i] + inPic2.pixelData[i]);
                        break;
                    case 2:
                        temp = (inPic1.pixelData[i] - inPic2.pixelData[i]);
                        break;
                    case 3:
                        temp = (inPic1.pixelData[i] * inPic2.pixelData[i]);
                        break;
                    case 4:
                        if (inPic2.pixelData[i] == 0) inPic2.pixelData[i] = 1;
                        temp = (inPic1.pixelData[i] / inPic2.pixelData[i]);
                        break;
                    case 5:
                        temp = (byte)(inPic1.pixelData[i] & inPic2.pixelData[i]);
                        break;
                    case 6:
                        temp = (byte)(inPic1.pixelData[i] | inPic2.pixelData[i]);
                        break;
                    default:
                        break;
                }
                        
                if (temp > 255)
                    outPic.pixelData[i] = (byte)255;
                else if (temp < 0)
                    outPic.pixelData[i] = (byte)0;
                else
                    outPic.pixelData[i] = (byte)temp;
            }
            outPic.toFileStream(inPic1.fs.Name,inPic2.fs.Name,mode);
             
            return true;
        }

        public static bool notOperator(process inPic1,out process outPic)
        {
            outPic = new process();
            //对每一个字节进行二进制与或运算，不用转化为二值图像
            process.copy(inPic1, out outPic);

            for (int i = 0; i < inPic1.infoHader.length; i++)
            {
                byte temp = 0;
                temp = (byte)~inPic1.pixelData[i];
                outPic.pixelData[i] = temp;
            }

            outPic.toFileStream(inPic1.fs.Name, 2);
            return true;
        }
        
        //时间关系仅做固定尺寸平移
        public static bool move(process inPic , out process outPic)
        {
            outPic = new process();
            outPic = (process)inPic.MemberwiseClone();
            if (outPic.fileHader.bfOffBits != 54)
            {
                outPic.colorTable = (byte[])inPic.colorTable.Clone();
            }
            outPic.pixelData = new byte[inPic.pixelData.Length];

            int xMovePix = (int)(inPic.infoHader.biWidth / 10);
            int yMovePix = (int)(inPic.infoHader.biHeight / 10);
            int lw = (int)inPic.infoHader.l_width;

            for (int h = 0, i = 0; h < inPic.infoHader.biHeight - yMovePix; h++)
            {
                for (i = 0; i < lw - xMovePix * inPic.infoHader.channels; i++)
                {
                    outPic.pixelData[(h + yMovePix) * lw + (xMovePix) * inPic.infoHader.channels + i] = inPic.pixelData[h * lw + i];
                }
            }

            outPic.toFileStream(inPic.fs.Name, 3);
            return true;
        }

        //时间关系仅完成水平镜像
        public static bool mirror(process inPic, out process outPic)
        {
            outPic = new process();
            process.copy(inPic, out outPic);

            uint lw = inPic.infoHader.l_width;
            int fixNum = (int)(lw - inPic.infoHader.biWidth * inPic.infoHader.channels);
            for (int h = 0, i = 0; h < inPic.infoHader.biHeight; h++)
            {
                for (i = 0; i < lw - fixNum; )
                {
                    //outPic.pixelData[(h + 1) * lw - i - fixNum - 1] = inPic.pixelData[h * lw + i ];
                    byte R = inPic.pixelData[h * lw + i];
                    byte G = inPic.pixelData[h * lw + i + 1];
                    byte B = inPic.pixelData[h * lw + i + 2];
                    outPic.pixelData[(h + 1) * lw - i - fixNum - 1] = B;
                    outPic.pixelData[(h + 1) * lw - i - fixNum - 2] = G;
                    outPic.pixelData[(h + 1) * lw - i - fixNum - 3] = R;

                    i += 3;
                }

            }
            outPic.toFileStream(inPic.fs.Name, 7);
            return true;
        }

        /// <summary>
        /// 缩小函数，仅接受24位图像输入
        /// </summary>
        /// <param name="inPic"></param>
        /// <param name="outPic"></param>
        /// <returns></returns>
        public static bool narrow(process inPic, out process outPic)
        {
            //xy统一缩小50%
            int newWidth = (int)(inPic.infoHader.biWidth / 2);
            int newheight = (int)(inPic.infoHader.biHeight / 2);
            int newLw = (int)(newWidth * inPic.infoHader.channels + 3) / 4 * 4;

            outPic = (process)inPic.MemberwiseClone();
            if (outPic.fileHader.bfOffBits != 54)
            {
                outPic.colorTable = (byte[])inPic.colorTable.Clone();
            }
            outPic.pixelData = new byte[newheight * newLw];

            int fixNum = (int)(newLw - newWidth*inPic.infoHader.channels);
            for (int h = 0, w = 0; h < newheight; h++)
            {
                for (w = 0; w < newWidth && (2*h)<inPic.infoHader.biHeight; w++)
                {
                    int oIndex = (int)(h * newLw + w * inPic.infoHader.channels);
                    int iIndex = (int)(2 * h * inPic.infoHader.l_width + 2 * w * inPic.infoHader.channels);

                    int R = inPic.pixelData[iIndex];
                    int G = inPic.pixelData[iIndex + 1];
                    int B = inPic.pixelData[iIndex + 2];
                    outPic.pixelData[oIndex] = (byte)R;
                    outPic.pixelData[oIndex + 1] = (byte)G;
                    outPic.pixelData[oIndex + 2] = (byte)B;
                }
            }

            //重构文件头
            outPic.infoHader.biWidth = (uint)newWidth;
            outPic.infoHader.biHeight = (uint)newheight;
            outPic.fileHader.bfSize = (uint)(54 + newLw * newheight * outPic.infoHader.channels);
            outPic.infoHader.biSizeImage = (uint)(newLw * newheight * outPic.infoHader.channels);
            outPic.infoHader.length = (uint)(newLw * newheight);

            outPic.toFileStream(inPic.fs.Name, 6);

            return true;
        }

        //使用后向映射（双线性好像很好玩，有时间可以做一下）最近邻的线性插值锯齿现象较严重
        public static bool enlarge(process inPic, out process outPic)
        {
            double enlSize = 2.0;           //放大倍数，时间紧迫未完善做到根据输入确定放大倍数
            int lw = (int)inPic.infoHader.l_width;
            int ch = (int)inPic.infoHader.channels;
            int newWidth = (int)Math.Ceiling(inPic.infoHader.biWidth * enlSize);    //向上取整
            int newHeight = (int)Math.Ceiling(inPic.infoHader.biHeight * enlSize);
            int newLw = (int)((newWidth * ch +3)/4*4);
           
            outPic = (process)inPic.MemberwiseClone();
            if (outPic.fileHader.bfOffBits != 54)
            {
                outPic.colorTable = (byte[])inPic.colorTable.Clone();
            }
            outPic.pixelData = new byte[newHeight * newLw];         //创建新的数据区
         
            for (int h = 0, w = 0; h < newHeight; h++)
            {
                double hTemp = ((double)h / (double)newHeight)*(double)inPic.infoHader.biHeight;
                int hDown = (int)Math.Ceiling(hTemp);               //同一行的上下近邻是一致的
                int hUp = (int)hTemp;
                if (hDown > (inPic.infoHader.biHeight - 1))
                {
                    hDown = (int)inPic.infoHader.biHeight - 1;
                }

                for (w = 0; w < newWidth; w++)
                {
                    double wTemp = ((double)w / (double)newWidth)*(double)inPic.infoHader.biWidth;
                    int wLeft = (int)wTemp;
                    int wRight = (int)Math.Ceiling(wTemp);
                    if (wRight > (inPic.infoHader.biWidth - 1))
                    {
                        wRight = (int)inPic.infoHader.biWidth - 1;
                    }

                    int oIndex = (int)(h*newLw + w*ch);
                    //新的像素为四个角像素的平均
                    int R = (inPic.pixelData[hUp * lw + wLeft * ch]             
                            + inPic.pixelData[hUp * lw + wRight * ch] 
                            + inPic.pixelData[hDown * lw + wLeft * ch] 
                            + inPic.pixelData[hDown * lw + wRight * ch]) / 4;
                    int G = (inPic.pixelData[hUp * lw + wLeft * ch +1]
                            + inPic.pixelData[hUp * lw + wRight * ch +1]
                            + inPic.pixelData[hDown * lw + wLeft * ch +1]
                            + inPic.pixelData[hDown * lw + wRight * ch +1]) / 4;
                    int B = (inPic.pixelData[hUp * lw + wLeft * ch +2]
                            + inPic.pixelData[hUp * lw + wRight * ch +2]
                            + inPic.pixelData[hDown * lw + wLeft * ch +2]
                            + inPic.pixelData[hDown * lw + wRight * ch +2]) / 4;

                    outPic.pixelData[oIndex] = (byte)R;
                    outPic.pixelData[oIndex +1] = (byte)G;
                    outPic.pixelData[oIndex +2] = (byte)B;
                }
            }

            outPic.infoHader.biWidth = (uint)newWidth;
            outPic.infoHader.biHeight = (uint)newHeight;
            outPic.fileHader.bfSize = (uint)(54 + newLw * newHeight * ch);
            outPic.infoHader.biSizeImage = (uint)(newLw * newHeight * ch);
            outPic.infoHader.length = (uint)(newLw * newHeight);
            outPic.toFileStream(inPic.fs.Name, 5);

            return true;
        }

        //时间关系只做了顺时针旋转45度
        public static bool spin(process inPic, out process outPic)
        {
            double cos = 0.707;         //旋转角度
            double sin = 0.707;    
            
            outPic = (process)inPic.MemberwiseClone();          //计算新图像的参数
            int lw = (int)inPic.infoHader.l_width;
            int ch = (int)inPic.infoHader.channels;
            int nWidth = (int)Math.Ceiling((int)inPic.infoHader.biWidth * 0.707 + (int)inPic.infoHader.biHeight * 0.707);
            int nHeight = (int)Math.Ceiling((int)inPic.infoHader.biWidth * 0.707 + (int)inPic.infoHader.biHeight * 0.707);
            int nLw = (int)((nWidth *ch+3)/4*4);

            int oldXSize = (int)inPic.infoHader.biWidth / 2;        //辅助参数
            int oldYSize = (int)inPic.infoHader.biHeight / 2;
            int nXSize = (int)nWidth / 2;
            int nYSize = (int)nHeight / 2;


            if (outPic.fileHader.bfOffBits != 54)
            {
                outPic.colorTable = (byte[])inPic.colorTable.Clone();
            }
            outPic.pixelData = new byte[nLw * nHeight];         //创建新的像素空间

            //直接将像素转移到新的图像
            for (int x = 0, y = 0; y < inPic.infoHader.biHeight; y++)
            {
                for (x = 0; x < inPic.infoHader.biWidth; x++)
                {
                    int R = inPic.pixelData[y * inPic.infoHader.l_width + x * ch];
                    int G = inPic.pixelData[y * inPic.infoHader.l_width + x * ch +1];
                    int B = inPic.pixelData[y * inPic.infoHader.l_width + x * ch +2];

                    int nX = (int)(cos * (x - oldXSize) + sin * (y - oldYSize));        //计算新的坐标
                    int nY = (int)(cos * (y - oldYSize) - sin * (x - oldXSize));

                    nX = nX + nXSize;
                    nY = nY + nYSize;

                    outPic.pixelData[nY * nLw + nX * ch] = (byte)R;
                    outPic.pixelData[nY * nLw + nX * ch +1] = (byte)G;
                    outPic.pixelData[nY * nLw + nX * ch +2] = (byte)B;
                }
            }

            //对图像进行双线性插值补全遗漏像素
            for (int x = 0, y = 0; y < nHeight; y++)
            {
                int yUp = y + 1;
                int yDown = y - 1;
                if (yDown < 0) yDown = 0;
                if (yUp > (nHeight - 1)) yUp = nHeight - 1;

                for (x = 0; x < nWidth; x++)
                {
                    int xLeft = x - 1;
                    int xRight = x + 1;
                    if (xLeft < 0) xLeft = 0;
                    if (xRight > (nWidth - 1)) xRight = nWidth - 1;

                    int R = outPic.pixelData[y * nLw + x * ch];
                    int G = outPic.pixelData[y * nLw + x * ch + 1];
                    int B = outPic.pixelData[y * nLw + x * ch + 2];

                    if (R == 0 && G == 0 && B == 0)
                    {
                        R = (int)(outPic.pixelData[y * nLw + xLeft * ch] + outPic.pixelData[y * nLw + xRight * ch]
                            + outPic.pixelData[yUp * nLw + x * ch] + outPic.pixelData[yDown * nLw + x * ch]) / 4;

                        G = (int)(outPic.pixelData[y * nLw + xLeft * ch + 1] + outPic.pixelData[y * nLw + xRight * ch + 1]
                            + outPic.pixelData[yUp * nLw + x * ch + 1] + outPic.pixelData[yDown * nLw + x * ch] + 1) / 4;

                        B = (int)(outPic.pixelData[y * nLw + xLeft * ch + 2] + outPic.pixelData[y * nLw + xRight * ch + 2]
                            + outPic.pixelData[yUp * nLw + x * ch + 2] + outPic.pixelData[yDown * nLw + x * ch + 2]) / 4;
                    }

                    outPic.pixelData[y * nLw + x * ch] = (byte)R;
                    outPic.pixelData[y * nLw + x * ch + 1] = (byte)G;
                    outPic.pixelData[y * nLw + x * ch + 2] = (byte)B;
                }
            }

            outPic.infoHader.biWidth = (uint)nWidth;
            outPic.infoHader.biHeight = (uint)nHeight;
            outPic.fileHader.bfSize = (uint)(54 + nLw * nHeight * ch);
            outPic.infoHader.biSizeImage = (uint)(nLw * nHeight * ch);
            outPic.infoHader.length = (uint)(nLw * nHeight);
            outPic.toFileStream(inPic.fs.Name, 4);


            return true;
        }

        /**一下算法输出图像不再自动保存，需要手动保存
         **位图切割部分不提供保存功能**/

        //位面切割，如果不是8位图像自动转化位8位 
        public static System.Drawing.Image bitCut(process inPic, int mode )
        {
            process outPic = new process();
            if (inPic.infoHader.biBitCount != 8)
            {
                inPic.transToGray(out outPic, 2);
            }
            else
            {
                copy(inPic, out outPic);
            }

            for (int i = 0; i < outPic.infoHader.length; i++)
            {
                int temp = outPic.pixelData[i] & (1 << mode);
                
                outPic.pixelData[i] = (byte)temp;    
            }

            return ReturnPhoto(outPic);
        }

        //线性拓展
        public static System.Drawing.Image linearExpand(process inPic)
        {
            process outPic = new process();
            double a = 1.4;
            double b = -50;
            //int left = 70;
            //int right = 200;

            if (inPic.infoHader.biBitCount != 8)
            {
                inPic.transToGray(out outPic, 2);
            }
            else
            {
                copy(inPic, out outPic);
            }

            for (int i = 0; i < outPic.infoHader.length; i++)
            {
                int temp = (int)outPic.pixelData[i];
                temp = (int)(a * temp+0.5 + b);
                if (temp < 0) temp = 0;
                if (temp > 255) temp = 255;
                outPic.pixelData[i] = (byte)temp;
            }
            return ReturnPhoto(outPic);
        }

        //对数拓展
        public static System.Drawing.Image nonlinearExpand(process inPic)
        {
            process outPic = new process();
            //double a = 1.2;
            //double b = -50;
            //int left = 70;
            //int right = 200;
            double c = 255 / Math.Log10(256);

            if (inPic.infoHader.biBitCount != 8)
            {
                inPic.transToGray(out outPic, 2);
            }
            else
            {
                copy(inPic, out outPic);
            }

            for (int i = 0; i < outPic.infoHader.length; i++)
            {
                int temp = outPic.pixelData[i];
                temp = (int)(c * Math.Log10(1 + temp));
                if (temp > 255) temp = 255;
                outPic.pixelData[i] = (byte)temp;

            }
            return ReturnPhoto(outPic);
        }

        //指数拓展
        public static System.Drawing.Image nonlinearExpand1(process inPic)
        {
            process outPic = new process();
            double gama = 1.2;
                
            if (inPic.infoHader.biBitCount != 8)
            {
                inPic.transToGray(out outPic, 2);
            }
            else
            {
                copy(inPic, out outPic);
            }

            for (int i = 0; i < outPic.infoHader.length; i++)
            {
                int temp = outPic.pixelData[i];
                temp = (int)(Math.Pow(temp, gama));
                if (temp > 255) temp = 255;
                outPic.pixelData[i] = (byte)temp;

            }
            return ReturnPhoto(outPic);
        }
        
        /// <summary>
        /// 直方均衡
        /// </summary>
        /// <param name="inPic"></param>
        /// <returns></returns>
        // 直方均衡
        public static System.Drawing.Image grayHistrogramAvg(process inPic)
        {
            process outPic = new process();
            if (inPic.infoHader.biBitCount != 8)
            {
                if (!inPic.transToGray(out outPic, 2)) return ReturnPhoto(outPic);
            }
            else
            {
                copy(inPic, out outPic);
            }

            int[] grayHis = new int[256];
            double sum = (double)(outPic.infoHader.biHeight * outPic.infoHader.biWidth);
            //统计直方图
            for (int h = 0, w = 0; h < outPic.infoHader.biHeight; h++)
            {
                for (w = 0; w < outPic.infoHader.biWidth; w++)
                {
                    uint temp = (uint)(outPic.pixelData[h * outPic.infoHader.l_width + w] - 0);
                    grayHis[temp]++;
                }
            }
            double[] pro = new double[256];
            //灰度变换
            for (int i = 0; i < 256; i++)
            {
                pro[i] = (double)grayHis[i] / sum;
                if (i != 0)
                {
                    pro[i] += pro[i - 1];
                }
                grayHis[i] = (int)(255 * pro[i] + 0.5);
            }

            for (int h = 0, w = 0; h < outPic.infoHader.biHeight; h++)
            {
                for (w = 0; w < outPic.infoHader.biWidth; w++)
                {
                    outPic.pixelData[h * outPic.infoHader.l_width + w] = (byte)grayHis[(int)outPic.pixelData[h * outPic.infoHader.l_width + w]];
                }
            }
            return ReturnPhoto(outPic);
        }

        /// <summary>
        /// 基于灰度调色板的伪彩色变换
        /// </summary>
        /// <param name="inPic"></param>
        /// <returns></returns>
        //基于灰度调色板的伪彩色变换
        public static System.Drawing.Image fakeColor(process inPic)
        {
            process outPic;
            if (inPic.infoHader.biBitCount != 8)
            {
                if (!inPic.transToGray(out outPic, 2)) return ReturnPhoto(outPic);
            }
            else
            {
                copy(inPic, out outPic);
            }

            for (int i = 0; i < 256; i ++)
            {
                outPic.colorTable[i * 4] = (byte)((i * 2 + 80) / 1 + 20);
                outPic.colorTable[i * 4 + 1] = (byte)((i * 4 + 120) / 3 + 21);
                outPic.colorTable[i * 4 + 2] = (byte)((i + 40) / 2 + 3);
            }
            return ReturnPhoto(outPic);
        }

        /// <summary>
        /// 加权滤波器，请输入一个矩形二维数组
        /// </summary>
        /// <param name="inPic"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        //加权滤波器
        public static System.Drawing.Image weightFilter(process inPic, double[,] filter)
        {
            process outPic = new process();
            copy(inPic, out outPic);

            uint channels = outPic.infoHader.channels;
            int size = filter.GetLength(0);
            int broundLimit = size / 2;
            double sum = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    sum += filter[i, j];
                }
            }
            double[] temp = new double[channels];

            //h、w表示现在处理的像素点
            for (int h = broundLimit; h < outPic.infoHader.biHeight - broundLimit; h++)
            {
                int hLow = h - broundLimit;
                for (int w = broundLimit; w < outPic.infoHader.biWidth - broundLimit; w++)
                {
                    int wLow = w - broundLimit;
                    //将这一像素模板覆盖的所有像素的数据写入temp中
                    for (int i = hLow; i <= h + broundLimit; i++)
                    {
                        for (int j = wLow; j <= w + broundLimit; j++)
                        {
                            for (int k = 0; k < channels; k++)
                            {
                                //i,j表示以当前像素为中心，模板覆盖位置 
                                temp[k] += inPic.pixelData[i * outPic.infoHader.l_width + j * channels + k] * filter[(i - hLow), (j - wLow)];
                            }
                        }
                    }
                    for (int k = 0; k < outPic.infoHader.channels; k++)
                    {
                        outPic.pixelData[h * outPic.infoHader.l_width + w * channels + k] = (byte)(temp[k] / sum);
                        temp[k] = 0;
                    }
                }
            }

            return ReturnPhoto(outPic);
        }

        /// <summary>
        /// 一维中值滤波器，请输入一个奇数设置滤波器大小
        /// </summary>
        /// <param name="inPic"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        //一维中值滤波器
        public static System.Drawing.Image medianFilter1D(process inPic, int size)
        {
            process outPic = new process();
            copy(inPic, out outPic);

            int broundLimit = size / 2;
            byte[][] temp = new byte[outPic.infoHader.channels][];
            for (int i = 0; i < outPic.infoHader.channels; i++)
            {
                temp[i] = new byte[size];
            }

            for (int h = 0; h < outPic.infoHader.biHeight; h++)
            {
                for (int w = broundLimit; w < outPic.infoHader.biWidth - broundLimit; w++)
                {
                    for (int i = w - broundLimit; i <= w + broundLimit; i++)
                    {
                        for (int k = 0; k < outPic.infoHader.channels; k++)
                        {
                            temp[k][(i - (w - broundLimit))] = outPic.pixelData[h * outPic.infoHader.l_width + i * outPic.infoHader.channels + k];
                        }
                    }
                    for (int k = 0; k < outPic.infoHader.channels; k++)
                    {
                        outPic.pixelData[h * outPic.infoHader.l_width + w * outPic.infoHader.channels + k] = getMidNum(temp[k]);
                    }
                }
            }

            return ReturnPhoto(outPic);
        }

        /// <summary>
        /// 二维中值滤波器，请输入二维矩阵宽度
        /// </summary>
        /// <param name="inPic"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        //二维中值滤波器
        public static System.Drawing.Image medianFilter2D(process inPic, int size)
        {
            process outPic = new process();
            copy(inPic, out outPic);

            int broundLimit = size / 2;
            int length = size * size;
            uint channels = outPic.infoHader.channels;

            byte[][] temp = new byte[channels][];
            for (int i = 0; i < outPic.infoHader.channels; i++)
            {
                temp[i] = new byte[length];
            }

            for (int h = broundLimit; h < outPic.infoHader.biHeight - broundLimit; h++)
            {
                int hLow = h - broundLimit;
                for (int w = broundLimit; w < outPic.infoHader.biWidth - broundLimit; w++)
                {
                    int wLow = w - broundLimit;
                    for (int i = hLow; i <= h + broundLimit; i++)
                    {
                        for (int j = wLow; j <= w + broundLimit; j++)
                        {
                            for (int k = 0; k < channels; k++)
                            {
                                temp[k][(i - hLow) * size + (j - wLow)] = outPic.pixelData[i * outPic.infoHader.l_width + j * channels + k];
                            }
                        }
                    }

                    for (int k = 0; k < outPic.infoHader.channels; k++)
                    {
                        outPic.pixelData[h * outPic.infoHader.l_width + w * channels + k] = getMidNum(temp[k]);
                    }
                }

            }

            return ReturnPhoto(outPic);
        }


        /// <summary>
        /// 返回图像对比度，mode==1为4近邻，mode==2为8近邻
        /// </summary>
        /// <param name="inPic"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        //返回图像对比度
        public static double contrast(process inPic, int mode)
        {
            int width = (int)inPic.infoHader.biWidth;
            int height = (int)inPic.infoHader.biHeight;
            int Lw = (int)inPic.infoHader.l_width;
            int channels = (int)inPic.infoHader.channels;

            int temp0 = 2, temp1 = 3, temp2 = 4;
            int num = 0;
            double[] contrastSum = new double[channels];

            if (mode == 2)
            {
                temp0 = 3;
                temp1 = 5;
                temp2 = 8;
            }
            num = 4 * temp0 + ((int)(width - 2) + (int)(height - 2)) * 2 * temp1 + (int)((width - 2) * (height - 2) * temp2);

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    if (h > 0)  
                    {
                        for (int k = 0; k < channels; k++)
                            contrastSum[k] += Math.Pow((inPic.pixelData[h * Lw + w * channels + k] - inPic.pixelData[(h - 1) * Lw + w * channels + k]), 2.0);
                        
                        if (mode == 2)
                        {
                            if (w > 0)
                                for (int k = 0; k < channels; k++)
                                    contrastSum[k] += Math.Pow((inPic.pixelData[h * Lw + w * channels + k] - inPic.pixelData[(h - 1) * Lw + (w - 1) * channels + k]), 2.0);
                            
                            if (w < width - 1)
                                for (int k = 0; k < channels; k++)
                                    contrastSum[k] += Math.Pow((inPic.pixelData[h * Lw + w * channels + k] - inPic.pixelData[(h - 1) * Lw + (w + 1) * channels + k]), 2.0);
                        }
                    }

                    if (h < height - 1)
                    {
                        for (int k = 0; k < channels; k++)
                            contrastSum[k] += Math.Pow((inPic.pixelData[h * Lw + w * channels + k] - inPic.pixelData[(h + 1) * Lw + w * channels + k]), 2.0);
                        
                        if (mode == 2)
                        {
                            if (w > 0)
                                for (int k = 0; k < channels; k++)
                                    contrastSum[k] += Math.Pow((inPic.pixelData[h * Lw + w * channels + k] - inPic.pixelData[(h + 1) * Lw + (w - 1) * channels + k]), 2.0);
                           
                            if (w < width - 1)
                                for (int k = 0; k < channels; k++)
                                    contrastSum[k] += Math.Pow((inPic.pixelData[h * Lw + w * channels + k] - inPic.pixelData[(h + 1) * Lw + (w + 1) * channels + k]), 2.0);
                        }
                    }

                    if (w > 0)
                        for (int k = 0; k < channels; k++)
                            contrastSum[k] += Math.Pow((inPic.pixelData[h * Lw + w * channels + k] - inPic.pixelData[h * Lw + (w - 1) * channels + k]), 2.0);

                    if(w<width-1)
                        for (int k = 0; k < channels; k++)
                            contrastSum[k] += Math.Pow((inPic.pixelData[h * Lw + w * channels + k] - inPic.pixelData[h * Lw + (w + 1) * channels + k]), 2.0);
                }
            }
            
            double result = 0;
            for (int k = 0; k < channels; k++)
                result += contrastSum[k];

            return result / channels / num;
        }
    
    
    }
}
