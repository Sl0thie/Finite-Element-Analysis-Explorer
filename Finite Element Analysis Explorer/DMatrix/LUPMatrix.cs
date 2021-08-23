using System;

namespace Finite_Element_Analysis_Explorer
{
    /// <summary>
    /// LUPMatrix class.
    /// </summary>
    internal class LUPMatrix
    {
        /// <summary>
        /// static matrix methods - consider placing in a class.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="cols">Number of columns.</param>
        /// <returns>Returns an array of the specified.</returns>
        internal static decimal[][] MatrixCreate(int rows, int cols)
        {
            // allocates/creates a matrix initialized to all 0.0. assume rows and cols > 0
            // do error checking here
            decimal[][] result = new decimal[rows][];
            for (int i = 0; i < rows; ++i)
            {
                result[i] = new decimal[cols];
            }

            // for (int i = 0; i < rows; ++i)
            //  for (int j = 0; j < cols; ++j)
            //    result[i][j] = 0.0; // explicit initialization needed in some languages
            return result;
        }

        /// <summary>
        /// Creates a vector.
        /// </summary>
        /// <param name="rows">The number of rows.</param>
        /// <returns>An array of the specified size.</returns>
        internal static decimal[] VectorCreate(int rows)
        {
            // allocates/creates a matrix initialized to all 0.0. assume rows and cols > 0
            // do error checking here
            decimal[] result = new decimal[rows];

            return result;
        }

        /// <summary>
        /// Create random matrix.
        /// </summary>
        /// <param name="rows">The number of rows.</param>
        /// <param name="cols">The number of columns.</param>
        /// <param name="minVal">The minimum value.</param>
        /// <param name="maxVal">The maximum value.</param>
        /// <param name="seed">Seed for the random number generator.</param>
        /// <returns>A two dimensional array that represents the matrix.</returns>
        internal static decimal[][] MatrixRandom(int rows, int cols, decimal minVal, decimal maxVal, int seed)
        {
            // return a matrix with random values
            Random ran = new Random(seed);
            decimal[][] result = MatrixCreate(rows, cols);
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    result[i][j] = ((maxVal - minVal) * (decimal)ran.NextDouble()) + minVal;
                }
            }

