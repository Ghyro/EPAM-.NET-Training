using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Task_2.Event;

namespace Tasks.Task_2.Matrix
{
    /// <summary>
    /// <see cref="DiagonalMatrix{T}"/> is a square matrix whose elements outside the main diagonal
    /// obviously have default values of the element type
    /// </summary>
    /// <typeparam name="T">Input type</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T> where T : IComparable<T>
    {
        #region constructor
        /// <summary>
        /// Implementation base constructor <see cref="SquareMatrix{T}"/>
        /// </summary>
        /// <param name="size">Input size</param>
        public DiagonalMatrix(int size) : base(size)
        {
        }
        #endregion

        #region indexer
        /// <summary>
        /// Overrid base indexer <see cref="SquareMatrix{T}"/>
        /// </summary>
        /// <param name="i">The first element</param>
        /// <param name="j">The second element</param>
        /// <exception cref="IndexOutOfRangeException">
        /// <paramref name="i"/> > this.Size
        /// <paramref name="j"/> > this.Size
        /// </exception>
        /// <returns>Array = value</returns>
        public override T this[int i, int j]
        {
            get
            {
                if (!this.VerifyIndex(i, j))
                {
                    throw new IndexOutOfRangeException();
                }

                return this.Array[i, j];
            }

            set
            {
                if (!this.VerifyIndex(i, j))
                {
                    throw new IndexOutOfRangeException();
                }

                if (!this.Dioganal(i, j))
                {
                    throw new IndexOutOfRangeException();
                }

                this.OnChangeElements(this, new ChangeMatrixElementsEventArgs<T>(i, j));
                this.Array[i, j] = value;
            }
        }
        #endregion

        #region dioganal
        /// <summary>
        /// Calculation of the diagonal elements
        /// </summary>
        /// <param name="i">The first element</param>
        /// <param name="j">The second element</param>
        /// <returns>true</returns>
        private bool Dioganal(int i, int j)
        {
            return i == j;
        }
        #endregion
    }
}
