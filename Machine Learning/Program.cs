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
            var Agent = new BasicModel(new LinearRegression_Algorithm());

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


            Console.WriteLine(Matrix.ToString(Agent.workingFunction));
            //double[][] beta = Matrix.Inverse(Matrix.Multiply(Matrix.Transpose(X), X));
            //beta = Matrix.Multiply(beta, Matrix.Transpose(X));
            //beta = Matrix.Multiply(beta, Y);

            //Console.WriteLine(Matrix.ToString(beta));

            //File.WriteAllText("C:\\Users\\Matko\\Desktop\\filename.txt", "Hello, World!");
            //Console.WriteLine(File.ReadAllText("C:\\Users\\Matko\\Desktop\\filename.txt"));
        }
    }
}