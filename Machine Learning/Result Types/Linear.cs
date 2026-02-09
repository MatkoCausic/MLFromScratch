using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Machine_Learning.Result_Types
{
    internal class Linear : Result
    {
        public Linear(int length)
        {
            this.Data = new double[length];
        }


        public override double ProcessData(Matrix input, Matrix output)
        {
            return 0;
        }

    }
}
