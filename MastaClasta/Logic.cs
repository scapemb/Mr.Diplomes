using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PercepTRON_Legacy;

namespace MastaClasta
{
    internal class Logic
    {
        public Bitmap ProcessBitmap { set; get; }

        public Int32 BlackBorder { set; get; }
        public Int32 WhiteBorder { set; get; }
        public Int32 NumberOfClasters { set; get; }
        public Int32 GaussianBlurRadius { set; get; }
        public Int32 GaussianBlurWeight { set; get; }
        public Int32 BinaryBorder { set; get; }

        public PercepTRON_Legacy.Perceptron mPerceptron;

        private Byte[] GetRgbValuesFromBmp(Bitmap bitmap)
        {
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(new Point(0, 0), bitmap.Size), ImageLockMode.ReadOnly,
                bitmap.PixelFormat);

            var rgbValues = new Byte[bitmapData.Stride*bitmap.Height];

            Marshal.Copy(bitmapData.Scan0, rgbValues, 0, rgbValues.Length);
            bitmap.UnlockBits(bitmapData);

            return rgbValues;
        }

        private void SetRgbValuesToBmp(ref Bitmap bitmap, Byte[] rgbValues)
        {
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(new Point(0, 0), bitmap.Size), ImageLockMode.WriteOnly,
                bitmap.PixelFormat);

            Marshal.Copy(rgbValues, 0, bitmapData.Scan0, rgbValues.Length);

