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

        private void Geo_Load(object sender, EventArgs e)
        {
            inPic = new process();
            outPic = new process();
        }

        private void moveButt_Click(object sender, EventArgs e)
        {
            singleMethod(1);
        }

        private void mirrorButt_Click(object sender, EventArgs e)
        {
            singleMethod(5);
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
                        case 4:
                            tag = process.narrow(inPic, out outPic);
                            break;
                        case 5:
                            tag = process.mirror(inPic, out outPic);
                            break;
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

        private void spinButt_Click(object sender, EventArgs e)
        {

        }

        private void narrowButt_Click(object sender, EventArgs e)
        {
            singleMethod(4);
        }


    }
}
