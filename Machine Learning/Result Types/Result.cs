using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning
{
    internal abstract class Result
    {
        double[] data;
        public double[] Data
        {
            get { return data; }
            set { data = value; }
        }

        public Result()
        {
            this.data = Array.Empty<double>();
        }

        public abstract double ProcessData(Matrix input);
    }
}
