using Machine_Learning.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Supervised.Regression
{
    internal class MultiLinearRegression_Algorithm : IRegressionAlgorithm
    {

        public MultiLinearRegression_Algorithm()
        {

        }

        public double[] Run(Matrix input, Matrix output)
        {
            if (input.Columns < 2)
                throw new Exception("Input dimension is too small. Try to implement given problem on LinearRegression_Algorithm...");

            double[] outputFunction = Array.Empty<double>();

            input = input.Intercept();

            /* buffer = (inputT * input)^-1 * inputT * output */
            /* B = (X^T*X)^-1 * X^T*Y */
            Matrix buffer = (input.Transpose() * input).Inverse() * input.Transpose() * output;

            if (outputFunction == null || outputFunction.Length != buffer.Rows)
                outputFunction = new double[buffer.Rows];

            for (int i = 0; i < buffer.Rows; i++)
                outputFunction[i] = buffer.Data[i][0];

            return outputFunction;
        }

    }
}
