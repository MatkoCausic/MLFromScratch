using System;
using System.IO;
using System.Numerics;
using System.Text.RegularExpressions;
using Machine_Learning.Utilities;

namespace Machine_Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            var Agent = new BasicModel();

            Matrix X1 = new Matrix(new double[][]
            {
                [0,6,5],[0,20,12],[1,25,21],[0,10,2]
            }
            );
            Matrix X2 = new Matrix(new double[][]
            {
                [0],[0],[1],[0]
            }
            );
            Matrix y = new Matrix(new double[][]
            {
                [1600],
                [2200],
                [2500],
                [2000]
            });

            Console.WriteLine(MatrixStat.ToString(X1.Data));
            Agent.Fit(X1, y);

            double[] inputParameters = [1,20,5];

            Console.WriteLine(Agent.Predict(inputParameters));

            Console.WriteLine(MatrixStat.ToString(Agent.WorkingFunction));
            
            //File.WriteAllText("C:\\Users\\Matko\\Desktop\\filename.txt", "Hello, World!");
            //Console.WriteLine(File.ReadAllText("C:\\Users\\Matko\\Desktop\\filename.txt"));
        }
    }
}