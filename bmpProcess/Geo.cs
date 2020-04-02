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
                MessageBox.Show("Input a file name as a bmp file\n" + ex);
            }
        }

        private void avgFilterButt_Click(object sender, EventArgs e)
        {
            try
            {
                //double[,] filter = { {0,1,0},
                //                   {1,4,1},
                //                   {0,1,0}};
                double[,] filter = { {1,1,1},
                                   {1,1,1},
                                   {1,1,1}};
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
                this.outPicBox.Image = process.sharpening(inPic, filter);
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
            double[,] filter = { { 0, -0.25, 0 }, 
                                { -0.25, 1, -0.25 }, 
                                { 0, -0.25, 0 } };
            sharpening(filter);
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



    }
}
