using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Result_Types
{
    internal class Polynomial : Result
    {
        int DEGREE = 3;
        public Polynomial(int length)
        {
            this.Data = new double[length];
        }

        public override double ProcessData(Matrix input)
        {
            double result = this.Data[0];
            int idx = 1;

            for (int i = 1; i <= DEGREE; i++)
                for (int j = 0; j < input.Columns; j++)
                    result += this.Data[idx++] * Math.Pow(input.Data[0][j], i);

            return result;
        }
    }
}
