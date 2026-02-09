using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    internal interface IResult
    {
        void Predict(double[][] input);
    }
}
