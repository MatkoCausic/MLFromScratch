using Machine_Learning.Result_Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Supervised.Regression
{
    internal class RidgeRegression_Algorithm : IRegressionAlgorithm
    {
        private double lambda;

        public RidgeRegression_Algorithm(double lambda) 
        {
            this.lambda = lambda;
        }

        public Result Train(Matrix input, Matrix output)
        {
            input = input.Intercept();

            Matrix R = input.Singular();
            R.Data[0][0] = 0;

            /* B = (X^T*X + Lamba*R)^-1 * X^T*Y */
            Matrix buffer = (input.Transpose() * input + lambda * R).Inverse() * input.Transpose() * output;

            Result result = new Linear(buffer.Rows);

            for (int i = 0; i < buffer.Rows; i++)
                result.Data[i] = buffer.Data[i][0];

            return result;
        }
    }
}
