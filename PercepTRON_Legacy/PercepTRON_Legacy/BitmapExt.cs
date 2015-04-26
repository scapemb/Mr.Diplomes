using System.Drawing;

namespace HOPE
{
    public static class BitmapExt
    {
        public static int[][] ToJaggedInt(this Bitmap image)
        {
            int[][] matrix = new int[image.Width][];

            for (int widthOffset = 0; widthOffset < image.Width; widthOffset++)
            {
                matrix[widthOffset] = new int[image.Height];
                for (int heightOffset = 0; heightOffset < image.Height; heightOffset++)
                {
                    matrix[widthOffset][heightOffset] = image.GetPixel(widthOffset, heightOffset).Name == "ff000000" ? 1 : -1;
                }
            }

            return matrix;
        }

        public static int[,] ToInt2D(this Bitmap image)
        {
            int[,] matrix = new int[image.Width, image.Height];

            for (int widthOffset = 0; widthOffset < image.Width; widthOffset++)
            {
                for (int heightOffset = 0; heightOffset < image.Height; heightOffset++)
                {
                    matrix[widthOffset, heightOffset] = image.GetPixel(widthOffset, heightOffset).Name == "ff000000" ? 1 : -1;
                }
            }

            return matrix;
        }

        public static Bitmap AddColor(this Bitmap image, Color color)
        {
            for (int widthOffset = 0; widthOffset < image.Width; widthOffset++)
            {
                for (int heightOffset = 0; heightOffset < image.Height; heightOffset++)
                {
                    if (image.GetPixel(widthOffset, heightOffset).Name != "ff000000")
                    {
                        image.SetPixel(widthOffset, heightOffset, color);
                    }
                }
            }

            return image;
        }
    }
}
