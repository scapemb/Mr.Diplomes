using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace HOPE
{
    public static class MatrixHelper
    {
        public static void SerializeBmp(string imagePath, string xmlPath)
        {
            ((Bitmap)Image.FromFile(imagePath)).ToJaggedInt().Serialize(xmlPath);
        }

        public static int[][] DeserializeMatrix(string xmlPath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(int[][]));

            using (var reader = new StreamReader(xmlPath))
            {
                return (int[][])xmlSerializer.Deserialize(reader);
            }
        }
    }
}
