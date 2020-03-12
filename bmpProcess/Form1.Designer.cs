namespace bmpProcess
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.InPicBox1 = new System.Windows.Forms.PictureBox();
            this.outPicBox = new System.Windows.Forms.PictureBox();
            this.run = new System.Windows.Forms.Button();
            this.openInPic1 = new System.Windows.Forms.Button();
            this.closeButt = new System.Windows.Forms.Button();
            this.sumButt = new System.Windows.Forms.Button();
            this.InPicBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openInPic2 = new System.Windows.Forms.Button();
            this.subButt = new System.Windows.Forms.Button();
            this.mulButt = new System.Windows.Forms.Button();
            this.divButt = new System.Windows.Forms.Button();
            this.andButt = new System.Windows.Forms.Button();
            this.orButt = new System.Windows.Forms.Button();
            this.noButt = new System.Windows.Forms.Button();
            this.openGeo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InPicBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InPicBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // InPicBox1
            // 
            this.InPicBox1.Location = new System.Drawing.Point(12, 81);
            this.InPicBox1.Name = "InPicBox1";
            this.InPicBox1.Size = new System.Drawing.Size(350, 400);
            this.InPicBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.InPicBox1.TabIndex = 0;
            this.InPicBox1.TabStop = false;
            // 
            // outPicBox
            // 
            this.outPicBox.Location = new System.Drawing.Point(724, 81);
            this.outPicBox.Name = "outPicBox";
            this.outPicBox.Size = new System.Drawing.Size(350, 400);
            this.outPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outPicBox.TabIndex = 1;
            this.outPicBox.TabStop = false;
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(351, 25);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(100, 30);
            this.run.TabIndex = 2;
            this.run.Text = "1转灰度";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // openInPic1
            // 
            this.openInPic1.Cursor = System.Windows.Forms.Cursors.Default;
            this.openInPic1.Location = new System.Drawing.Point(33, 25);
            this.openInPic1.Name = "openInPic1";
            this.openInPic1.Size = new System.Drawing.Size(100, 30);
            this.openInPic1.TabIndex = 3;
            this.openInPic1.Text = "打开输入1";
            this.openInPic1.UseVisualStyleBackColor = true;
            this.openInPic1.Click += new System.EventHandler(this.openInPic1_Click_1);
            // 
            // closeButt
            // 
            this.closeButt.Location = new System.Drawing.Point(245, 25);
            this.closeButt.Name = "closeButt";
            this.closeButt.Size = new System.Drawing.Size(100, 30);
            this.closeButt.TabIndex = 5;
            this.closeButt.Text = "关闭";
            this.closeButt.UseVisualStyleBackColor = true;
            this.closeButt.Click += new System.EventHandler(this.closeButt_Click);
            // 
            // sumButt
            // 
            this.sumButt.Location = new System.Drawing.Point(12, 526);
            this.sumButt.Name = "sumButt";
            this.sumButt.Size = new System.Drawing.Size(100, 30);
            this.sumButt.TabIndex = 6;
            this.sumButt.Text = "加法";
            this.sumButt.UseVisualStyleBackColor = true;
            this.sumButt.Click += new System.EventHandler(this.sumButt_Click);
            // 
            // InPicBox2
            // 
            this.InPicBox2.Location = new System.Drawing.Point(368, 81);
            this.InPicBox2.Name = "InPicBox2";
            this.InPicBox2.Size = new System.Drawing.Size(350, 400);
            this.InPicBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.InPicBox2.TabIndex = 7;
            this.InPicBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 496);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "输入图像1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(507, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "输入图像2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(860, 496);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "输出图像";
            // 
            // openInPic2
            // 
            this.openInPic2.Cursor = System.Windows.Forms.Cursors.Default;
            this.openInPic2.Location = new System.Drawing.Point(139, 25);
            this.openInPic2.Name = "openInPic2";
            this.openInPic2.Size = new System.Drawing.Size(100, 30);
            this.openInPic2.TabIndex = 11;
            this.openInPic2.Text = "打开输入2";
            this.openInPic2.UseVisualStyleBackColor = true;
            this.openInPic2.Click += new System.EventHandler(this.openInPic2_Click);
            // 
            // subButt
            // 
            this.subButt.Location = new System.Drawing.Point(118, 526);
            this.subButt.Name = "subButt";
            this.subButt.Size = new System.Drawing.Size(100, 30);
            this.subButt.TabIndex = 12;
            this.subButt.Text = "减法";
            this.subButt.UseVisualStyleBackColor = true;
            this.subButt.Click += new System.EventHandler(this.subButt_Click);
            // 
            // mulButt
            // 
            this.mulButt.Location = new System.Drawing.Point(224, 526);
            this.mulButt.Name = "mulButt";
            this.mulButt.Size = new System.Drawing.Size(100, 30);
            this.mulButt.TabIndex = 13;
            this.mulButt.Text = "乘法";
            this.mulButt.UseVisualStyleBackColor = true;
            this.mulButt.Click += new System.EventHandler(this.mulButt_Click);
            // 
            // divButt
            // 
            this.divButt.Location = new System.Drawing.Point(330, 526);
            this.divButt.Name = "divButt";
            this.divButt.Size = new System.Drawing.Size(100, 30);
            this.divButt.TabIndex = 14;
            this.divButt.Text = "除法";
            this.divButt.UseVisualStyleBackColor = true;
            this.divButt.Click += new System.EventHandler(this.divButt_Click);
            // 
            // andButt
            // 
            this.andButt.Location = new System.Drawing.Point(581, 526);
            this.andButt.Name = "andButt";
            this.andButt.Size = new System.Drawing.Size(100, 30);
            this.andButt.TabIndex = 15;
            this.andButt.Text = "1-2与";
            this.andButt.UseVisualStyleBackColor = true;
            this.andButt.Click += new System.EventHandler(this.andButt_Click);
            // 
            // orButt
            // 
            this.orButt.Location = new System.Drawing.Point(702, 526);
            this.orButt.Name = "orButt";
            this.orButt.Size = new System.Drawing.Size(100, 30);
            this.orButt.TabIndex = 16;
            this.orButt.Text = "1-2或";
            this.orButt.UseVisualStyleBackColor = true;
            this.orButt.Click += new System.EventHandler(this.orButt_Click);
            // 
            // noButt
            // 
            this.noButt.Location = new System.Drawing.Point(827, 526);
            this.noButt.Name = "noButt";
            this.noButt.Size = new System.Drawing.Size(100, 30);
            this.noButt.TabIndex = 17;
            this.noButt.Text = "1-非";
            this.noButt.UseVisualStyleBackColor = true;
            this.noButt.Click += new System.EventHandler(this.noButt_Click);
            // 
            // openGeo
            // 
            this.openGeo.Location = new System.Drawing.Point(827, 25);
            this.openGeo.Name = "openGeo";
            this.openGeo.Size = new System.Drawing.Size(100, 30);
            this.openGeo.TabIndex = 18;
            this.openGeo.Text = "几何运算";
            this.openGeo.UseVisualStyleBackColor = true;
            this.openGeo.Click += new System.EventHandler(this.openGeo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 612);
            this.Controls.Add(this.openGeo);
            this.Controls.Add(this.noButt);
            this.Controls.Add(this.orButt);
            this.Controls.Add(this.andButt);
            this.Controls.Add(this.divButt);
            this.Controls.Add(this.mulButt);
            this.Controls.Add(this.subButt);
            this.Controls.Add(this.openInPic2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InPicBox2);
            this.Controls.Add(this.sumButt);
            this.Controls.Add(this.closeButt);
            this.Controls.Add(this.openInPic1);
            this.Controls.Add(this.run);
            this.Controls.Add(this.outPicBox);
            this.Controls.Add(this.InPicBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InPicBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InPicBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox InPicBox1;
        private System.Windows.Forms.PictureBox outPicBox;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Button openInPic1;
        private System.Windows.Forms.Button closeButt;
        private System.Windows.Forms.Button sumButt;
        private System.Windows.Forms.PictureBox InPicBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button openInPic2;
        private System.Windows.Forms.Button subButt;
        private System.Windows.Forms.Button mulButt;
        private System.Windows.Forms.Button divButt;
        private System.Windows.Forms.Button andButt;
        private System.Windows.Forms.Button orButt;
        private System.Windows.Forms.Button noButt;
        private System.Windows.Forms.Button openGeo;
    }
}

