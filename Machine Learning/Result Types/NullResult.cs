using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Result_Types
{
    // singleton koristi sealed modifikator kako bi spriječili nasljeđivanje kroz vanjske klase
    internal sealed class NullResult : Result
    {
        static NullResult instance;
        private NullResult() { }

        public static NullResult GetInstance()
        {
            if(instance == null)
            {
                instance = new NullResult();
            }

            return instance;
        }

        public override double ProcessData(Matrix input, Matrix output) => 0;
    }
}
