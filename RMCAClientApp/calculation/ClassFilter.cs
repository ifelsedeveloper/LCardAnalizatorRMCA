using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LCardAnalizator.calculation
{
    public static class ClassFilter
    {
        public static double[] filterSmooth(double[] x, double[] y)
        {
            double[] res = new double[y.LongLength];

            double sum_numerator, val;
            int count = 4;
            int j;
            for (int i = count; i < y.Count() - count; i++)
            {
                sum_numerator = 0;
                for (j = i - count; j < i + count; j++)
                {
                    sum_numerator += y[j];
                }
                val = sum_numerator / (count * 2);
                if (y[i] < val * 2.5) res[i] = val;
                else res[i] = y[i];
            }

            return res;
        }
    }
}
