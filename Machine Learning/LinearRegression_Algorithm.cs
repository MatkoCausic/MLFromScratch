using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    internal class LinearRegression_Algorithm : IAlgorithm
    {
        private double[] outputFunction;
        public double[] OutputFunction
        {
            get { return outputFunction; }
            private set { outputFunction = value; }
        }

        public LinearRegression_Algorithm()
        {
            outputFunction = Array.Empty<double>();

        }

        public void Run(double[][] input, double[][] output)
        {
            input = Intercept(input);
            Console.WriteLine(Matrix.ToString(input));

            /* buffer = (inputT * input)^-1 * inputT * output */
            double[][] buffer = Matrix.Inverse(Matrix.Multiply(Matrix.Transpose(input), input));
            buffer = Matrix.Multiply(buffer, Matrix.Transpose(input));
            buffer = Matrix.Multiply(buffer, output);

            if (OutputFunction == null || OutputFunction.Length != buffer.Length)
                OutputFunction = new double[buffer.Length];

            for (int i = 0; i < buffer.Length; i++)
                OutputFunction[i] = buffer[i][0];
        }

        public static double[][] Intercept(double[][] matrix)
        {
            var (rows, columns) = Matrix.GetDimensions(matrix);
            int newMatrixColumns = columns+1;

            double[][] interceptedMatrix = new double[rows][];
            for (int i = 0; i < rows; i++)
                interceptedMatrix[i] = new double[newMatrixColumns];

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < newMatrixColumns; j++)
                {
                    if (j == 0)
                        interceptedMatrix[i][j] = 1;
                    else
                        interceptedMatrix[i][j] = matrix[i][j-1];
                }
            }

            return interceptedMatrix;
        }
    }
}
