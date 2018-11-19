using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tasks.Task_2.Event;

namespace Tasks.Task_2.Matrix
{
    /// <summary>
    /// Create generic classes for representing square, symmetric and diagonal matrices
    /// </summary>
    /// <typeparam name="T">Input type</typeparam>
    public class SquareMatrix<T> : IEnumerable<T>
    {
        #region protected fields
        protected internal readonly T[,] Array;
        private int _sizeArray;
        #endregion

        #region constructors
        /// <summary>
        /// Initialization size of <see cref="Array"/>
        /// </summary>
        /// <param name="size">Input size</param>
        public SquareMatrix(int size)
        {
            this.Size = size;
            this.Array = new T[this.Size, this.Size];
        }

        /// <summary>
        /// Initialization of <see cref="Array"/>
        /// </summary>
        /// <param name="array">Input array</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array"/> is null.
        /// </exception>
        public SquareMatrix(T[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            this.Size = array.GetLength(0);
            this.Array = array;
        }
        #endregion

        #region properties
        /// <summary>
        /// Event which to work with elements which change
        /// </summary>
        public event EventHandler<ChangeMatrixElementsEventArgs<T>> Change;

        /// <summary>
        /// Size of array
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <param name="value">
        /// if < 0.
        /// </param>
        /// </exception>
        public int Size
        {
            get
            {
                return this._sizeArray;
            }

            protected internal set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this._sizeArray = value;
            }
        }

        #endregion

        #region indexer
        /// <summary>
        /// Array indexer
        /// </summary>
        /// <param name="i">The first element</param>
        /// <param name="j">The second element</param>
        /// <exception cref="IndexOutOfRangeException">
        /// <paramref name="i"/> > this.Size
        /// <paramref name="j"/> > this.Size
        /// </exception>
        /// <returns>Array = value</returns>
        public virtual T this[int i, int j]
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

                this.Array[i, j] = value;
            }
        }
        #endregion

        #region ienumerator
        /// <summary>
        /// Implementation <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <returns>Elements</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Array.GetLength(0); i++)
            {
                for (int j = 0; j < this.Array.GetLength(1); i++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Array.GetEnumerator();
        }
        #endregion

        /// <summary>
        /// Checking index of array
        /// </summary>
        /// <param name="i">The first element</param>
        /// <param name="j">The second element</param>
        /// <returns>bool true</returns>
        protected bool VerifyIndex(int i, int j) => i < this.Size && j < this.Size;

        /// <summary>
        /// Event handler
        /// </summary>
        /// <param name="sender">this object</param>
        /// <param name="e">some info about event</param>
        protected virtual void OnChangeElements(object sender, ChangeMatrixElementsEventArgs<T> e)
        {
            this.Change?.Invoke(this, e);
        }
    }
}
