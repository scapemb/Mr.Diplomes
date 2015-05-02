using System;
using System.Collections.Generic;

namespace PercepTRON_Legacy
{
    public class Perceptron
    {
        private readonly int _m;
        private readonly int _n;
        private readonly int _h;
        private readonly double[,] _v;
        private readonly double[,] _w;
        private readonly double[] _q;
        private readonly double[] _t;
        private readonly double[] _g;
        private readonly double[] _y;
        private readonly double[] _e;
        private readonly double[] _d;
        private readonly double _alpha;
        private readonly double _beta;
        private readonly int _timeOut;
        private readonly double _error;
        private readonly Random _random = new Random(DateTime.Now.Millisecond);


        private readonly List<int[]> _listPatterns;

        public Perceptron()
        {

        }

        public Perceptron(List<int[]> listPatterns, int m, double alpha, double beta, int timeOut, double error)
        {
            _timeOut = timeOut;
            _error = error;
            _alpha = alpha;
            _beta = beta;
            _listPatterns = listPatterns;
            _m = m;
            _n = _listPatterns[0].Length;
            _h = _n / 2;

            /*

                    V  Q  W  T
            ---->X---->G---->Y 
                 nSqrt     h     m 
                 i     j     k
                       E     D
                    b     a
 
            */

            _v = CreateMatrix(_n, _h, 0.0);
            _w = CreateMatrix(_h, _m, 0.0);

            _q = new double[_h];
            _t = new double[_m];

            _g = new double[_h];
            _y = new double[_m];

            _e = new double[_h];
            _d = new double[_m];
        }

        public int Steps { get; private set; }

        /// <summary>
        /// 1
        /// </summary>
        protected virtual void InitRandomly()
        {
            InitRandomly(_v, _n, _h);
            InitRandomly(_w, _h, _m);

            InitRandomly(_q);
            InitRandomly(_t);
        }

        public virtual void Teach()
        {
            InitRandomly();

            //2

            Steps = 0;
            int to = _timeOut;
            do
            {
                Steps++;

                for (int pattern = 0; pattern < _m; pattern++)
                {
                    int[] x = _listPatterns[pattern];

                    // 2.1 пропускание входного вектора через скрытый слой
                    for (int j = 0; j < _h; j++)
                    {
                        double q = _q[j];
                        for (int i = 0; i < _n; i++)
                        {
                            q += _v[i, j] * x[i];
                        }
                        _g[j] = Fun(q);
                    }

                    // 2.2 пропускание выхода скрытого слоя через выходной слой
                    for (int k = 0; k < _m; k++)
                    {
                        double t = _t[k];
                        for (int j = 0; j < _h; j++)
                        {
                            t += _w[j, k] * _g[j];
                        }
                        _y[k] = Fun(t);
                    }

                    // 2.6 Ошибка k-го нейрона выходного слоя определяется как
                    double maxError = 0.0;
                    for (int i = 0; i < _m; i++)
                    {
                        double encodingVal = 0.0;
                        if (pattern == i)
                        {
                            encodingVal = 1.0;
                        }
                        _d[i] = encodingVal - _y[i];
                        double abs = Math.Abs(_d[i]);
                        if (abs > maxError) maxError = abs;
                    }

                    // 2.11 + 2.12 При этом главной трудностью является определение 
                    // ошибки нейрона скрытого слоя. Эту ошибку явно определить по формуле, 
                    // аналогичной (2.6), невозможно, однако существует возможность 
                    // рассчитать ее через ошибки нейронов выходного слоя 
                    // (отсюда произошло название алгоритма обратного распространения ошибки):
                    for (int j = 0; j < _h; j++)
                    {
                        _e[j] = 0.0;
                        for (int k = 0; k < _m; k++)
                        {
                            _e[j] += _d[k] * (_y[k] * (1 - _y[k])) * _w[j, k];
                        }
                    }

                    // Происходит коррекция знаний сети, при этом главное значение имеет отклонение реально полученного выхода сети y от идеального вектора yr.
                    //Со-гласно методу градиентного спуска, изменение весовых коэффициентов и по-рогов нейронной сети происходит по следующим формулам
                    // Пересчёт весов и порогов каждого слоя
                    // 2.13 
                    for (int j = 0; j < _h; j++)
                        for (int k = 0; k < _m; k++)
                            _w[j, k] += _alpha * _y[k] * (1 - _y[k]) * _d[k] * _g[j];

                    // 2.14
                    for (int k = 0; k < _m; k++)
                        _t[k] += _alpha * _y[k] * (1 - _y[k]) * _d[k];


                    // 2.15
                    for (int i = 0; i < _n; i++)
                        for (int j = 0; j < _h; j++)
                            _v[i, j] += _beta * _g[j] * (1 - _g[j]) * _e[j] * x[i];

                    // 2.16
                    for (int j = 0; j < _h; j++)
                        _q[j] += _beta * _g[j] * (1 - _g[j]) * _e[j];


                    bool isContinue = (maxError > _error) && (to-- != 0);
                    if (!isContinue)
                    {
                        return;
                    }

                }
            } while (true);
        }

        protected virtual double Fun(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        public virtual double[] Recognize(int[] patternNoised)
        {
            int[] x = patternNoised;

            // 2.1 пропускание входного вектора через скрытый слой
            for (int j = 0; j < _h; j++)
            {
                double q = _q[j];
                for (int i = 0; i < _n; i++)
                {
                    q += _v[i, j] * x[i];
                }
                _g[j] = Fun(q);
            }

            // 2.2 пропускание выхода скрытого слоя через выходной слой
            for (int k = 0; k < _m; k++)
            {
                double t = _t[k];
                for (int j = 0; j < _h; j++)
                {
                    t += _w[j, k] * _g[j];
                }
                _y[k] = Fun(t);
            }

            for (int k = 0; k < _m; k++)
            {
                _y[k] = _y[k] * 100.0;
            }

            return _y;
        }

        private double[,] CreateMatrix(int nParam, int mParam, double flagNotParam)
        {
            double[,] pattern = new double[nParam, mParam];
            for (int i = 0; i < nParam; i++)
            {
                for (int j = 0; j < mParam; j++)
                {
                    pattern[i, j] = flagNotParam;
                }
            }
            return pattern;
        }

        private void InitRandomly(double[,] layer, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    layer[i, j] = GetRandomMinusPlusOne();
                }
            }
        }

        private void InitRandomly(double[] layer)
        {
            for (int i = 0; i < layer.Length; i++)
            {
                layer[i] = GetRandomMinusPlusOne();
            }
        }

        private double GetRandomMinusPlusOne()
        {
            double rnd = _random.NextDouble();
            if (_random.Next(0, 2) == 1)
            {
                rnd = -rnd;
            }
            return rnd;
        }
    }
}