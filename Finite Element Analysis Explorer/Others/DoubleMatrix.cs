using System;

namespace Finite_Element_Analysis_Explorer
{
    internal class DoubleMatrix
    {
        internal static double[][] MatrixCreate(int rows, int cols)
        {
            // allocates/creates a matrix initialized to all 0.0. assume rows and cols > 0
            // do error checking here
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
            {
                result[i] = new double[cols];
            }

            return result;
        }

        internal static double[] VectorCreate(int rows)
        {
            // allocates/creates a matrix initialized to all 0.0. assume rows and cols > 0
            // do error checking here
            double[] result = new double[rows];

            return result;
        }

        internal static double[][] MatrixRandom(int rows, int cols, double minVal, double maxVal, int seed)
        {
            // return a matrix with random values
            Random ran = new Random(seed);
            double[][] result = MatrixCreate(rows, cols);
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    result[i][j] = ((maxVal - minVal) * (double)ran.NextDouble()) + minVal;
                }
            }

            return result;
        }

        internal static double[][] MatrixIdentity(int n)
        {
            // return an n x n Identity matrix
            double[][] result = MatrixCreate(n, n);
            for (int i = 0; i < n; ++i)
            {
                result[i][i] = 1.0;
            }

            return result;
        }

        internal static string MatrixAsString(double[][] matrix)
        {
            string s = string.Empty;
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[i].Length; ++j)
                {
                    s += matrix[i][j].ToString("F3").PadLeft(8) + " ";
                }

                s += Environment.NewLine;
            }

            return s;
        }

        internal static bool MatrixAreEqual(double[][] matrixA, double[][] matrixB, double epsilon)
        {
            // true if all values in matrixA == corresponding values in matrixB
            int aRows = matrixA.Length;
            int aCols = matrixA[0].Length;
            int bRows = matrixB.Length;
            int bCols = matrixB[0].Length;
            if (aRows != bRows || aCols != bCols)
            {
                throw new Exception("Non-conformable matrices in MatrixAreEqual");
            }

            for (int i = 0; i < aRows; ++i)
            {
                for (int j = 0; j < aCols; ++j)
                {
                    // if (matrixA[i][j] != matrixB[i][j])
                    if (Math.Abs(matrixA[i][j] - matrixB[i][j]) > epsilon)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        internal static double[][] MatrixProduct(double[][] matrixA, double[][] matrixB)
        {
            int aRows = matrixA.Length;
            int aCols = matrixA[0].Length;
            int bRows = matrixB.Length;
            int bCols = matrixB[0].Length;
            if (aCols != bRows)
            {
                throw new Exception("Non-conformable matrices in MatrixProduct");
            }

            double[][] result = MatrixCreate(aRows, bCols);

            for (int i = 0; i < aRows; ++i)
            {
                for (int j = 0; j < bCols; ++j)
                {
                    for (int k = 0; k < aCols; ++k)
                    {
                        result[i][j] += matrixA[i][k] * matrixB[k][j];
                    }
                }
            }

            return result;
        }

        internal static double[] MatrixVectorProduct(double[][] matrix, double[] vector)
        {
            // result of multiplying an n x m matrix by a m x 1 column vector (yielding an n x 1 column vector)
            int mRows = matrix.Length;
            int mCols = matrix[0].Length;
            int vRows = vector.Length;
            if (mCols != vRows)
            {
                throw new Exception("Non-conformable matrix and vector in MatrixVectorProduct");
            }

            double[] result = new double[mRows]; // an n x m matrix times a m x 1 column vector is a n x 1 column vector
            for (int i = 0; i < mRows; ++i)
            {
                for (int j = 0; j < mCols; ++j)
                {
                    result[i] += matrix[i][j] * vector[j];
                }
            }

            return result;
        }

        internal static double[][] MatrixDecompose(double[][] matrix, out int[] perm, out int toggle)
        {
            // Doolittle LUP decomposition with partial pivoting.
            // returns: result is L (with 1s on diagonal) and U; perm holds row permutations; toggle is +1 or -1 (even or odd)
            int rows = matrix.Length;
            int cols = matrix[0].Length; // assume all rows have the same number of columns so just use row [0].
            if (rows != cols)
            {
                throw new Exception("Attempt to MatrixDecompose a non-square matrix");
            }

            int n = rows; // convenience

            double[][] result = MatrixDuplicate(matrix); // make a copy of the input matrix

            perm = new int[n]; // set up row permutation result
            for (int i = 0; i < n; ++i)
            {
                perm[i] = i;
            }

            toggle = 1; // toggle tracks row swaps. +1 -> even, -1 -> odd. used by MatrixDeterminant

            for (int j = 0; j < n - 1; ++j)
            {
                double colMax = Math.Abs(result[j][j]); // find largest value in col j
                int pRow = j;
                for (int i = j + 1; i < n; ++i)
                {
                    if (result[i][j] > colMax)
                    {
                        colMax = result[i][j];
                        pRow = i;
                    }
                }

                if (pRow != j)
                {
                    double[] rowPtr = result[pRow];
                    result[pRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[pRow];
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle;
                }

                if (Math.Abs(result[j][j]) < 1.0E-20)
                {
                    return null;
                }

                for (int i = j + 1; i < n; ++i)
                {
                    result[i][j] /= result[j][j];
                    for (int k = j + 1; k < n; ++k)
                    {
                        result[i][k] -= result[i][j] * result[j][k];
                    }
                }
            } // main j column loop

            return result;
        } // MatrixDecompose

        internal static double[][] MatrixInverse(double[][] matrix)
        {
            int n = matrix.Length;
            double[][] result = MatrixDuplicate(matrix);

            int[] perm;
            int toggle;
            double[][] lum = MatrixDecompose(matrix, out perm, out toggle);
            if (lum == null)
            {
                throw new Exception("Unable to compute inverse");
            }

            double[] b = new double[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                    {
                        b[j] = 1.0;
                    }
                    else
                    {
                        b[j] = 0.0;
                    }
                }

                double[] x = HelperSolve(lum, b);

                for (int j = 0; j < n; ++j)
                {
                    result[j][i] = x[j];
                }
            }

            return result;
        }

        internal static double MatrixDeterminant(double[][] matrix)
        {
            int[] perm;
            int toggle;
            double[][] lum = MatrixDecompose(matrix, out perm, out toggle);
            if (lum == null)
            {
                throw new Exception("Unable to compute MatrixDeterminant");
            }

            double result = toggle;
            for (int i = 0; i < lum.Length; ++i)
            {
                result *= lum[i][i];
            }

            return result;
        }

        internal static double[] HelperSolve(double[][] luMatrix, double[] b) // helper
        {
            // before calling this helper, permute b using the perm array from MatrixDecompose that generated luMatrix
            int n = luMatrix.Length;
            double[] x = new double[n];
            b.CopyTo(x, 0);

            for (int i = 1; i < n; ++i)
            {
                double sum = x[i];
                for (int j = 0; j < i; ++j)
                {
                    sum -= luMatrix[i][j] * x[j];
                }

                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1][n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                double sum = x[i];
                for (int j = i + 1; j < n; ++j)
                {
                    sum -= luMatrix[i][j] * x[j];
                }

                x[i] = sum / luMatrix[i][i];
            }

            return x;
        }

        internal static double[] SystemSolve(double[][] a, double[] b)
        {
            // Solve Ax = b
            int n = a.Length;

            // 1. decompose A
            int[] perm;
            int toggle;
            double[][] luMatrix = MatrixDecompose(a, out perm, out toggle);
            if (luMatrix == null)
            {
                return null;
            }

            // 2. permute b according to perm[] into bp
            double[] bp = new double[b.Length];
            for (int i = 0; i < n; ++i)
            {
                bp[i] = b[perm[i]];
            }

            // 3. call helper
            double[] x = HelperSolve(luMatrix, bp);
            return x;
        } // SystemSolve

        internal static double[][] MatrixDuplicate(double[][] matrix)
        {
            // allocates/creates a duplicate of a matrix. assumes matrix is not null.
            double[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[i].Length; ++j)
                {
                    result[i][j] = matrix[i][j];
                }
            }

            return result;
        }

        internal static double[][] ExtractLower(double[][] matrix)
        {
            // lower part of a Doolittle decomposition (1.0s on diagonal, 0.0s in upper)
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            double[][] result = MatrixCreate(rows, cols);
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (i == j)
                    {
                        result[i][j] = 1.0;
                    }
                    else if (i > j)
                    {
                        result[i][j] = matrix[i][j];
                    }
                }
            }

            return result;
        }

        internal static double[][] ExtractUpper(double[][] matrix)
        {
            // upper part of a Doolittle decomposition (0.0s in the strictly lower part)
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            double[][] result = MatrixCreate(rows, cols);
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (i <= j)
                    {
                        result[i][j] = matrix[i][j];
                    }
                }
            }

            return result;
        }

        internal static double[][] PermArrayToMatrix(int[] perm)
        {
            // convert Doolittle perm array to corresponding perm matrix
            int n = perm.Length;
            double[][] result = MatrixCreate(n, n);
            for (int i = 0; i < n; ++i)
            {
                result[i][perm[i]] = 1.0;
            }

            return result;
        }

        internal static double[][] UnPermute(double[][] luProduct, int[] perm)
        {
            // unpermute product of Doolittle lower * upper matrix according to perm[]
            // no real use except to demo LU decomposition, or for consistency testing
            double[][] result = MatrixDuplicate(luProduct);

            int[] unperm = new int[perm.Length];
            for (int i = 0; i < perm.Length; ++i)
            {
                unperm[perm[i]] = i;
            }

            for (int r = 0; r < luProduct.Length; ++r)
            {
                result[r] = luProduct[unperm[r]];
            }

            return result;
        } // UnPermute

        internal static string VectorAsString(double[] vector)
        {
            string s = string.Empty;
            for (int i = 0; i < vector.Length; ++i)
            {
                s += vector[i].ToString("F3").PadLeft(8) + Environment.NewLine;
            }

            s += Environment.NewLine;
            return s;
        }

        internal static string VectorAsString(int[] vector)
        {
            string s = string.Empty;
            for (int i = 0; i < vector.Length; ++i)
            {
                s += vector[i].ToString().PadLeft(2) + " ";
            }

            s += Environment.NewLine;
            return s;
        }
    }
}
