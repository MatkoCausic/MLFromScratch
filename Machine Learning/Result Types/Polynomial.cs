using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Result_Types
{
    internal class Polynomial : Result
    {
        public Polynomial(int length)
        {
            this.Data = new double[length];
        }


        public override double ProcessData(Matrix input)
        {
            double result = this.Data[0];

            for (int i = 1; i <= input.Rows; i++)
                result += this.Data[i] * Math.Pow(input.Data[i - 1][0], i);

            return result;
        }
    }
}