            bitmap.UnlockBits(bitmapData);
        }

        private Byte[] ConvertRgbToGrayScale(Byte[] rgbValues)
        {
            var grayScaleValues = new Byte[rgbValues.Length/3];

            for (Int32 i = 0; i < rgbValues.Length - 2; i += 3)
            {
                grayScaleValues[i/3] = Convert.ToByte(Constants.BlueColorIntensity*rgbValues[i] +
                                                      Constants.GreenColorIntensity*rgbValues[i + 1] +
                                                      Constants.RedColorIntensity*rgbValues[i + 2]);
            }

            return grayScaleValues;
        }

        private Byte[] ConvertGrayScaleToRgb(Byte[] grayScaleValues)
        {
            var rgbValues = new Byte[grayScaleValues.Length*3];

            for (Int32 i = 0; i < rgbValues.Length - 2; i += 3)
            {
                rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = grayScaleValues[i/3];
            }

            return rgbValues;
        }

        private Byte[] ConvertGrayScaleToRgbWithColors(Byte[] grayScaleValues)
        {
            var rgbValues = new Byte[grayScaleValues.Length * 3];

            for (Int32 i = 0; i < rgbValues.Length - 2; i += 3)
            {
                var byteOffset = grayScaleValues[i/3];
                rgbValues[i] = byteOffset;
                rgbValues[i + 1] = rgbValues[i + 2] = byteOffset == Byte.MinValue ? Byte.MinValue : (Byte)(Byte.MaxValue - byteOffset);
            }

            return rgbValues;
        }

        public void Try()
        {
            Int32 width = ProcessBitmap.Width;
            Int32 height = ProcessBitmap.Height;
            PixelFormat pixelFormat = ProcessBitmap.PixelFormat;

            if (pixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show(Properties.Resources.Logic_Start_Error,
                    String.Format("Your image has {0}. It must be {1}", pixelFormat, PixelFormat.Format24bppRgb));
                return;
            }

            var grayScaleBitmap = new Bitmap(width, height, pixelFormat);
            var colorMap = GetRgbValuesFromBmp(ProcessBitmap);
            var grayScaleData = ConvertRgbToGrayScale(GetRgbValuesFromBmp(ProcessBitmap));

            SetRgbValuesToBmp(ref grayScaleBitmap,
                ConvertGrayScaleToRgb(grayScaleData));
            grayScaleBitmap.Save(Resources.GrayScaleImageName);

            Bitmap bluredBitmap = new Bitmap(width, height, pixelFormat);
            if (GaussianBlurRadius > 0)
            {
                SetRgbValuesToBmp(ref bluredBitmap,
                    ConvertGrayScaleToRgb(ConvolutionFilter(grayScaleData, height, width,
                        MatrixCalculator.Calculate(GaussianBlurRadius, GaussianBlurWeight))));
            }
            else
            {
                bluredBitmap = grayScaleBitmap;
            }

            bluredBitmap.Save(Resources.BluredImageName);


            SetRgbValuesToBmp(ref bluredBitmap,
                ConvertGrayScaleToRgb(CorrectBrightnessRange(
                    ConvertRgbToGrayScale(GetRgbValuesFromBmp(bluredBitmap)), BlackBorder, WhiteBorder)));
            bluredBitmap.Save(Resources.LeveledImageName);

            byte[] binaryData = Binarization(ConvertRgbToGrayScale(GetRgbValuesFromBmp(bluredBitmap)), BinaryBorder);

            var binaryImage = new Bitmap(width, height, pixelFormat);
            SetRgbValuesToBmp(ref binaryImage, ConvertGrayScaleToRgb(binaryData));
            binaryImage.Save(Resources.BinarizedImageName);
        }

        public void Start()
        {
            Int32 width = ProcessBitmap.Width;
            Int32 height = ProcessBitmap.Height;
            PixelFormat pixelFormat = ProcessBitmap.PixelFormat;

            if (pixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show(Properties.Resources.Logic_Start_Error,
                    String.Format("Your image has {0}. It must be {1}", pixelFormat, PixelFormat.Format24bppRgb));
                return;
            }

            var grayScaleBitmap = new Bitmap(width, height, pixelFormat);
            var colorMap = GetRgbValuesFromBmp(ProcessBitmap);
            var grayScaleData = ConvertRgbToGrayScale(GetRgbValuesFromBmp(ProcessBitmap));

            SetRgbValuesToBmp(ref grayScaleBitmap,
                ConvertGrayScaleToRgb(grayScaleData));
            grayScaleBitmap.Save(Resources.GrayScaleImageName);

            Bitmap bluredBitmap = new Bitmap(width, height, pixelFormat);
            if (GaussianBlurRadius > 0)
            {
                SetRgbValuesToBmp(ref bluredBitmap,
                    ConvertGrayScaleToRgb(ConvolutionFilter(grayScaleData, height, width,
                        MatrixCalculator.Calculate(GaussianBlurRadius, GaussianBlurWeight))));
            }
            else
            {
                bluredBitmap = grayScaleBitmap;
            }

            bluredBitmap.Save(Resources.BluredImageName);


            SetRgbValuesToBmp(ref bluredBitmap,
                ConvertGrayScaleToRgb(CorrectBrightnessRange(
                    ConvertRgbToGrayScale(GetRgbValuesFromBmp(bluredBitmap)), BlackBorder, WhiteBorder)));
            bluredBitmap.Save(Resources.LeveledImageName);

            byte[] binaryData = Binarization(ConvertRgbToGrayScale(GetRgbValuesFromBmp(bluredBitmap)), BinaryBorder);

            var binaryImage = new Bitmap(width, height, pixelFormat);
            SetRgbValuesToBmp(ref binaryImage, ConvertGrayScaleToRgb(binaryData));
            binaryImage.Save(Resources.BinarizedImageName);

            byte[] regions = IterativeScan(binaryData, width, height);

            IEnumerable<ImageClaster> fullObjects = CalculateMetricsForObjects(regions, colorMap, width, height);


            var objects = new List<LightImageClaster>();
            objects.AddRange(fullObjects.Select(im => im.ToLightImageClaster()));
            DeleteBadClasters(ref objects);
            Normalization(ref objects);

            var changeObjectClassTable = new Hashtable();
            var colorObjectClassTable = new Hashtable();

            Random random = new Random();

            GetObjectClassTable(objects, changeObjectClassTable, colorObjectClassTable, random);

            var resultBitmap = new Bitmap(width, height, pixelFormat);

            SetRgbValuesToBmp(ref resultBitmap,
                ConvertGrayScaleToRgbWithColors(ColorObjects(regions, changeObjectClassTable, width * height), changeObjectClassTable, colorObjectClassTable));
            resultBitmap.Save(Resources.ResultImageName);
        }

        public void NeuralTeach()
        {
            Int32 width = ProcessBitmap.Width;
            Int32 height = ProcessBitmap.Height;
            PixelFormat pixelFormat = ProcessBitmap.PixelFormat;

            if (pixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show(Properties.Resources.Logic_Start_Error,
                    String.Format("Your image has {0}. It must be {1}", pixelFormat, PixelFormat.Format24bppRgb));
                return;
            }

            var grayScaleBitmap = new Bitmap(width, height, pixelFormat);
            var colorMap = GetRgbValuesFromBmp(ProcessBitmap);
            var grayScaleData = ConvertRgbToGrayScale(GetRgbValuesFromBmp(ProcessBitmap));

            SetRgbValuesToBmp(ref grayScaleBitmap,
                ConvertGrayScaleToRgb(grayScaleData));
            grayScaleBitmap.Save(Resources.GrayScaleImageName);

            Bitmap bluredBitmap = new Bitmap(width, height, pixelFormat);
            if (GaussianBlurRadius > 0)
            {
                SetRgbValuesToBmp(ref bluredBitmap,
                    ConvertGrayScaleToRgb(ConvolutionFilter(grayScaleData, height, width,
                        MatrixCalculator.Calculate(GaussianBlurRadius, GaussianBlurWeight))));
            }
            else
            {
                bluredBitmap = grayScaleBitmap;
            }

            bluredBitmap.Save(Resources.BluredImageName);


            SetRgbValuesToBmp(ref bluredBitmap,
                ConvertGrayScaleToRgb(CorrectBrightnessRange(
                    ConvertRgbToGrayScale(GetRgbValuesFromBmp(bluredBitmap)), BlackBorder, WhiteBorder)));
            bluredBitmap.Save(Resources.LeveledImageName);

            byte[] binaryData = Binarization(ConvertRgbToGrayScale(GetRgbValuesFromBmp(bluredBitmap)), BinaryBorder);

            var binaryImage = new Bitmap(width, height, pixelFormat);
            SetRgbValuesToBmp(ref binaryImage, ConvertGrayScaleToRgb(binaryData));
            binaryImage.Save(Resources.BinarizedImageName);

            byte[] regions = IterativeScan(binaryData, width, height);

            IEnumerable<ImageClaster> fullObjects = CalculateMetricsForObjects(regions, colorMap, width, height);


            var objects = new List<LightImageClaster>();
            objects.AddRange(fullObjects.Select(im => im.ToLightImageClaster()));
            DeleteBadClasters(ref objects);
            Normalization(ref objects);


            List<int[]> NeuronsForTeach = new List<int[]>();

            foreach (LightImageClaster claster in objects )
            {
                NeuronsForTeach.Add(ObjectToNeurons(claster));
            }

            mPerceptron = new PercepTRON_Legacy.Perceptron(
                NeuronsForTeach,
                NumberOfClasters,
                0.1,
                0.1,
                500000,
                0.001
                );

            mPerceptron.Teach();

            MessageBox.Show("Teaching complete");

        }

        private int[] ObjectToNeurons(LightImageClaster claster)
        {
            List<int> neurons = new List<int>();

            neurons.AddRange( IntToNeuronsArray(Convert.ToInt32( claster.Perimeter * 100) ) );
            neurons.AddRange(IntToNeuronsArray(Convert.ToInt32(claster.Square * 100)));
            neurons.AddRange(IntToNeuronsArray(Convert.ToInt32(claster.Elongation * 100)));
            neurons.AddRange(IntToNeuronsArray(Convert.ToInt32(claster.Compactness * 100)));

            neurons.AddRange(IntToNeuronsArray(Convert.ToInt32(claster.ColorMap[0] * 100)));
            neurons.AddRange(IntToNeuronsArray(Convert.ToInt32(claster.ColorMap[1] * 100)));
            neurons.AddRange(IntToNeuronsArray(Convert.ToInt32(claster.ColorMap[2] * 100)));

            return neurons.ToArray();
        }

        private int[] IntToNeuronsArray(int value)
        {
            BitArray b = new BitArray(new int[] { value });
            bool[] bits = new bool[b.Count];
            b.CopyTo(bits, 0);
            return  bits.Select(bit => (int)(bit ? 1 : -1)).ToArray();
        }

        public void NeuralRecognize()
        {
            Int32 width = ProcessBitmap.Width;
            Int32 height = ProcessBitmap.Height;
            PixelFormat pixelFormat = ProcessBitmap.PixelFormat;

            if (pixelFormat != PixelFormat.Format24bppRgb)
            {
                MessageBox.Show(Properties.Resources.Logic_Start_Error,
                    String.Format("Your image has {0}. It must be {1}", pixelFormat, PixelFormat.Format24bppRgb));
                return;
            }

            var grayScaleBitmap = new Bitmap(width, height, pixelFormat);
            var colorMap = GetRgbValuesFromBmp(ProcessBitmap);
            var grayScaleData = ConvertRgbToGrayScale(GetRgbValuesFromBmp(ProcessBitmap));

            SetRgbValuesToBmp(ref grayScaleBitmap,
                ConvertGrayScaleToRgb(grayScaleData));
            grayScaleBitmap.Save(Resources.GrayScaleImageName);

            Bitmap bluredBitmap = new Bitmap(width, height, pixelFormat);
            if (GaussianBlurRadius > 0)
            {
                SetRgbValuesToBmp(ref bluredBitmap,
                    ConvertGrayScaleToRgb(ConvolutionFilter(grayScaleData, height, width,
                        MatrixCalculator.Calculate(GaussianBlurRadius, GaussianBlurWeight))));
            }
            else
            {
                bluredBitmap = grayScaleBitmap;
            }

            bluredBitmap.Save(Resources.BluredImageName);


            SetRgbValuesToBmp(ref bluredBitmap,
                ConvertGrayScaleToRgb(CorrectBrightnessRange(
                    ConvertRgbToGrayScale(GetRgbValuesFromBmp(bluredBitmap)), BlackBorder, WhiteBorder)));
            bluredBitmap.Save(Resources.LeveledImageName);

            byte[] binaryData = Binarization(ConvertRgbToGrayScale(GetRgbValuesFromBmp(bluredBitmap)), BinaryBorder);

            var binaryImage = new Bitmap(width, height, pixelFormat);
            SetRgbValuesToBmp(ref binaryImage, ConvertGrayScaleToRgb(binaryData));
            binaryImage.Save(Resources.BinarizedImageName);

            byte[] regions = IterativeScan(binaryData, width, height);

            IEnumerable<ImageClaster> fullObjects = CalculateMetricsForObjects(regions, colorMap, width, height);


            var objects = new List<LightImageClaster>();
            objects.AddRange(fullObjects.Select(im => im.ToLightImageClaster()));
            DeleteBadClasters(ref objects);
            Normalization(ref objects);


            List<ObjectForRecognize> NeuronsForRecognize = new List<ObjectForRecognize>();

            foreach (LightImageClaster claster in objects)
            {
                NeuronsForRecognize.Add(new ObjectForRecognize( ObjectToNeurons(claster), claster.BasicImageClass ));
            }

            var recognized = new List<double[]>();

            foreach (ObjectForRecognize objectToRecognize in NeuronsForRecognize)
            {
                var mad = objectToRecognize.Neurons;
                double[] lol = new double[NumberOfClasters];
                mPerceptron.Recognize(mad).CopyTo(lol, 0);
                objectToRecognize.Result = lol;
                recognized.Add(lol);
            }

            var changeObjectClassTable = new Hashtable();
            var colorObjectClassTable = new Hashtable();

            Random random = new Random();

            foreach (ObjectForRecognize objectToRecognize in NeuronsForRecognize)
            {
                double maxValue = objectToRecognize.Result.Max();
                int maxIndex = objectToRecognize.Result.ToList().IndexOf(maxValue);

                objectToRecognize.ResultNumber = maxIndex + 1;
            }


            GetObjectClassTable(NeuronsForRecognize, changeObjectClassTable, colorObjectClassTable, random);

            var resultBitmap = new Bitmap(width, height, pixelFormat);

            SetRgbValuesToBmp(ref resultBitmap,
                ConvertGrayScaleToRgbWithColors(ColorObjects(regions, changeObjectClassTable, width * height), changeObjectClassTable, colorObjectClassTable));
            resultBitmap.Save(Resources.ResultImageName);

        }

        public class ObjectForRecognize
        {
            public int[] Neurons { get; set; }

            public double[] Result { get; set; }

            public int ObjectNumber { get; set; }

            public int ResultNumber { get; set; }

            public ObjectForRecognize(int[] neurons, int number) {
                Neurons = neurons;
                ObjectNumber = number;
            }
        }

        private void GetObjectClassTable(List<ObjectForRecognize> results, Hashtable changeObjectClassTable, Hashtable colorObjectClassTable, Random random)
        {
            foreach (ObjectForRecognize result in results)
            {
                changeObjectClassTable.Add(result.ObjectNumber, result.ResultNumber);

                    if (!colorObjectClassTable.ContainsKey(result.ResultNumber))
                    {
                        var randomColorMap = new double[3];
                        randomColorMap[0] = GetRandomNumber(0, 255, random);
                        randomColorMap[1] = GetRandomNumber(0, 255, random);
                        randomColorMap[2] = GetRandomNumber(0, 255, random);
                        colorObjectClassTable.Add(result.ResultNumber, randomColorMap);
                    }
                
            }
        }

        private void GetObjectClassTable(List<LightImageClaster> objects, Hashtable changeObjectClassTable, Hashtable colorObjectClassTable, Random random)
        {
            foreach (LightImageClaster lightImageClaster in ClasterObjects(objects, CalculateGoodCenters(objects, Constants.Attributes.Square)))
            {
                changeObjectClassTable.Add(lightImageClaster.BasicImageClass, lightImageClaster.ResultImageClass);

                foreach (int ResultImageClass in changeObjectClassTable.Values)
                {
                    if (!colorObjectClassTable.ContainsKey(ResultImageClass))
                    {
                        var randomColorMap = new double[3];
                        randomColorMap[0] = lightImageClaster.ColorMap[0] * GetRandomNumber(50, 150, random);
                        randomColorMap[1] = lightImageClaster.ColorMap[1] * GetRandomNumber(50, 150, random);
                        randomColorMap[2] = lightImageClaster.ColorMap[2] * GetRandomNumber(50, 150, random);
                        colorObjectClassTable.Add(ResultImageClass, randomColorMap);
                    }
                }

            }
        }

        public double GetRandomNumber(double minimum, double maximum, Random random)
        {
            
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private void DeleteBadClasters(ref List<LightImageClaster> objects)
        {
            objects.RemoveAll(t => t.IsBadClaster());
        }

        private Byte[] ConvertGrayScaleToRgbWithColors(Byte[] imageData, Hashtable changeObjectClassTable, Hashtable colorObjectClassTable)
        {
            var rgbValues = new Byte[imageData.Length * 3];

            for (Int32 i = 0; i < rgbValues.Length - 2; i += 3)
            {
                var byteOffset = imageData[i / 3];
                if (byteOffset == 0)
                {
                    continue;
                }

                SetRgbData(changeObjectClassTable, colorObjectClassTable, rgbValues, i, byteOffset);

            }

            return rgbValues;
        }

        private static void SetRgbData(Hashtable changeObjectClassTable, Hashtable colorObjectClassTable, byte[] rgbValues, Int32 i, byte byteOffset)
        {
            if (changeObjectClassTable.ContainsKey((Int32)byteOffset))
            {
                rgbValues[i] = Convert.ToByte(((double[])colorObjectClassTable[(Int32)byteOffset])[0]);
                rgbValues[i + 1] = Convert.ToByte(((double[])colorObjectClassTable[(Int32)byteOffset])[1]);
                rgbValues[i + 2] = Convert.ToByte(((double[])colorObjectClassTable[(Int32)byteOffset])[2]);
            }
        }

        private Byte[] ColorObjects(Byte[] imageData, Hashtable changeObjectClassTable, Int32 size)
        {
            for (Int32 i = 0; i < size; i++)
            {
                Byte offsetByte = imageData[i];
                if (offsetByte == 0)
                {
                    continue;
                }
                if (changeObjectClassTable.ContainsKey((Int32)offsetByte))
                {
                    imageData[i] = Convert.ToByte((Int32)changeObjectClassTable[(Int32)offsetByte]);
                }
            }

            return imageData;
        }

        private Byte[] ConvolutionFilter(Byte[] sourceData,int height, int width, Double[,] filterMatrix, Double factor = 1)
        {

            var resultBuffer = new Byte[width * height];


            Int32 filterWidth = filterMatrix.GetLength(0);

            Int32 filterOffset = (filterWidth - 1)/2;

            for (Int32 offsetY = 0; offsetY < height; offsetY++)
            {
                for (Int32 offsetX = 0; offsetX < width; offsetX++)
                {
                    Double color = 0;


                    Int32 byteOffset = offsetY * width + offsetX;
                    Int32 minX, maxX, minY, maxY;

                    if (offsetX < filterOffset)
                    {
                        minX = -offsetX;
                        maxX = filterOffset;

                        if (offsetY < filterOffset)
                        {
                            minY = -offsetY;
                            maxY = filterOffset;

                        }
                        else if (offsetY >= filterOffset && offsetY < height - filterOffset)
                        {
                            minY = -filterOffset;
                            maxY = filterOffset;
                        }
                        else
                        {
                            minY = -filterOffset;
                            maxY = height - offsetY - 1;
                        }
                    }
                    else if (offsetX >= filterOffset && offsetX < width - filterOffset)
                    {
                        minX = -filterOffset;
                        maxX = filterOffset;

                        if (offsetY < filterOffset)
                        {
                            minY = -offsetY;
                            maxY = filterOffset;
                        }
                        else if (offsetY >= filterOffset && offsetY < height - filterOffset)
                        {
                            minY = -filterOffset;
                            maxY = filterOffset;
                        }
                        else
                        {
                            minY = -filterOffset;
                            maxY = height - offsetY -1;
                        }
                    }
                    else
                    {
                        minX = -filterOffset;
                        maxX = width - offsetX - 1;

                        if (offsetY < filterOffset)
                        {
                            minY = -offsetY;
                            maxY = filterOffset;
                        }
                        else if (offsetY >= filterOffset && offsetY < height - filterOffset)
                        {
                            minY = -filterOffset;
                            maxY = filterOffset;
                        }
                        else
                        {
                            minY = -filterOffset;
                            maxY = height - offsetY - 1;
                        }
                    }

                    Double magicMul = Math.Pow(2*filterOffset, 2)/((maxY - minY)*(maxX - minX));

                    for (Int32 filterY = minY; filterY <= maxY; filterY++)
                    {
                        for (Int32 filterX = minX; filterX <= maxX; filterX++)
                        {

                            Int32 calcOffset = byteOffset + (filterX) + (filterY * width);

                            color += sourceData[calcOffset] * filterMatrix[filterY + filterOffset, filterX + filterOffset];
                        }
                    }

                    color = factor*color;
                    color *= magicMul;

                    //MessageBox.Show(String.Format("X = {0}, Y = {1}, Blue = {2}, Red = {3}, Green = {4}", offsetX,
                        //offsetY, blue, red, green));
                    color = (color > 255 ? 255 : (color < 0 ? 0 : color));


                    resultBuffer[byteOffset] = (Byte) (color);
                }
            }

            return resultBuffer;
        }

        private Byte[] Binarization(Byte[] data, Int32 border)
        {
            var result = new Byte[data.Length];

            for (Int32 i = 0; i < data.Length; i++)
            {
                result[i] = data[i] < border ? Byte.MinValue : Byte.MaxValue;
            }
            
            return result;
        }

        private Byte[] CorrectBrightnessRange(Byte[] data, Int32 lowBorder, Int32 highBorder)
        {
            var result = new Byte[data.Length];

            var transformTable = new Byte[Byte.MaxValue + 1];

            for (Int32 i = 0; i < Byte.MaxValue; i++)
            {
                if (i > highBorder)
                {
                    transformTable[i] = Byte.MaxValue;
                }
                else
                {
                    transformTable[i] = Byte.MinValue;
                }
            }

            Double fStep = 256.0/(highBorder - lowBorder);
            Double fCol = 0.0;

            for (Int32 i = lowBorder; i <= highBorder; i++)
            {
                transformTable[i] = Convert.ToByte(Math.Min(fCol + 0.5, 255));
                fCol += fStep;
            }
            for (Int32 i = 0; i < data.Length; i ++)
            {
                result[i] = transformTable[data[i]];
            }

            return result;
        }

        private IEnumerable<ImageClaster> CalculateMetricsForObjects(Byte[] data, Byte[] colorMap, Int32 width, Int32 height)
        {

            Dictionary<Byte, ImageClaster> objects = new Dictionary<Byte, ImageClaster>();

            CalculateGeometricMetrics(data, colorMap, width, height, objects);

            CalculateMoments(data, width, height, objects);

            return objects.Values;
        }

        private static void CalculateGeometricMetrics(Byte[] data, Byte[] colorMap, Int32 width, Int32 height, Dictionary<Byte, ImageClaster> objects)
        {
            for (Int32 offsetY = 0; offsetY < height; offsetY++)
            {
                for (Int32 offsetX = 0; offsetX < width; offsetX++)
                {
                    Int32 byteOffset = offsetY * width + offsetX;
                    Byte objectClass = data[byteOffset];

                    if (objectClass == 0)
                        continue;

                    if (!objects.ContainsKey(objectClass))
                    {
                        objects.Add(objectClass, new ImageClaster { ImageClass = objectClass });
                    }

                    Byte[] colorByte = new Byte[3];
                    for (int i = 0; i < 3; i++)
                    {
                        colorByte[i] = colorMap[byteOffset * 3 + i];
                    }

                    objects[objectClass].RColorSum += colorByte[0];
                    objects[objectClass].GColorSum += colorByte[1];
                    objects[objectClass].BColorSum += colorByte[2];

                    objects[objectClass].Square++;
                    objects[objectClass].MassX += offsetX;
                    objects[objectClass].MassY += offsetY;

                    if (((offsetY == 0) || (data[byteOffset - width] == 0)) ||
                        ((offsetX == 0) || (data[byteOffset - 1] == 0)) ||
                        ((offsetY == height - 1) || (data[byteOffset + width] == 0)) ||
                        ((offsetX == width - 1) || (data[byteOffset + 1] == 0)))
                    {
                        objects[objectClass].Perimeter++;
                    }
                }
            }
        }

        private static void CalculateMoments(Byte[] data, Int32 width, Int32 height, Dictionary<Byte, ImageClaster> objects)
        {
            for (Int32 offsetY = 0; offsetY < height; offsetY++)
            {
                for (Int32 offsetX = 0; offsetX < width; offsetX++)
                {
                    int byteOffset = offsetY * width + offsetX;
                    byte objectClass = data[byteOffset];

                    if (objectClass == 0)
                        continue;

                    objects[objectClass].Moment11 += (offsetX - objects[objectClass].MassCenterX) *
                                                     (offsetY - objects[objectClass].MassCenterY);
                    objects[objectClass].Moment20 += (offsetX - objects[objectClass].MassCenterX) *
                                                     (offsetX - objects[objectClass].MassCenterX);
                    objects[objectClass].Moment02 += (offsetY - objects[objectClass].MassCenterY) *
                                                     (offsetY - objects[objectClass].MassCenterY);
                }
            }
        }

        private Byte[] IterativeScan(Byte[] data, Int32 width, Int32 height)
        {
            var regionList = new List<Byte>();
            for (Int32 offsetY = 0; offsetY < height; offsetY++)
            {
                for (Int32 offsetX = 0; offsetX < width; offsetX++)
                {
                    Int32 byteOffset = offsetY * width + offsetX;

                    Byte prevY = offsetX == 0 ? Byte.MinValue : data[byteOffset - 1];
                    Byte prevX = offsetY == 0 ? Byte.MinValue : data[byteOffset - width];

                    if (data[byteOffset] == Byte.MaxValue)
                    {
                        if (prevY == Byte.MinValue)
                        {
                            if (prevX == Byte.MinValue)
                            {
                                regionList.Add((Byte) (regionList.LastOrDefault() + 1));

                                data[byteOffset] = regionList.Last();
                            }
                            else
                            {
                                data[byteOffset] = prevX;
                            }
                        }
                        else
                        {
                            if (prevX == Byte.MinValue)
                            {
                                data[byteOffset] = prevY;
                            }
                            else
                            {
                                data[byteOffset] = prevX;
                                if (prevX != prevY)
                                {
                                    //make prevX = prevY
                                    for (Int32 i = 0; i < byteOffset; i++)
                                    {
                                        if (data[i] == prevY)
                                        {
                                            data[i] = prevX;
                                        }
                                    }
                                    regionList.Remove(prevY);
                                }
                            }
                        }
                    }
                }
            }

            return data;
        }

        private List<LightImageClaster> CalculateGoodCenters(IEnumerable<LightImageClaster> objects,
            Constants.Attributes attribute)
        {
            var lightImageClasters = objects as IList<LightImageClaster> ?? objects.ToList();

            LightImageClaster maxObject;
            LightImageClaster minObject;
            Double delta, border;
            switch (attribute)
            {
                case Constants.Attributes.Compactness:
                {
                    CalculateCenterParametersByCompactness(lightImageClasters, out maxObject, out minObject, out delta, out border);

                    break;
                }
                case Constants.Attributes.Elongation:
                {
                    CalculateCenterParametersByElongation(lightImageClasters, out maxObject, out minObject, out delta, out border);
                    break;
                }
                case Constants.Attributes.Perimeter:
                {
                    CalculateCenterParametersByPerimeter(lightImageClasters, out maxObject, out minObject, out delta, out border);
                    break;
                }
                case Constants.Attributes.Square:
                {
                    CalculateCenterParametersBySquare(lightImageClasters, out maxObject, out minObject, out delta, out border);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException("attribute");
            }

            if (NumberOfClasters < 3)
            {
                return new List<LightImageClaster>(NumberOfClasters) {minObject, maxObject};
            }

            delta /= NumberOfClasters;
            border += delta;
            List<LightImageClaster> calculatedCenters = new List<LightImageClaster>(NumberOfClasters)
            {
                minObject,
                maxObject
            };

            for (int i = 0; i < NumberOfClasters - 2; i++)
            {
                var modBorder = border;

                switch (attribute)
                {
                       
                    case Constants.Attributes.Square:
                    {
                        border = AddCenterBySquare(lightImageClasters, delta, border, calculatedCenters, modBorder);
                        break;
                    }
                    case Constants.Attributes.Perimeter:
                    {
                        border = AddCenterByPerimeter(lightImageClasters, delta, border, calculatedCenters, modBorder);
                        break;
                    }
                    case Constants.Attributes.Compactness:
                    {
                        border = AddCenterByCompactness(lightImageClasters, delta, border, calculatedCenters, modBorder);
                        break;
                    }
                    case Constants.Attributes.Elongation:
                    {
                        border = AddCenterByElongation(lightImageClasters, delta, border, calculatedCenters, modBorder);
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException("attribute");
                }
            }
            return calculatedCenters;
        }

        private static double AddCenterByElongation(IList<LightImageClaster> lightImageClasters, Double delta, Double border, List<LightImageClaster> calculatedCenters, double modBorder)
        {
            calculatedCenters.Add(
                lightImageClasters.First(
                    s =>
                        Math.Abs(s.Elongation -
                                 lightImageClasters.Where(t => t.Elongation > modBorder)
                                     .Min(v => v.Elongation)) < Constants.Epsilon));
            border += delta;
            return border;
        }

        private static double AddCenterByCompactness(IList<LightImageClaster> lightImageClasters, Double delta, Double border, List<LightImageClaster> calculatedCenters, double modBorder)
        {
            calculatedCenters.Add(
                lightImageClasters.First(
                    s =>
                        Math.Abs(s.Compactness -
                                 lightImageClasters.Where(t => t.Compactness > modBorder)
                                     .Min(v => v.Compactness)) < Constants.Epsilon));
            border += delta;
            return border;
        }

        private static double AddCenterByPerimeter(IList<LightImageClaster> lightImageClasters, Double delta, Double border, List<LightImageClaster> calculatedCenters, double modBorder)
        {
            calculatedCenters.Add(
                lightImageClasters.First(
                    s =>
                        Math.Abs(s.Perimeter -
                                 lightImageClasters.Where(t => t.Perimeter > modBorder)
                                     .Min(v => v.Perimeter)) < Constants.Epsilon));
            border += delta;
            return border;
        }

        private static double AddCenterBySquare(IList<LightImageClaster> lightImageClasters, Double delta, Double border, List<LightImageClaster> calculatedCenters, double modBorder)
        {
            calculatedCenters.Add(
                lightImageClasters.First(
                    s =>
                        Math.Abs(s.Square -
                                 lightImageClasters.Where(t => t.Square > modBorder).Min(v => v.Square)) <
                        Constants.Epsilon));
            border += delta;
            return border;
        }

        private static void CalculateCenterParametersBySquare(IList<LightImageClaster> lightImageClasters, out LightImageClaster maxObject, out LightImageClaster minObject, out Double delta, out Double border)
        {
            maxObject = lightImageClasters.First(t => (Math.Abs(t.Square - lightImageClasters.Max(v => v.Square)) < Constants.Epsilon));
            minObject = lightImageClasters.First(t => (Math.Abs(t.Square - lightImageClasters.Min(v => v.Square)) < Constants.Epsilon));
            delta = maxObject.Square - minObject.Square;
            border = minObject.Square;
        }

        private static void CalculateCenterParametersByPerimeter(IList<LightImageClaster> lightImageClasters, out LightImageClaster maxObject, out LightImageClaster minObject, out Double delta, out Double border)
        {
            maxObject = lightImageClasters.First(t => (Math.Abs(t.Perimeter - lightImageClasters.Max(v => v.Perimeter)) < Constants.Epsilon));
            minObject = lightImageClasters.First(t => (Math.Abs(t.Perimeter - lightImageClasters.Min(v => v.Perimeter)) < Constants.Epsilon));
            delta = maxObject.Perimeter - minObject.Perimeter;
            border = minObject.Perimeter;
        }

        private static void CalculateCenterParametersByElongation(IList<LightImageClaster> lightImageClasters, out LightImageClaster maxObject, out LightImageClaster minObject, out Double delta, out Double border)
        {
            maxObject =
                lightImageClasters.First(
                    t => Math.Abs(t.Elongation - lightImageClasters.Max(v => v.Elongation)) < Constants.Epsilon);
            minObject =
                lightImageClasters.First(
                    t => Math.Abs(t.Elongation - lightImageClasters.Min(v => v.Elongation)) < Constants.Epsilon);
            delta = maxObject.Elongation - minObject.Elongation;

            border = minObject.Elongation;
        }

        private static void CalculateCenterParametersByCompactness(IList<LightImageClaster> lightImageClasters, out LightImageClaster maxObject, out LightImageClaster minObject, out Double delta, out Double border)
        {
            maxObject =
                lightImageClasters.First(
                    t =>
                        Math.Abs(t.Compactness - lightImageClasters.Max(v => v.Compactness)) < Constants.Epsilon);
            minObject =
                lightImageClasters.First(
                    t =>
                        Math.Abs(t.Compactness - lightImageClasters.Min(v => v.Compactness)) < Constants.Epsilon);
            delta = maxObject.Compactness - minObject.Compactness;

            border = minObject.Compactness;
        }

        private void Normalization(ref List<LightImageClaster> objects)
        {
            var maxElongation = objects.Max(t => t.Elongation);
            var maxCompactness = objects.Max(t => t.Compactness);
            var maxSquare = objects.Max(t => t.Square);
            var maxPerimeter = objects.Max(t => t.Perimeter);

            var maxRColor = objects.Max(t => t.ColorMap[0]);
            var maxGColor = objects.Max(t => t.ColorMap[1]);
            var maxBColor = objects.Max(t => t.ColorMap[2]);

            objects.ForEach(t =>
            {
                t.Compactness /= maxCompactness;
                t.Elongation /= maxElongation;
                t.Square /= maxSquare;
                t.Perimeter /= maxPerimeter;

                t.ColorMap[0] /= maxRColor;
                t.ColorMap[1] /= maxGColor;
                t.ColorMap[2] /= maxBColor;
            });
        }
    
        private LightImageClaster CalculateCenter(IEnumerable<LightImageClaster> objects)
        {
            IList<LightImageClaster> lightImageClasters = objects as IList<LightImageClaster> ?? objects.ToList();

            var countCenter = new LightImageClaster {ResultImageClass = lightImageClasters.First().ResultImageClass};

            foreach (LightImageClaster lightImageClaster in lightImageClasters)
            {
                CalculateClasterParametersSum(countCenter, lightImageClaster);
            }

            CalculateClasterParametersAverage(lightImageClasters, countCenter);


            return
                lightImageClasters.First(
                    t => Math.Abs(t.CalculateEuclideanDistance(countCenter) - lightImageClasters.Select(
                        lightImageClaster => lightImageClaster.CalculateEuclideanDistance(countCenter))
                        .ToList()
                        .Min()) < Constants.Epsilon);
        }

        private static void CalculateClasterParametersAverage(IList<LightImageClaster> lightImageClasters, LightImageClaster countCenter)
        {
            countCenter.Compactness /= lightImageClasters.Count;
            countCenter.Elongation /= lightImageClasters.Count;

            countCenter.ColorMap[0] /= lightImageClasters.Count;
            countCenter.ColorMap[1] /= lightImageClasters.Count;
            countCenter.ColorMap[2] /= lightImageClasters.Count;
        }

        private static void CalculateClasterParametersSum(LightImageClaster countCenter, LightImageClaster lightImageClaster)
        {
            countCenter.Compactness += lightImageClaster.Compactness;
            countCenter.Elongation += lightImageClaster.Elongation;

            countCenter.ColorMap[0] += lightImageClaster.ColorMap[0];
            countCenter.ColorMap[1] += lightImageClaster.ColorMap[1];
            countCenter.ColorMap[2] += lightImageClaster.ColorMap[2];
        }

        private List<LightImageClaster> ClasterObjects(List<LightImageClaster> objects, List<LightImageClaster> centers)
        {
            foreach (LightImageClaster lightImageClaster in objects)
            {
                LightImageClaster local = lightImageClaster;

                lightImageClaster.ResultImageClass =
                    centers.FindIndex(
                        t =>
                            Math.Abs(t.CalculateEuclideanDistance(local) -
                                     centers.Select(el => el.CalculateEuclideanDistance(local)).Min()) <
                            Constants.Epsilon) + 1;
            }
            var newCenters = new List<LightImageClaster>(centers.Count);

            for (Int32 i = 0; i < centers.Count; i++)
            {
                Int32 localI = i + 1;
                try
                {
                    newCenters.Add(CalculateCenter(objects.Where(t => t.ResultImageClass == localI)));
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(String.Format("{0} is uncorrect", localI));
                }
                
            }

            return centers.Where((t, i) => t != newCenters[i]).Any() ? ClasterObjects(objects, newCenters) : objects;
        }

        private static class Constants
        {
            public const Double RedColorIntensity = 0.11;
            public const Double GreenColorIntensity = 0.59;
            public const Double BlueColorIntensity = 0.3;
            public const Double Epsilon = 0.001;

            public enum Attributes { Square, Perimeter, Compactness, Elongation}
        }
    }
}