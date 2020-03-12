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
                    this.inBox.Image = System.Drawing.Image.FromStream(fs);
                    //this.picBoxL.Load(pathname);
                    if (isRshow)
                    {
                        this.outBox.Image = null;
                        isRshow = false;
                    }
                    if (fs != null)
                    {
                        //inPic1 = new process();
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

        private void Geo_Load(object sender, EventArgs e)
        {
            inPic = new process();
            outPic = new process();
        }

        private void moveButt_Click(object sender, EventArgs e)
        {

        }

    }
}
