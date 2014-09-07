using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace LCardAnalizator.calculation
{
    public static class ClassFilter
    {
        public static double[] filterSmooth(double[] x, double[] y, int numberPoints, int typeFilter)
        {
            double[] res = new double[y.LongLength];

            //double sum_numerator, val;
            //int count = 4;
            //int j;
            //for (int i = count; i < y.Count() - count; i++)
            //{
            //    sum_numerator = 0;
            //    for (j = i - count; j < i + count; j++)
            //    {
            //        sum_numerator += y[j];
            //    }
            //    val = sum_numerator / (count * 2);
            //    if (y[i] < val * 2.5) res[i] = val;
            //    else res[i] = y[i];
            //}
            CvMat Mat = new CvMat(1, y.Length, MatrixType.F64C1);
            Random rnd = new Random();
            for (int i = 0; i < y.Length; i++)
                Mat.DataArrayDouble[i] = Math.Abs(y[i]);
            if(typeFilter == 0)
                Cv.Smooth(Mat, Mat, SmoothType.Gaussian, numberPoints, numberPoints);
            if (typeFilter == 1)
                Cv.Smooth(Mat, Mat, SmoothType.Blur, numberPoints);
            if (typeFilter == 2)
                Cv.Smooth(Mat, Mat, SmoothType.BlurNoScale, numberPoints);
            for (int i = 0; i < y.Length; i++)
                res[i] = Mat.DataArrayDouble[i];

            return res;
        }

        public static double[] SmoothGauss(double[] x, double[] y, int numberPoints)
        {

            double[] res = new double[y.LongLength];
            CvMat Mat = new CvMat(1, y.Length, MatrixType.F64C1);
            CvMat MatRes = new CvMat(1, y.Length, MatrixType.F64C1);
            for (int i = 0; i < y.Length; i++)
                Mat.DataArrayDouble[i] = Math.Abs(y[i]);
            Cv.Smooth(Mat, MatRes, SmoothType.Gaussian, numberPoints, numberPoints);
            for (int i = 0; i < y.Length; i++)
                res[i] = MatRes.DataArrayDouble[i];
            return res;
        }
    }
}
