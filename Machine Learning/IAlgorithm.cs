using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    internal interface IAlgorithm
    {
        double[] Run(double[][] input, double[][] output);
    }
}
