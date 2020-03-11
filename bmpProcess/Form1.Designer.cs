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
            this.picBoxL = new System.Windows.Forms.PictureBox();
            this.picBoxR = new System.Windows.Forms.PictureBox();
            this.run = new System.Windows.Forms.Button();
            this.openButt = new System.Windows.Forms.Button();
            this.saveButt = new System.Windows.Forms.Button();
            this.closeButt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxR)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxL
            // 
            this.picBoxL.Location = new System.Drawing.Point(128, 81);
            this.picBoxL.Name = "picBoxL";
            this.picBoxL.Size = new System.Drawing.Size(350, 400);
            this.picBoxL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxL.TabIndex = 0;
            this.picBoxL.TabStop = false;
            // 
            // picBoxR
            // 
            this.picBoxR.Location = new System.Drawing.Point(533, 81);
            this.picBoxR.Name = "picBoxR";
            this.picBoxR.Size = new System.Drawing.Size(350, 400);
            this.picBoxR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxR.TabIndex = 1;
            this.picBoxR.TabStop = false;
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(533, 487);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(100, 30);
            this.run.TabIndex = 2;
            this.run.Text = "运行";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // openButt
            // 
            this.openButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.openButt.Location = new System.Drawing.Point(128, 487);
            this.openButt.Name = "openButt";
            this.openButt.Size = new System.Drawing.Size(100, 30);
            this.openButt.TabIndex = 3;
            this.openButt.Text = "打开";
            this.openButt.UseVisualStyleBackColor = true;
            this.openButt.Click += new System.EventHandler(this.openButt_Click);
            // 
            // saveButt
            // 
            this.saveButt.Location = new System.Drawing.Point(256, 487);
            this.saveButt.Name = "saveButt";
            this.saveButt.Size = new System.Drawing.Size(100, 30);
            this.saveButt.TabIndex = 4;
            this.saveButt.Text = "保存";
            this.saveButt.UseVisualStyleBackColor = true;
            this.saveButt.Click += new System.EventHandler(this.saveButt_Click);
            // 
            // closeButt
            // 
            this.closeButt.Location = new System.Drawing.Point(378, 487);
            this.closeButt.Name = "closeButt";
            this.closeButt.Size = new System.Drawing.Size(100, 30);
            this.closeButt.TabIndex = 5;
            this.closeButt.Text = "关闭";
            this.closeButt.UseVisualStyleBackColor = true;
            this.closeButt.Click += new System.EventHandler(this.closeButt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 612);
            this.Controls.Add(this.closeButt);
            this.Controls.Add(this.saveButt);
            this.Controls.Add(this.openButt);
            this.Controls.Add(this.run);
            this.Controls.Add(this.picBoxR);
            this.Controls.Add(this.picBoxL);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxL;
        private System.Windows.Forms.PictureBox picBoxR;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Button openButt;
        private System.Windows.Forms.Button saveButt;
        private System.Windows.Forms.Button closeButt;
    }
}

