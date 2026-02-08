using Machine_Learning.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Supervised.Regression
{
    internal class LinearRegression_Algorithm : IRegressionAlgorithm
    {
        public LinearRegression_Algorithm()
        {

        }

        public double[] Run(Matrix input, Matrix output)
        {
            if (input.Columns > 1)
                throw new Exception("Input dimensions are too large. Try to implement given problem on MultipleLinearRegression_Algorithm...");

            double[] outputFunction = new double[2];

            input = input.Intercept();

            /* buffer = (inputT * input)^-1 * inputT * output */
            /* B = (X^T*X)^-1 * X^T*Y */
            Matrix buffer = (input.Transpose() * input).Inverse() * input.Transpose() * output;

            for (int i = 0; i < buffer.Rows; i++)
                outputFunction[i] = buffer.Data[i][0];

            return outputFunction;
        }
    }
}
