using System;
using System.Diagnostics;

namespace Tasks
{
    /// <summary>
    /// Task 1 and task 2 (implementations)
    /// </summary>
    public class Task1_2
    {
        /// <summary>
        /// Develop a class that allows you to perform GCD
        /// calculations using the Euclidean algorithm for two, three, etc. integers
        /// </summary>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <returns>Value</returns>
        public static int AlgorithmEuclideanNative(int number1, int number2)
        {
            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);

            while (number1 != number2)
            {
                if (number1 > number2)
                {
                    number1 -= number2;
                }

                else
                {
                    number2 -= number1;
                }
            }

            return number1;
        }

        /// <summary>
        /// Classical implementation (two param)
        /// </summary>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <returns>Value</returns>
        public static int AlgorithmEuclidean(int number1, int number2) => AlgorithmEuclideanNative(number1, number2);

        /// <summary>
        /// Implementation algorithm with array
        /// </summary>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <param name="numbers">Input array</param>
        /// <returns>Value</returns>
        public static int AlgorithmEuclidean(int number1, int number2, params int[] numbers)
        {
            ValidationEuclidean(numbers);

            int outputResult = AlgorithmEuclideanNative(number1, number2);

            for (int i = 0; i < numbers.Length; i++)
            {
                outputResult = AlgorithmEuclideanNative(outputResult, numbers[i]);
            }

            return outputResult;
        }
        
        /// <summary>
        /// Get time to classical implementation (two param)
        /// </summary>
        /// <param name="time">This object represents a time interval.</param>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <returns>Value</returns>
        public static int AlgorithmEuclideanTime(out TimeSpan timeSpan, int number1, int number2)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            int outputResult = AlgorithmEuclidean(number1, number2);

            stopwatch.Stop();

            timeSpan = stopwatch.Elapsed;

            return outputResult;
        }

        /// <summary>
        /// Get time to implementation with array
        /// </summary>
        /// <param name="time">This object represents a time interval.</param>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <param name="numbers">Input array</param>
        /// <returns>Value</returns>
        public static int AlgorithmEuclideanTime(out TimeSpan timeSpan, int number1, int number2, params int[] numbers)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            int outputResult = AlgorithmEuclidean(number1, number2, numbers);

            stopwatch.Stop();

            timeSpan = stopwatch.Elapsed;

            return outputResult;
        }

        /// <summary>
        /// Check input array
        /// </summary>
        /// <param name="numbers">Input array</param>
        /// <exception cref="ArgumentNullException">if input array = null.</exception>
        public static void ValidationEuclidean(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Array is null!");
            }
        }

        /// <summary>
        /// Add to the developed class methods that implement the Stein algorithm
        /// (binary Euclidean algorithm) for calculating the GCD of two, three, etc. integers
        /// </summary>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <returns>Value</returns>
        public static int AlgorithmSteinNative(int number1, int number2)
        {
            number1 = Math.Abs(number1);

            number2 = Math.Abs(number2);

            if (number1 == number2)
            {
                return number1;
            }

            if (number1 == 0)
            {
                return number2;
            }

            if (number2 == 0)
            {
                return number1;
            }

            if ((~number1 & 1) != 0)
            {
                if ((number2 & 1) != 0)
                {
                    return AlgorithmSteinNative(number1 >> 1, number2);
                }

                else
                {
                    return AlgorithmSteinNative(number1 >> 1, number2 >> 1) << 1;
                }
            }

            if ((~number2 & 1) != 0)
            {
                return AlgorithmSteinNative(number1, number2 >> 1);
            }

            if (number1 > number2)
            {
                return AlgorithmSteinNative((number1 - number2) >> number1, number2);
            }

            return AlgorithmSteinNative((number2 - number1) >> 1, number1);
        }

        /// <summary>
        /// Stein implementation (two param)
        /// </summary>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <returns>Value</returns>
        public static int AlgorithmStein(int number1, int number2) => AlgorithmSteinNative(number1, number2);

        /// <summary>
        /// Stein implementation with array
        /// </summary>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <param name="numbers">Input array</param>
        /// <returns>Value</returns>
        public static int AlgorithmStein(int number1, int number2, params int[] numbers)
        {
            ValidationStein(numbers);

            int outputResult = AlgorithmSteinNative(number1, number2);

            for (int i = 0; i < numbers.Length; i++)
            {
                outputResult = AlgorithmSteinNative(outputResult, numbers[i]);
            }

            return outputResult;
        }

        /// <summary>
        /// Get time to implementation (two number)
        /// </summary>
        /// <param name="time">This object represents a time interval.</param>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <param name="numbers">Input array</param>
        /// <returns>Value</returns>
        public static int AlgorithmSteinTime(out TimeSpan timeSpan, int number1, int number2)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            int outputResult = AlgorithmStein(number1, number2);

            stopwatch.Stop();

            timeSpan = stopwatch.Elapsed;

            return outputResult;
        }

        /// <summary>
        /// Get time to implementation with array
        /// </summary>
        /// <param name="time">This object represents a time interval.</param>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <param name="numbers">Input array</param>
        /// <returns>Value</returns>
        public static int AlgorithmSteinTime(out TimeSpan timeSpan, int number1, int number2, params int[] numbers)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            int outputResult = AlgorithmStein(number1, number2);

            stopwatch.Stop();

            timeSpan = stopwatch.Elapsed;

            return outputResult;
        }

        /// <summary>
        /// Check input array
        /// </summary>
        /// <param name="numbers">Input array</param>
        /// <exception cref="ArgumentNullException">if input array = null.</exception>
        public static void ValidationStein(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Array is null!");
            }
        }

    }
}
