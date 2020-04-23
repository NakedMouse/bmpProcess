using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace bmpProcess
{
    public partial class Geo : Form
    {
        public FileStream fs;
        public process inPic;
        public process outPic;
        private string pathname = string.Empty;
        private bool isRshow = false;

        public Geo()
        {
            InitializeComponent();
            inPic = new process();
            outPic = new process();
        }

        private void geoOpenIn_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = ",";
            file.Filter = "所有文件(*.*)|*.*";
            file.ShowDialog();
            if (file.FileName != string.Empty)
            {
                try
                {
                    pathname = file.FileName;
                    fs = new FileStream(pathname, FileMode.Open, FileAccess.ReadWrite);
                    this.inPicBox.Image = System.Drawing.Image.FromStream(fs);
                    if (isRshow)
                    {
                        this.outPicBox.Image = null;
                        isRshow = false;
                    }
                    if (fs != null)
                    {
                        inPic.getData(fs);
                    }
                    getContrast();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void resetButt_Click(object sender, EventArgs e)
        {
            this.outPicBox.Image = null;
            this.inPicBox.Image = null;
            try
            {
                fs.Close();
                inPic.fs.Close();
                outPic.fs.Close();
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void Geo_Load(object sender, EventArgs e)
        {
            inPic = new process();
            outPic = new process();
        }

        private void singleMethod(int mode)
        {
            int start = System.Environment.TickCount;
            try
            {
                if (inPic.fileHader.bfType == 19778)
                {
                    bool tag = false;
                    switch (mode)
                    {
                        case 1:
                            tag = process.move(inPic, out outPic);
                            getContrast();
                            break;
                        case 2:
                            tag = process.spin(inPic, out outPic);
                            break;
                        case 3:
                            tag = process.enlarge(inPic, out outPic);
                            break;
                        case 4:
                            tag = process.narrow(inPic, out outPic);
                            break;
                        case 5:
                            tag = process.mirror(inPic, out outPic);
                            break;
                        case 6:
                            this.outPicBox.Image = process.linearExpand(inPic);
                            getContrast();
                            return;
                        case 7:
                            this.outPicBox.Image = process.nonlinearExpand(inPic);
                            getContrast();
                            return;
                        case 8:
                            this.outPicBox.Image = process.nonlinearExpand1(inPic);
                            getContrast();
                            return;
                        case 9:
                            this.outPicBox.Image = process.grayHistrogramAvg(inPic);
                            getContrast();
                            return;
                        case 10:
                            this.outPicBox.Image = process.fakeColor(inPic);
                            getContrast();
                            return;
                    }
                    if (tag)
                    {
                        //this.outPicBox.Image = Image.FromStream(outPic.fs);
                        this.outPicBox.Image = process.ReturnPhoto(outPic);
                        int end = System.Environment.TickCount;
                        this.timeBox.Text = (end - start).ToString();
                        getContrast();
                        isRshow = true;
                        outPic.fs.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                outPic.fs.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void saveButt_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.ShowDialog();
                outPicBox.Image.Save(save.FileName);
                MessageBox.Show("Save success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input a file name as a bmp file\n" + ex.Message);
            }
        }

        private void getContrast()
        {
            try
            {
                if (this.inPicBox.Image != null)
                {
                    double contrast1 = process.contrast(inPic, 2);
                    this.textBox2.Text = contrast1.ToString();
                }
                if (this.outPicBox.Image != null)
                {
                    if (!Directory.Exists("out//temp"))
                    {
                        Directory.CreateDirectory("out//temp");
                    }
                    string file = "out//temp//temp.bmp";
                    this.outPicBox.Image.Save(file);
                    FileStream tempFs = new FileStream(file, FileMode.Open, FileAccess.ReadWrite);
                    outPic.getData(tempFs);
                    tempFs.Close();
                    double contrast2 = process.contrast(outPic, 2);
                    this.textBox3.Text = contrast2.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //上面是辅助性功能，以下是空域、几何处理部分

        private void moveButt_Click(object sender, EventArgs e)
        {
            singleMethod(1);
        }

        private void mirrorButt_Click(object sender, EventArgs e)
        {
            singleMethod(5);
        }

        private void spinButt_Click(object sender, EventArgs e)
        {
            singleMethod(2);
        }

        private void enlargeButt_Click(object sender, EventArgs e)
        {
            singleMethod(3);
        }

        private void narrowButt_Click(object sender, EventArgs e)
        {
            singleMethod(4);
        }

        private void linearExpandButt_Click(object sender, EventArgs e)
        {
            singleMethod(6);
        }

        private void nonlinearExpandButt_Click(object sender, EventArgs e)
        {
            singleMethod(7);
        }

        private void nonlinearExpandButt2_Click(object sender, EventArgs e)
        {
            singleMethod(8);
        }

        private void histogramAvgButt_Click(object sender, EventArgs e)
        {
            singleMethod(9);
        }

        private void colorButt_Click(object sender, EventArgs e)
        {
            singleMethod(10);
        }


        //以下是平滑处理部分
        private void Geo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.outPicBox.Image = null;
            this.inPicBox.Image = null;
            try
            {
                fs.Close();
                inPic.fs.Close();
                outPic.fs.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void avgFilterButt_Click(object sender, EventArgs e)
        {
            try
            {
                //double[,] filter = { {0,1,0},
                //                   {1,4,1},
                //                   {0,1,0}};
                double[,] filter = { {1,1,1,1,1},
                                   {1,1,1,1,1},
                                   {1,1,1,1,1},
                                   {1,1,1,1,1},
                                   {1,1,1,1,1},};
                this.outPicBox.Image = process.weightFilter(inPic, filter);
                getContrast();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void weightFilterButt_Click(object sender, EventArgs e)
        {
            try
            {
                //double[,] filter = { {0,1,0},
                //                   {1,8,1},
                //                   {0,1,0}};
                double[,] filter = { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };
                this.outPicBox.Image = process.weightFilter(inPic, filter);
                getContrast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void midFilterButt_Click(object sender, EventArgs e)
        {
            try
            {
                int size = 3;
                this.outPicBox.Image = process.medianFilter1D(inPic, size);
                getContrast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void medianFilter2DButt_Click(object sender, EventArgs e)
        {
            try
            {
                int size = 3;
                this.outPicBox.Image = process.medianFilter2D(inPic, size);
                getContrast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void KNN_Butt_Click(object sender, EventArgs e)
        {
            try
            {
                int size = 3;
                int start = System.Environment.TickCount;
                this.outPicBox.Image = process.KNN(inPic, size);
                int end = System.Environment.TickCount;
                this.timeBox.Text = (end - start).ToString();
                getContrast();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SymmetricFilterButt_Click(object sender, EventArgs e)
        {
            try
            {
                int start = System.Environment.TickCount;
                this.outPicBox.Image = process.SymmetricNFilter(inPic);
                int end = System.Environment.TickCount;
                this.timeBox.Text = (end - start).ToString();
                getContrast();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sigmaButt_Click(object sender, EventArgs e)
        {
            try
            {
                int start = System.Environment.TickCount;
                this.outPicBox.Image = process.sigmaFilter(inPic,3);
                int end = System.Environment.TickCount;
                this.timeBox.Text = (end - start).ToString();
                getContrast();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        //锐化一般性入口
        private void sharpening(double[,] filter)
        {
            try
            {
                int start = System.Environment.TickCount;
                //this.outPicBox.Image = process.sharpening(inPic, filter);
                this.outPicBox.Image = process.sharpeningThreshold(inPic, filter);
                int end = System.Environment.TickCount;
                this.timeBox.Text = (end - start).ToString();
                getContrast();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void levelSharpButt_Click(object sender, EventArgs e)
        {
            //double[,] filter = { { 0, 2, 1 }, 
            //                   {  -2, 0, 2 }, 
            //                   {  -1,-2, 0 } };
            double[,] filter = { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };
            sharpening(filter);
        }

        private void verSharpButt_Click(object sender, EventArgs e)
        {
            double[,] filter = { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } };
            sharpening(filter);
        }

        private void crossDiffSharpButt_Click(object sender, EventArgs e)
        {
            try
            {
                int start = System.Environment.TickCount;
                this.outPicBox.Image = process.RobertsSharpening(inPic);
                int end = System.Environment.TickCount;
                this.timeBox.Text = (end - start).ToString();
                getContrast();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void laplaceSharpButt1_Click(object sender, EventArgs e)
        {
            double[,] filter = { { 0, -1, 0 }, { -1, 4, -1 }, { 0, -1, 0 } };
            sharpening(filter);
        }

        private void laplaceSharpButt2_Click(object sender, EventArgs e)
        {
            double[,] filter = { { -1, -1, -1 }, 
                                { -1, 8, -1 }, 
                                { -1, -1, -1 } };
            sharpening(filter);
        }

        private void laplaceSharpButt3_Click(object sender, EventArgs e)
        {
            double[,] filter = { { 1, -2, 1 }, 
                                { -2, 4, -2 }, 
                                { 1, -2, 1 } };
            sharpening(filter);
        }

        private void laplaceSharpButt4_Click(object sender, EventArgs e)
        {
            double[,] filter = { { 0, -1, 0 }, 
                                { -1, 5, -1 }, 
                                { 0, -1, 0 } };
            sharpening(filter);
        }

        private void LoGSharpButt_Click(object sender, EventArgs e)
        {
            double[,] filter = { { 0, 0, -1, 0, 0 }, 
                               { 0, -1, -2, -1, 0 }, 
                               { -1, -2, 16, -2, -1 }, 
                               { 0, -1, -2, -1, 0 }, 
                               { 0, 0, -1, 0, 0 } };
            sharpening(filter);
        }

        private void wallisSharpButt_Click(object sender, EventArgs e)
        {
            wallis(false);
        }

        private void sobelSharpButt_Click(object sender, EventArgs e)
        {
            try
            {
                int start = System.Environment.TickCount;
                double[,] filter = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
                this.outPicBox.Image = process.nonDirecSharpening(inPic,filter);
                int end = System.Environment.TickCount;
                this.timeBox.Text = (end - start).ToString();
                getContrast();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void priwittSharpButt_Click(object sender, EventArgs e)
        {
            try
            {
                int start = System.Environment.TickCount;
                double[,] filter = { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
                this.outPicBox.Image = process.nonDirecSharpening(inPic, filter);
                int end = System.Environment.TickCount;
                this.timeBox.Text = (end - start).ToString();
                getContrast();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openForm_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void wallisAbsSharpButt_Click(object sender, EventArgs e)
        {
            wallis(true);
        }
        
        private void wallis(bool tag)
        {
            try
            {
                int start = System.Environment.TickCount;
                this.outPicBox.Image = process.wallis(inPic, tag);
                int end = System.Environment.TickCount;
                this.timeBox.Text = (end - start).ToString();
                getContrast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //页面切换
        private void airspaceProcessButt_Click(object sender, EventArgs e)
        {
            switchPanel(1);
        }

        private void smoothButt_Click(object sender, EventArgs e)
        {
            switchPanel(2);
        }

        private void sharpenButt_Click(object sender, EventArgs e)
        {
            switchPanel(3);
        }

        private void imgSegmenButt_Click(object sender, EventArgs e)
        {
            switchPanel(4);
        }

        private void switchPanel(int tag)
        {
            this.smoothPanel.Hide();
            this.airspaceProcessPanel.Hide();
            this.sharpenPanel.Hide();
            this.imgSegmenPanel.Hide();
            this.binaryPanel.Hide();
            switch(tag){
                case 1:
                    this.airspaceProcessPanel.Show();
                    break;
                case 2:
                    this.smoothPanel.Show();
                    break;
                case 3:
                    this.sharpenPanel.Show();
                    break;
                case 4:
                    this.imgSegmenPanel.Show();
                    break;
                case 5:
                    this.binaryPanel.Show();
                    break;
                default:
                    break;
            }

        }

        private void binaryButt_Click(object sender, EventArgs e)
        {
            switchPanel(5); 
        }

        //图像分割
        private void pParaSegButt_Click(object sender, EventArgs e)
        {
            pParaSegmen();
        }

        private void pParaTxtBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pParaSegmen();
            }
        }
        
        private void pParaSegmen()
        {
            double pPara = 0;
            try
            {
                int start = System.Environment.TickCount;
                pPara = Convert.ToDouble(this.pParaTxtBox.Text);
                if (pPara > 100 || pPara < 0)
                {
                    MessageBox.Show("请在pPara输入框输入合理参数。");
                }
                else
                {
                    this.outPicBox.Image = process.pParaSegmen(inPic, pPara);
                    int end = System.Environment.TickCount;
                    this.timeBox.Text = (end - start).ToString();
                    getContrast();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请在pPara输入框输入合理参数。");
            }
        }

        private void uniforMeasureButt_Click(object sender, EventArgs e)
        {
            segmen(1);
        }

        private void segmen(int tag)
        {
            try
            {
                int start = System.Environment.TickCount;

                switch (tag)
                {
                    case 1:
                        this.outPicBox.Image = process.uniforMeasureSegmen(inPic);
                        break;
                    case 2:
                        this.outPicBox.Image = process.clusterSegmen(inPic);
                        break;
                    case 3:
                        this.outPicBox.Image = process.globalThresholdSegmen(inPic);
                        break;
                    default:
                        break;
                }

                int end = System.Environment.TickCount;
                this.timeBox.Text = (end - start).ToString();
                getContrast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clusterButt_Click(object sender, EventArgs e)
        {
            segmen(2);
        }

        private void globalThresholdButt_Click(object sender, EventArgs e)
        {
            segmen(3);
        }

        
        //二值处理
        private void tagLab8Butt_Click(object sender, EventArgs e)
        {
            int mode = 0;
            tagLabel(mode);
        }

        private void tagLab4Butt_Click(object sender, EventArgs e)
        {
            int mode = 1;
            tagLabel(mode);
        }

        private void tagLabel(int mode)
        {
            outPic = process.tagLabel(inPic, mode);
            try
            {
                this.outPicBox.Image = process.ReturnPhoto(outPic);
                getContrast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void biButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (inPic.infoHader.channels != 1)
                {
                    inPic.transToGray(out outPic, 0);
                }
                else
                {
                    process.copy(inPic, out outPic);
                }
                outPic.binarization(200);
                this.outPicBox.Image = process.ReturnPhoto(outPic);
                getContrast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void corrosionButt_Click(object sender, EventArgs e)
        {
            corrosionAndExpand(1);
        }

        private void corrTimesTxtBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                corrosionAndExpand(1);
            }
        }

        private void expandButt_Click(object sender, EventArgs e)
        {
            corrosionAndExpand(2);
        }

        private void expandTxtBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                corrosionAndExpand(2);
            }
        }

        private void corrosionAndExpand(int mode)
        {
            try
            {
                //int[,] filter ={{0,1,0},{1,1,1},{0,1,0}};
                int[,] filter = { { 1, 0 }, { 1, 1 } };
                int times;
                if (mode == 1)
                    times = Convert.ToInt16(this.corrTimesTxtBox.Text);
                else
                    times = Convert.ToInt16(this.expandTxtBox.Text);
                process.copy(inPic, out outPic);

                for (int i = 0; i < times; i++)
                    outPic = process.corroAndExpand(outPic, filter, 1, 1, mode);
                
                this.outPicBox.Image = process.ReturnPhoto(outPic);
                getContrast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openOperaButt_Click(object sender, EventArgs e)
        {
            openAndClose(1);
        }

        private void closeOperaButt_Click(object sender, EventArgs e)
        {
            openAndClose(2);
        }

        private void openAndClose(int mode)
        {
            try
            {
                //int[,] filter ={{0,1,0},
                //               {1,1,1},
                //               {0,1,0}};
                int[,] filter = { { 1, 0 }, { 1, 1 } };
                int corroTimes = Convert.ToInt16(this.corrTimesTxtBox.Text);
                int expandTimes = Convert.ToInt16(this.expandTxtBox.Text);

                outPic = process.openAndCloseOperate(inPic, filter, 1,1 , corroTimes, expandTimes, mode);
                this.outPicBox.Image = process.ReturnPhoto(outPic);
                getContrast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getEdgeButt_Click(object sender, EventArgs e)
        {
            try
            {
                int[,] filter ={{0,1,0},
                               {1,1,1},
                               {0,1,0}};

                outPic = process.getEdge(inPic, filter, 2, 2);
                this.outPicBox.Image = process.ReturnPhoto(outPic);
                getContrast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void holeFillingButt_Click(object sender, EventArgs e)
        {
            try
            {
                outPic = process.holeFilling(inPic,false);
                this.outPicBox.Image = process.ReturnPhoto(outPic);
                getContrast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void holeFilling1Butt_Click(object sender, EventArgs e)
        {
            try
            {
                outPic = process.holeFilling(inPic, true);
                this.outPicBox.Image = process.ReturnPhoto(outPic);
                getContrast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getBoneButt_Click(object sender, EventArgs e)
        {
            try
            {
                int corroTimes = Convert.ToInt16(this.corrTimesTxtBox.Text);
                outPic = process.getBone(inPic, corroTimes);
                this.outPicBox.Image = process.ReturnPhoto(outPic);
                getContrast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    
    }
}
