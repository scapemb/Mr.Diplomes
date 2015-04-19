using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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

            IEnumerable<ImageClaster> fullObjects = CalculateMetricsForObjects(regions, width, height);


            var objects = new List<LightImageClaster>();
            objects.AddRange(fullObjects.Select(im => im.ToLightImageClaster()));
            int lol2;
            DeleteBadClasters(ref objects);
            Normaliztion(ref objects);
            int lol;
            var changeObjectClassTable = new Hashtable();

            foreach (LightImageClaster lightImageClaster in ClasterObjects(objects, CalculateGoodCenters(objects, Constants.Attributes.Square)))
            //foreach (LightImageClaster lightImageClaster in ClasterObjects(objects, objects.GetRange(0, NumberOfClasters)))
            {
                changeObjectClassTable.Add(lightImageClaster.BasicImageClass, lightImageClaster.ResultImageClass);
                //MessageBox.Show(
                //    String.Format(
                //        "Changed class from {0} to {1}.\nElongation = {2}, Compactnes = {3}\nSquare = {4}, Perimeter = {5}",
                //        lightImageClaster.BasicImageClass, lightImageClaster.ResultImageClass,
                //        lightImageClaster.Elongation.ToString("F2"), lightImageClaster.Compactness.ToString("F2"),
                //        lightImageClaster.Square, lightImageClaster.Perimeter), "lol");
            }

            var resultBitmap = new Bitmap(width, height, pixelFormat);

            SetRgbValuesToBmp(ref resultBitmap,
                ConvertGrayScaleToRgbWithColors(ColorObjects(regions, changeObjectClassTable, width*height)));
            resultBitmap.Save(Resources.ResultImageName);
        }

        private void DeleteBadClasters(ref List<LightImageClaster> objects)
        {
            objects.RemoveAll(t => t.IsBadClaster());
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
                    imageData[i] = Convert.ToByte((Int32)changeObjectClassTable[(Int32)offsetByte] * (Byte.MaxValue / NumberOfClasters));
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

        private Byte[] CutRange(Byte[] image, Double reducePercent = 0.0)
        {
            Int32 borderMin = 0, borderMax = Byte.MaxValue;

            if (Math.Abs(reducePercent) < Constants.Epsilon)
            {
                return CorrectBrightnessRange(image, borderMin, borderMax);
            }

            var histogram = new Double[Byte.MaxValue + 1];

            for (Int32 i = 0; i <= Byte.MaxValue; i++)
            {
                histogram[i] = 0.0;
            }

            foreach (Byte t in image)
            {
                histogram[t] += 1.0;
            }
            for (Int32 i = 0; i <= Byte.MaxValue; i++)
            {
                histogram[i] *= 100.0/image.Length;
            }
            //Looking for borders to reduce
            for (Double low = 0.0; low < reducePercent;)
            {
                low += histogram[borderMin++];
            }
            for (Double high = 0.0; high < reducePercent;)
            {
                high += histogram[borderMax--];
            }
            return CorrectBrightnessRange(image, borderMin, borderMax);
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


        private IEnumerable<ImageClaster> CalculateMetricsForObjects(Byte[] data, Int32 width, Int32 height)
        {

            Dictionary<Byte, ImageClaster> objects = new Dictionary<Byte, ImageClaster>();

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
                        objects.Add(objectClass, new ImageClaster {ImageClass = objectClass});
                        //MessageBox.Show(String.Format("X = {0}, Y = {1}, calss = {2}", offsetX, offsetY, objectClass));
                    }
                    
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

            for (Int32 offsetY = 0; offsetY < height; offsetY++)
            {
                for (Int32 offsetX = 0; offsetX < width; offsetX++)
                {
                    int byteOffset = offsetY*width + offsetX;
                    byte objectClass = data[byteOffset];

                    if (objectClass == 0)
                        continue;

                    objects[objectClass].Moment11 += (offsetX - objects[objectClass].MassCenterX)*
                                                     (offsetY - objects[objectClass].MassCenterY);
                    objects[objectClass].Moment20 += (offsetX - objects[objectClass].MassCenterX)*
                                                     (offsetX - objects[objectClass].MassCenterX);
                    objects[objectClass].Moment02 += (offsetY - objects[objectClass].MassCenterY)*
                                                     (offsetY - objects[objectClass].MassCenterY);
                }
            }
            return objects.Values;
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

                    break;
                }
                case Constants.Attributes.Elongation:
                {
                    maxObject =
                        lightImageClasters.First(
                            t => Math.Abs(t.Elongation - lightImageClasters.Max(v => v.Elongation)) < Constants.Epsilon);
                    minObject =
                        lightImageClasters.First(
                            t => Math.Abs(t.Elongation - lightImageClasters.Min(v => v.Elongation)) < Constants.Epsilon);
                    delta = maxObject.Elongation - minObject.Elongation;

                    border = minObject.Elongation;
                    break;
                }
                case Constants.Attributes.Perimeter:
                {
                    maxObject = lightImageClasters.First(t => (Math.Abs(t.Perimeter - lightImageClasters.Max(v => v.Perimeter)) < Constants.Epsilon));
                    minObject = lightImageClasters.First(t => (Math.Abs(t.Perimeter - lightImageClasters.Min(v => v.Perimeter)) < Constants.Epsilon));
                    delta = maxObject.Perimeter - minObject.Perimeter;
                    border = minObject.Perimeter;
                    break;
                }
                case Constants.Attributes.Square:
                {
                    maxObject = lightImageClasters.First(t => (Math.Abs(t.Square - lightImageClasters.Max(v => v.Square)) < Constants.Epsilon));
                    minObject = lightImageClasters.First(t => (Math.Abs(t.Square - lightImageClasters.Min(v => v.Square)) < Constants.Epsilon));
                    delta = maxObject.Square - minObject.Square;
                    border = minObject.Square;
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
                        calculatedCenters.Add(
                            lightImageClasters.First(
                                s =>
                                    Math.Abs(s.Square -
                                             lightImageClasters.Where(t => t.Square > modBorder).Min(v => v.Square)) <
                                    Constants.Epsilon));
                        border += delta;
                        break;
                    }
                    case Constants.Attributes.Perimeter:
                    {
                        calculatedCenters.Add(
                            lightImageClasters.First(
                                s =>
                                    Math.Abs(s.Perimeter -
                                             lightImageClasters.Where(t => t.Perimeter > modBorder)
                                                 .Min(v => v.Perimeter)) < Constants.Epsilon));
                        border += delta;
                        break;
                    }
                    case Constants.Attributes.Compactness:
                    {
                        calculatedCenters.Add(
                            lightImageClasters.First(
                                s =>
                                    Math.Abs(s.Compactness -
                                             lightImageClasters.Where(t => t.Compactness > modBorder)
                                                 .Min(v => v.Compactness)) < Constants.Epsilon));
                        border += delta;
                        break;
                    }
                    case Constants.Attributes.Elongation:
                    {
                        calculatedCenters.Add(
                            lightImageClasters.First(
                                s =>
                                    Math.Abs(s.Elongation -
                                             lightImageClasters.Where(t => t.Elongation > modBorder)
                                                 .Min(v => v.Elongation)) < Constants.Epsilon));
                        border += delta;
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException("attribute");
                }
            }
            var lol = 2;
            return calculatedCenters;
        }

        private void Normaliztion(ref List<LightImageClaster> objects)
        {
            var maxElongation = objects.Max(t => t.Elongation);
            var maxCompactness = objects.Max(t => t.Compactness);
            var maxSquare = objects.Max(t => t.Square);
            var maxPerimeter = objects.Max(t => t.Perimeter);
            objects.ForEach(t =>
            {
                t.Compactness /= maxCompactness;
                t.Elongation /= maxElongation;
                t.Square /= maxSquare;
                t.Perimeter /= maxPerimeter;
            });
        }
        private LightImageClaster CalculateCenter(IEnumerable<LightImageClaster> objects)
        {
            IList<LightImageClaster> lightImageClasters = objects as IList<LightImageClaster> ?? objects.ToList();

            var countCenter = new LightImageClaster {ResultImageClass = lightImageClasters.First().ResultImageClass};

            foreach (LightImageClaster lightImageClaster in lightImageClasters)
            {
                countCenter.Compactness += lightImageClaster.Compactness;
                countCenter.Elongation += lightImageClaster.Elongation;
            }

            countCenter.Compactness /= lightImageClasters.Count;
            countCenter.Elongation /= lightImageClasters.Count;


            return
                lightImageClasters.First(
                    t => Math.Abs(t.CalculateEuclideanDistance(countCenter) - lightImageClasters.Select(
                        lightImageClaster => lightImageClaster.CalculateEuclideanDistance(countCenter))
                        .ToList()
                        .Min()) < Constants.Epsilon);
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
                    MessageBox.Show(String.Format("{0} sosnul", localI));
                    //centers.Remove(centers.First(t => t.ResultImageClass == localI));
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