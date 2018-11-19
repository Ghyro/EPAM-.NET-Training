using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Task_2.Event;

namespace Tasks.Task_2.Matrix
{
    /// <summary>
    /// <see cref="SymmetricalMatrix{T}"/> is a square matrix that coincides with the transposed one
    /// </summary>
    /// <typeparam name="T">Input type</typeparam>
    public class SymmetricalMatrix<T> : SquareMatrix<T> where T : IComparable<T>
    {
        #region constructors
        /// <summary>
        ///  Implementation base constructor <see cref="SquareMatrix{T}"/>
        /// </summary>
        /// <param name="size">Input size</param>
        public SymmetricalMatrix(int size) : base(size)
        {
        }

        /// <summary>
        /// Implementation base constructor <see cref="SquareMatrix{T}"/>
        /// </summary>
        /// <param name="array">Input array</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="array"/>is not symmetry
        /// </exception>
        public SymmetricalMatrix(T[,] array) : base(array)
        {
            if (!this.Symmetry(array))
            {
                throw new ArgumentException(nameof(array));
            }
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

                this.OnChangeElements(this, new ChangeMatrixElementsEventArgs<T>(i, j));

                this.Array[i, j] = value;

                base[j, i] = value;
            }
        }
        #endregion

        /// <summary>
        /// Calculation of the symmetry elements
        /// </summary>
        /// <param name="array">Input array</param>
        /// <returns>
        /// <true> if elements are symmetry
        /// </returns>
        private bool Symmetry(T[,] array)
        {
            for (int i = 0; i < this.Array.GetLength(0); i++)
            {
                for (int j = 0; j < this.Array.GetLength(1); j++)
                {
                    if (array[i, j].CompareTo(array[j, i]) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
