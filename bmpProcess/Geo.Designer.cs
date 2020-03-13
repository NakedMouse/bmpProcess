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
            ((System.ComponentModel.ISupportInitialize)(this.outPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inPicBox)).BeginInit();
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
            this.outPicBox.Location = new System.Drawing.Point(592, 101);
            this.outPicBox.Name = "outPicBox";
            this.outPicBox.Size = new System.Drawing.Size(450, 450);
            this.outPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outPicBox.TabIndex = 6;
            this.outPicBox.TabStop = false;
            // 
            // inPicBox
            // 
            this.inPicBox.Location = new System.Drawing.Point(30, 101);
            this.inPicBox.Name = "inPicBox";
            this.inPicBox.Size = new System.Drawing.Size(450, 450);
            this.inPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inPicBox.TabIndex = 7;
            this.inPicBox.TabStop = false;
            // 
            // moveButt
            // 
            this.moveButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.moveButt.Location = new System.Drawing.Point(486, 118);
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
            this.spinButt.Location = new System.Drawing.Point(486, 163);
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
            this.enlargeButt.Location = new System.Drawing.Point(486, 211);
            this.enlargeButt.Name = "enlargeButt";
            this.enlargeButt.Size = new System.Drawing.Size(100, 30);
            this.enlargeButt.TabIndex = 10;
            this.enlargeButt.Text = "放大";
            this.enlargeButt.UseVisualStyleBackColor = true;
            // 
            // narrowButt
            // 
            this.narrowButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.narrowButt.Location = new System.Drawing.Point(486, 257);
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
            this.mirrorButt.Location = new System.Drawing.Point(486, 307);
            this.mirrorButt.Name = "mirrorButt";
            this.mirrorButt.Size = new System.Drawing.Size(100, 30);
            this.mirrorButt.TabIndex = 12;
            this.mirrorButt.Text = "镜像";
            this.mirrorButt.UseVisualStyleBackColor = true;
            this.mirrorButt.Click += new System.EventHandler(this.mirrorButt_Click);
            // 
            // Geo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 614);
            this.Controls.Add(this.mirrorButt);
            this.Controls.Add(this.narrowButt);
            this.Controls.Add(this.enlargeButt);
            this.Controls.Add(this.spinButt);
            this.Controls.Add(this.moveButt);
            this.Controls.Add(this.inPicBox);
            this.Controls.Add(this.outPicBox);
            this.Controls.Add(this.geoOpenIn);
            this.Name = "Geo";
            this.Text = "Geo";
            this.Load += new System.EventHandler(this.Geo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.outPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inPicBox)).EndInit();
            this.ResumeLayout(false);

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
    }
}