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
            this.outBox = new System.Windows.Forms.PictureBox();
            this.inBox = new System.Windows.Forms.PictureBox();
            this.moveButt = new System.Windows.Forms.Button();
            this.spinButt = new System.Windows.Forms.Button();
            this.bigButt = new System.Windows.Forms.Button();
            this.smallButt = new System.Windows.Forms.Button();
            this.mirrorButt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.outBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inBox)).BeginInit();
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
            // outBox
            // 
            this.outBox.Location = new System.Drawing.Point(592, 101);
            this.outBox.Name = "outBox";
            this.outBox.Size = new System.Drawing.Size(450, 450);
            this.outBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outBox.TabIndex = 6;
            this.outBox.TabStop = false;
            // 
            // inBox
            // 
            this.inBox.Location = new System.Drawing.Point(30, 101);
            this.inBox.Name = "inBox";
            this.inBox.Size = new System.Drawing.Size(450, 450);
            this.inBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inBox.TabIndex = 7;
            this.inBox.TabStop = false;
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
            // 
            // bigButt
            // 
            this.bigButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.bigButt.Location = new System.Drawing.Point(486, 211);
            this.bigButt.Name = "bigButt";
            this.bigButt.Size = new System.Drawing.Size(100, 30);
            this.bigButt.TabIndex = 10;
            this.bigButt.Text = "放大";
            this.bigButt.UseVisualStyleBackColor = true;
            // 
            // smallButt
            // 
            this.smallButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.smallButt.Location = new System.Drawing.Point(486, 257);
            this.smallButt.Name = "smallButt";
            this.smallButt.Size = new System.Drawing.Size(100, 30);
            this.smallButt.TabIndex = 11;
            this.smallButt.Text = "缩小";
            this.smallButt.UseVisualStyleBackColor = true;
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
            // 
            // Geo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 614);
            this.Controls.Add(this.mirrorButt);
            this.Controls.Add(this.smallButt);
            this.Controls.Add(this.bigButt);
            this.Controls.Add(this.spinButt);
            this.Controls.Add(this.moveButt);
            this.Controls.Add(this.inBox);
            this.Controls.Add(this.outBox);
            this.Controls.Add(this.geoOpenIn);
            this.Name = "Geo";
            this.Text = "Geo";
            this.Load += new System.EventHandler(this.Geo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.outBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button geoOpenIn;
        private System.Windows.Forms.PictureBox outBox;
        private System.Windows.Forms.PictureBox inBox;
        private System.Windows.Forms.Button moveButt;
        private System.Windows.Forms.Button spinButt;
        private System.Windows.Forms.Button bigButt;
        private System.Windows.Forms.Button smallButt;
        private System.Windows.Forms.Button mirrorButt;
    }
}