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
    public partial class bitCut : Form
    {
        public FileStream fs;
        public process inPic;
        public process outPic;
        private string pathname = string.Empty;
        private bool isRshow = false;

        public bitCut()
        {
            InitializeComponent();
            inPic = new process();
            outPic = new process();
        }

        private void openInPic1_Click(object sender, EventArgs e)
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
                    this.InPicBox.Image = System.Drawing.Image.FromStream(fs);
                    //this.picBoxL.Load(pathname);
                    //if (isRshow)
                    //{
                    //    this.outPicBox.Image = null;
                    //    isRshow = false;
                    //}
                    if (fs != null)
                    {
                        //inPic2 = new process();
                        inPic.getData(fs);
                        //ulong a = pic.fileHader.bfSize;
                        //string str = "type:" + (inPic1.fileHader.bfType - 0x0).ToString() + "  offBits:" + (inPic1.fileHader.bfOffBits - 0).ToString();
                        //MessageBox.Show(str);
                    }
                    fs.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bitCutButt_Click(object sender, EventArgs e)
        {
            try
            {
                //if (inPic.transToGray(out outPic, 2))
                //{
                //     this.bitCutBox1.Image = process.ReturnPhoto(outPic);
                //}
                this.bitCutBox1.Image = process.bitCut(inPic, 7);
                this.bitCutBox2.Image = process.bitCut(inPic, 6);
                this.bitCutBox3.Image = process.bitCut(inPic, 5);
                this.bitCutBox4.Image = process.bitCut(inPic, 4);
                this.bitCutBox5.Image = process.bitCut(inPic, 3);
                this.bitCutBox6.Image = process.bitCut(inPic, 2);
                this.bitCutBox7.Image = process.bitCut(inPic, 1);
                this.bitCutBox8.Image = process.bitCut(inPic, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No out");
            }
        }

        private void closeButt_Click(object sender, EventArgs e)
        {
            this.InPicBox.Image = null;
            this.bitCutBox1.Image = null;
            this.bitCutBox2.Image = null;
            this.bitCutBox3.Image = null;
            this.bitCutBox4.Image = null;
            this.bitCutBox5.Image = null;
            this.bitCutBox6.Image = null;
            this.bitCutBox7.Image = null;
            this.bitCutBox8.Image = null;
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
