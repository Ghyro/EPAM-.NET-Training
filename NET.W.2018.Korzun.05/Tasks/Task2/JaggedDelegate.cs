using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task2
{
    public class JaggedDelegate
    {
        /// <summary>
        /// Sorts two-dimensional array using bubble-sort algorithm.
        /// </summary>
        /// <param name="array">Input two-dimensional array</param>
        /// <param name="comparer">The delegate for sort</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array"/>is null,
        /// <paramref name="comparer"/>is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="array"/> is length = 1.
        /// </exception>
        private static void SortArray(int[][] array, Comparison<int[]> comparer)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 1)
            {
                throw new ArgumentException(nameof(array));
            }

            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            SortArray(array, new Delegate(comparer));
        }

        /// <summary>
        /// Sorts two-dimensional array using bubble-sort algorithm (implementation).
        /// </summary>
        private static void SortArray(int[][] array, IComparer<int[]> comparison)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparison.Compare(array[j], array[j + 1]) > 0)
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
    }
}
