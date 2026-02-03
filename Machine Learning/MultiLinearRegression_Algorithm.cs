using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    internal class MultiLinearRegression_Algorithm : IAlgorithm
    {

        public MultiLinearRegression_Algorithm()
        {

        }

        public double[] Run(double[][] input, double[][] output)
        {
            var (rows, columns) = Matrix.GetDimensions(input);
            if (columns < 2)
                throw new Exception("Input dimension is too small. Try to implement given problem on LinearRegression_Algorithm...");

            double[] outputFunction = Array.Empty<double>();

            input = Matrix.Intercept(input);

            /* buffer = (inputT * input)^-1 * inputT * output */
            /* B = (X^T*X)^-1 * X^T*Y */
            double[][] buffer = Matrix.Inverse(Matrix.Multiply(Matrix.Transpose(input), input));
            buffer = Matrix.Multiply(buffer, Matrix.Transpose(input));
            buffer = Matrix.Multiply(buffer, output);

            if (outputFunction == null || outputFunction.Length != buffer.Length)
                outputFunction = new double[buffer.Length];

            for (int i = 0; i < buffer.Length; i++)
                outputFunction[i] = buffer[i][0];

            return outputFunction;
        }

    }
}
