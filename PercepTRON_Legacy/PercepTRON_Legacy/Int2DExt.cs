using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace HOPE
{
    public static class Int2DExt
    {
        public static void Serialize(this int[][] matrix, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(int[][]));

            using (var writer = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(writer, matrix);
            }
        }

        public static Bitmap ToBitmap(this int[][] matrix)
        {
            Bitmap image = new Bitmap(matrix.Count(), matrix.Select(x => x.Count()).Aggregate(0, (current, c) => (current > c) ? current : c), PixelFormat.Format24bppRgb);

            for (int widthOffset = 0; widthOffset < image.Width; widthOffset++)
            {
                for (int heightOffset = 0; heightOffset < image.Height; heightOffset++)
                {
                    image.SetPixel(widthOffset, heightOffset, matrix[widthOffset][heightOffset] == 1? Color.Black : Color.White);
                }
            }

            return image;
        }

        public static Bitmap ToBitmap(this int[,] matrix)
        {
            Bitmap image = new Bitmap(matrix.GetLength(0), matrix.GetLength(1), PixelFormat.Format24bppRgb);

            for (int widthOffset = 0; widthOffset < image.Width; widthOffset++)
            {
                for (int heightOffset = 0; heightOffset < image.Height; heightOffset++)
                {
                    image.SetPixel(widthOffset, heightOffset, matrix[widthOffset, heightOffset] == 1 ? Color.Black : Color.White);
                }
            }

            return image;
        }

        public static int[] ToIntArray(this int[][] matrix)
        {
            return matrix.SelectMany(i => i).ToArray();
        }
    }
}
