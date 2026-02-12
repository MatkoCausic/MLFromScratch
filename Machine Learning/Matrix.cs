using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Machine_Learning
{
    internal class Matrix
    {
        double[][] data;
        int rows;
        int columns;

        public double[][] Data
        {
            get { return data; }
            set { data = value; }
        }
        public int Rows
        {
            get { return rows; }
        }
        public int Columns
        {
            get { return columns; }
        }

        
        public Matrix(int rows, int columns)
        {
            Data = new double[rows][];
            for (int i = 0; i < rows; i++)
                Data[i] = new double[columns];

            this.rows = rows;
            this.columns = columns;
        }

        public Matrix(double[][] data)
        {
            this.Data = data ?? throw new ArgumentNullException(nameof(data));
            this.rows = data.Length;
            this.columns = (data.Length > 0 && data[0] != null) ? data[0].Length : 0;
        }

        public static Matrix operator *(double scalar, Matrix matrix)
        {
            Matrix product = new Matrix(matrix.Rows, matrix.Columns);

            for (int i = 0; i < matrix.Rows; i++)
                for (int j = 0; j < matrix.Columns; j++)
                    product.Data[i][j] = matrix.Data[i][j] * scalar;

            return product;
        }

        public static Matrix operator* (Matrix lhs, Matrix rhs)
        {
            if(lhs.Columns != rhs.Rows) 
            {
                Console.WriteLine("Matrices that can not multiply");
                Console.WriteLine(lhs.ToString());
                Console.WriteLine(rhs.ToString());
                throw new Exception("Matrices can't be multiplied because dimensions don't match...");
            }

            Matrix product = new Matrix(lhs.Rows, rhs.Columns);

            for(int i = 0; i < product.Rows; i++)
            {
                for(int j = 0; j < product.Columns; j++)
                {
                    double buffer = 0;
                    for (int k = 0; k < lhs.Columns; k++)
                        buffer += lhs.Data[i][k] * rhs.Data[k][j];
                    product.Data[i][j] = buffer;
                }
            }

            return product;
        }
        
        public static Matrix operator+ (Matrix lhs, Matrix rhs)
        {
            if (lhs.Rows != rhs.Rows || lhs.Columns != rhs.Columns)
                throw new Exception("Matrices can't be summed because dimensions don't match...");

            Matrix sum = new Matrix(lhs.Rows, lhs.Columns);

            for (int i = 0; i < sum.Rows; i++)
                for (int j = 0; j < sum.Columns; j++)
                    sum.Data[i][j] = lhs.Data[i][j] + rhs.Data[i][j];

            return sum;
        }

        public double Determinant()
        {
            double res = 0;

            if (Rows != Columns)
                throw new Exception("Only square matrices have determinant...");

            if (Rows == 1)
                return this.Data[0][0];

            if (Rows == 2)
                return this.Data[0][0] * this.Data[1][1] - this.Data[0][1] * this.Data[1][0];

            for (int col = 0; col < Rows; col++)
            {
                Matrix sub = new Matrix(Rows - 1, Rows - 1);
                //double[][] sub = new double[Rows - 1][];
                //for (int i = 0; i < Rows - 1; i++)
                //    sub[i] = new double[Rows - 1];

                for (int i = 1; i < Rows; i++)
                {
                    int subcol = 0;
                    for (int j = 0; j < Rows; j++)
                    {
                        if (j == col)
                            continue;

                        sub.Data[i - 1][subcol++] = this.Data[i][j];
                    }
                }

                int sign = (col % 2 == 0) ? 1 : -1;
                res += sign * this.Data[0][col] * sub.Determinant();
            }

            return res;
        }

        #region CHATGPT INVERSE

        public Matrix Inverse(
            double eps = 1e-12,
            int regularizationTries = 12,
            double lambdaStart = 1e-12,
            double lambdaGrowth = 10.0
            )
        {
            if (Data == null) throw new ArgumentNullException(nameof(this.Data));
            if (Rows == 0) throw new ArgumentException("Matrix has no rows.", nameof(this.Data));
            if (Rows != Columns) throw new Exception("Only square matrices have an inverse...");

            for (int i = 0; i < Rows; i++)
                if (Data[i] == null || Data[i].Length != Rows)
                    throw new ArgumentException("Matrix must be rectangular and square.", nameof(this.Data));

            // A) Gauss–Jordan (strict)
            if (TryInverseGaussJordan(this, out Matrix invGJ, eps))
            {
                //Console.WriteLine("invGJ:");
                //Console.WriteLine(invGJ.ToString());
                return invGJ;
            }

            // B) LU (strict)
            if (TryInverseLU(this, out Matrix invLU, eps))
            {
                //Console.WriteLine("invLU:");
                //Console.WriteLine(invLU.ToString());
                return invLU;
            }

            // C) Fallback: regularizirani "inverz" (aproksimacija)
            // Invertiramo A + λI, sa rastućim λ dok ne postane stabilno.
            double lambda = lambdaStart;
            for (int t = 0; t < regularizationTries; t++)
            {
                Matrix reg = this.Copy();
                for (int d = 0; d < reg.Rows; d++)
                    reg.Data[d][d] += lambda;

                if (TryInverseGaussJordan(reg, out Matrix invRegGJ, eps))
                {
                    //Console.WriteLine("invRegGJ:");
                    //Console.WriteLine(invRegGJ.ToString());
                    return invRegGJ;
                }

                if (TryInverseLU(reg, out Matrix invRegLU, eps))
                {
                    //Console.WriteLine("invRegLU:");
                    //Console.WriteLine(invRegLU.ToString());
                    return invRegLU;
                }

                lambda *= lambdaGrowth;
            }

            throw new Exception("Matrix is singular/ill-conditioned: inverse failed even after regularization.");
        }

        private static bool TryInverseGaussJordan(Matrix a, out Matrix inv, double eps)
        {
            inv = null;

            int n = a.Rows;
            Matrix aug = new Matrix(n, 2 * n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    aug.Data[i][j] = a.Data[i][j];
                aug.Data[i][n + i] = 1.0;
            }

            for (int col = 0; col < n; col++)
            {
                int pivotRow = col;
                double maxAbs = Math.Abs(aug.Data[col][col]);

                for (int r = col + 1; r < n; r++)
                {
                    double v = Math.Abs(aug.Data[r][col]);
                    if (v > maxAbs)
                    {
                        maxAbs = v;
                        pivotRow = r;
                    }
                }

                if (maxAbs < eps) return false;

                if (pivotRow != col)
                {
                    var tmp = aug.Data[col];
                    aug.Data[col] = aug.Data[pivotRow];
                    aug.Data[pivotRow] = tmp;
                }

                double pivot = aug.Data[col][col];
                for (int j = 0; j < 2 * n; j++)
                    aug.Data[col][j] /= pivot;

                for (int r = 0; r < n; r++)
                {
                    if (r == col) continue;

                    double factor = aug.Data[r][col];
                    if (Math.Abs(factor) < eps) continue;

                    for (int j = 0; j < 2 * n; j++)
                        aug.Data[r][j] -= factor * aug.Data[col][j];
                }
            }

            inv = new Matrix(n, n);
            for (int i = 0; i < n; i++)
                Array.Copy(aug.Data[i], n, inv.Data[i], 0, n);

            return true;
        }

        // -------------------- Strategy B: LU (Doolittle + pivoting) --------------------
        private static bool TryInverseLU(Matrix a, out Matrix inv, double eps)
        {
            inv = null;

            int n = a.Rows;
            double[][] lu = new double[n][];
            for (int i = 0; i < n; i++)
            {
                lu[i] = new double[n];
                Array.Copy(a.Data[i], 0, lu[i], 0, n);
            }

            int[] piv = new int[n];
            for (int i = 0; i < n; i++) piv[i] = i;

            // LU factorization with partial pivoting
            for (int k = 0; k < n; k++)
            {
                int p = k;
                double max = Math.Abs(lu[k][k]);
                for (int i = k + 1; i < n; i++)
                {
                    double v = Math.Abs(lu[i][k]);
                    if (v > max)
                    {
                        max = v;
                        p = i;
                    }
                }

                if (max < eps) return false;

                if (p != k)
                {
                    var tmpRow = lu[k];
                    lu[k] = lu[p];
                    lu[p] = tmpRow;

                    int tmpP = piv[k];
                    piv[k] = piv[p];
                    piv[p] = tmpP;
                }

                double pivot = lu[k][k];
                for (int i = k + 1; i < n; i++)
                {
                    lu[i][k] /= pivot;
                    double lik = lu[i][k];
                    for (int j = k + 1; j < n; j++)
                        lu[i][j] -= lik * lu[k][j];
                }
            }

            inv = new Matrix(n, n);

            // Solve for each column of identity
            double[] b = new double[n];
            double[] y = new double[n];
            double[] x = new double[n];

            for (int col = 0; col < n; col++)
            {
                // b = e_col
                for (int i = 0; i < n; i++) b[i] = 0.0;
                b[col] = 1.0;

                // Apply pivot: bp[i] = b[piv[i]]
                // Forward substitution: Ly = bp  (L has 1s on diagonal)
                for (int i = 0; i < n; i++)
                {
                    double sum = b[piv[i]];
                    for (int j = 0; j < i; j++)
                        sum -= lu[i][j] * y[j];
                    y[i] = sum;
                }

                // Back substitution: Ux = y
                for (int i = n - 1; i >= 0; i--)
                {
                    double sum = y[i];
                    for (int j = i + 1; j < n; j++)
                        sum -= lu[i][j] * x[j];

                    double ui = lu[i][i];
                    if (Math.Abs(ui) < eps) return false;

                    x[i] = sum / ui;
                }

                // Write solution as column in inverse
                for (int r = 0; r < n; r++)
                    inv.Data[r][col] = x[r];
            }

            return true;
        }

        //public Matrix Inverse()
        //{
        //    if(data == null)
        //        throw new ArgumentNullException(nameof(this.Data));
        //    int n = Rows;
        //    if (n == 0)
        //        throw new ArgumentException("Matrix has no rows.", nameof(this.Data));
        //    int m = Columns; //?? throw new ArgumentException("Row 0 is null.", nameof(this.Data));
        //    if(m != n)
        //        throw new Exception("Only square matrices have an inverse...");

        //    // Validate rectangular
        //    for (int i = 0; i < n; i++)
        //        if (this.Data[i] == null || this.Data[i].Length != n)
        //            throw new ArgumentException("Matrix must be rectangular and square.", nameof(this.Data));

        //    // Build augmented matrix [A | I] in double
        //    Matrix aug = new Matrix(n, 2*n);
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n; j++)
        //            aug.Data[i][j] = this.Data[i][j];
        //        aug.Data[i][n + i] = 1.0;
        //    }

        //    const double eps = 1e-12;

        //    // Gauss–Jordan elimination with partial pivoting
        //    for(int col = 0; col < n; col++)
        //    {
        //        // Find pivot row with max abs value in this column
        //        int pivotRow = col;
        //        double maxAbs = Math.Abs(aug.Data[col][col]);
        //        for(int r = col+1; r < n; r++)
        //        {
        //            double v = Math.Abs(aug.Data[r][col]);
        //            if(v > maxAbs)
        //            {
        //                maxAbs = v;
        //                pivotRow = r;
        //            }
        //        }

        //        if (maxAbs < eps)
        //            throw new Exception("Matirx is singular (no inverse).");

        //        // Swap current row with pivotRow
        //        if(pivotRow != col)
        //        {
        //            var tmp = aug.Data[col];
        //            aug.Data[col] = aug.Data[pivotRow];
        //            aug.Data[pivotRow] = tmp;
        //        }

        //        // Normalize pivot row
        //        double pivot = aug.Data[col][col];
        //        for (int j = 0; j < 2 * n; j++)
        //            aug.Data[col][j] /= pivot;

        //        // Eliminate this column in all other rows
        //        for(int r = 0; r < n; r++)
        //        {
        //            if (r == col)
        //                continue;
        //            double factor = aug.Data[r][col];
        //            if (Math.Abs(factor) < eps)
        //                continue;

        //            for (int j = 0; j < 2 * n; j++)
        //                aug.Data[r][j] -= factor * aug.Data[col][j];
        //        }
        //    }

        //    Matrix inv = new Matrix(n, n);
        //    for (int i = 0; i < n; i++)
        //        Array.Copy(aug.Data[i], n, inv.Data[i], 0, n);

        //    return inv;
        //}

        public Matrix Copy()
        {
            Matrix c = new Matrix(Rows, Columns);
            for (int i = 0; i < Rows; i++)
                Array.Copy(Data[i], 0, c.Data[i], 0, Columns);
            return c;
        }
        #endregion
        public Matrix Transpose()
        {
            Matrix transposed = new Matrix(Columns, Rows);

            for(int i = 0; i < Rows; i++)
                for(int j = 0; j < Columns; j++)
                    transposed.Data[j][i] = this.Data[i][j];

            return transposed;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                    sb.Append(this.Data[i][j] + " ");
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public Matrix Intercept()
        {
            int newMatrixColumns = Columns + 1;

            Matrix interceptedMatrix = new Matrix(Rows, newMatrixColumns);

            for(int i = 0; i < Rows; i++)
            {
                for(int j = 0; j < newMatrixColumns; j++)
                {
                    if (j == 0)
                        interceptedMatrix.Data[i][j] = 1;
                    else
                        interceptedMatrix.Data[i][j] = this.Data[i][j - 1];
                }
            }

            return interceptedMatrix;
        }

        // Singular - square by rows
        public Matrix Singular()
        {
            Matrix singular = new Matrix(Rows, Rows);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (i == j)
                        singular.Data[i][j] = 1;
                    else
                        singular.Data[i][j] = 0;
                }
            }

            return singular;
        }
    }
}
