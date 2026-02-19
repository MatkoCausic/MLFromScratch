using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Supervised
{
    internal interface ISupervisedModel : IMlModel
    {
        void ChangeAlgorithm(ISupervisedAlgorithm algorithm);

    }
}
