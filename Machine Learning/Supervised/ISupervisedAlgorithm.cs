using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    internal interface ISupervisedAlgorithm
    {
        Result Train(Matrix input, Matrix output);
    }
}
