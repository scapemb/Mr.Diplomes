namespace MastaClasta
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBoxRecognizeType = new System.Windows.Forms.GroupBox();
            this.radioButtonNeural = new System.Windows.Forms.RadioButton();
            this.radioButtonClasters = new System.Windows.Forms.RadioButton();
            this.buttonRecognizeNeural = new System.Windows.Forms.Button();
            this.buttonTeachNeural = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.trackBarClustersNumber = new System.Windows.Forms.TrackBar();
            this.buttonTry = new System.Windows.Forms.Button();
            this.trackBarBlur = new System.Windows.Forms.TrackBar();
            this.trackBarBlack = new System.Windows.Forms.TrackBar();
            this.trackBarWhite = new System.Windows.Forms.TrackBar();
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxGrayScale = new System.Windows.Forms.PictureBox();
            this.pictureBoxBlured = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeveled = new System.Windows.Forms.PictureBox();
            this.pictureBoxBinariezed = new System.Windows.Forms.PictureBox();
            this.labelWhite = new System.Windows.Forms.Label();
            this.labelBlack = new System.Windows.Forms.Label();
            this.labelBlur = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.numericUpDownWhite = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBlack = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBlur = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNumber = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBoxRecognizeType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarClustersNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrayScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlured)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeveled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBinariezed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1110, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.startToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click_1);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click_1);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1110, 699);
            this.splitContainer1.SplitterDistance = 545;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.numericUpDownNumber);
            this.splitContainer2.Panel1.Controls.Add(this.numericUpDownBlur);
            this.splitContainer2.Panel1.Controls.Add(this.numericUpDownBlack);
            this.splitContainer2.Panel1.Controls.Add(this.numericUpDownWhite);
            this.splitContainer2.Panel1.Controls.Add(this.labelNumber);
            this.splitContainer2.Panel1.Controls.Add(this.labelBlur);
            this.splitContainer2.Panel1.Controls.Add(this.labelBlack);
            this.splitContainer2.Panel1.Controls.Add(this.labelWhite);
            this.splitContainer2.Panel1.Controls.Add(this.groupBoxRecognizeType);
            this.splitContainer2.Panel1.Controls.Add(this.buttonRecognizeNeural);
            this.splitContainer2.Panel1.Controls.Add(this.buttonTeachNeural);
            this.splitContainer2.Panel1.Controls.Add(this.buttonStart);
            this.splitContainer2.Panel1.Controls.Add(this.trackBarClustersNumber);
            this.splitContainer2.Panel1.Controls.Add(this.buttonTry);
            this.splitContainer2.Panel1.Controls.Add(this.trackBarBlur);
            this.splitContainer2.Panel1.Controls.Add(this.trackBarBlack);
            this.splitContainer2.Panel1.Controls.Add(this.trackBarWhite);
            this.splitContainer2.Panel1.Controls.Add(this.sourcePictureBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.resultPictureBox);
            this.splitContainer2.Size = new System.Drawing.Size(1110, 545);
            this.splitContainer2.SplitterDistance = 530;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBoxRecognizeType
            // 
            this.groupBoxRecognizeType.Controls.Add(this.radioButtonNeural);
            this.groupBoxRecognizeType.Controls.Add(this.radioButtonClasters);
            this.groupBoxRecognizeType.Location = new System.Drawing.Point(10, 365);
            this.groupBoxRecognizeType.Name = "groupBoxRecognizeType";
            this.groupBoxRecognizeType.Size = new System.Drawing.Size(161, 52);
            this.groupBoxRecognizeType.TabIndex = 7;
            this.groupBoxRecognizeType.TabStop = false;
            this.groupBoxRecognizeType.Text = "Recognize type";
            // 
            // radioButtonNeural
            // 
            this.radioButtonNeural.AutoSize = true;
            this.radioButtonNeural.Location = new System.Drawing.Point(99, 29);
            this.radioButtonNeural.Name = "radioButtonNeural";
            this.radioButtonNeural.Size = new System.Drawing.Size(56, 17);
            this.radioButtonNeural.TabIndex = 1;
            this.radioButtonNeural.Text = "Neural";
            this.radioButtonNeural.UseVisualStyleBackColor = true;
            this.radioButtonNeural.CheckedChanged += new System.EventHandler(this.radioButtonNeural_CheckedChanged);
            // 
            // radioButtonClasters
            // 
            this.radioButtonClasters.AutoSize = true;
            this.radioButtonClasters.Checked = true;
            this.radioButtonClasters.Location = new System.Drawing.Point(6, 29);
            this.radioButtonClasters.Name = "radioButtonClasters";
            this.radioButtonClasters.Size = new System.Drawing.Size(87, 17);
            this.radioButtonClasters.TabIndex = 0;
            this.radioButtonClasters.TabStop = true;
            this.radioButtonClasters.Text = "Clasterization";
            this.radioButtonClasters.UseVisualStyleBackColor = true;
            this.radioButtonClasters.CheckedChanged += new System.EventHandler(this.radioButtonClasters_CheckedChanged);
            // 
            // buttonRecognizeNeural
            // 
            this.buttonRecognizeNeural.Location = new System.Drawing.Point(450, 458);
            this.buttonRecognizeNeural.Name = "buttonRecognizeNeural";
            this.buttonRecognizeNeural.Size = new System.Drawing.Size(75, 23);
            this.buttonRecognizeNeural.TabIndex = 6;
            this.buttonRecognizeNeural.Text = "Recognize";
            this.buttonRecognizeNeural.UseVisualStyleBackColor = true;
            this.buttonRecognizeNeural.Visible = false;
            this.buttonRecognizeNeural.Click += new System.EventHandler(this.recognizeNeuron_Click);
            // 
            // buttonTeachNeural
            // 
            this.buttonTeachNeural.Location = new System.Drawing.Point(450, 429);
            this.buttonTeachNeural.Name = "buttonTeachNeural";
            this.buttonTeachNeural.Size = new System.Drawing.Size(75, 23);
            this.buttonTeachNeural.TabIndex = 5;
            this.buttonTeachNeural.Text = "Teach";
            this.buttonTeachNeural.UseVisualStyleBackColor = true;
            this.buttonTeachNeural.Visible = false;
            this.buttonTeachNeural.Click += new System.EventHandler(this.teachNeural_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonStart.Location = new System.Drawing.Point(450, 389);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // trackBarClustersNumber
            // 
            this.trackBarClustersNumber.LargeChange = 1;
            this.trackBarClustersNumber.Location = new System.Drawing.Point(278, 496);
            this.trackBarClustersNumber.Name = "trackBarClustersNumber";
            this.trackBarClustersNumber.Size = new System.Drawing.Size(112, 45);
            this.trackBarClustersNumber.TabIndex = 3;
            this.trackBarClustersNumber.Scroll += new System.EventHandler(this.trackBarClustersNumber_Scroll);
            // 
            // buttonTry
            // 
            this.buttonTry.Location = new System.Drawing.Point(450, 360);
            this.buttonTry.Name = "buttonTry";
            this.buttonTry.Size = new System.Drawing.Size(75, 23);
            this.buttonTry.TabIndex = 2;
            this.buttonTry.Text = "Try";
            this.buttonTry.UseVisualStyleBackColor = true;
            this.buttonTry.Click += new System.EventHandler(this.buttonTry_Click);
            // 
            // trackBarBlur
            // 
            this.trackBarBlur.LargeChange = 3;
            this.trackBarBlur.Location = new System.Drawing.Point(280, 445);
            this.trackBarBlur.Maximum = 21;
            this.trackBarBlur.Name = "trackBarBlur";
            this.trackBarBlur.Size = new System.Drawing.Size(110, 45);
            this.trackBarBlur.TabIndex = 1;
            this.trackBarBlur.Scroll += new System.EventHandler(this.trackBarBlur_Scroll);
            // 
            // trackBarBlack
            // 
            this.trackBarBlack.LargeChange = 10;
            this.trackBarBlack.Location = new System.Drawing.Point(278, 406);
            this.trackBarBlack.Maximum = 255;
            this.trackBarBlack.Name = "trackBarBlack";
            this.trackBarBlack.Size = new System.Drawing.Size(112, 45);
            this.trackBarBlack.TabIndex = 1;
            this.trackBarBlack.Scroll += new System.EventHandler(this.trackBarBlack_Scroll);
            // 
            // trackBarWhite
            // 
            this.trackBarWhite.LargeChange = 10;
            this.trackBarWhite.Location = new System.Drawing.Point(278, 360);
            this.trackBarWhite.Maximum = 255;
            this.trackBarWhite.Name = "trackBarWhite";
            this.trackBarWhite.Size = new System.Drawing.Size(112, 45);
            this.trackBarWhite.TabIndex = 1;
            this.trackBarWhite.Scroll += new System.EventHandler(this.trackBarWhite_Scroll);
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.sourcePictureBox.Location = new System.Drawing.Point(0, 0);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(530, 354);
            this.sourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.Location = new System.Drawing.Point(0, 0);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(576, 387);
            this.resultPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resultPictureBox.TabIndex = 1;
            this.resultPictureBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxGrayScale, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxBlured, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxLeveled, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxBinariezed, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1110, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxGrayScale
            // 
            this.pictureBoxGrayScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxGrayScale.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxGrayScale.Name = "pictureBoxGrayScale";
            this.pictureBoxGrayScale.Size = new System.Drawing.Size(271, 144);
            this.pictureBoxGrayScale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGrayScale.TabIndex = 0;
            this.pictureBoxGrayScale.TabStop = false;
            // 
            // pictureBoxBlured
            // 
            this.pictureBoxBlured.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBlured.Location = new System.Drawing.Point(280, 3);
            this.pictureBoxBlured.Name = "pictureBoxBlured";
            this.pictureBoxBlured.Size = new System.Drawing.Size(271, 144);
            this.pictureBoxBlured.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBlured.TabIndex = 1;
            this.pictureBoxBlured.TabStop = false;
            // 
            // pictureBoxLeveled
            // 
            this.pictureBoxLeveled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLeveled.Location = new System.Drawing.Point(557, 3);
            this.pictureBoxLeveled.Name = "pictureBoxLeveled";
            this.pictureBoxLeveled.Size = new System.Drawing.Size(271, 144);
            this.pictureBoxLeveled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLeveled.TabIndex = 1;
            this.pictureBoxLeveled.TabStop = false;
            // 
            // pictureBoxBinariezed
            // 
            this.pictureBoxBinariezed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBinariezed.Location = new System.Drawing.Point(834, 3);
            this.pictureBoxBinariezed.Name = "pictureBoxBinariezed";
            this.pictureBoxBinariezed.Size = new System.Drawing.Size(273, 144);
            this.pictureBoxBinariezed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBinariezed.TabIndex = 1;
            this.pictureBoxBinariezed.TabStop = false;
            // 
            // labelWhite
            // 
            this.labelWhite.AutoSize = true;
            this.labelWhite.Location = new System.Drawing.Point(204, 365);
            this.labelWhite.Name = "labelWhite";
            this.labelWhite.Size = new System.Drawing.Size(68, 13);
            this.labelWhite.TabIndex = 8;
            this.labelWhite.Text = "White border";
            // 
            // labelBlack
            // 
            this.labelBlack.AutoSize = true;
            this.labelBlack.Location = new System.Drawing.Point(205, 406);
            this.labelBlack.Name = "labelBlack";
            this.labelBlack.Size = new System.Drawing.Size(67, 13);
            this.labelBlack.TabIndex = 8;
            this.labelBlack.Text = "Black border";
            // 
            // labelBlur
            // 
            this.labelBlur.AutoSize = true;
            this.labelBlur.Location = new System.Drawing.Point(247, 445);
            this.labelBlur.Name = "labelBlur";
            this.labelBlur.Size = new System.Drawing.Size(25, 13);
            this.labelBlur.TabIndex = 8;
            this.labelBlur.Text = "Blur";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(191, 496);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(81, 13);
            this.labelNumber.TabIndex = 8;
            this.labelNumber.Text = "Objects number";
            // 
            // numericUpDownWhite
            // 
            this.numericUpDownWhite.Location = new System.Drawing.Point(397, 361);
            this.numericUpDownWhite.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownWhite.Name = "numericUpDownWhite";
            this.numericUpDownWhite.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownWhite.TabIndex = 9;
            // 
            // numericUpDownBlack
            // 
            this.numericUpDownBlack.Location = new System.Drawing.Point(397, 404);
            this.numericUpDownBlack.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownBlack.Name = "numericUpDownBlack";
            this.numericUpDownBlack.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownBlack.TabIndex = 9;
            // 
            // numericUpDownBlur
            // 
            this.numericUpDownBlur.Location = new System.Drawing.Point(397, 443);
            this.numericUpDownBlur.Name = "numericUpDownBlur";
            this.numericUpDownBlur.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownBlur.TabIndex = 9;
            // 
            // numericUpDownNumber
            // 
            this.numericUpDownNumber.Location = new System.Drawing.Point(397, 494);
            this.numericUpDownNumber.Name = "numericUpDownNumber";
            this.numericUpDownNumber.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownNumber.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 723);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MastaClasta";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBoxRecognizeType.ResumeLayout(false);
            this.groupBoxRecognizeType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarClustersNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrayScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlured)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeveled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBinariezed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.PictureBox resultPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxGrayScale;
        private System.Windows.Forms.PictureBox pictureBoxBlured;
        private System.Windows.Forms.PictureBox pictureBoxLeveled;
        private System.Windows.Forms.PictureBox pictureBoxBinariezed;
        private System.Windows.Forms.TrackBar trackBarWhite;
        private System.Windows.Forms.TrackBar trackBarBlur;
        private System.Windows.Forms.TrackBar trackBarBlack;
        private System.Windows.Forms.Button buttonTry;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TrackBar trackBarClustersNumber;
        private System.Windows.Forms.Button buttonTeachNeural;
        private System.Windows.Forms.Button buttonRecognizeNeural;
        private System.Windows.Forms.GroupBox groupBoxRecognizeType;
        private System.Windows.Forms.RadioButton radioButtonNeural;
        private System.Windows.Forms.RadioButton radioButtonClasters;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Label labelBlur;
        private System.Windows.Forms.Label labelBlack;
        private System.Windows.Forms.Label labelWhite;
        private System.Windows.Forms.NumericUpDown numericUpDownNumber;
        private System.Windows.Forms.NumericUpDown numericUpDownBlur;
        private System.Windows.Forms.NumericUpDown numericUpDownBlack;
        private System.Windows.Forms.NumericUpDown numericUpDownWhite;

    }
}

