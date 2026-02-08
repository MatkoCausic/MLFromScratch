using Machine_Learning.Supervised.Regression;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    // Je li mogu model svesti na metode koje će vrijediti za svaki moguću funkciju? Ako imaš lin za lin da vrijedi, ako imaš nelin da vrijedi za nelin
    internal class BasicModel
    {
        private IRegressionAlgorithm algorithm;
        private bool hasBeenTrained;
        private /*IResult*/ double[] workingFunction;
        public double[][]? input, output;

        public bool HasBeenTrained
        {
            get { return hasBeenTrained; }
            private set { hasBeenTrained = value; }
        }

        public double[] WorkingFunction
        {
            get { return workingFunction; }
            private set { workingFunction = value; }
        }

        public BasicModel()
        {
            this.algorithm = new MultiLinearRegression_Algorithm();
            this.hasBeenTrained = false;
            this.workingFunction = new double[0];
            input = null;
            output = null;
        }

        public BasicModel(IRegressionAlgorithm algorithm) : base()
        {
            this.algorithm = algorithm;
        }

        public void ChangeAlgorithm(IRegressionAlgorithm algorithm) => this.algorithm = algorithm;

        public void Fit(Matrix input, Matrix output)
        {
            if (!HasBeenTrained)
                HasBeenTrained = true;

            workingFunction = algorithm.Run(input, output);
        }

        public double Predict(double[] input)
        {
            if (!hasBeenTrained)
                throw new Exception("Model hasn't been trained yet...");

            if (input.Length != workingFunction.Length-1)
                throw new Exception("There are missing parameters to make a prediction...");

            double result = workingFunction[0];
            for (int i = 1; i <= input.Length; i++)
                result += workingFunction[i] * input[i - 1];

            return result;
        }

        private void Validate()
        {

        }
    }

}
