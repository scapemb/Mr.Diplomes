using System;
using System.Windows.Forms;

namespace MastaClasta
{
    public partial class OptionsForm : Form
    {
        public Int32 BlackBorder { set; get; }
        public Int32 WhiteBorder { set; get; }
        public Int32 NumberOfClasters { set; get; }

        public Int32 GaussianBlurPower { set; get; }
        public Int32 BinaryBorder { set; get; }
        public OptionsForm()
        {
            InitializeComponent();

            textBoxBLB.Text = Resources.OptionsForm_Default_BlackBorder;
            textBoxWB.Text = Resources.OptionsForm_Default_WhiteBorder;
            textBox3BIB.Text = Resources.OptionsForm_Default_BinarizationBorder;
            textBox4BP.Text = Resources.OptionsForm_Default_BlurPower;
            textBox5NOO.Text = Resources.OptionsForm_Default_Number_Of_Objects;


        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                BlackBorder = Convert.ToInt32(textBoxBLB.Text);
                if (BlackBorder < 0 || BlackBorder > 255)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                textBoxBLB.Clear();
                return;
                
            }

            try
            {
                WhiteBorder = Convert.ToInt32(textBoxWB.Text);
                if (WhiteBorder < 0 || WhiteBorder > 255)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                textBoxWB.Clear();
                return;
            }

            try
            {
                BinaryBorder = Convert.ToInt32(textBox3BIB.Text);
                if (BinaryBorder < 0 || BinaryBorder > 255)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                textBox3BIB.Clear();
                return;
            }

            try
            {
                GaussianBlurPower = Convert.ToInt32(textBox4BP.Text);

                if (GaussianBlurPower < 3 && GaussianBlurPower != 0)
                {
                    GaussianBlurPower = 3;
                }
                if (GaussianBlurPower % 2 != 1 && GaussianBlurPower != 0)
                {
                    GaussianBlurPower++;
                }

            }
            catch (Exception)
            {
                textBox4BP.Clear();
                return;
            }

            try
            {
                NumberOfClasters = Convert.ToInt32(textBox5NOO.Text);
                if (NumberOfClasters < 1)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                textBox5NOO.Clear();
                return;

            }

            DialogResult = DialogResult.OK;
        }
    }
}
