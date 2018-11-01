using System;
using System.Text;

/// <summary>
/// Task2
/// </summary>
namespace Tasks
{
    /// <summary>
    /// Task2 implementation (static class)
    /// </summary>
    public static class Task2
    {
        #region Const. values
        /// <summary>
        /// Const values for all scope of program
        /// </summary>
        private const int ExponentLength = 11;
        private const int MantissaLength = 52;
        private const int Bias = 1023;
        private const int ReverseBias = -1022;
        private const int PositiveBit = 1;
        private const int NegativeBit = 0;
        #endregion

        #region BitsStringImplementation
        /// <summary>
        /// Implement the extension method to get a string binary representation of a real
        /// double-precision number in IEEE 754 format. 
        /// </summary>
        /// <param name="number">Input double number for convert</param>
        /// <returns>String binary</returns>
        public static string BitsString(this double number)
        {
            // Get sign
            int sign = GetSign(number);

            if (sign == 1)
            {
                number = Math.Abs(number);
            }

            // Get order
            int exponent = GetExponent(number);

            // Get mantissa
            double mantissa = GetMantissa(number, exponent);

            // Сreating an array of exponent numbers
            int[] exponentBinArr = ConvertExponentToBinArr(exponent);

            // Сreating an array of mantissa
            int[] mantissaBinArr = ConvertMantissaToBinArr(mantissa);

            // Merge all number parameters in IEEE 754 format
            string result = string.Concat(sign, string.Concat(exponentBinArr), string.Concat(mantissaBinArr));

            // String binary
            return result;
        }
        #endregion

        #region GetSign
        /// <summary>
        /// Get sign of the number
        /// </summary>
        /// <param name="number">Input number</param>
        /// <returns>Current bit</returns>
        private static int GetSign(double number)
        {
            int bit = NegativeBit;

            if (double.IsNegativeInfinity(1.0 / number) || number < 0.0)
            {
                bit = PositiveBit;
            }

            return bit;
        }
        #endregion

        #region GetExponent
        /// <summary>
        /// Get exponent of the number
        /// </summary>
        /// <param name="number">Input number</param>
        /// <returns>Exponent</returns>
        private static int GetExponent(double number)
        {
            if (double.IsNaN(number))
            {
                return (int)Math.Pow(2, ExponentLength) - 1;
            }

            int exponent = 0;
            double fraction = (number / Math.Pow(2, exponent)) - 1;

            while ((fraction < 0) || (fraction >= 1))
            {
                if (fraction < 1.0)
                {
                    --exponent;
                }
                else
                {
                    ++exponent;
                }

                fraction = (number / Math.Pow(2, exponent)) - 1;
            }

            exponent  = exponent + Bias;

            if (exponent < 0)
            {
                exponent = 0;
            }            

            return exponent;
        }
        #endregion

        #region GetMantissa
        /// <summary>
        /// Get mantissa of the number
        /// </summary>
        /// <param name="number">Input number</param>
        /// <param name="exponent">Exponent</param>
        /// <returns>Mantissa</returns>
        private static double GetMantissa(double number, int exponent)
        {
            if (double.IsNaN(number))
            {
                return Math.Pow(2, MantissaLength);
            }

            exponent = exponent - Bias;
            double mantissa = 0;

            if (exponent <= -Bias)
            {
                mantissa = number / Math.Pow(2, ReverseBias);
            }
            else
            {
                mantissa = (number / Math.Pow(2, exponent)) - 1;
            }

            return mantissa;
        }
        #endregion

        #region GetBinArr(Exponent)
        /// <summary>
        /// Creating an exponent array (binary)
        /// </summary>
        /// <param name="exponent">Exponent of number</param>
        /// <returns>Array</returns>
        private static int[] ConvertExponentToBinArr(int exponent)
        {            
            int[] result = new int[ExponentLength];

            for (int i = 0; exponent != 0; exponent >>= 1, i++)
            {
                int bit = 0;
                if ((exponent & 1) == 1)
                {
                    bit = PositiveBit;
                }
                else
                {
                    bit = NegativeBit;
                }

                result[result.Length - i - 1] = bit;
            }

            return result;
        }
        #endregion

        #region GetBinArr(Mantissa)
        /// <summary>
        /// Creating an mantissa array (binary)
        /// </summary>
        /// <param name="mantissaValue">Mantissa</param>
        /// <returns>Array</returns>
        private static int[] ConvertMantissaToBinArr(double mantissaValue)
        {
            int[] result = new int[MantissaLength];

            for (int i = 0; i < result.Length; i++)
            {
                mantissaValue = mantissaValue * 2;
                if (mantissaValue >= 1)
                {
                    result[i] = PositiveBit;
                    mantissaValue = mantissaValue - 1;
                }
                else
                {
                    result[i] = NegativeBit;
                }
            }

            return result;
        }
        #endregion
    }
}