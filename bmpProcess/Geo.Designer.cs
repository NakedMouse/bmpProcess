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
            this.sigmaButt = new System.Windows.Forms.Button();
            this.SymmetricFilterButt = new System.Windows.Forms.Button();
            this.KNN_Butt = new System.Windows.Forms.Button();
            this.avgFilterButt = new System.Windows.Forms.Button();
            this.weightFilterButt = new System.Windows.Forms.Button();
            this.midFilterButt = new System.Windows.Forms.Button();
            this.medianFilter2DButt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.wallisAbsSharpButt = new System.Windows.Forms.Button();
            this.wallisSharpButt = new System.Windows.Forms.Button();
            this.LoGSharpButt = new System.Windows.Forms.Button();
            this.laplaceSharpButt4 = new System.Windows.Forms.Button();
            this.laplaceSharpButt3 = new System.Windows.Forms.Button();
            this.laplaceSharpButt2 = new System.Windows.Forms.Button();
            this.laplaceSharpButt1 = new System.Windows.Forms.Button();
            this.priwittSharpButt = new System.Windows.Forms.Button();
            this.levelSharpButt = new System.Windows.Forms.Button();
            this.verSharpButt = new System.Windows.Forms.Button();
            this.crossDiffSharpButt = new System.Windows.Forms.Button();
            this.sobelSharpButt = new System.Windows.Forms.Button();
            this.openForm = new System.Windows.Forms.Button();
            this.airspaceProcessPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.smoothPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.sharpenPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.airspaceProcessButt = new System.Windows.Forms.Button();
            this.smoothButt = new System.Windows.Forms.Button();
            this.sharpenButt = new System.Windows.Forms.Button();
            this.imgSegmenButt = new System.Windows.Forms.Button();
            this.imgSegmenPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pParaTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uniforMeasureButt = new System.Windows.Forms.Button();
            this.globalThresholdButt = new System.Windows.Forms.Button();
            this.clusterButt = new System.Windows.Forms.Button();
            this.pParaSegButt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.outPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inPicBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.airspaceProcessPanel.SuspendLayout();
            this.smoothPanel.SuspendLayout();
            this.sharpenPanel.SuspendLayout();
            this.imgSegmenPanel.SuspendLayout();
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
            this.outPicBox.Location = new System.Drawing.Point(788, 101);
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
            this.spinButt.Location = new System.Drawing.Point(112, 24);
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
            this.enlargeButt.Location = new System.Drawing.Point(218, 24);
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
            this.narrowButt.Location = new System.Drawing.Point(324, 24);
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
            this.mirrorButt.Location = new System.Drawing.Point(430, 24);
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
            this.linearExpandButt.Location = new System.Drawing.Point(17, 56);
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
            this.nonlinearExpandButt1.Location = new System.Drawing.Point(133, 56);
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
            this.histogramAvgButt.Location = new System.Drawing.Point(17, 92);
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
            this.colorButt.Location = new System.Drawing.Point(133, 92);
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
            this.textBox1.Location = new System.Drawing.Point(414, 557);
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
            this.nonlinearExpandButt2.Location = new System.Drawing.Point(245, 56);
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
            this.groupBox1.Location = new System.Drawing.Point(607, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 71);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "几何处理";
            // 
            // sigmaButt
            // 
            this.sigmaButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.sigmaButt.Location = new System.Drawing.Point(20, 125);
            this.sigmaButt.Name = "sigmaButt";
            this.sigmaButt.Size = new System.Drawing.Size(100, 30);
            this.sigmaButt.TabIndex = 22;
            this.sigmaButt.Text = "Sigma";
            this.sigmaButt.UseVisualStyleBackColor = true;
            this.sigmaButt.Click += new System.EventHandler(this.sigmaButt_Click);
            // 
            // SymmetricFilterButt
            // 
            this.SymmetricFilterButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.SymmetricFilterButt.Location = new System.Drawing.Point(243, 89);
            this.SymmetricFilterButt.Name = "SymmetricFilterButt";
            this.SymmetricFilterButt.Size = new System.Drawing.Size(100, 30);
            this.SymmetricFilterButt.TabIndex = 21;
            this.SymmetricFilterButt.Text = "对称近邻";
            this.SymmetricFilterButt.UseVisualStyleBackColor = true;
            this.SymmetricFilterButt.Click += new System.EventHandler(this.SymmetricFilterButt_Click);
            // 
            // KNN_Butt
            // 
            this.KNN_Butt.Cursor = System.Windows.Forms.Cursors.Default;
            this.KNN_Butt.Location = new System.Drawing.Point(132, 89);
            this.KNN_Butt.Name = "KNN_Butt";
            this.KNN_Butt.Size = new System.Drawing.Size(100, 30);
            this.KNN_Butt.TabIndex = 20;
            this.KNN_Butt.Text = "KNN滤波";
            this.KNN_Butt.UseVisualStyleBackColor = true;
            this.KNN_Butt.Click += new System.EventHandler(this.KNN_Butt_Click);
            // 
            // avgFilterButt
            // 
            this.avgFilterButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.avgFilterButt.Location = new System.Drawing.Point(20, 53);
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
            this.weightFilterButt.Location = new System.Drawing.Point(132, 53);
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
            this.midFilterButt.Location = new System.Drawing.Point(243, 53);
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
            this.medianFilter2DButt.Location = new System.Drawing.Point(20, 89);
            this.medianFilter2DButt.Name = "medianFilter2DButt";
            this.medianFilter2DButt.Size = new System.Drawing.Size(100, 30);
            this.medianFilter2DButt.TabIndex = 15;
            this.medianFilter2DButt.Text = "二维中值";
            this.medianFilter2DButt.UseVisualStyleBackColor = true;
            this.medianFilter2DButt.Click += new System.EventHandler(this.medianFilter2DButt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 560);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "对比度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(907, 563);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "对比度：";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(175, 557);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 28;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(980, 560);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 25);
            this.textBox3.TabIndex = 29;
            // 
            // timeBox
            // 
            this.timeBox.Enabled = false;
            this.timeBox.Location = new System.Drawing.Point(545, 586);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(99, 25);
            this.timeBox.TabIndex = 30;
            // 
            // wallisAbsSharpButt
            // 
            this.wallisAbsSharpButt.AutoSize = true;
            this.wallisAbsSharpButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.wallisAbsSharpButt.Location = new System.Drawing.Point(231, 210);
            this.wallisAbsSharpButt.Name = "wallisAbsSharpButt";
            this.wallisAbsSharpButt.Size = new System.Drawing.Size(100, 30);
            this.wallisAbsSharpButt.TabIndex = 27;
            this.wallisAbsSharpButt.Text = "Wallis_abs";
            this.wallisAbsSharpButt.UseVisualStyleBackColor = true;
            this.wallisAbsSharpButt.Click += new System.EventHandler(this.wallisAbsSharpButt_Click);
            // 
            // wallisSharpButt
            // 
            this.wallisSharpButt.AutoSize = true;
            this.wallisSharpButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.wallisSharpButt.Location = new System.Drawing.Point(231, 174);
            this.wallisSharpButt.Name = "wallisSharpButt";
            this.wallisSharpButt.Size = new System.Drawing.Size(100, 30);
            this.wallisSharpButt.TabIndex = 26;
            this.wallisSharpButt.Text = "Wallis";
            this.wallisSharpButt.UseVisualStyleBackColor = true;
            this.wallisSharpButt.Click += new System.EventHandler(this.wallisSharpButt_Click);
            // 
            // LoGSharpButt
            // 
            this.LoGSharpButt.AutoSize = true;
            this.LoGSharpButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.LoGSharpButt.Location = new System.Drawing.Point(125, 174);
            this.LoGSharpButt.Name = "LoGSharpButt";
            this.LoGSharpButt.Size = new System.Drawing.Size(100, 30);
            this.LoGSharpButt.TabIndex = 25;
            this.LoGSharpButt.Text = "LoG";
            this.LoGSharpButt.UseVisualStyleBackColor = true;
            this.LoGSharpButt.Click += new System.EventHandler(this.LoGSharpButt_Click);
            // 
            // laplaceSharpButt4
            // 
            this.laplaceSharpButt4.Cursor = System.Windows.Forms.Cursors.Default;
            this.laplaceSharpButt4.Location = new System.Drawing.Point(19, 174);
            this.laplaceSharpButt4.Name = "laplaceSharpButt4";
            this.laplaceSharpButt4.Size = new System.Drawing.Size(100, 30);
            this.laplaceSharpButt4.TabIndex = 24;
            this.laplaceSharpButt4.Text = "Laplace H4";
            this.laplaceSharpButt4.UseVisualStyleBackColor = true;
            this.laplaceSharpButt4.Click += new System.EventHandler(this.laplaceSharpButt4_Click);
            // 
            // laplaceSharpButt3
            // 
            this.laplaceSharpButt3.Cursor = System.Windows.Forms.Cursors.Default;
            this.laplaceSharpButt3.Location = new System.Drawing.Point(231, 138);
            this.laplaceSharpButt3.Name = "laplaceSharpButt3";
            this.laplaceSharpButt3.Size = new System.Drawing.Size(100, 30);
            this.laplaceSharpButt3.TabIndex = 23;
            this.laplaceSharpButt3.Text = "Laplace H3";
            this.laplaceSharpButt3.UseVisualStyleBackColor = true;
            this.laplaceSharpButt3.Click += new System.EventHandler(this.laplaceSharpButt3_Click);
            // 
            // laplaceSharpButt2
            // 
            this.laplaceSharpButt2.Cursor = System.Windows.Forms.Cursors.Default;
            this.laplaceSharpButt2.Location = new System.Drawing.Point(125, 138);
            this.laplaceSharpButt2.Name = "laplaceSharpButt2";
            this.laplaceSharpButt2.Size = new System.Drawing.Size(100, 30);
            this.laplaceSharpButt2.TabIndex = 22;
            this.laplaceSharpButt2.Text = "Laplace H2";
            this.laplaceSharpButt2.UseVisualStyleBackColor = true;
            this.laplaceSharpButt2.Click += new System.EventHandler(this.laplaceSharpButt2_Click);
            // 
            // laplaceSharpButt1
            // 
            this.laplaceSharpButt1.Cursor = System.Windows.Forms.Cursors.Default;
            this.laplaceSharpButt1.Location = new System.Drawing.Point(19, 138);
            this.laplaceSharpButt1.Name = "laplaceSharpButt1";
            this.laplaceSharpButt1.Size = new System.Drawing.Size(100, 30);
            this.laplaceSharpButt1.TabIndex = 21;
            this.laplaceSharpButt1.Text = "Laplace H1";
            this.laplaceSharpButt1.UseVisualStyleBackColor = true;
            this.laplaceSharpButt1.Click += new System.EventHandler(this.laplaceSharpButt1_Click);
            // 
            // priwittSharpButt
            // 
            this.priwittSharpButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.priwittSharpButt.Location = new System.Drawing.Point(231, 102);
            this.priwittSharpButt.Name = "priwittSharpButt";
            this.priwittSharpButt.Size = new System.Drawing.Size(100, 30);
            this.priwittSharpButt.TabIndex = 20;
            this.priwittSharpButt.Text = "Priwitt";
            this.priwittSharpButt.UseVisualStyleBackColor = true;
            this.priwittSharpButt.Click += new System.EventHandler(this.priwittSharpButt_Click);
            // 
            // levelSharpButt
            // 
            this.levelSharpButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.levelSharpButt.Location = new System.Drawing.Point(20, 66);
            this.levelSharpButt.Name = "levelSharpButt";
            this.levelSharpButt.Size = new System.Drawing.Size(100, 30);
            this.levelSharpButt.TabIndex = 13;
            this.levelSharpButt.Text = "水平一阶";
            this.levelSharpButt.UseVisualStyleBackColor = true;
            this.levelSharpButt.Click += new System.EventHandler(this.levelSharpButt_Click);
            // 
            // verSharpButt
            // 
            this.verSharpButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.verSharpButt.Location = new System.Drawing.Point(125, 66);
            this.verSharpButt.Name = "verSharpButt";
            this.verSharpButt.Size = new System.Drawing.Size(100, 30);
            this.verSharpButt.TabIndex = 14;
            this.verSharpButt.Text = "垂直一阶";
            this.verSharpButt.UseVisualStyleBackColor = true;
            this.verSharpButt.Click += new System.EventHandler(this.verSharpButt_Click);
            // 
            // crossDiffSharpButt
            // 
            this.crossDiffSharpButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.crossDiffSharpButt.Location = new System.Drawing.Point(19, 102);
            this.crossDiffSharpButt.Name = "crossDiffSharpButt";
            this.crossDiffSharpButt.Size = new System.Drawing.Size(100, 30);
            this.crossDiffSharpButt.TabIndex = 19;
            this.crossDiffSharpButt.Text = "交叉微分";
            this.crossDiffSharpButt.UseVisualStyleBackColor = true;
            this.crossDiffSharpButt.Click += new System.EventHandler(this.crossDiffSharpButt_Click);
            // 
            // sobelSharpButt
            // 
            this.sobelSharpButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.sobelSharpButt.Location = new System.Drawing.Point(125, 102);
            this.sobelSharpButt.Name = "sobelSharpButt";
            this.sobelSharpButt.Size = new System.Drawing.Size(100, 30);
            this.sobelSharpButt.TabIndex = 15;
            this.sobelSharpButt.Text = "Sobel方法";
            this.sobelSharpButt.UseVisualStyleBackColor = true;
            this.sobelSharpButt.Click += new System.EventHandler(this.sobelSharpButt_Click);
            // 
            // openForm
            // 
            this.openForm.Location = new System.Drawing.Point(442, 48);
            this.openForm.Name = "openForm";
            this.openForm.Size = new System.Drawing.Size(107, 32);
            this.openForm.TabIndex = 32;
            this.openForm.Text = "简单运算";
            this.openForm.UseVisualStyleBackColor = true;
            this.openForm.Click += new System.EventHandler(this.openForm_Click);
            // 
            // airspaceProcessPanel
            // 
            this.airspaceProcessPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.airspaceProcessPanel.Controls.Add(this.label3);
            this.airspaceProcessPanel.Controls.Add(this.colorButt);
            this.airspaceProcessPanel.Controls.Add(this.histogramAvgButt);
            this.airspaceProcessPanel.Controls.Add(this.nonlinearExpandButt2);
            this.airspaceProcessPanel.Controls.Add(this.nonlinearExpandButt1);
            this.airspaceProcessPanel.Controls.Add(this.linearExpandButt);
            this.airspaceProcessPanel.Location = new System.Drawing.Point(420, 238);
            this.airspaceProcessPanel.Name = "airspaceProcessPanel";
            this.airspaceProcessPanel.Size = new System.Drawing.Size(360, 136);
            this.airspaceProcessPanel.TabIndex = 33;
            this.airspaceProcessPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "空域处理";
            // 
            // smoothPanel
            // 
            this.smoothPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.smoothPanel.Controls.Add(this.sigmaButt);
            this.smoothPanel.Controls.Add(this.label4);
            this.smoothPanel.Controls.Add(this.SymmetricFilterButt);
            this.smoothPanel.Controls.Add(this.avgFilterButt);
            this.smoothPanel.Controls.Add(this.KNN_Butt);
            this.smoothPanel.Controls.Add(this.weightFilterButt);
            this.smoothPanel.Controls.Add(this.medianFilter2DButt);
            this.smoothPanel.Controls.Add(this.midFilterButt);
            this.smoothPanel.Location = new System.Drawing.Point(420, 238);
            this.smoothPanel.Name = "smoothPanel";
            this.smoothPanel.Size = new System.Drawing.Size(360, 180);
            this.smoothPanel.TabIndex = 34;
            this.smoothPanel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "平滑处理";
            // 
            // sharpenPanel
            // 
            this.sharpenPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.sharpenPanel.Controls.Add(this.wallisAbsSharpButt);
            this.sharpenPanel.Controls.Add(this.label5);
            this.sharpenPanel.Controls.Add(this.wallisSharpButt);
            this.sharpenPanel.Controls.Add(this.verSharpButt);
            this.sharpenPanel.Controls.Add(this.LoGSharpButt);
            this.sharpenPanel.Controls.Add(this.sobelSharpButt);
            this.sharpenPanel.Controls.Add(this.laplaceSharpButt4);
            this.sharpenPanel.Controls.Add(this.crossDiffSharpButt);
            this.sharpenPanel.Controls.Add(this.laplaceSharpButt3);
            this.sharpenPanel.Controls.Add(this.levelSharpButt);
            this.sharpenPanel.Controls.Add(this.laplaceSharpButt2);
            this.sharpenPanel.Controls.Add(this.priwittSharpButt);
            this.sharpenPanel.Controls.Add(this.laplaceSharpButt1);
            this.sharpenPanel.Location = new System.Drawing.Point(420, 238);
            this.sharpenPanel.Name = "sharpenPanel";
            this.sharpenPanel.Size = new System.Drawing.Size(360, 243);
            this.sharpenPanel.TabIndex = 35;
            this.sharpenPanel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "锐化处理";
            // 
            // airspaceProcessButt
            // 
            this.airspaceProcessButt.Location = new System.Drawing.Point(422, 149);
            this.airspaceProcessButt.Name = "airspaceProcessButt";
            this.airspaceProcessButt.Size = new System.Drawing.Size(107, 32);
            this.airspaceProcessButt.TabIndex = 36;
            this.airspaceProcessButt.Text = "空域处理";
            this.airspaceProcessButt.UseVisualStyleBackColor = true;
            this.airspaceProcessButt.Click += new System.EventHandler(this.airspaceProcessButt_Click);
            // 
            // smoothButt
            // 
            this.smoothButt.Location = new System.Drawing.Point(547, 149);
            this.smoothButt.Name = "smoothButt";
            this.smoothButt.Size = new System.Drawing.Size(107, 32);
            this.smoothButt.TabIndex = 37;
            this.smoothButt.Text = "平滑处理";
            this.smoothButt.UseVisualStyleBackColor = true;
            this.smoothButt.Click += new System.EventHandler(this.smoothButt_Click);
            // 
            // sharpenButt
            // 
            this.sharpenButt.Location = new System.Drawing.Point(667, 149);
            this.sharpenButt.Name = "sharpenButt";
            this.sharpenButt.Size = new System.Drawing.Size(107, 32);
            this.sharpenButt.TabIndex = 38;
            this.sharpenButt.Text = "锐化处理";
            this.sharpenButt.UseVisualStyleBackColor = true;
            this.sharpenButt.Click += new System.EventHandler(this.sharpenButt_Click);
            // 
            // imgSegmenButt
            // 
            this.imgSegmenButt.Location = new System.Drawing.Point(422, 187);
            this.imgSegmenButt.Name = "imgSegmenButt";
            this.imgSegmenButt.Size = new System.Drawing.Size(107, 32);
            this.imgSegmenButt.TabIndex = 39;
            this.imgSegmenButt.Text = "图像分割";
            this.imgSegmenButt.UseVisualStyleBackColor = true;
            this.imgSegmenButt.Click += new System.EventHandler(this.imgSegmenButt_Click);
            // 
            // imgSegmenPanel
            // 
            this.imgSegmenPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.imgSegmenPanel.Controls.Add(this.label7);
            this.imgSegmenPanel.Controls.Add(this.pParaTxtBox);
            this.imgSegmenPanel.Controls.Add(this.label6);
            this.imgSegmenPanel.Controls.Add(this.uniforMeasureButt);
            this.imgSegmenPanel.Controls.Add(this.globalThresholdButt);
            this.imgSegmenPanel.Controls.Add(this.clusterButt);
            this.imgSegmenPanel.Controls.Add(this.pParaSegButt);
            this.imgSegmenPanel.Location = new System.Drawing.Point(420, 238);
            this.imgSegmenPanel.Name = "imgSegmenPanel";
            this.imgSegmenPanel.Size = new System.Drawing.Size(362, 240);
            this.imgSegmenPanel.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 27;
            this.label7.Text = "P参数";
            // 
            // pParaTxtBox
            // 
            this.pParaTxtBox.Location = new System.Drawing.Point(124, 186);
            this.pParaTxtBox.Name = "pParaTxtBox";
            this.pParaTxtBox.Size = new System.Drawing.Size(100, 25);
            this.pParaTxtBox.TabIndex = 20;
            this.pParaTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pParaTxtBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pParaTxtBox_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "图像分割";
            // 
            // uniforMeasureButt
            // 
            this.uniforMeasureButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.uniforMeasureButt.Location = new System.Drawing.Point(125, 66);
            this.uniforMeasureButt.Name = "uniforMeasureButt";
            this.uniforMeasureButt.Size = new System.Drawing.Size(100, 30);
            this.uniforMeasureButt.TabIndex = 14;
            this.uniforMeasureButt.Text = "均匀性";
            this.uniforMeasureButt.UseVisualStyleBackColor = true;
            this.uniforMeasureButt.Click += new System.EventHandler(this.uniforMeasureButt_Click);
            // 
            // globalThresholdButt
            // 
            this.globalThresholdButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.globalThresholdButt.Location = new System.Drawing.Point(125, 102);
            this.globalThresholdButt.Name = "globalThresholdButt";
            this.globalThresholdButt.Size = new System.Drawing.Size(100, 30);
            this.globalThresholdButt.TabIndex = 15;
            this.globalThresholdButt.Text = "全局阈值";
            this.globalThresholdButt.UseVisualStyleBackColor = true;
            this.globalThresholdButt.Click += new System.EventHandler(this.globalThresholdButt_Click);
            // 
            // clusterButt
            // 
            this.clusterButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.clusterButt.Location = new System.Drawing.Point(19, 102);
            this.clusterButt.Name = "clusterButt";
            this.clusterButt.Size = new System.Drawing.Size(100, 30);
            this.clusterButt.TabIndex = 19;
            this.clusterButt.Text = "聚类";
            this.clusterButt.UseVisualStyleBackColor = true;
            this.clusterButt.Click += new System.EventHandler(this.clusterButt_Click);
            // 
            // pParaSegButt
            // 
            this.pParaSegButt.Cursor = System.Windows.Forms.Cursors.Default;
            this.pParaSegButt.Location = new System.Drawing.Point(20, 66);
            this.pParaSegButt.Name = "pParaSegButt";
            this.pParaSegButt.Size = new System.Drawing.Size(100, 30);
            this.pParaSegButt.TabIndex = 13;
            this.pParaSegButt.Text = "P参数";
            this.pParaSegButt.UseVisualStyleBackColor = true;
            this.pParaSegButt.Click += new System.EventHandler(this.pParaSegButt_Click);
            // 
            // Geo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1200, 623);
            this.Controls.Add(this.imgSegmenButt);
            this.Controls.Add(this.sharpenButt);
            this.Controls.Add(this.smoothButt);
            this.Controls.Add(this.airspaceProcessButt);
            this.Controls.Add(this.openForm);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveButt);
            this.Controls.Add(this.resetButt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.inPicBox);
            this.Controls.Add(this.outPicBox);
            this.Controls.Add(this.geoOpenIn);
            this.Controls.Add(this.imgSegmenPanel);
            this.Controls.Add(this.airspaceProcessPanel);
            this.Controls.Add(this.sharpenPanel);
            this.Controls.Add(this.smoothPanel);
            this.Name = "Geo";
            this.Text = "Geo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Geo_FormClosed);
            this.Load += new System.EventHandler(this.Geo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.outPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inPicBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.airspaceProcessPanel.ResumeLayout(false);
            this.airspaceProcessPanel.PerformLayout();
            this.smoothPanel.ResumeLayout(false);
            this.smoothPanel.PerformLayout();
            this.sharpenPanel.ResumeLayout(false);
            this.sharpenPanel.PerformLayout();
            this.imgSegmenPanel.ResumeLayout(false);
            this.imgSegmenPanel.PerformLayout();
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
        private System.Windows.Forms.Button avgFilterButt;
        private System.Windows.Forms.Button weightFilterButt;
        private System.Windows.Forms.Button midFilterButt;
        private System.Windows.Forms.Button medianFilter2DButt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button KNN_Butt;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.Button SymmetricFilterButt;
        private System.Windows.Forms.Button sigmaButt;
        private System.Windows.Forms.Button laplaceSharpButt2;
        private System.Windows.Forms.Button laplaceSharpButt1;
        private System.Windows.Forms.Button priwittSharpButt;
        private System.Windows.Forms.Button levelSharpButt;
        private System.Windows.Forms.Button verSharpButt;
        private System.Windows.Forms.Button crossDiffSharpButt;
        private System.Windows.Forms.Button sobelSharpButt;
        private System.Windows.Forms.Button LoGSharpButt;
        private System.Windows.Forms.Button laplaceSharpButt4;
        private System.Windows.Forms.Button laplaceSharpButt3;
        private System.Windows.Forms.Button wallisSharpButt;
        private System.Windows.Forms.Button openForm;
        private System.Windows.Forms.Button wallisAbsSharpButt;
        private System.Windows.Forms.Panel airspaceProcessPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel smoothPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel sharpenPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button airspaceProcessButt;
        private System.Windows.Forms.Button smoothButt;
        private System.Windows.Forms.Button sharpenButt;
        private System.Windows.Forms.Button imgSegmenButt;
        private System.Windows.Forms.Panel imgSegmenPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button uniforMeasureButt;
        private System.Windows.Forms.Button globalThresholdButt;
        private System.Windows.Forms.Button clusterButt;
        private System.Windows.Forms.Button pParaSegButt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox pParaTxtBox;
    }
}