namespace bmpProcess
{
    partial class Geo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.geoOpenIn = new System.Windows.Forms.Button();
            this.outPicBox = new System.Windows.Forms.PictureBox();
            this.inPicBox = new System.Windows.Forms.PictureBox();
            this.moveButt = new System.Windows.Forms.Button();
            this.spinButt = new System.Windows.Forms.Button();
            this.enlargeButt = new System.Windows.Forms.Button();
            this.narrowButt = new System.Windows.Forms.Button();
            this.mirrorButt = new System.Windows.Forms.Button();
            this.linearExpandButt = new System.Windows.Forms.Button();
            this.nonlinearExpandButt1 = new System.Windows.Forms.Button();
            this.histogramAvgButt = new System.Windows.Forms.Button();
            this.colorButt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.resetButt = new System.Windows.Forms.Button();
            this.nonlinearExpandButt2 = new System.Windows.Forms.Button();
            this.saveButt = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.avgFilterButt = new System.Windows.Forms.Button();
            this.weightFilterButt = new System.Windows.Forms.Button();
            this.midFilterButt = new System.Windows.Forms.Button();
            this.medianFilter2DButt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.outPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inPicBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // geoOpenIn
            // 
            this.geoOpenIn.Cursor = System.Windows.Forms.Cursors.Default;
            this.geoOpenIn.Location = new System.Drawing.Point(53, 50);
            this.geoOpenIn.Name = "geoOpenIn";
            this.geoOpenIn.Size = new System.Drawing.Size(100, 30);
            this.geoOpenIn.TabIndex = 4;
            this.geoOpenIn.Text = "打开";
            this.geoOpenIn.UseVisualStyleBackColor = true;
            this.geoOpenIn.Click += new System.EventHandler(this.geoOpenIn_Click);
            // 
            // outPicBox
            // 
            this.outPicBox.Location = new System.Drawing.Point(654, 101);
            this.outPicBox.Name = "outPicBox";
            this.outPicBox.Size = new System.Drawing.Size(400, 450);
            this.outPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outPicBox.TabIndex = 6;
            this.outPicBox.TabStop = false;
            // 
            // inPicBox
            // 
            this.inPicBox.Location = new System.Drawing.Point(12, 101);
            this.inPicBox.Name = "inPicBox";
            this.inPicBox.Size = new System.Drawing.Size(400, 450);
            this.inPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inPicBox.TabIndex = 7;
            this.inPicBox.TabStop = false;
            // 
            // moveButt
            // 
            this.moveButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.moveButt.Location = new System.Drawing.Point(6, 24);
            this.moveButt.Name = "moveButt";
            this.moveButt.Size = new System.Drawing.Size(100, 30);
            this.moveButt.TabIndex = 8;
            this.moveButt.Text = "平移";
            this.moveButt.UseVisualStyleBackColor = true;
            this.moveButt.Click += new System.EventHandler(this.moveButt_Click);
            // 
            // spinButt
            // 
            this.spinButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.spinButt.Location = new System.Drawing.Point(124, 24);
            this.spinButt.Name = "spinButt";
            this.spinButt.Size = new System.Drawing.Size(100, 30);
            this.spinButt.TabIndex = 9;
            this.spinButt.Text = "旋转";
            this.spinButt.UseVisualStyleBackColor = true;
            this.spinButt.Click += new System.EventHandler(this.spinButt_Click);
            // 
            // enlargeButt
            // 
            this.enlargeButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.enlargeButt.Location = new System.Drawing.Point(6, 60);
            this.enlargeButt.Name = "enlargeButt";
            this.enlargeButt.Size = new System.Drawing.Size(100, 30);
            this.enlargeButt.TabIndex = 10;
            this.enlargeButt.Text = "放大";
            this.enlargeButt.UseVisualStyleBackColor = true;
            this.enlargeButt.Click += new System.EventHandler(this.enlargeButt_Click);
            // 
            // narrowButt
            // 
            this.narrowButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.narrowButt.Location = new System.Drawing.Point(124, 60);
            this.narrowButt.Name = "narrowButt";
            this.narrowButt.Size = new System.Drawing.Size(100, 30);
            this.narrowButt.TabIndex = 11;
            this.narrowButt.Text = "缩小";
            this.narrowButt.UseVisualStyleBackColor = true;
            this.narrowButt.Click += new System.EventHandler(this.narrowButt_Click);
            // 
            // mirrorButt
            // 
            this.mirrorButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.mirrorButt.Location = new System.Drawing.Point(6, 96);
            this.mirrorButt.Name = "mirrorButt";
            this.mirrorButt.Size = new System.Drawing.Size(100, 30);
            this.mirrorButt.TabIndex = 12;
            this.mirrorButt.Text = "镜像";
            this.mirrorButt.UseVisualStyleBackColor = true;
            this.mirrorButt.Click += new System.EventHandler(this.mirrorButt_Click);
            // 
            // linearExpandButt
            // 
            this.linearExpandButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.linearExpandButt.Location = new System.Drawing.Point(6, 24);
            this.linearExpandButt.Name = "linearExpandButt";
            this.linearExpandButt.Size = new System.Drawing.Size(100, 30);
            this.linearExpandButt.TabIndex = 13;
            this.linearExpandButt.Text = "线性展宽";
            this.linearExpandButt.UseVisualStyleBackColor = true;
            this.linearExpandButt.Click += new System.EventHandler(this.linearExpandButt_Click);
            // 
            // nonlinearExpandButt1
            // 
            this.nonlinearExpandButt1.Cursor = System.Windows.Forms.Cursors.Default;
            this.nonlinearExpandButt1.Location = new System.Drawing.Point(124, 24);
            this.nonlinearExpandButt1.Name = "nonlinearExpandButt1";
            this.nonlinearExpandButt1.Size = new System.Drawing.Size(100, 30);
            this.nonlinearExpandButt1.TabIndex = 14;
            this.nonlinearExpandButt1.Text = "对数展宽";
            this.nonlinearExpandButt1.UseVisualStyleBackColor = true;
            this.nonlinearExpandButt1.Click += new System.EventHandler(this.nonlinearExpandButt_Click);
            // 
            // histogramAvgButt
            // 
            this.histogramAvgButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.histogramAvgButt.Location = new System.Drawing.Point(124, 60);
            this.histogramAvgButt.Name = "histogramAvgButt";
            this.histogramAvgButt.Size = new System.Drawing.Size(100, 30);
            this.histogramAvgButt.TabIndex = 15;
            this.histogramAvgButt.Text = "直方均衡";
            this.histogramAvgButt.UseVisualStyleBackColor = true;
            this.histogramAvgButt.Click += new System.EventHandler(this.histogramAvgButt_Click);
            // 
            // colorButt
            // 
            this.colorButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.colorButt.Location = new System.Drawing.Point(6, 96);
            this.colorButt.Name = "colorButt";
            this.colorButt.Size = new System.Drawing.Size(100, 30);
            this.colorButt.TabIndex = 16;
            this.colorButt.Text = "伪彩色";
            this.colorButt.UseVisualStyleBackColor = true;
            this.colorButt.Click += new System.EventHandler(this.colorButt_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(347, 557);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(368, 25);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "空域处理将先转换为灰度图像且不保存输出图像";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // resetButt
            // 
            this.resetButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.resetButt.Location = new System.Drawing.Point(180, 50);
            this.resetButt.Name = "resetButt";
            this.resetButt.Size = new System.Drawing.Size(100, 30);
            this.resetButt.TabIndex = 18;
            this.resetButt.Text = "重置";
            this.resetButt.UseVisualStyleBackColor = true;
            this.resetButt.Click += new System.EventHandler(this.resetButt_Click);
            // 
            // nonlinearExpandButt2
            // 
            this.nonlinearExpandButt2.Cursor = System.Windows.Forms.Cursors.Default;
            this.nonlinearExpandButt2.Location = new System.Drawing.Point(6, 60);
            this.nonlinearExpandButt2.Name = "nonlinearExpandButt2";
            this.nonlinearExpandButt2.Size = new System.Drawing.Size(100, 30);
            this.nonlinearExpandButt2.TabIndex = 19;
            this.nonlinearExpandButt2.Text = "指数展宽";
            this.nonlinearExpandButt2.UseVisualStyleBackColor = true;
            this.nonlinearExpandButt2.Click += new System.EventHandler(this.nonlinearExpandButt2_Click);
            // 
            // saveButt
            // 
            this.saveButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.saveButt.Location = new System.Drawing.Point(312, 50);
            this.saveButt.Name = "saveButt";
            this.saveButt.Size = new System.Drawing.Size(100, 30);
            this.saveButt.TabIndex = 20;
            this.saveButt.Text = "保存输出";
            this.saveButt.UseVisualStyleBackColor = true;
            this.saveButt.Click += new System.EventHandler(this.saveButt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.moveButt);
            this.groupBox1.Controls.Add(this.spinButt);
            this.groupBox1.Controls.Add(this.enlargeButt);
            this.groupBox1.Controls.Add(this.narrowButt);
            this.groupBox1.Controls.Add(this.mirrorButt);
            this.groupBox1.Location = new System.Drawing.Point(418, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 130);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "几何处理";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linearExpandButt);
            this.groupBox2.Controls.Add(this.nonlinearExpandButt1);
            this.groupBox2.Controls.Add(this.nonlinearExpandButt2);
            this.groupBox2.Controls.Add(this.histogramAvgButt);
            this.groupBox2.Controls.Add(this.colorButt);
            this.groupBox2.Location = new System.Drawing.Point(418, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 138);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "空域处理";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.avgFilterButt);
            this.groupBox3.Controls.Add(this.weightFilterButt);
            this.groupBox3.Controls.Add(this.midFilterButt);
            this.groupBox3.Controls.Add(this.medianFilter2DButt);
            this.groupBox3.Location = new System.Drawing.Point(418, 393);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 138);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "滤波处理";
            // 
            // avgFilterButt
            // 
            this.avgFilterButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.avgFilterButt.Location = new System.Drawing.Point(6, 24);
            this.avgFilterButt.Name = "avgFilterButt";
            this.avgFilterButt.Size = new System.Drawing.Size(100, 30);
            this.avgFilterButt.TabIndex = 13;
            this.avgFilterButt.Text = "均值滤波";
            this.avgFilterButt.UseVisualStyleBackColor = true;
            this.avgFilterButt.Click += new System.EventHandler(this.avgFilterButt_Click);
            // 
            // weightFilterButt
            // 
            this.weightFilterButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.weightFilterButt.Location = new System.Drawing.Point(124, 24);
            this.weightFilterButt.Name = "weightFilterButt";
            this.weightFilterButt.Size = new System.Drawing.Size(100, 30);
            this.weightFilterButt.TabIndex = 14;
            this.weightFilterButt.Text = "加权滤波";
            this.weightFilterButt.UseVisualStyleBackColor = true;
            this.weightFilterButt.Click += new System.EventHandler(this.weightFilterButt_Click);
            // 
            // midFilterButt
            // 
            this.midFilterButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.midFilterButt.Location = new System.Drawing.Point(6, 60);
            this.midFilterButt.Name = "midFilterButt";
            this.midFilterButt.Size = new System.Drawing.Size(100, 30);
            this.midFilterButt.TabIndex = 19;
            this.midFilterButt.Text = "一维中值";
            this.midFilterButt.UseVisualStyleBackColor = true;
            this.midFilterButt.Click += new System.EventHandler(this.midFilterButt_Click);
            // 
            // medianFilter2DButt
            // 
            this.medianFilter2DButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.medianFilter2DButt.Location = new System.Drawing.Point(124, 60);
            this.medianFilter2DButt.Name = "medianFilter2DButt";
            this.medianFilter2DButt.Size = new System.Drawing.Size(100, 30);
            this.medianFilter2DButt.TabIndex = 15;
            this.medianFilter2DButt.Text = "二维中值";
            this.medianFilter2DButt.UseVisualStyleBackColor = true;
            this.medianFilter2DButt.Click += new System.EventHandler(this.medianFilter2DButt_Click);
            // 
            // Geo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 614);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveButt);
            this.Controls.Add(this.resetButt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.inPicBox);
            this.Controls.Add(this.outPicBox);
            this.Controls.Add(this.geoOpenIn);
            this.Name = "Geo";
            this.Text = "Geo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Geo_FormClosed);
            this.Load += new System.EventHandler(this.Geo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.outPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inPicBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button geoOpenIn;
        private System.Windows.Forms.PictureBox outPicBox;
        private System.Windows.Forms.PictureBox inPicBox;
        private System.Windows.Forms.Button moveButt;
        private System.Windows.Forms.Button spinButt;
        private System.Windows.Forms.Button enlargeButt;
        private System.Windows.Forms.Button narrowButt;
        private System.Windows.Forms.Button mirrorButt;
        private System.Windows.Forms.Button linearExpandButt;
        private System.Windows.Forms.Button nonlinearExpandButt1;
        private System.Windows.Forms.Button histogramAvgButt;
        private System.Windows.Forms.Button colorButt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button resetButt;
        private System.Windows.Forms.Button nonlinearExpandButt2;
        private System.Windows.Forms.Button saveButt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button avgFilterButt;
        private System.Windows.Forms.Button weightFilterButt;
        private System.Windows.Forms.Button midFilterButt;
        private System.Windows.Forms.Button medianFilter2DButt;
    }
}