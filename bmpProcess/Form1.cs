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
    public partial class Form1 : Form
    {
        public FileStream fs;
        public process inPic1;
        public process inPic2;
        public process outPic;
        public Form1()
        {
            InitializeComponent();
        }
        private string pathname = string.Empty;
        private bool isRshow = false;

        private void run_Click(object sender, EventArgs e)
        {
            //showRight(pathname);
            outPic = new process();
            if (inPic1.transToGray(out outPic)) 
            {
                this.outPicBox.Image = Image.FromStream(outPic.fs);
                isRshow = true;
                outPic.fs.Close();
            }
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            inPic1 = new process();
            inPic2 = new process();
            outPic = new process();
        }

        private void closeButt_Click(object sender, EventArgs e)
        {
            this.outPicBox.Image = null;
            this.InPicBox1.Image = null;
            this.InPicBox2.Image = null;
            try
            {
                inPic1.fs.Close();
                inPic2.fs.Close();
                outPic.fs.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            fs.Close();
        }

        private void openInPic2_Click(object sender, EventArgs e)
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
                    this.InPicBox2.Image = System.Drawing.Image.FromStream(fs);
                    //this.picBoxL.Load(pathname);
                    if (isRshow)
                    {
                        this.outPicBox.Image = null;
                        isRshow = false;
                    }
                    if (fs != null)
                    {
                        //inPic2 = new process();
                        inPic2.getData(fs);
                        //ulong a = pic.fileHader.bfSize;
                        //string str = "type:" + (inPic1.fileHader.bfType - 0x0).ToString() + "  offBits:" + (inPic1.fileHader.bfOffBits - 0).ToString();
                        //MessageBox.Show(str);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void openInPic1_Click_1(object sender, EventArgs e)
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
                    this.InPicBox1.Image = System.Drawing.Image.FromStream(fs);
                    //this.picBoxL.Load(pathname);
                    if (isRshow)
                    {
                        this.outPicBox.Image = null;
                        isRshow = false;
                    }
                    if (fs != null)
                    {
                        inPic1.getData(fs);
                    }
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void sumButt_Click(object sender, EventArgs e)
        {
            doubMethod(1);
        }

        private void subButt_Click(object sender, EventArgs e)
        {
            doubMethod(2);
        }

        private void mulButt_Click(object sender, EventArgs e)
        {
            doubMethod(3);
        }

        private void divButt_Click(object sender, EventArgs e)
        {
            doubMethod(4);
        }

        private void andButt_Click(object sender, EventArgs e)
        {
            doubMethod(5);            
        }

        private void orButt_Click(object sender, EventArgs e)
        {
            doubMethod(6);       
        }

        private void noButt_Click(object sender, EventArgs e)
        {
            try
            {
                if (inPic1.fileHader.bfType == 19778 )
                {
                    if (process.notOperator(inPic1, out outPic))
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

        private void openGeo_Click(object sender, EventArgs e)
        {
            //Application.Run(new geo());
            Geo geo = new Geo();
            geo.Show();
        }

        private void doubMethod(int mode)
        {
            try
            {
                if (inPic1.fileHader.bfType == 19778 && inPic2.fileHader.bfType == 19778)
                {
                    if (process.doubOperator(inPic1, inPic2, out outPic, mode))
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
                MessageBox.Show("Please open two picture with same size!\n");
            }
        }
    }
}
