namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// DecimalMatrix class.
    /// </summary>
    internal class DecimalMatrix
    {
        private decimal[,] mInnerMatrix;
        private int mRowCount = 0;

        /// <summary>
        /// Gets the row count.
        /// </summary>
        internal int RowCount
        {
            get { return mRowCount; }
        }

        private int mColumnCount = 0;

        /// <summary>
        /// Gets the column count.
        /// </summary>
        internal int ColumnCount
        {
            get { return mColumnCount; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalMatrix"/> class.
        /// </summary>
        internal DecimalMatrix()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalMatrix"/> class.
        /// </summary>
        /// <param name="rowCount">rowCount.</param>
        /// <param name="columnCount">columnCount.</param>
        internal DecimalMatrix(int rowCount, int columnCount)
        {
            mRowCount = rowCount;
            mColumnCount = columnCount;
            mInnerMatrix = new decimal[rowCount, columnCount];
        }

        /// <summary>
        /// this.
        /// </summary>
        /// <param name="rowNumber">rowNumber.</param>
        /// <param name="columnNumber">columnNumber.</param>
        /// <returns>Result.</returns>
        internal decimal this[int rowNumber, int columnNumber]
        {
            get
            {
                return mInnerMatrix[rowNumber, columnNumber];
            }

            set
            {
                mInnerMatrix[rowNumber, columnNumber] = value;
            }
        }

        /// <summary>
        /// Gets a row.
        /// </summary>
        /// <param name="rowIndex">rowIndex.</param>
        /// <returns>Result.</returns>
        internal decimal[] GetRow(int rowIndex)
        {
            decimal[] rowValues = new decimal[mColumnCount];
            for (int i = 0; i < mColumnCount; i++)
            {
                rowValues[i] = mInnerMatrix[rowIndex, i];
            }

            return rowValues;
        }

        /// <summary>
        /// Sets a row.
        /// </summary>
        /// <param name="rowIndex">rowIndex.</param>
        /// <param name="value">value.</param>
        internal void SetRow(int rowIndex, decimal[] value)
        {
            if (value.Length != mColumnCount)
            {
                throw new Exception("Boyut Uyusmazligi");
            }

            for (int i = 0; i < value.Length; i++)
            {
                mInnerMatrix[rowIndex, i] = value[i];
            }
        }

        /// <summary>
        /// Gets a column.
        /// </summary>
        /// <param name="columnIndex">columnIndex.</param>
        /// <returns>Result.</returns>
        internal decimal[] GetColumn(int columnIndex)
        {
            decimal[] columnValues = new decimal[mRowCount];
            for (int i = 0; i < mRowCount; i++)
            {
                columnValues[i] = mInnerMatrix[i, columnIndex];
            }

            return columnValues;
        }

        /// <summary>
        /// Sets a column.
        /// </summary>
        /// <param name="columnIndex">columnIndex.</param>
        /// <param name="value">value.</param>
        internal void SetColumn(int columnIndex, decimal[] value)
        {
            if (value.Length != mRowCount)
            {
                throw new Exception("Boyut Uyusmazligi");
            }

            for (int i = 0; i < value.Length; i++)
            {
                mInnerMatrix[i, columnIndex] = value[i];
            }
        }

        /// <summary>
        /// Plus operator.
        /// </summary>
        /// <param name="pMatrix1">pMatrix1.</param>
        /// <param name="pMatrix2">pMatrix2.</param>
        /// <returns>Result.</returns>
        public static DecimalMatrix operator +(DecimalMatrix pMatrix1, DecimalMatrix pMatrix2)
        {
            if (!(pMatrix1.RowCount == pMatrix2.RowCount && pMatrix1.ColumnCount == pMatrix2.ColumnCount))
            {
                throw new Exception("Boyut Uyusmazligi");
            }

            DecimalMatrix returnMartix = new DecimalMatrix(pMatrix1.RowCount, pMatrix2.RowCount);
            for (int i = 0; i < pMatrix1.RowCount; i++)
            {
                for (int j = 0; j < pMatrix1.ColumnCount; j++)
                {
                    returnMartix[i, j] = pMatrix1[i, j] + pMatrix2[i, j];
                }
            }

            return returnMartix;
        }

        /// <summary>
        /// Multiplication operator.
        /// </summary>
        /// <param name="scalarValue">scalarValue.</param>
        /// <param name="pMatrix">pMatrix.</param>
        /// <returns>Result.</returns>
        public static DecimalMatrix operator *(decimal scalarValue, DecimalMatrix pMatrix)
        {
            DecimalMatrix returnMartix = new DecimalMatrix(pMatrix.RowCount, pMatrix.RowCount);
            for (int i = 0; i < pMatrix.RowCount; i++)
            {
                for (int j = 0; j < pMatrix.ColumnCount; j++)
                {
                    returnMartix[i, j] = pMatrix[i, j] * scalarValue;
                }
            }

            return returnMartix;
        }

        /// <summary>
        /// Minus operator.
        /// </summary>
        /// <param name="pMatrix1">pMatrix1.</param>
        /// <param name="pMatrix2">pMatrix2.</param>
        /// <returns>Result.</returns>
        public static DecimalMatrix operator -(DecimalMatrix pMatrix1, DecimalMatrix pMatrix2)
        {
            if (!(pMatrix1.RowCount == pMatrix2.RowCount && pMatrix1.ColumnCount == pMatrix2.ColumnCount))
            {
                throw new Exception("Boyut Uyusmazligi");
            }

            return pMatrix1 + (-1 * pMatrix2);
        }

        /// <summary>
        /// Equals operator.
        /// </summary>
        /// <param name="pMatrix1">pMatrix1.</param>
        /// <param name="pMatrix2">pMatrix2.</param>
        /// <returns>Result.</returns>
        public static bool operator ==(DecimalMatrix pMatrix1, DecimalMatrix pMatrix2)
        {
            if (!(pMatrix1.RowCount == pMatrix2.RowCount && pMatrix1.ColumnCount == pMatrix2.ColumnCount))
            {
                return false;
            }

            for (int i = 0; i < pMatrix1.RowCount; i++)
            {
                for (int j = 0; j < pMatrix1.ColumnCount; j++)
                {
                    if (pMatrix1[i, j] != pMatrix2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(DecimalMatrix pMatrix1, DecimalMatrix pMatrix2)
        {
            return !(pMatrix1 == pMatrix2);
        }

        public static DecimalMatrix operator -(DecimalMatrix pMatrix)
        {
            return -1 * pMatrix;
        }

        public static DecimalMatrix operator ++(DecimalMatrix pMatrix)
        {
            for (int i = 0; i < pMatrix.RowCount; i++)
            {
                for (int j = 0; j < pMatrix.ColumnCount; j++)
                {
                    pMatrix[i, j] += 1;
                }
            }

            return pMatrix;
        }

        public static DecimalMatrix operator --(DecimalMatrix pMatrix)
        {
            for (int i = 0; i < pMatrix.RowCount; i++)
            {
                for (int j = 0; j < pMatrix.ColumnCount; j++)
                {
                    pMatrix[i, j] -= 1;
                }
            }

            return pMatrix;
        }

        public static DecimalMatrix operator *(DecimalMatrix pMatrix1, DecimalMatrix pMatrix2)
        {
            if (pMatrix1.ColumnCount != pMatrix2.RowCount)
            {
                throw new Exception("Boyut Uyusmazligi");
            }

            DecimalMatrix returnMatrix = new DecimalMatrix(pMatrix1.RowCount, pMatrix2.ColumnCount);
            for (int i = 0; i < pMatrix1.RowCount; i++)
            {
                decimal[] rowValues = pMatrix1.GetRow(i);
                for (int j = 0; j < pMatrix2.ColumnCount; j++)
                {
                    decimal[] columnValues = pMatrix2.GetColumn(j);
                    decimal value = 0;
                    for (int a = 0; a < rowValues.Length; a++)
                    {
                        value += rowValues[a] * columnValues[a];
                    }

                    returnMatrix[i, j] = value;
                }
            }

            return returnMatrix;
        }

        /// <summary>
        /// Transposes the matrix.
        /// </summary>
        /// <returns>Result.</returns>
        internal DecimalMatrix Transpose()
        {
            DecimalMatrix mReturnMartix = new DecimalMatrix(ColumnCount, RowCount);
            for (int i = 0; i < mRowCount; i++)
            {
                for (int j = 0; j < mColumnCount; j++)
                {
                    mReturnMartix[j, i] = mInnerMatrix[i, j];
                }
            }

            return mReturnMartix;
        }

        /// <summary>
        /// Are the objects equal?.
        /// </summary>
        /// <param name="obj">obj.</param>
        /// <returns>Result.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>Result.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Is zero matrix.
        /// </summary>
        /// <returns>Result.</returns>
        internal bool IsZeroMatrix()
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (mInnerMatrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Is the matrix square.
        /// </summary>
        /// <returns>Result.</returns>
        internal bool IsSquareMatrix()
        {
            return RowCount == ColumnCount;
        }

        /// <summary>
        /// Is the lower triangle.
        /// </summary>
        /// <returns>Result.</returns>
        internal bool IsLowerTriangle()
        {
            if (!IsSquareMatrix())
            {
                return false;
            }

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = i + 1; j < ColumnCount; j++)
                {
                    if (mInnerMatrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Is upper triangle.
        /// </summary>
        /// <returns>Result.</returns>
        internal bool IsUpperTriangle()
        {
            if (!IsSquareMatrix())
            {
                return false;
            }

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (mInnerMatrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Is diagonal matrix.
        /// </summary>
        /// <returns>Result.</returns>
        internal bool IsDiagonalMatrix()
        {
            if (!IsSquareMatrix())
            {
                return false;
            }

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (i != j && mInnerMatrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Is identity matrix.
        /// </summary>
        /// <returns>Result.</returns>
        internal bool IsIdentityMatrix()
        {
            if (!IsSquareMatrix())
            {
                return false;
            }

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    decimal checkValue = 0;
                    if (i == j)
                    {
                        checkValue = 1;
                    }

                    if (mInnerMatrix[i, j] != checkValue)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Is symmetric matrix.
        /// </summary>
        /// <returns>Result.</returns>
        internal bool IsSymetricMatrix()
        {
            if (!IsSquareMatrix())
            {
                return false;
            }

            DecimalMatrix transposeMatrix = Transpose();
            if (this == transposeMatrix)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Write to the debug output.
        /// </summary>
        /// <param name="titleText">titleText.</param>
        internal void WriteToDebug(string titleText)
        {
            Debug.WriteLine(titleText + "Matrix Content");
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    Debug.Write(mInnerMatrix[i, j].ToString() + "  ");
                }

                Debug.Write("\n");
            }
        }
    }
}