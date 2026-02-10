using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Supervised.Classification.Binary
{
    internal class LogisticRegression_Algorithm : IBinaryClassificationAlgorithm
    {
        public LogisticRegression_Algorithm() { }

        public Result Train(Matrix input, Matrix output)
        {
            input = input.Intercept();


            return result;
        }
    }
}
