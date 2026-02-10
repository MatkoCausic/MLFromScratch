using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Result_Types
{
    internal class Logistic : Result
    {
        double[] data;
        public double[] Data
        {
            get { return data; }
            set { data = value; }
        }

        public Logistic()
        {
            this.data = Array.Empty<double>();
        }

        public Logistic(int length)
        {
            this.data = new double[length];
        }

        //MIDPOINT = -BETA0/BETA1
        //SCALE_PARAMETER = 1/BETA1

        public override double ProcessData(Matrix input)
        {
            double z = Data[0];

            for (int i = 1; i <= input.Rows; i++)
                z += this.Data[i] * input.Data[i - 1][0];
            //double z = -0.352292020373514 + 0.2546689303904923 * 3.78;

            return 1/(1.0 + Math.Exp(-z));
        }
    }
}
