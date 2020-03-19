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
            try
            {
                if (inPic.fileHader.bfType == 19778)
                {
                    bool tag = false;
                    switch (mode)
                    {
                        case 1:
                            tag = process.move(inPic, out outPic);
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
                            return;
                        case 7:
                            this.outPicBox.Image = process.nonlinearExpand(inPic);
                            return;
                        case 8:
                            this.outPicBox.Image = process.nonlinearExpand1(inPic);
                            return;
                        case 9:
                            this.outPicBox.Image = process.grayHistrogramAvg(inPic);
                            return;
                        case 10:
                            this.outPicBox.Image = process.fakeColor(inPic);
                            return;
                    }
                    if (tag)
                    {
                        this.outPicBox.Image = Image.FromStream(outPic.fs);
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

        private void saveButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (pathname != string.Empty)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.ShowDialog();
                    outPicBox.Image.Save(save.FileName);
                    MessageBox.Show("Save success!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input a file name as a bmp file\n" + ex);
            }
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



    }
}
