using System;
using System.IO;
using System.Numerics;
using System.Text.RegularExpressions;
using MathNet.Numerics.LinearAlgebra;

namespace Machine_Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            var Agent = new BasicModel();

            double[][] X = new double[][]
            {
                [0,6,5],[0,20,12],[1,25,21],[0,10,2]
            };
            double[][] Y = new double[][]
            {
                [1600],
                [2200],
                [2500],
                [2000]
            };

            Agent.Fit(X, Y);

            double[] inputParameters = [1,20,5];

            Console.WriteLine(Agent.Predict(inputParameters));

            //Console.WriteLine(Matrix.ToString(Agent.WorkingFunction));
            
            //File.WriteAllText("C:\\Users\\Matko\\Desktop\\filename.txt", "Hello, World!");
            //Console.WriteLine(File.ReadAllText("C:\\Users\\Matko\\Desktop\\filename.txt"));
        }
    }
}