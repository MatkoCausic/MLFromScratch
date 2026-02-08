using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Supervised.Regression
{
    internal interface IRegressionAlgorithm
    {
        double[] Run(Matrix input, Matrix output);
        //double[] OutputFunction { get; }

        //double Predict(double[][] X);
        //void Fit(double[][] X, double[][] y);
    }
}
