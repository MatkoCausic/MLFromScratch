using Machine_Learning.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace Machine_Learning.Optimisation_Methods
{
    internal class Gradient_Ascent
    {
        Func<double, double> f, grad_f; // funkcija koju maksimiziramo, njen gradijent - derivacija
        List<double> x; // početne koordinate x0
        double lr; // learning rate
        int n_iters; // broj iteracija
        double tol; // idk

        public Gradient_Ascent(
            Func<double, double> f, Func<double, double> grad_f, List<double> input,
            List<double> x0, double lr = 0.001, int n_iters = 10000, double tol = 1e-6
            )
        {
            this.f = f;
            this.grad_f = grad_f;
            this.x = new List<double>(x0);
            this.lr = lr;
            this.n_iters = n_iters;
            this.tol = tol;
        }

        public (List<double>, List<double>) Gradient_Ascent_2D()
        {
            List<double> values = new List<double>();

            for(int i = 0; i < n_iters; i++)
            {
                List<double> g = grad_F(grad_f,x);
                if(Utility.Norm(g) < tol)
                {
                    Console.WriteLine($"Konvergencija postignuta u iteraciji {i}.");
                    break;
                }

                for (int j = 0; j < x.Count; j++)
                    // GRADIENT ASCENT
                    x[j] = x[j] + lr * g[j];

                values.Add(F(f,x));
            }

            return (new List<double>(x), values);
        }

        static double F(Func<double, double> f, List<double> input)
        {
            double output = 0;
            foreach (var item in input)
                output += f(item);

            return output;
        }

        static List<double> grad_F(Func<double, double> grad_f, List<double> input)
        {
            List<double> output = new List<double>(input.Count);
            foreach (double x in input)
                output.Add(grad_f(x));

            return output;
        }
    }
}
