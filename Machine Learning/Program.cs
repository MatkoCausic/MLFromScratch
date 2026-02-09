using System;
using System.IO;
using System.Numerics;
using System.Text.RegularExpressions;
using Machine_Learning.Supervised.Regression;
using Machine_Learning.Utilities;

namespace Machine_Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

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

            var Agent = new BasicModel();

            Console.WriteLine(Utility.ToString(X1.Data));
            Agent.Fit(X1, y);
            Matrix inputParameters = new Matrix(new double[][]
            {
                [1],[20],[5]
            });

            // LIN 2902,857142857132
            // 1434,2857142857156 382,85714285713993 65,71428571428518 -45,71428571428544

            // POLY 2902,857142857132
            // 1434,2857142857156 382,85714285713993 65,71428571428518 -45,71428571428544

            Console.WriteLine(Agent.Predict(inputParameters));

            Console.WriteLine(Utility.ToString(Agent.WorkingFunction.Data));
            
            //File.WriteAllText("C:\\Users\\Matko\\Desktop\\filename.txt", "Hello, World!");
            //Console.WriteLine(File.ReadAllText("C:\\Users\\Matko\\Desktop\\filename.txt"));
        }
    }
}