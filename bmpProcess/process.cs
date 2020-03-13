﻿using System;
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

        public bool transToGray(out process outPic)
        {
            if (infoHader.channels != 3) 
            {
                outPic = new process();
                return false;
            }
            //picR.fileHader = this.fileHader;
            outPic = (process)this.MemberwiseClone();
            if (outPic.fileHader.bfOffBits == 54)         //将原图片复制到新图片中 
            {
                //this.pixelData.CopyTo(picR.pixelData, 0);
                outPic.pixelData = (byte[])pixelData.Clone();
            }
            else 
            {
                //索引色暂时未适配
                //this.pixelData.CopyTo(picR.pixelData, this.infoHader.length);
                //this.colorTable.CopyTo(picR.colorTable, (int)(picR.fileHader.bfOffBits - 54));
                this.pixelData.CopyTo(outPic.pixelData, 0);
                this.colorTable.CopyTo(outPic.colorTable, 0);
            }

            uint fixNum = infoHader.l_width - infoHader.biWidth * infoHader.channels;
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
                    outPic.pixelData[h * infoHader.l_width + grayIndex] = charTemp;
                    outPic.pixelData[h * infoHader.l_width + grayIndex + 1] = charTemp;
                    outPic.pixelData[h * infoHader.l_width + grayIndex + 2] = charTemp;
		        }

		        //补位
		        charTemp = 0xff;
		        for (uint j = 0; j < fixNum; j++) {
                    outPic.pixelData[h * infoHader.l_width + w * infoHader.channels + j] = charTemp;
		        }
	        }

            outPic.toFileStream(this.fs.Name , 1);
            return true;
        }

        /*第二个参数mode 1 为灰度图像 ， 2 3 4 5 依次为加减乘除*/
        //第二个参数mode 1 为灰度图像 ， 2 3 4 5 依次为加减乘除
        public void toFileStream(string filename ,string filename2 , int mode)
        {
            int lastIndex = filename.LastIndexOf('.');
            int preIndex = filename.LastIndexOf('\\');
            string fname = filename.Substring(preIndex+1, lastIndex - preIndex-1);

            int lastIndex1 = filename2.LastIndexOf('.');
            int preIndex1 = filename2.LastIndexOf('\\');
            string fname1 = filename2.Substring(preIndex1 + 1, lastIndex1 - preIndex1 - 1);
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

            try
            {
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
            Marshal.StructureToPtr(this.fileHader,filePtr,false);
            Byte[] fileBuff = new Byte[14];
            Marshal.Copy(filePtr,fileBuff,0,14);
            Marshal.FreeHGlobal(filePtr);

            IntPtr infoPtr = Marshal.AllocHGlobal(52);
            Marshal.StructureToPtr(this.infoHader,infoPtr,false);
            Byte[] infoBuff = new Byte[40];
            Marshal.Copy(infoPtr,infoBuff,0,40);
            Marshal.FreeHGlobal(infoPtr);

            fs.Write(fileBuff, 0, 14);
            fs.Write(infoBuff, 0, 40);
            if (this.fileHader.bfOffBits != 54)
            {
                fs.Write(this.colorTable, 0, (int)(this.fileHader.bfOffBits - 54));
            }
            fs.Write(this.pixelData, 0, (int)this.infoHader.length);
        }

        public void toFileStream(string filename, int mode)
        {
            int lastIndex = filename.LastIndexOf('.');
            int preIndex = filename.LastIndexOf('\\');
            string fname = filename.Substring(preIndex + 1, lastIndex - preIndex - 1);
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
                case 7:
                    outFileName = "out//" + fname + "_Mirror.bmp";
                    break;
                default:
                    outFileName = "out//" + fname + "_none.bmp";
                    break;
            }

            try
            {
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

        private static void copy(process inPic , out process outPic)
        {
            outPic = (process)inPic.MemberwiseClone();
            if (outPic.fileHader.bfOffBits != 54)
            {
                outPic.colorTable = (byte[])inPic.colorTable.Clone();
            }
            outPic.pixelData = (byte[])inPic.pixelData.Clone();
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
        
        //时间关系仅做固定尺寸平移，其他方向的平移后续补上
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
            
            for (int h = 0, i = 0; h < inPic.infoHader.biHeight - yMovePix; h++)
            {
                for (i = 0; i < inPic.infoHader.l_width - xMovePix*inPic.infoHader.channels; i++)
                {
                    outPic.pixelData[(h + yMovePix) * inPic.infoHader.l_width + (xMovePix) * inPic.infoHader.channels + i] =
                        inPic.pixelData[h * inPic.infoHader.l_width + i];
                }
            }

            outPic.toFileStream(inPic.fs.Name, 3);
            return true;
        }

        //时间关系仅完成水平镜像，垂直镜像后续补上
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
    

    }
}
