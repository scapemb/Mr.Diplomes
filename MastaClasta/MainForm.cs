using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MastaClasta
{
    public partial class MainForm : Form
    {
        private Logic _logic;
        public MainForm()
        {
            InitializeComponent();
            startToolStripMenuItem.Enabled = false;
            
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog { Title = Properties.Resources.MainForm_OpenFileDialogTitle, Filter = Properties.Resources.MainForm_OpenFileDialogFilter })
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                {
                    sourcePictureBox.Image = Image.FromStream(streamReader.BaseStream);
                }
                startToolStripMenuItem.Enabled = true;
            }
        }

        private void startToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (OptionsForm options = new OptionsForm())
            {
                if (options.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                _logic = new Logic
                {
                    BinaryBorder = options.BinaryBorder,
                    BlackBorder = options.BlackBorder,
                    WhiteBorder = options.WhiteBorder,
                    GaussianBlurRadius = options.GaussianBlurPower,
                    GaussianBlurWeight = options.GaussianBlurPower,
                    NumberOfClasters = options.NumberOfClasters,
                    ProcessBitmap = (Bitmap)sourcePictureBox.Image
                };

                _logic.Start();

                resultPictureBox.SafetySetImageFromFile(Resources.ResultImageName);
                pictureBoxGrayScale.SafetySetImageFromFile(Resources.GrayScaleImageName);
                pictureBoxBlured.SafetySetImageFromFile(Resources.BluredImageName);
                pictureBoxLeveled.SafetySetImageFromFile(Resources.LeveledImageName);
                pictureBoxBinariezed.SafetySetImageFromFile(Resources.BinarizedImageName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
