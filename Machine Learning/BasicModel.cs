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
        private ISupervisedAlgorithm algorithm;
        private bool hasBeenTrained;
        private Result workingFunction;

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
        }

        public BasicModel(ISupervisedAlgorithm algorithm) : this()
        {
            this.algorithm = algorithm;
        }

        public void ChangeAlgorithm(ISupervisedAlgorithm algorithm)
        {
            this.algorithm = algorithm;
            WorkingFunction = NullResult.GetInstance();
        }

        public void Fit(Matrix input, Matrix output)
        {
            if (input.Rows != output.Rows)
                throw new ArgumentException($"X.Rows ({input.Rows}) must equal y.Rows ({output.Rows}).");

            if (output.Columns != 1)
                throw new ArgumentException($"y must be N×1. Got {output.Rows}×{output.Columns}.");

            if (!HasBeenTrained)
                HasBeenTrained = true;

            workingFunction = algorithm.Train(input, output);
        }

        public double Predict(Matrix input)
        {
            if (!hasBeenTrained)
                throw new Exception("Model hasn't been trained yet...");

            //if (input.Rows != workingFunction.Data.Length - 1)
            //    throw new Exception("There are missing parameters to make a prediction...");

            return workingFunction.ProcessData(input);
        }

        private void Validate()
        {
            throw new NotImplementedException();
        }
    }

}
