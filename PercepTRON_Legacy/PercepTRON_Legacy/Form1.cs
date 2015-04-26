using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HOPE;
using lab3;

namespace PercepTRON_Legacy
{
    public partial class Form1 : Form
    {
        private static Perceptron _perceptron;
        private static MultilayerPerceptron _multilayerPerceptron;

        private Dictionary<int, PictureBox> dictionary;


        public Form1()
        {
            InitializeComponent();

            pictureBoxA1.SafetySetImageFromFile("p1.bmp");
            pictureBoxA2.SafetySetImageFromFile("p2.bmp");
            pictureBoxA3.SafetySetImageFromFile("p3.bmp");
            pictureBoxB1.SafetySetImageFromFile("m1.bmp");
            pictureBoxB2.SafetySetImageFromFile("m2.bmp");
            pictureBoxB3.SafetySetImageFromFile("m3.bmp");
            pictureBoxC1.SafetySetImageFromFile("i1.bmp");
            pictureBoxC2.SafetySetImageFromFile("i2.bmp");
            pictureBoxC3.SafetySetImageFromFile("i3.bmp");


            //Dictionary<char, List<int[]>> lol = ;

            _multilayerPerceptron = new MultilayerPerceptron(new Dictionary<char, List<int[]>>
            {
                {
                    'p', new List<int[]>
                    {
                        (Image.FromFile("p1.bmp") as Bitmap).ToJaggedInt().ToIntArray(),
                        (Image.FromFile("p2.bmp") as Bitmap).ToJaggedInt().ToIntArray(),
                        (Image.FromFile("p3.bmp") as Bitmap).ToJaggedInt().ToIntArray()
                    }
                },
                {
                    'm', new List<int[]>
                    {
                        (Image.FromFile("m1.bmp") as Bitmap).ToJaggedInt().ToIntArray(),
                        (Image.FromFile("m2.bmp") as Bitmap).ToJaggedInt().ToIntArray(),
                        (Image.FromFile("m3.bmp") as Bitmap).ToJaggedInt().ToIntArray()
                    }
                },
                {
                    'i', new List<int[]>
                    {
                        (Image.FromFile("i1.bmp") as Bitmap).ToJaggedInt().ToIntArray(),
                        (Image.FromFile("i2.bmp") as Bitmap).ToJaggedInt().ToIntArray(),
                        (Image.FromFile("i3.bmp") as Bitmap).ToJaggedInt().ToIntArray()
                    }
                }
            }, 1.0, 0.8, 0.01);
            _perceptron = new Perceptron(
                new List<int[,]>
                {
                    (Image.FromFile("p1.bmp") as Bitmap).ToInt2D(),
                    (Image.FromFile("p2.bmp") as Bitmap).ToInt2D(),
                    (Image.FromFile("p3.bmp") as Bitmap).ToInt2D(),
                    (Image.FromFile("m1.bmp") as Bitmap).ToInt2D(),
                    (Image.FromFile("m2.bmp") as Bitmap).ToInt2D(),
                    (Image.FromFile("m3.bmp") as Bitmap).ToInt2D(),
                    (Image.FromFile("i1.bmp") as Bitmap).ToInt2D(),
                    (Image.FromFile("i2.bmp") as Bitmap).ToInt2D(),
                    (Image.FromFile("i3.bmp") as Bitmap).ToInt2D()
                },
                25,
                0.1,
                0.1,
                10000,
                0.01
                );

            _perceptron.Teach();

            

            //labelSteps.Text += _perceptron.Steps.ToString(CultureInfo.InvariantCulture);
            labelSteps.Text += _multilayerPerceptron.iterationCount.ToString(CultureInfo.InvariantCulture);

            dictionary = new Dictionary<int, PictureBox>
            {
                {0, pictureBoxA1},
                {1, pictureBoxA2},
                {2, pictureBoxA3},
                {3, pictureBoxB1},
                {4, pictureBoxB2},
                {5, pictureBoxB3},
                {6, pictureBoxC1},
                {7, pictureBoxC2},
                {8, pictureBoxC3}
            };
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog
            {
                Filter = @"bmp files (*.bmp)|*.bmp",
                RestoreDirectory = true
            })
            {
                if (fileDialog.ShowDialog() != DialogResult.OK)
                    return;
                try
                {
                    pictureBoxBrowse.SafetySetImageFromFile(fileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            pictureBoxResult.Image =
                (pictureBoxBrowse.Image as Bitmap).ToJaggedInt()
                    .ToIntArray()
                    .AddNoise(trackBar1.Value)
                    .ToInt2D()
                    .ToBitmap();

            var results = _perceptron.Recognize((pictureBoxResult.Image as Bitmap).ToInt2D());
            double[] maxResults = new double[results.Length];
            Array.Copy(results, maxResults, results.Length);
            Array.Sort(maxResults);

            var maxPositions = maxResults.Skip(results.Length - 3).Select(result => Array.IndexOf(results, result)).ToArray();
            foreach (var pictureBox in dictionary.Values)
            {
                pictureBox.Image = (pictureBox.Image as Bitmap).AddColor(Color.White);
            }


            dictionary[maxPositions[0]].Image = (dictionary[maxPositions[0]].Image as Bitmap).AddColor(Color.Red);
            dictionary[maxPositions[1]].Image = (dictionary[maxPositions[1]].Image as Bitmap).AddColor(Color.Yellow);
            dictionary[maxPositions[2]].Image = (dictionary[maxPositions[2]].Image as Bitmap).AddColor(Color.Green);

            listBox1.Items.Clear();

            foreach (var result in results)
            {
                listBox1.Items.Add(result.ToString("F2"));
            }
        }
    }
}
