using System;
using System.Text;

namespace Tasks
{
    public static class Task2
    {
        const int ExponentLength = 11;
        const int MantissaLength = 52;
        const int Bias = 1023;
        const int ReverseBias = -1022;
        const int positiveBit = 1;
        const int negativeBit = 0;

        public static string BitsString(this double number)
        {
            int sign = GetSign(number);

            if (sign == 1)
            {
                number = Math.Abs(number);
            }

            int exponent = GetExponent(number);

            double mantissa = GetMantissa(number, exponent);

            int[] exponentBitArr = ConvertExponentToBitArr(exponent);

            int[] mantissaBitArr = ConvertMantissaToBitArr(mantissa);

            string result = string.Concat(sign, string.Concat(exponentBitArr), string.Concat(mantissaBitArr));

            return result;
        }

        private static int GetSign(double number)
        {
            int bit = negativeBit;

            if (double.IsNegativeInfinity(1.0 / number) || number < 0.0)
            {
                bit = positiveBit;
            }

            return bit;
        }

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
            exponent = exponent < 0 ? 0 : exponent;

            return exponent;
        }

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

        private static int[] ConvertExponentToBitArr(int exponent)
        {            
            int[] result = new int[ExponentLength];

            for (int i = 0; exponent != 0; exponent >>= 1, i++)
            {
                int bit = 0;
                if ((exponent & 1) == 1)
                {
                    bit = positiveBit;
                }
                else
                {
                    bit = negativeBit;
                }
                result[result.Length - i - 1] = bit;
            }

            return result;
        }

        private static int[] ConvertMantissaToBitArr(double mantissaValue)
        {
            int[] result = new int[MantissaLength];

            for (int i = 0; i < result.Length; i++)
            {
                mantissaValue = mantissaValue * 2;
                if (mantissaValue >= 1)
                {
                    result[i] = positiveBit;
                    mantissaValue = mantissaValue - 1;
                }
                else
                {
                    result[i] = negativeBit;
                }
            }

            return result;
        }        

        
    }
}