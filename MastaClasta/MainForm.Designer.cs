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
            this.trackBarClustersNumber = new System.Windows.Forms.TrackBar();
            this.buttonStart = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBarClustersNumber)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(1110, 476);
            this.splitContainer1.SplitterDistance = 305;
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
            this.splitContainer2.Size = new System.Drawing.Size(1110, 305);
            this.splitContainer2.SplitterDistance = 530;
            this.splitContainer2.TabIndex = 0;
            // 
            // buttonTry
            // 
            this.buttonTry.Location = new System.Drawing.Point(452, 279);
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
            this.trackBarBlur.Location = new System.Drawing.Point(224, 257);
            this.trackBarBlur.Maximum = 21;
            this.trackBarBlur.Name = "trackBarBlur";
            this.trackBarBlur.Size = new System.Drawing.Size(90, 45);
            this.trackBarBlur.TabIndex = 1;
            this.trackBarBlur.Scroll += new System.EventHandler(this.trackBarBlur_Scroll);
            // 
            // trackBarBlack
            // 
            this.trackBarBlack.LargeChange = 10;
            this.trackBarBlack.Location = new System.Drawing.Point(115, 257);
            this.trackBarBlack.Maximum = 255;
            this.trackBarBlack.Name = "trackBarBlack";
            this.trackBarBlack.Size = new System.Drawing.Size(103, 45);
            this.trackBarBlack.TabIndex = 1;
            // 
            // trackBarWhite
            // 
            this.trackBarWhite.LargeChange = 10;
            this.trackBarWhite.Location = new System.Drawing.Point(0, 258);
            this.trackBarWhite.Maximum = 255;
            this.trackBarWhite.Name = "trackBarWhite";
            this.trackBarWhite.Size = new System.Drawing.Size(109, 45);
            this.trackBarWhite.TabIndex = 1;
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourcePictureBox.Location = new System.Drawing.Point(0, 0);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(530, 305);
            this.sourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPictureBox.Location = new System.Drawing.Point(0, 0);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(576, 305);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1110, 167);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxGrayScale
            // 
            this.pictureBoxGrayScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxGrayScale.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxGrayScale.Name = "pictureBoxGrayScale";
            this.pictureBoxGrayScale.Size = new System.Drawing.Size(271, 161);
            this.pictureBoxGrayScale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxGrayScale.TabIndex = 0;
            this.pictureBoxGrayScale.TabStop = false;
            // 
            // pictureBoxBlured
            // 
            this.pictureBoxBlured.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBlured.Location = new System.Drawing.Point(280, 3);
            this.pictureBoxBlured.Name = "pictureBoxBlured";
            this.pictureBoxBlured.Size = new System.Drawing.Size(271, 161);
            this.pictureBoxBlured.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBlured.TabIndex = 1;
            this.pictureBoxBlured.TabStop = false;
            // 
            // pictureBoxLeveled
            // 
            this.pictureBoxLeveled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLeveled.Location = new System.Drawing.Point(557, 3);
            this.pictureBoxLeveled.Name = "pictureBoxLeveled";
            this.pictureBoxLeveled.Size = new System.Drawing.Size(271, 161);
            this.pictureBoxLeveled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLeveled.TabIndex = 1;
            this.pictureBoxLeveled.TabStop = false;
            // 
            // pictureBoxBinariezed
            // 
            this.pictureBoxBinariezed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBinariezed.Location = new System.Drawing.Point(834, 3);
            this.pictureBoxBinariezed.Name = "pictureBoxBinariezed";
            this.pictureBoxBinariezed.Size = new System.Drawing.Size(273, 161);
            this.pictureBoxBinariezed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBinariezed.TabIndex = 1;
            this.pictureBoxBinariezed.TabStop = false;
            // 
            // trackBarClustersNumber
            // 
            this.trackBarClustersNumber.LargeChange = 1;
            this.trackBarClustersNumber.Location = new System.Drawing.Point(320, 257);
            this.trackBarClustersNumber.Name = "trackBarClustersNumber";
            this.trackBarClustersNumber.Size = new System.Drawing.Size(92, 45);
            this.trackBarClustersNumber.TabIndex = 3;
            // 
            // buttonStart
            // 
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.No;
            this.buttonStart.Location = new System.Drawing.Point(452, 250);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 500);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBarClustersNumber)).EndInit();
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

    }
}

