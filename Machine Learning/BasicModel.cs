using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    internal class BasicModel
    {
        private IAlgorithm algorithm;
        private bool result;
        //public Input input;

        public bool Result
        {
            get { return result; }
            private set { result = value; }
        }

        public BasicModel()
        {
            this.algorithm = new LinearRegression_Algorithm();
            
        }

        public BasicModel(IAlgorithm algorithm)
        {
            this.algorithm = algorithm;

        }

        public void Run()
        {

        }

        public void ChangeAlgorithm(IAlgorithm algorithm) => this.algorithm = algorithm;

        private void Train()
        {

            result = true;
        }

        private void Validate()
        {

        }
    }

}
