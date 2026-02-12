using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Utilities
{
    internal static class Statistic
    {
        public static double MeanAbsoluteError(double[] actual, double[] calculated)
        {
            if (actual.Length != calculated.Length)
                throw new ArgumentException("Actual and calculated sizes should be the same...");

            double sum = 0;

            for (int i = 0; i < actual.Length; i++)
                sum += Math.Abs(actual[i] - calculated[i]);

            return sum/actual.Length;
        }

        public static double MeanSquaredError(double[] actual, double[] calculated)
        {
            if (actual.Length != calculated.Length)
                throw new ArgumentException("Actual and calculated sizes should be the same...");

            double sum = 0;

            for (int i = 0; i < actual.Length; i++)
                sum += Math.Pow(actual[i] - calculated[i],2);

            return sum / actual.Length;
        }

        public static double RootMeanSquareError(double[] actual, double[] calculated) => Math.Sqrt(MeanSquaredError(actual, calculated));
    }
}
