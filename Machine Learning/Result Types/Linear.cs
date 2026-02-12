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

        public override double ProcessData(Matrix input)
        {
            double result = this.Data[0];

            Console.WriteLine(result);
            for (int i = 1; i <= input.Rows; i++)
            {
                Console.WriteLine(this.Data[i]+"*"+input.Data[i - 1][0]);
                result += this.Data[i] * input.Data[i - 1][0];
            }
            return result;
        }

    }
}
