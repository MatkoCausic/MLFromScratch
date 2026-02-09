using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Supervised.Regression
{
    internal interface IRegressionAlgorithm : ISupervisedAlgorithm
    {
        Result Train(Matrix input, Matrix output);
    }
}
