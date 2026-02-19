using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    internal interface IMlModel
    {
        void ChangeAlgorithm(IMlAlgorithm algorithm);
    }
}
