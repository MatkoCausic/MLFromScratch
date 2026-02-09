using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    internal interface ISupervisedAlgorithms<out IResult>
    {
        IResult Run(double[][] input, double[][] output);
    }
}
