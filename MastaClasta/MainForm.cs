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


        private void buttonTry_Click(object sender, EventArgs e)
        {

            _logic = new Logic
            {
                BinaryBorder = 10,
                BlackBorder = trackBarBlack.Value,
                WhiteBorder = trackBarWhite.Value,
                GaussianBlurRadius = trackBarBlur.Value,
                GaussianBlurWeight = trackBarBlur.Value,
                ProcessBitmap = (Bitmap)sourcePictureBox.Image
            };


            if (null == _logic.ProcessBitmap)
            {
                MessageBox.Show("Please choose image to process",
                  "Error");
                return;
            }

            _logic.Try();

            resultPictureBox.SafetySetImageFromFile(Resources.ResultImageName);
            pictureBoxGrayScale.SafetySetImageFromFile(Resources.GrayScaleImageName);
            pictureBoxBlured.SafetySetImageFromFile(Resources.BluredImageName);
            pictureBoxLeveled.SafetySetImageFromFile(Resources.LeveledImageName);
            pictureBoxBinariezed.SafetySetImageFromFile(Resources.BinarizedImageName);

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            _logic = new Logic
            {
                BinaryBorder = 10,
                BlackBorder = trackBarBlack.Value,
                WhiteBorder = trackBarWhite.Value,
                GaussianBlurRadius = 3,
                GaussianBlurWeight = 3,
                NumberOfClasters = trackBarClustersNumber.Value,
                ProcessBitmap = (Bitmap)sourcePictureBox.Image
            };

            if (null == _logic.ProcessBitmap)
            {
                MessageBox.Show("Please choose image to process",
                  "Error");
                return;
            }

            _logic.Start();

            resultPictureBox.SafetySetImageFromFile(Resources.ResultImageName);
            pictureBoxGrayScale.SafetySetImageFromFile(Resources.GrayScaleImageName);
            pictureBoxBlured.SafetySetImageFromFile(Resources.BluredImageName);
            pictureBoxLeveled.SafetySetImageFromFile(Resources.LeveledImageName);
            pictureBoxBinariezed.SafetySetImageFromFile(Resources.BinarizedImageName);
        }

        private void teachNeural_Click(object sender, EventArgs e)
        {
            _logic = new Logic
            {
                BinaryBorder = 10,
                BlackBorder = trackBarBlack.Value,
                WhiteBorder = trackBarWhite.Value,
                GaussianBlurRadius = trackBarBlur.Value,
                GaussianBlurWeight = trackBarBlur.Value,
                NumberOfClasters = trackBarClustersNumber.Value,
                ProcessBitmap = (Bitmap)sourcePictureBox.Image
            };

            _logic.NeuralTeach();
        }

        private void recognizeNeuron_Click(object sender, EventArgs e)
        {
            _logic.ProcessBitmap = (Bitmap)sourcePictureBox.Image;

            _logic.NeuralRecognize();

            resultPictureBox.SafetySetImageFromFile(Resources.ResultImageName);
            pictureBoxGrayScale.SafetySetImageFromFile(Resources.GrayScaleImageName);
            pictureBoxBlured.SafetySetImageFromFile(Resources.BluredImageName);
            pictureBoxLeveled.SafetySetImageFromFile(Resources.LeveledImageName);
            pictureBoxBinariezed.SafetySetImageFromFile(Resources.BinarizedImageName);
        }


        private void trackBarWhite_Scroll(object sender, EventArgs e)
        {
            numericUpDownWhite.Value = trackBarWhite.Value;
        }

        private void trackBarBlack_Scroll(object sender, EventArgs e)
        {
            numericUpDownBlack.Value = trackBarBlack.Value;
        }

        private void trackBarBlur_Scroll(object sender, EventArgs e)
        {
            numericUpDownBlur.Value = trackBarBlur.Value;
        }

        private void trackBarClustersNumber_Scroll(object sender, EventArgs e)
        {
            numericUpDownNumber.Value = trackBarClustersNumber.Value;
        }

        private void radioButtonClasters_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonClasters.Checked)
            {
                buttonStart.Visible = true;
                buttonTeachNeural.Visible = false;
                buttonRecognizeNeural.Visible = false;
            }
        }

        private void radioButtonNeural_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNeural.Checked)
            {
                buttonStart.Visible = false;
                buttonTeachNeural.Visible = true;
                buttonRecognizeNeural.Visible = true;
            }
        }

    }
}