            return result;
        }

        /// <summary>
        /// Get matrix identity.
        /// </summary>
        /// <param name="n">n.</param>
        /// <returns>A two dimensional array that represents the matrix.</returns>
        internal static decimal[][] MatrixIdentity(int n)
        {
            // return an n x n Identity matrix
            decimal[][] result = MatrixCreate(n, n);
            for (int i = 0; i < n; ++i)
            {
                result[i][i] = 1.0m;
            }

            return result;
        }

        /// <summary>
        /// Convert matrix to string for output.
        /// </summary>
        /// <param name="matrix">The matrix to convert.</param>
        /// <returns>A string of the matrix.</returns>
        internal static string MatrixAsString(decimal[][] matrix)
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

        /// <summary>
        /// Compare if matrices are equal.
        /// </summary>
        /// <param name="matrixA">The first matrix.</param>
        /// <param name="matrixB">The second matrix.</param>
        /// <param name="epsilon">The epsilon.</param>
        /// <returns>True if the matrices are equal.</returns>
        internal static bool MatrixAreEqual(decimal[][] matrixA, decimal[][] matrixB, decimal epsilon)
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
                    if (Math.Abs(matrixA[i][j] - matrixB[i][j]) > epsilon)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Multiply two matrices.
        /// </summary>
        /// <param name="matrixA">The first matrix.</param>
        /// <param name="matrixB">The second matrix.</param>
        /// <returns>The product of the two matrices.</returns>
        internal static decimal[][] MatrixProduct(decimal[][] matrixA, decimal[][] matrixB)
        {
            int aRows = matrixA.Length;
            int aCols = matrixA[0].Length;
            int bRows = matrixB.Length;
            int bCols = matrixB[0].Length;
            if (aCols != bRows)
            {
                throw new Exception("Non-conformable matrices in MatrixProduct");
            }

            decimal[][] result = MatrixCreate(aRows, bCols);

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

        /// <summary>
        /// Calculate the vector product.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="vector">The vector.</param>
        /// <returns>The product of the two.</returns>
        internal static decimal[] MatrixVectorProduct(decimal[][] matrix, decimal[] vector)
        {
            // result of multiplying an n x m matrix by a m x 1 column vector (yielding an n x 1 column vector)
            int mRows = matrix.Length;
            int mCols = matrix[0].Length;
            int vRows = vector.Length;
            if (mCols != vRows)
            {
                throw new Exception("Non-conformable matrix and vector in MatrixVectorProduct");
            }

            decimal[] result = new decimal[mRows]; // an n x m matrix times a m x 1 column vector is a n x 1 column vector
            for (int i = 0; i < mRows; ++i)
            {
                for (int j = 0; j < mCols; ++j)
                {
                    result[i] += matrix[i][j] * vector[j];
                }
            }

            return result;
        }

        /// <summary>
        /// Decompose matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="perm">The perm.</param>
        /// <param name="toggle">The toggle.</param>
        /// <returns>The decomposed matrix.</returns>
        internal static decimal[][] MatrixDecompose(decimal[][] matrix, out int[] perm, out int toggle)
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

            decimal[][] result = MatrixDuplicate(matrix); // make a copy of the input matrix

            perm = new int[n]; // set up row permutation result
            for (int i = 0; i < n; ++i)
            {
                perm[i] = i;
            }

            toggle = 1; // toggle tracks row swaps. +1 -> even, -1 -> odd. used by MatrixDeterminant

            for (int j = 0; j < n - 1; ++j)
            {
                decimal colMax = Math.Abs(result[j][j]); // find largest value in col j
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
                    decimal[] rowPtr = result[pRow];
                    result[pRow] = result[j];
                    result[j] = rowPtr;

                    int tmp = perm[pRow];
                    perm[pRow] = perm[j];
                    perm[j] = tmp;

                    toggle = -toggle; // adjust the row-swap toggle
                }

                if (Math.Abs(result[j][j]) < 1.0E-20m)
                {
                    return null; // consider a throw
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

        /// <summary>
        /// Calculate the matrix inverse.
        /// </summary>
        /// <param name="matrix">The original matrix.</param>
        /// <returns>The inverse of the matrix.</returns>
        internal static decimal[][] MatrixInverse(decimal[][] matrix)
        {
            int n = matrix.Length;
            decimal[][] result = MatrixDuplicate(matrix);

            int[] perm;
            int toggle;
            decimal[][] lum = MatrixDecompose(matrix, out perm, out toggle);
            if (lum == null)
            {
                throw new Exception("Unable to compute inverse");
            }

            decimal[] b = new decimal[n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == perm[j])
                    {
                        b[j] = 1.0m;
                    }
                    else
                    {
                        b[j] = 0.0m;
                    }
                }

                decimal[] x = HelperSolve(lum, b);

                for (int j = 0; j < n; ++j)
                {
                    result[j][i] = x[j];
                }
            }

            return result;
        }

        /// <summary>
        /// Find the matrix determinant.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>The determinant.</returns>
        internal static decimal MatrixDeterminant(decimal[][] matrix)
        {
            int[] perm;
            int toggle;
            decimal[][] lum = MatrixDecompose(matrix, out perm, out toggle);
            if (lum == null)
            {
                throw new Exception("Unable to compute MatrixDeterminant");
            }

            decimal result = toggle;
            for (int i = 0; i < lum.Length; ++i)
            {
                result *= lum[i][i];
            }

            return result;
        }

        /// <summary>
        /// Solve helper.
        /// </summary>
        /// <param name="luMatrix">The lu.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result.</returns>
        internal static decimal[] HelperSolve(decimal[][] luMatrix, decimal[] b) // helper
        {
            // before calling this helper, permute b using the perm array from MatrixDecompose that generated luMatrix
            int n = luMatrix.Length;
            decimal[] x = new decimal[n];
            b.CopyTo(x, 0);

            for (int i = 1; i < n; ++i)
            {
                decimal sum = x[i];
                for (int j = 0; j < i; ++j)
                {
                    sum -= luMatrix[i][j] * x[j];
                }

                x[i] = sum;
            }

            x[n - 1] /= luMatrix[n - 1][n - 1];
            for (int i = n - 2; i >= 0; --i)
            {
                decimal sum = x[i];
                for (int j = i + 1; j < n; ++j)
                {
                    sum -= luMatrix[i][j] * x[j];
                }

                x[i] = sum / luMatrix[i][i];
            }

            return x;
        }

        /// <summary>
        /// System solver.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result.</returns>
        internal static decimal[] SystemSolve(decimal[][] a, decimal[] b)
        {
            // Solve Ax = b
            int n = a.Length;

            // 1. decompose A
            int[] perm;
            int toggle;
            decimal[][] luMatrix = MatrixDecompose(a, out perm, out toggle);
            if (luMatrix == null)
            {
                return null;
            }

            // 2. permute b according to perm[] into bp
            decimal[] bp = new decimal[b.Length];
            for (int i = 0; i < n; ++i)
            {
                bp[i] = b[perm[i]];
            }

            // 3. call helper
            decimal[] x = HelperSolve(luMatrix, bp);
            return x;
        } // SystemSolve

        /// <summary>
        /// Duplicate the matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>The duplicate.</returns>
        internal static decimal[][] MatrixDuplicate(decimal[][] matrix)
        {
            // allocates/creates a duplicate of a matrix. assumes matrix is not null.
            decimal[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
            for (int i = 0; i < matrix.Length; ++i)
            {
                for (int j = 0; j < matrix[i].Length; ++j)
                {
                    result[i][j] = matrix[i][j];
                }
            }

            return result;
        }

        /// <summary>
        /// Extract lower.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>The lower.</returns>
        internal static decimal[][] ExtractLower(decimal[][] matrix)
        {
            // lower part of a Doolittle decomposition (1.0s on diagonal, 0.0s in upper)
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            decimal[][] result = MatrixCreate(rows, cols);
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (i == j)
                    {
                        result[i][j] = 1.0m;
                    }
                    else if (i > j)
                    {
                        result[i][j] = matrix[i][j];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Extract upper.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>The upper.</returns>
        internal static decimal[][] ExtractUpper(decimal[][] matrix)
        {
            // upper part of a Doolittle decomposition (0.0s in the strictly lower part)
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            decimal[][] result = MatrixCreate(rows, cols);
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

        /// <summary>
        /// Perm array to matrix.
        /// </summary>
        /// <param name="perm">The perm.</param>
        /// <returns>The matrix.</returns>
        internal static decimal[][] PermArrayToMatrix(int[] perm)
        {
            // convert Doolittle perm array to corresponding perm matrix
            int n = perm.Length;
            decimal[][] result = MatrixCreate(n, n);
            for (int i = 0; i < n; ++i)
            {
                result[i][perm[i]] = 1.0m;
            }

            return result;
        }

        /// <summary>
        /// Un-permute.
        /// </summary>
        /// <param name="luProduct">The lu.</param>
        /// <param name="perm">The perm.</param>
        /// <returns>The results.</returns>
        internal static decimal[][] UnPermute(decimal[][] luProduct, int[] perm)
        {
            // unpermute product of Doolittle lower * upper matrix according to perm[]
            // no real use except to demo LU decomposition, or for consistency testing
            decimal[][] result = MatrixDuplicate(luProduct);

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

        /// <summary>
        /// Converts a vector to a string.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The string of the vector.</returns>
        internal static string VectorAsString(decimal[] vector)
        {
            string s = string.Empty;
            for (int i = 0; i < vector.Length; ++i)
            {
                s += vector[i].ToString("E30").PadLeft(8) + Environment.NewLine;
            }

            s += Environment.NewLine;
            return s;
        }

        /// <summary>
        /// Converts a vector to a string.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns>The string of the vector.</returns>
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
