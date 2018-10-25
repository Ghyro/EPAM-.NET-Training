using System;

namespace Tasks
{
    /// <summary>
    /// Task 1 (implementation)
    /// </summary>
    public class Task1
    {
        #region Const. values
        /// <summary>
        /// For Int32. Represents a 32-bit signed integer.
        /// </summary>
        private const int maxBits = 31;
        private const int minBits = 0;
        #endregion

        #region Algorithm
        /// <summary>
        /// Insert bits of one number into another
        /// </summary>
        /// <param name="value1">The first value</param>
        /// <param name="value2">The second value</param>
        /// <param name="start">Start position</param>
        /// <param name="end">End position</param>
        /// <returns>Integer with inserted bits of second number into first number</returns>
        public static int InsertNumber(int value1, int value2, int startPosition, int endPosition)
        {
            //Call method for checking input values
            Validation(startPosition, endPosition);

            int bitMask = ((2 << (endPosition - startPosition)) - 1) << startPosition;

            //Inversion bitMask
            int maskInversion = ~bitMask;

            //Return value
            return (value1 & maskInversion) | ((value2 << startPosition) & bitMask);
        }
        #endregion

        #region Validation
        /// <summary>
        /// //Check input values
        /// </summary>
        /// <param name="value1">The first value</param>
        /// <param name="value2">The second value</param>
        /// <param name="start">Start position</param>
        /// <param name="end">End position</param>
        /// <exception cref="ArgumentException">if i > j and i < 0, 
        /// j > 31, i > 31, j < 0</exception>
        public static void Validation(int startPosition, int endPosition)
        {
            if (startPosition > endPosition)
            {
                throw new ArgumentException("Start position mustn't be bigger than end position!");
            }

            if ((startPosition < minBits) || (endPosition > maxBits) || (startPosition > maxBits) || (endPosition < minBits))
            {
                throw new ArgumentException("Two positions (start, end) must be less than 0 and bigger than 32!");
            }
        }
        #endregion
    }
}
