using System;
using System.Collections.Generic;

namespace Tasks
{
    /// <summary>
    /// Task 4 (implementation)
    /// </summary>
    public class Task4
    {
        #region FilterDigit
        /// <summary>
        /// Accepts a list of integers and filters the list so that only
        /// the numbers containing the specified digit are left at the output.
        /// </summary>
        /// <param name="array">List of integer values</param>
        /// <param name="currentNumber">Digit for filter</param>
        /// <returns>list of digits which contain current digit</returns>
        public static List<int> FilterDigit(List<int> inputList, int currentDigit)
        {
            Validation(inputList, currentDigit);

            string currentString = Convert.ToString(currentDigit);

            List<int> list = new List<int>();

            foreach (int value in inputList)
            {
                string strList = Convert.ToString(value);

                if (strList.Contains(currentString))
                {
                    list.Add(value);
                }
            }

            return list;
        }
        #endregion

        #region Validation
        /// <summary>
        /// Check input values
        /// </summary>
        /// <param name="array">List of integer values</param>
        /// <param name="currentNumber">Digit for filter</param>
        /// <exception cref="ArgumentNullException">if list is null</exception>
        /// <exception cref="ArgumentException">if input digit < 0 || > 10</exception>
        public static void Validation(List<int> inputList, int currentDigit)
        {
            if (inputList is null)
            {
                throw new ArgumentNullException(nameof(inputList));
            }

            if (currentDigit < 0 || currentDigit > 9)
            {
                throw new ArgumentException($"{nameof(currentDigit)} must be positive value" +
                    " for filter and doesn't bigger than 9!");
            }
        }
        #endregion
    }
}
