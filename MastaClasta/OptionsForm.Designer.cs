namespace MastaClasta
{
    partial class OptionsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWB = new System.Windows.Forms.TextBox();
            this.textBoxBLB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3BIB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4BP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5NOO = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "White border";
            // 
            // textBoxWB
            // 
            this.textBoxWB.Location = new System.Drawing.Point(64, 27);
            this.textBoxWB.Name = "textBoxWB";
            this.textBoxWB.Size = new System.Drawing.Size(100, 20);
            this.textBoxWB.TabIndex = 1;
            // 
            // textBoxBLB
            // 
            this.textBoxBLB.Location = new System.Drawing.Point(64, 67);
            this.textBoxBLB.Name = "textBoxBLB";
            this.textBoxBLB.Size = new System.Drawing.Size(100, 20);
            this.textBoxBLB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Black border";
            // 
            // textBox3BIB
            // 
            this.textBox3BIB.Location = new System.Drawing.Point(64, 107);
            this.textBox3BIB.Name = "textBox3BIB";
            this.textBox3BIB.Size = new System.Drawing.Size(100, 20);
            this.textBox3BIB.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Binarization border";
            // 
            // textBox4BP
            // 
            this.textBox4BP.Location = new System.Drawing.Point(64, 147);
            this.textBox4BP.Name = "textBox4BP";
            this.textBox4BP.Size = new System.Drawing.Size(100, 20);
            this.textBox4BP.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Blur power";
            // 
            // textBox5NOO
            // 
            this.textBox5NOO.Location = new System.Drawing.Point(64, 187);
            this.textBox5NOO.Name = "textBox5NOO";
            this.textBox5NOO.Size = new System.Drawing.Size(100, 20);
            this.textBox5NOO.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Number of objects";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(127, 226);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(24, 226);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 261);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBox5NOO);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4BP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3BIB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxBLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxWB);
            this.Controls.Add(this.label1);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWB;
        private System.Windows.Forms.TextBox textBoxBLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3BIB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4BP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5NOO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
    }
}