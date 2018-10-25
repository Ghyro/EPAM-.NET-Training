using System;
using System.Collections.Generic;

namespace Tasks
{
    /// <summary>
    /// Implement the algorithm of the “bubble” sorting of a non-rectangular (jagged array)
    /// integer array (do not use sorting methods of the class System.Array)
    /// so that it is possible to order the rows of the matrix
    /// </summary>
    public static class Jagged
    {
        /// <summary>
        /// Sorts two-dimensional array using bubble-sort algorithm.
        /// </summary>
        /// <param name="array">Input two-dimensional array</param>
        /// <param name="comparer">Implementation IComparer to define order sort.</param>
        public static void SortArray(int[][] array, IComparer<int[]> comparer)
        {
            Validation(array, comparer);

            SortArray(array, comparer.Compare);
        }

        /// <summary>
        /// Sorts two-dimensional array using bubble-sort algorithm (implementation).
        /// </summary>
        public static void SortArray(int[][] array, Comparison<int[]> comparison)
        {    
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparison(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }                       
                }
            }
        }

        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Check input values
        /// </summary>
        /// <param name="array">Input two-dimensional array</param>
        /// <param name="comparer">Implementation IComparer to define order sort.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="array"/>is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array"/>is null,
        /// <paramref name="comparer"/>is null.
        /// </exception>
        public static void Validation(int[][] array, IComparer<int[]> comparer)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length is 0)
            {
                throw new ArgumentException(nameof(array));
            }

            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }
        }
    }
}
