using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class MultilayerPerceptron
    {
        private double[,] associativeLayer_weights;
        private double[] associativeLayer_thresholds;

        private double[,] outputLayer_weights;
        private double[] outputLayer_thresholds;

        private int sensorCount;
        private int outputCount;
        private int associativeCount;

        private double alfa;
        private double beta;
        private double maxErrorTreshold;

        public int iterationCount { get; private set; }

        private char[] classesNames;

        public MultilayerPerceptron(Dictionary<char, List<int[]>> classes, double alfa, double beta, double maxError)
        {
            int size = classes.First().Value.First().Length;

            int i = 0;
            classesNames = new char[classes.Count];
            foreach (KeyValuePair<char, List<int[]>> tmp in classes)
                classesNames[i++] = tmp.Key;
            
            this.alfa = alfa;
            this.beta = beta;
            this.maxErrorTreshold = maxError;

            iterationCount = TeachNeuralNetwork(classes);
        }

        private int TeachNeuralNetwork(Dictionary<char, List<int[]>> classes)
        {
            sensorCount = classes.First().Value.First().Length;
            outputCount = classes.Count;
            
            Random random = new Random();

            associativeCount = (int) Math.Sqrt(sensorCount / outputCount); //(sensorCount + outputCount) / 2;

            associativeLayer_weights = new double[sensorCount, associativeCount];
            associativeLayer_thresholds = new double[associativeCount];

            outputLayer_weights = new double[associativeCount, outputCount];
            outputLayer_thresholds = new double[outputCount];

            Randomize(random);

            double[] associativeNeurons = new double[associativeCount];
            double[] outputNeurons = new double[outputCount];

            List<double> maxErrors = new List<double>();

            int iterCount = 0;
            double errorSumPrev = double.MaxValue;

            double[] outputErrors = new double[outputCount];
            double[] outputErrorsAbs = new double[outputCount];


            //double miu = 0.5;
            while (true)
            {
                maxErrors.Clear();
                int classNumber = 0;

                foreach (List<int[]> images in classes.Select(tmp => tmp.Value))
                {
                    foreach (int[] img in images)
                    {
                        for (int j = 0; j < associativeCount; j++)
                        {
                            double sum = 0;
                            for (int i = 0; i < sensorCount; i++)
                                sum += associativeLayer_weights[i, j] * img[i];

                            associativeNeurons[j] = ActivationFunction(sum + associativeLayer_thresholds[j]);
                        }

                        for (int k = 0; k < outputCount; k++)
                        {
                            double sum = 0;
                            for (int j = 0; j < associativeCount; j++)
                                sum += outputLayer_weights[j, k] * associativeNeurons[j];

                            outputNeurons[k] = ActivationFunction(sum + outputLayer_thresholds[k]);
                        }


                        //-----------------------------------------------------
                        Array.Clear(outputErrors, 0, outputErrors.Length);
                        outputErrors[classNumber] = 1;

                        for (int k = 0; k < outputCount; k++)
                            outputErrors[k] -= outputNeurons[k];

                        outputErrorsAbs = outputErrors.Select(Math.Abs).ToArray();
                        maxErrors.Add(outputErrorsAbs.Max());

                        double[] associativeErrors = new double[associativeCount];
                        for (int j = 0; j < associativeCount; j++)
                        {
                            double sum = 0;
                            for (int k = 0; k < outputCount; k++)
                                sum += outputErrors[k] * outputNeurons[k] * (1 - outputNeurons[k]) * outputLayer_weights[j, k];

                            associativeErrors[j] = sum;
                        }

                        //-----------------------------------------------------
                        // Correct weights and tresholds

                        for (int j = 0; j < associativeCount; j++)
                        {
                            for (int k = 0; k < outputCount; k++)
                            {
                                outputLayer_weights[j, k] += 
                                    alfa * outputNeurons[k] * (1 - outputNeurons[k]) * outputErrors[k] * associativeNeurons[j];
                            }
                        }
                        for (int k = 0; k < outputCount; k++)
                        {
                            outputLayer_thresholds[k] +=
                                alfa * outputNeurons[k] * (1 - outputNeurons[k]) * outputErrors[k];
                        }

                        for (int i = 0; i < sensorCount; i++)
                        {
                            for (int j = 0; j < associativeCount; j++)
                            {
                                associativeLayer_weights[i, j] +=
                                    beta * associativeNeurons[j] * (1 - associativeNeurons[j]) * associativeErrors[j] * img[i];
                            }
                        }
                        for (int j = 0; j < associativeCount; j++)
                        {
                            associativeLayer_thresholds[j] +=
                                beta * associativeNeurons[j] * (1 - associativeNeurons[j]) * associativeErrors[j];
                            iterCount++;
                        }
                       
                    }
                    classNumber++;
                }
                    
//                alfa -= 0.01 * alfa;
//                beta -= 0.01 * beta;
                

                double maxError = maxErrors.Max();
                if (maxError < maxErrorTreshold)
                    break;

                double errorSum = outputErrorsAbs.Sum();
                if (errorSum >= errorSumPrev)
                {
                    Randomize(random);
                    errorSumPrev = double.MaxValue;
                }
                else
                    errorSumPrev = errorSum;                  
            }
            return iterCount;             
        }

        //        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private double ActivationFunction(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }


        public double GetRandomNumber(double minimum, double maximum, Random random)
        {

            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private void Randomize(Random random)
        {
            //Random random = new Random(RandomProvider.Next() ^ Environment.TickCount);

            for (int i = 0; i < associativeLayer_weights.GetLength(0); i++)
            {
                for (int j = 0; j < associativeLayer_weights.GetLength(1); j++)
                    associativeLayer_weights[i, j] = 2 * random.NextDouble() - 1;
            }

            for (int i = 0; i < associativeLayer_thresholds.Length; i++)
                associativeLayer_thresholds[i] = 2 * random.NextDouble() - 1;

            for (int i = 0; i < outputLayer_weights.GetLength(0); i++)
            {
                for (int j = 0; j < outputLayer_weights.GetLength(1); j++)
                    outputLayer_weights[i, j] = 2 * random.NextDouble() - 1;
            }

            for (int i = 0; i < outputLayer_thresholds.Length; i++)
                outputLayer_thresholds[i] = 2 * random.NextDouble() - 1;
        }

        public Dictionary<char, double> ClassifyImage(int[] image)
        {
            if (sensorCount != image.Length)
                throw new Exception("Image has wrong size.");

            double[] associativeNeurons = new double[associativeCount];
            double[] outputNeurons = new double[outputCount];

            for (int j = 0; j < associativeCount; j++)
            {
                double sum = 0;
                for (int i = 0; i < sensorCount; i++)
                    sum += associativeLayer_weights[i, j] * image[i];

                associativeNeurons[j] = ActivationFunction(sum + associativeLayer_thresholds[j]);
            }

            for (int k = 0; k < outputCount; k++)
            {
                double sum = 0;
                for (int j = 0; j < associativeCount; j++)
                    sum += outputLayer_weights[j, k] * associativeNeurons[j];

                outputNeurons[k] = ActivationFunction(sum + outputLayer_thresholds[k]);
            }

            Dictionary<char, double> result = new Dictionary<char, double>();
            int t = 0;
            foreach (char className in classesNames)
            {
                result.Add(classesNames[t], outputNeurons[t]);
                t++;
            }

            return result;
        }
    }
}
