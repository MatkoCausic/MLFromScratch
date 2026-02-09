using Machine_Learning.Result_Types;
using Machine_Learning.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Supervised.Regression
{
    internal class PolynomialRegression_Algorithm : IRegressionAlgorithm
    {

        public PolynomialRegression_Algorithm() { }

        public Result Train(Matrix input, Matrix output)
        {
            input = input.Intercept();

            /* buffer = (inputT * input)^-1 * inputT * output */
            /* B = (X^T*X)^-1 * X^T*Y */
            Matrix buffer = (input.Transpose() * input).Inverse() * input.Transpose() * output;

            Result result = new Polynomial(buffer.Rows);

            for (int i = 0; i < buffer.Rows; i++)
                result.Data[i] = buffer.Data[i][0];

            return result;

        }
    }
}
