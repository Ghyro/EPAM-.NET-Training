using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task3
{
    /// <summary>
    /// Implement Generic Binary Search algorithm
    /// </summary>
    public static class BinarySearch
    {
        /// <summary>
        /// Input values, check input values.
        /// </summary>
        /// <typeparam name="T">The type of implementations<see cref="IComparer{T}"/></typeparam>
        /// <param name="array">The input array</param>
        /// <param name="element">The element which need to search</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array"/> is null,
        /// <paramref name="element"/> is equal null.
        /// </exception>
        /// <returns>Result implementation of algorithm</returns>
        public static int GenericSearch<T>(T[] array, T element)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (ReferenceEquals(element, null))
            {
                throw new ArgumentNullException(nameof(element));
            }

            return GenericBinarySearch(array, element);
        }

        /// <summary>
        /// Implementation of algorithm (Binary Search)
        /// </summary>
        /// <typeparam name="T">The type of implementations<see cref="IComparer{T}"/></typeparam>
        /// <param name="array">The input array</param>
        /// <param name="element">The element which need to search</param>
        /// <returns>
        /// <if element found> return element</if>
        /// <else element did not found> return -1</else>
        /// </returns>
        public static int GenericBinarySearch<T>(T[] array, T element)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;
                T midValue = array[middle];

                int result = ((IComparable)(midValue)).CompareTo(element);

                if (result == 0)
                {
                    return middle;
                }                    
                else if (result == -1)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }                   
            }

            return -1;
        }
    }
}
