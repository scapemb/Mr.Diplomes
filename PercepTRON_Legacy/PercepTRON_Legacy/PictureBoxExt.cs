using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HOPE
{
    public static class PictureBoxExt
    {
        public static void SafetySetImageFromFile(this PictureBox pictureBox, string fileName)
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                pictureBox.Image = Image.FromStream(streamReader.BaseStream);
            }
        }
    }
}
