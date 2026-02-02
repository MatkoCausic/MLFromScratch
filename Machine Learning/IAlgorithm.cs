using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    internal interface IAlgorithm
    {
        double[] OutputFunction { get; }
        void Run(double[][] input, double[][] output);
    }
}
