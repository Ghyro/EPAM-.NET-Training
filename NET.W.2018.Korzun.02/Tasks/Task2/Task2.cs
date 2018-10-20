﻿using System;
using System.Text;

namespace Tasks
{
    /// <summary>
    /// Task 2 (implementation)
    /// </summary>
    public class Task2
    {
        /// <summary>
        /// Check input values
        /// </summary>
        /// <param name="number">Input value</param>
        /// <exception cref="ArgumentException">if number <= 0</exception>
        public static void Validation (int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Number must be positive anyway!");
            }
        }

        /// <summary>
        /// Check if it hasn't bigger number
        /// </summary>
        /// <param name="array">input Array</param>
        /// <returns>false</returns>
        public static bool hasntNumber(int[] array)
        {
            int a = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] >= array[i + 1])
                {
                    a++;
                }
            }

            if (a == array.Length - 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Use simple swap
        /// </summary>
        /// <param name="x">The first value</param>
        /// <param name="y">The second value</param>
        public static void SwapNumber (ref int x, ref int y)
        {
            int temp;

            temp = x;
            x = y;
            y = temp;
        }

        /// <summary>
        /// Takes a positive integer and returns the closest largest
        /// integer consisting of the digits of the source number, and - 1
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Valid number or -1, if hasn't number</returns>
        public static int FindNextBiggerNumber (int number)
        {
            Validation(number);

            StringBuilder str = new StringBuilder();

            int[] arrayOfNumber = new int[number.ToString().Length];

            for (int i = 0; i < arrayOfNumber.Length; i++)
            {
                arrayOfNumber[i] = int.Parse(number.ToString()[i].ToString());
            }

            if (hasntNumber(arrayOfNumber))
            {
                return -1;
            }

            for (int i = arrayOfNumber.Length - 1; i >= 0; i--)
            {
                if (arrayOfNumber[i] > arrayOfNumber[i - 1])
                {
                    SwapNumber(ref arrayOfNumber[i], ref arrayOfNumber[i - 1]);
                    break;
                }
            }

            for (int i = 0; i < arrayOfNumber.Length; i++)
            {
                str.Append(arrayOfNumber[i]);
            }

            return int.Parse(str.ToString());
        }
    }
}