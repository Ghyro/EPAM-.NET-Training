using System;
using System.Linq;

namespace Sorts
{
    /// <summary>
    /// This class contains implementation the next algorithms:
    /// 1. Quick sort
    /// 2. Merge sort
    /// </summary>
    public class TwoSorts
    {
        /// <summary>
        /// Check input array
        /// </summary>
        /// <param name="array">Input array</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array"/>if array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="array"/>if array length = 0.
        /// </exception>
        public static void Validation(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array));
            }
        }

        /// <summary>
        /// Algorithm implementation: Merge Sort
        /// </summary>
        /// <param name="array">Input array</param>
        /// <returns>
        /// <paramref name="array"/>if length = 1.
        /// </returns>
        public static int[] MergeSort(int[] array)
        {
            Validation(array);

            if (array.Length == 1)
            {
                return array;
            }

            int mid_point = array.Length / 2;
            return ImpementationMergeSort(MergeSort(array.Take(mid_point).ToArray()), MergeSort(array.Skip(mid_point).ToArray()));
        }

        /// <summary>
        /// Algorithm implementation: Merge Sort
        /// </summary>
        /// <param name="array1">The first array</param>
        /// <param name="array2">The second array</param>
        /// <returns>Sorted array</returns>
        public static int[] ImpementationMergeSort(int[] array1, int[] array2)
        {
            int a = 0, b = 0;
            int[] mergeArray = new int[array1.Length + array2.Length];

            for (int i = 0; i < array1.Length + array2.Length; i++)
            {
                if (b < array2.Length && a < array1.Length)
                {
                    if (array1[a] > array2[b] && b < array2.Length)
                    {
                        mergeArray[i] = array2[b++];
                    }
                    else
                    {
                        mergeArray[i] = array1[a++];
                    }
                }
                else
                {
                    if (b < array2.Length)
                    {
                        mergeArray[i] = array2[b++];
                    }
                    else
                    {
                        mergeArray[i] = array1[a++];
                    }
                }
            }

            return mergeArray;
        }

        /// <summary>
        /// Algorithm implementation: Quick sort
        /// </summary>
        /// <param name="array">Input array</param>
        /// <returns>
        /// <paramref name="array"/>if length = 1.
        /// </returns>
        public static int[] QuickSort(int[] array)
        {
            Validation(array);

            if (array.Length == 1)
            {
                return array;
            }

            return ImpementationQuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Algorithm implementation: Quick sort
        /// </summary>
        /// <param name="array">Array for sort</param>
        /// <param name="left">The first value(null position)</param>
        /// <param name="right">The last value(last position-1)</param>
        private static int[] ImpementationQuickSort(int[] array, int left, int right)
        {
            int x = array[(right - left) / (2 + left)];
            int temp;
            int i = left;
            int j = right;

            while (i <= j)
            {
                while (array[i] < x && i <= right)
                {
                    ++i;
                }

                while (array[j] > x && j >= left)
                {
                    --j;
                }

                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    ++i;
                    --j;
                }

                if (j > right)
                {
                    ImpementationQuickSort(array, left, j);
                }

                if (i < right)
                {
                    ImpementationQuickSort(array, i, right);
                }
            }

            return array;
        }       
    }
}
