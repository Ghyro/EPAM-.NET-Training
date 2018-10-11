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
        /// Check array for null
        /// </summary>
        /// <param name="mass">Array for sort</param>
        /// <exception cref="ArgumentException">When our <paramref name="array"/>has length: 0.</exception>
        /// <exception cref="NullReferenceException">When our <paramref name="array"/>has null.</exception>
        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException("Array is empty!");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array has length: 0");
            }

            ImpementationQuickSort(array, 0, array.Length - 1);

        }

        /// <summary>
        /// Algorithm implementation: Quick sort
        /// </summary>
        /// <param name="mass">Array for sort</param>
        /// <param name="left">The first value(null position)</param>
        /// <param name="right">The last value(last position-1)</param>
        private static void ImpementationQuickSort(int[] array, int left, int right)
        {
            int x = array[(right - left) / 2 + left];
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
        }

        /// <summary>
        /// Check array for null, 0
        /// </summary>
        /// <param name="mass">Array for sort</param>
        /// <exception cref="ArgumentException">When our <paramref name="array"/>has length: 0.</exception>
        /// <exception cref="NullReferenceException">When our <paramref name="array"/>has null.</exception>
        /// <return>if array == 1</return>
        public static int[] MergeSort(int[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }
            
            if (array == null)
            {
                throw new NullReferenceException("Array us null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array has length: 0");
            }

            int mid_point = array.Length / 2;
            return ImpementationMergeSort(MergeSort(array.Take(mid_point).ToArray()), MergeSort(array.Skip(mid_point).ToArray()));
        }

        /// <summary>
        /// Algorithm implementation: Quick Sort
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
    }
}
