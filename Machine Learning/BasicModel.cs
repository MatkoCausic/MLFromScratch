using Machine_Learning.Result_Types;
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
        private Result workingFunction;
        public double[][]? input, output;

        public bool HasBeenTrained
        {
            get { return hasBeenTrained; }
            private set { hasBeenTrained = value; }
        }

        public Result WorkingFunction
        {
            get { return workingFunction; }
            private set { workingFunction = value; }
        }

        public BasicModel()
        {
            this.algorithm = new LinearRegression_Algorithm();
            this.hasBeenTrained = false;
            this.workingFunction = NullResult.GetInstance();
            input = null;
            output = null;
        }

        public BasicModel(IRegressionAlgorithm algorithm) : this()
        {
            this.algorithm = algorithm;
        }

        public void ChangeAlgorithm(IRegressionAlgorithm algorithm) => this.algorithm = algorithm;

        public void Fit(Matrix input, Matrix output)
        {
            if (!HasBeenTrained)
                HasBeenTrained = true;

            workingFunction = algorithm.Train(input, output);
        }

        public double Predict(double[] input)
        {
            if (!hasBeenTrained)
                throw new Exception("Model hasn't been trained yet...");

            if (input.Length != workingFunction.Data.Length-1)
                throw new Exception("There are missing parameters to make a prediction...");

            double result = workingFunction.Data[0];
            for (int i = 1; i <= input.Length; i++)
                result += workingFunction.Data[i] * input[i - 1];

            return result;
        }

        private void Validate()
        {

        }
    }

}
