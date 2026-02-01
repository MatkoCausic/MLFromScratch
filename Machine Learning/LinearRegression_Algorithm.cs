using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    internal class LinearRegression_Algorithm : IAlgorithm
    {
        private double[][] outputFunction;
        public double[][] OutputFunction
        {
            get { return outputFunction; }
            private set { outputFunction = value; }
        }

        public LinearRegression_Algorithm()
        {
            outputFunction = new double[][]
            {
                [0, 0, 0],
                [0, 0, 0],
                [0, 0, 0]
            };

        }

        public void Run(double[][] input, double[][] output)
        {
            /* buffer = (inputT * input)^-1 * inputT * output */
            double[][] buffer = Matrix.Inverse(Matrix.Multiply(Matrix.Transpose(input), input));
            buffer = Matrix.Multiply(buffer, Matrix.Transpose(input));
            buffer = Matrix.Multiply(buffer, output);

            OutputFunction = buffer;
        }
    }
}
