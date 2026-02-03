using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    internal class BasicModel
    {
        private IAlgorithm algorithm;
        private bool hasBeenTrained;
        private double[] workingFunction;
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

        public BasicModel(IAlgorithm algorithm) : base()
        {
            this.algorithm = algorithm;
        }

        public void ChangeAlgorithm(IAlgorithm algorithm) => this.algorithm = algorithm;

        public void Fit(double[][] input, double[][] output)
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
