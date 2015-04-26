using System;
using System.Collections.Generic;

namespace HOPE
{
    public static class Int1DExt
    {
        public static int[][] ToInt2D(this int[] array)
        {
            var length = (int)Math.Sqrt(array.Length);

            int[][] matrix = new int[length][];

            for (int heightOffset = 0; heightOffset < length; heightOffset++)
            {
                matrix[heightOffset] = new int[length];
                for (int widthOffset = 0; widthOffset < length; widthOffset++)
                {
                    matrix[heightOffset][widthOffset] = array[widthOffset + heightOffset * length];
                }
            }

            return matrix;
        }

        public static int[] AddNoise(this int[] array, int percents)
        {
            int maxBorder = array.Length;
            int invCount = percents*maxBorder/100;

            Dictionary<int,bool> invDictionary = new Dictionary<int, bool>(invCount);

            Random rnd = new Random(DateTime.Now.Millisecond + DateTime.Now.Second);

            while (invCount != 0)
            {
                var newVal = rnd.Next(maxBorder);
                if (invDictionary.ContainsKey(newVal))
                    continue;

                invDictionary.Add(newVal,true);
                invCount--;
            }

            foreach (var invPos in invDictionary.Keys)
            {
                array[invPos] = array[invPos] == 1 ? -1 : 1;
            }

            return array;
        }
    }
}
