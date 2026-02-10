using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Optimisation_Methods
{
    internal class Gradient_Descent
    {
        double f(double x) => Math.Pow(x, 2); // funckija koju minimiziramo
        double grad_f(double x) => 2 * x; //njen gradijent - derivacija
        double x = 10.0; // početna vrijednost idk
        double lr = 0.001; // learning rate
        int n_iters = 10000; // broj iteracija
        double tol_e = 1e-6; // idk

        public Gradient_Descent(double f, double grad_f, double x, double lr, int n_iters, double tol_e)
        {
            this.x = x;
            this.lr = lr;
            this.n_iters = n_iters;
            this.tol_e = tol_e;
        }

        public (double, double[]) Gradient_Descent_2D()
        {


            return (0, new double[0]);
        }
    }
}
