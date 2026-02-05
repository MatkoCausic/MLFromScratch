using Machine_Learning.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Supervised.Regression
{
    internal class LinearRegression_Algorithm : IAlgorithm
    {
        public LinearRegression_Algorithm()
        {

        }

        public double[] Run(double[][] input, double[][] output)
        {
            var (rows, columns) = Matrix.GetDimensions(input);
            if (columns > 1)
                throw new Exception("Input dimensions are too large. Try to implement given problem on MultipleLinearRegression_Algorithm...");

            double[] outputFunction = new double[2];

            input = Matrix.Intercept(input);

            /* buffer = (inputT * input)^-1 * inputT * output */
            /* B = (X^T*X)^-1 * X^T*Y */
            double[][] buffer = Matrix.Inverse(Matrix.Multiply(Matrix.Transpose(input), input));
            buffer = Matrix.Multiply(buffer, Matrix.Transpose(input));
            buffer = Matrix.Multiply(buffer, output);

            for (int i = 0; i < buffer.Length; i++)
                outputFunction[i] = buffer[i][0];

            return outputFunction;
        }
    }
}
