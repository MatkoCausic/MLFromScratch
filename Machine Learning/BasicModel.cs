using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    internal class BasicModel
    {
        private IAlgorithm algorithm;
        private bool result;
        private bool hasBeenTrained;
        private double[][] workingFunction;
        public double[][] input, output;

        public bool Result
        {
            get { return result; }
            private set { result = value; }
        }
        public bool HasBeenTrained
        {
            get { return hasBeenTrained; }
            private set { hasBeenTrained = value; }
        }

        public BasicModel() : base(new LinearRegression_Algorithm())
        {
            
        }

        public BasicModel(IAlgorithm algorithm)
        {
            this.algorithm = algorithm;
            this.hasBeenTrained = false;
            this.workingFunction = new double[0][];
        }

        public void Predict(double[][] input)
        {
            if (!HasBeenTrained)
                throw new Exception("Model hasn't been trained. Run initial training...");

            //workingFunction = 
        }

        public void ChangeAlgorithm(IAlgorithm algorithm) => this.algorithm = algorithm;

        private void Fit()
        {
            algorithm.Run(input, output);
            workingFunction = algorithm.OutputFunction;
        }

        private void Validate()
        {

        }
    }

}
