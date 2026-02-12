using System;
using System.IO;
using System.Numerics;
using System.Text.RegularExpressions;
using Machine_Learning.Result_Types;
using Machine_Learning.Supervised.Regression;
using Machine_Learning.Utilities;

namespace Machine_Learning
{
    class Program
    {
        static void RegressionTest()
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
            Matrix y1 = new Matrix(new double[][]
            {
                [1600],
                [2200],
                [2500],
                [2000]
            });
            Matrix y2 = new Matrix(new double[][]
            {
                [1],[20],[5]
            }
            );

            Matrix X3 = new Matrix(new double[][]
            {
                [1],[2],[3],[5],[6],[7],[8],[9],[10],[12],[13],[14],[15],[16],[18],[19],[21],[22]
            });

            Matrix y3 = new Matrix(new double[][]
            {
                [100],[90],[80],[60],[60],[55],[60],[65],[70],[70],[75],[76],[78],[79],[90],[99],[99],[100]
            });

            var RidgeAgent = new BasicModel(new RidgeRegression_Algorithm(0.5));
            var LinearAgent = new BasicModel();

            RidgeAgent.Fit(X1, y1);
            LinearAgent.Fit(X1, y1);

            //Matrix inputParameters = new Matrix(new double[][]
            //{
            //    [17]
            //});

            Console.WriteLine("Linear prediction result: " + LinearAgent.Predict(y2));
            Console.WriteLine(Utility.ToString(LinearAgent.WorkingFunction.Data));

            Console.WriteLine();

            Console.WriteLine("Ridge prediction result: " + RidgeAgent.Predict(y2));
            Console.WriteLine(Utility.ToString(RidgeAgent.WorkingFunction.Data));
        }
        static void FileTest()
        {
            File.WriteAllText("C:\\Users\\Matko\\Desktop\\filename.txt", "Hello, World!");
            Console.WriteLine(File.ReadAllText("C:\\Users\\Matko\\Desktop\\filename.txt"));
        }
        static void Main(string[] args)
        {
            RegressionTest();
            //ClassificationTest();
            //StatisticTest();
            //FileTest();
        }

        static void StatisticTest()
        {
            double[] actual = [2, 3, 5, 5, 9];
            double[] calculated = [3, 3, 8, 7, 6];

            Console.WriteLine(Statistic.MeanAbsoluteError(actual, calculated));

            double[] Y_true = [1, 1, 2, 2, 4];
            double[] Y_pred = [0.6, 1.29, 1.99, 2.69, 3.4];

            Console.WriteLine(Statistic.MeanSquaredError(Y_true, Y_pred));

            double[] expected = [31, 23, 14, 10.5, 6.5];
            double[] experimental = [32.5, 21.9, 15.1, 9, 5.2];

            Console.WriteLine(Statistic.RootMeanSquareError(expected, experimental));
        }

        static void ClassificationTest()
        {
            Matrix X = new Matrix(new double[][]
            {
                [3.78],[2.44],[2.09],[0.14],[1.72],[1.65],[4.92],[4.37],[4.96],[4.52],[3.69],[5.88]
            });

            Matrix y = new Matrix(new double[][]
            {
                [0],[0],[0],[0],[0],[0],[1],[1],[1],[1],[1],[1]
            });

            //BasicModel model = new BasicModel();
            //model.Fit(X, y);
            //Result whatever = model.WorkingFunction;

            //// -0,3522920203735144 0,2546689303904923
            //Console.WriteLine(Utility.ToString(whatever.Data));

            //Matrix linOut = new Matrix(new double[][]
            //{
            //    [-0.352292020373514, 0.2546689303904923]
            //});

            //Logistic log = new Logistic();
            //double result = log.ProcessData(X);
            //Console.WriteLine(result);
        }

    }
}