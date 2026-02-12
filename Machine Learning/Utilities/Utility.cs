using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Utilities
{
    internal static class Utility
    {
        public static (int, int) GetDimensions(double[][] matrix) => (matrix.Length, matrix[0].Length);

        public static string ToString(double[][] matrix)
        {
            var (rows, columns) = GetDimensions(matrix);
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    s.Append(matrix[i][j] + " ");
                s.Append("\n");
            }

            return s.ToString();
        }

        public static string ToString(double[] matrix)
        {
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < matrix.Length; i++)
                s.Append(matrix[i] + " ");
            s.Append("\n");

            return s.ToString();
        }

        public static double Norm(double[] input)
        {
            double result = 0;
            foreach (double x in input)
                result += Math.Pow(x, 2);

            return Math.Sqrt(result);
        }
        public static double Norm(List<double> input)
        {
            double result = 0;
            foreach (double x in input)
                result += Math.Pow(x, 2);

            return Math.Sqrt(result);
        }
    }
}
