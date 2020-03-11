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
        public process picL;
        public process picR;
        public Form1()
        {
            InitializeComponent();
        }
        private string pathname = string.Empty;
        private bool isRshow = false;

        private void run_Click(object sender, EventArgs e)
        {
            //showRight(pathname);
            picR = new process();
            if (picL.transToGray(out picR)) 
            {
                this.picBoxR.Image = Image.FromStream(picR.fs);
                isRshow = true;
            }
            picR.fs.Close();
        } 

        public void showLeft(string filePath)
        {
        
        }

        public void showRight(string filePath)
        {
            if (filePath != string.Empty)
            {
                try
                {
                    this.picBoxR.Load(pathname);
                    isRshow = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else {
                MessageBox.Show("No Picture.");
            }
        }

        private void saveButt_Click(object sender, EventArgs e)
        {
            try{
                if (pathname != string.Empty)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.ShowDialog();
                    picBoxL.Image.Save(save.FileName);
                    MessageBox.Show("Save success!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Input a file name as a bmp file\n"+ex);
            }
        }

        private void openButt_Click(object sender, EventArgs e)
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
                    this.picBoxL.Image = System.Drawing.Image.FromStream(fs);
                    //this.picBoxL.Load(pathname);
                    if (isRshow)
                    {
                        this.picBoxR.Image = null;
                        isRshow = false;
                    }
                    if (fs != null)
                    {
                        picL = new process();
                        picL.getData(fs);
                        //ulong a = pic.fileHader.bfSize;
                        string str = "type:" + (picL.fileHader.bfType - 0x0).ToString() + "  offBits:" + (picL.fileHader.bfOffBits-0).ToString();
                        MessageBox.Show(str);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void closeButt_Click(object sender, EventArgs e)
        {
            this.picBoxR.Image = null;
            this.picBoxL.Image = null;
            fs.Close();
        }


    }
}
