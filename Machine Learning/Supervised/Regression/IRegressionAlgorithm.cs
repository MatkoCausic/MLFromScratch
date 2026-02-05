using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Supervised.Regression
{
    internal interface IRegressionAlgorithm : IAlgorithm
    {
        double[] OutputFunction { get; }

        double Predict(double[][] X);
        void Fit(double[][] X, double[][] y);
    }
}
