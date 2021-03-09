using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Finite_Element_Analysis_Explorer
{
    internal class DecimalMatrix
    {
        private decimal[,] mInnerMatrix;
        private int mRowCount = 0;
        internal int RowCount
        {
            get { return mRowCount; }
        }
        private int mColumnCount = 0;
        internal int ColumnCount
        {
            get { return mColumnCount; }
        }

        internal DecimalMatrix()
        {

        }
        internal DecimalMatrix(int rowCount, int columnCount)
        {
            mRowCount = rowCount;
            mColumnCount = columnCount;
            mInnerMatrix = new decimal[rowCount, columnCount];
        }

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

        internal decimal[] GetRow(int rowIndex)
        {
            decimal[] rowValues = new decimal[mColumnCount];
            for (int i = 0; i < mColumnCount; i++)
            {
                rowValues[i] = mInnerMatrix[rowIndex, i];
            }
            return rowValues;
        }
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
        internal decimal[] GetColumn(int columnIndex)
        {
            decimal[] columnValues = new decimal[mRowCount];
            for (int i = 0; i < mRowCount; i++)
            {
                columnValues[i] = mInnerMatrix[i, columnIndex];
            }
            return columnValues;
        }
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
        public static DecimalMatrix operator -(DecimalMatrix pMatrix1, DecimalMatrix pMatrix2)
        {
            if (!(pMatrix1.RowCount == pMatrix2.RowCount && pMatrix1.ColumnCount == pMatrix2.ColumnCount))
            {
                throw new Exception("Boyut Uyusmazligi");
            }
            return pMatrix1 + (-1 * pMatrix2);
        }
        public static bool operator ==(DecimalMatrix pMatrix1, DecimalMatrix pMatrix2)
        {
            if (!(pMatrix1.RowCount == pMatrix2.RowCount && pMatrix1.ColumnCount == pMatrix2.ColumnCount))
            {
                //boyut uyusmazligi
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
            return true; ;
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
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal bool IsZeroMatrix()
        {
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    if (mInnerMatrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        internal bool IsSquareMatrix()
        {
            return (this.RowCount == this.ColumnCount);
        }
        internal bool IsLowerTriangle()
        {
            if (!this.IsSquareMatrix())
            {
                return false;
            }
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = i + 1; j < this.ColumnCount; j++)
                {
                    if (mInnerMatrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        internal bool IsUpperTriangle()
        {
            if (!this.IsSquareMatrix())
            {
                return false;
            }
            for (int i = 0; i < this.RowCount; i++)
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
        internal bool IsDiagonalMatrix()
        {
            if (!this.IsSquareMatrix())
            {
                return false;
            }
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    if (i != j && mInnerMatrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        internal bool IsIdentityMatrix()
        {
            if (!this.IsSquareMatrix())
            {
                return false;
            }
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
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
        internal bool IsSymetricMatrix()
        {
            if (!this.IsSquareMatrix())
            {
                return false;
            }
            DecimalMatrix transposeMatrix = this.Transpose();
            if (this == transposeMatrix)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void WriteToDebug(string TitleText)
        {
            Debug.WriteLine(TitleText + "Matrix Content");
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    Debug.Write(mInnerMatrix[i, j].ToString() + "  ");
                }
                Debug.Write("\n");
            }
        }


    }
}