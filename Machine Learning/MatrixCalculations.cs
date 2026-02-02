using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Machine_Learning
{
    internal static class Matrix
    {

        public static double[][] Multiply(double scalar, double[][] matrix)
        {
            var (rows, columns) = GetDimensions(matrix);

            Console.WriteLine($"Rows: {rows}, columns: {columns}");

            for(int i = 0; i < rows; i++)
                for(int j = 0; j < columns; j++)
                    matrix[i][j] *= scalar;

            return matrix;
        }

        public static double[][] Multiply(double[][] lhs, double[][] rhs)
        {
            var (lRow, lColumn) = GetDimensions(lhs);
            var (rRow, rColumn) = GetDimensions(rhs);

            if (lColumn != rRow)
                throw new Exception("Matrices can't be multiplied because dimensions don't match...");

            double[][] product = new double[lRow][];
            for (int i = 0; i < product.Length; i++)
                product[i] = new double[rColumn];

            for(int i = 0; i < lRow; i++)
            {
                for(int j = 0; j < rColumn; j++)
                {
                    double buffer = 0;
                    for(int k = 0; k < lColumn; k++)
                        buffer += lhs[i][k] * rhs[k][j];
                    product[i][j] = buffer;
                }
            }

            return product;
        }

        public static double Determinant(double[][] matrix)
        {
            double determinant = 0;
            double res = 0;
            var (rows, columns) = GetDimensions(matrix);
            if (rows != columns)
                throw new Exception("Only square matrices have determinant...");

            if (rows == 1)
                return matrix[0][0];

            if (rows == 2)
                return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];

            for(int col = 0; col < rows; col++)
            {
                double[][] sub = new double[rows - 1][];
                for (int i = 0; i < rows-1; i++)
                    sub[i] = new double[rows-1];

                for(int i = 1; i < rows; i++)
                {
                    int subcol = 0;
                    for(int j = 0; j < rows; j++)
                    {
                        if (j == col)
                            continue;

                        sub[i - 1][subcol++] = matrix[i][j];
                    }
                }

                int sign = (col % 2 == 0) ? 1 : -1;
                res += sign * matrix[0][col] * Determinant(sub);
            }

            return res;
        }

        public static double[][] Inverse(double[][] matrix)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            int n = matrix.Length;
            if (n == 0) throw new ArgumentException("Matrix has no rows.", nameof(matrix));
            int m = matrix[0]?.Length ?? throw new ArgumentException("Row 0 is null.", nameof(matrix));
            if (m != n) throw new Exception("Only square matrices have an inverse...");

            // Validate rectangular
            for (int i = 0; i < n; i++)
                if (matrix[i] == null || matrix[i].Length != n)
                    throw new ArgumentException("Matrix must be rectangular and square.", nameof(matrix));

            // Build augmented matrix [A | I] in double
            double[][] aug = new double[n][];
            for (int i = 0; i < n; i++)
            {
                aug[i] = new double[2 * n];
                for (int j = 0; j < n; j++)
                    aug[i][j] = matrix[i][j];
                aug[i][n + i] = 1.0;
            }

            const double eps = 1e-12;

            // Gauss–Jordan elimination with partial pivoting
            for (int col = 0; col < n; col++)
            {
                // Find pivot row with max abs value in this column
                int pivotRow = col;
                double maxAbs = Math.Abs(aug[col][col]);
                for (int r = col + 1; r < n; r++)
                {
                    double v = Math.Abs(aug[r][col]);
                    if (v > maxAbs)
                    {
                        maxAbs = v;
                        pivotRow = r;
                    }
                }

                if (maxAbs < eps)
                    throw new Exception("Matrix is singular (no inverse).");

                // Swap current row with pivotRow
                if (pivotRow != col)
                {
                    var tmp = aug[col];
                    aug[col] = aug[pivotRow];
                    aug[pivotRow] = tmp;
                }

                // Normalize pivot row
                double pivot = aug[col][col];
                for (int j = 0; j < 2 * n; j++)
                    aug[col][j] /= pivot;

                // Eliminate this column in all other rows
                for (int r = 0; r < n; r++)
                {
                    if (r == col) continue;
                    double factor = aug[r][col];
                    if (Math.Abs(factor) < eps) continue;

                    for (int j = 0; j < 2 * n; j++)
                        aug[r][j] -= factor * aug[col][j];
                }
            }

            // Extract inverse from right half
            double[][] inv = new double[n][];
            for (int i = 0; i < n; i++)
            {
                inv[i] = new double[n];
                Array.Copy(aug[i], n, inv[i], 0, n);
            }

            return inv;
        }

        public static double[][] Transpose(double[][] matrix)
        {
            var (rows, columns) = GetDimensions(matrix);

            double[][] transposed = new double[columns][];
            for (int i = 0; i < transposed.Length; i++)
                transposed[i] = new double[rows];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    transposed[j][i] = matrix[i][j];

            return transposed;
        }

        public static string ToString(double[][] matrix)
        {
            var (rows, columns) = GetDimensions(matrix);
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    s.Append(matrix[i][j]+" ");
                s.Append("\n");
            }

            return s.ToString();
        }

        public static string ToString(double[] matrix)
        {
            StringBuilder s = new StringBuilder();
            
            for(int i = 0; i < matrix.Length; i++)
                s.Append(matrix[i]+" ");
            s.Append("\n");

            return s.ToString();
        }

        public static (int, int) GetDimensions(double[][] matrix) => (matrix.Length, matrix[0].Length);
    }
}
