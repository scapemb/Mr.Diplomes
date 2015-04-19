using System;

namespace MastaClasta
{
    public static class MatrixCalculator
    {
        public static double[,] Calculate(int lenght, double weight)
        {
            double[,] kernel = new double[lenght, lenght];
            double sumTotal = 0;

            int kernelRadius = lenght / 2;

            double calculatedEuler = 1.0 / (2.0 * Math.PI * Math.Pow(weight, 2));

            for (int filterY = -kernelRadius; filterY <= kernelRadius; filterY++)
            {
                for (int filterX = -kernelRadius; filterX <= kernelRadius; filterX++)
                {
                    double distance = ((filterX*filterX) + (filterY*filterY))/(2*(weight*weight));

                    kernel[filterY + kernelRadius, filterX + kernelRadius] = calculatedEuler * Math.Exp(-distance);

                    sumTotal += kernel[filterY + kernelRadius, filterX + kernelRadius];
                }
            }

            for (int y = 0; y < lenght; y++)
            {
                for (int x = 0; x < lenght; x++)
                {
                    kernel[y, x] = kernel[y, x] * (1.0 / sumTotal);
                }
            }

            return kernel;
        }
    }
}
