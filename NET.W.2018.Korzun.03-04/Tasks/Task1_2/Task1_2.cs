using System;
using System.Diagnostics;

namespace Tasks.Task1_2
{
    /// <summary>
    /// Task 1 and task 2 (implementations)
    /// 4 overloads of Euclidean methods and 4 overloads of Stein(binary Euclidean) methods.
    /// </summary>
    public class Task1_2
    {
        #region Euclide call methods

        /// <summary>
        /// The first Euclidean method
        /// </summary>
        /// <param name="number1">The first parametr</param>
        /// <param name="number2">The second parametr</param>
        /// <returns>The greatest common divisor number</returns>
        public static int GcdEuclideanNative(int number1, int number2) => Gcd(AlgorithmEuclideanNative, number1, number2);

        /// <summary>
        /// The second Euclidean method
        /// </summary>
        /// <param name="numbers">Array of parameters</param>
        /// <returns>The greatest common divisor number</returns>
        public static int GcdEuclideanNative(params int[] numbers) => Gcd(AlgorithmEuclideanNative, numbers);

        /// <summary>
        /// The third Euclidean method
        /// </summary>
        /// <param name="time">The object of <see cref="TimeSpan"/></param>
        /// <param name="number1">The first parametr</param>
        /// <param name="number2">The second parametr</param>
        /// <returns>The greatest common divisor number</returns>
        public static int GcdEuclideanNative(out TimeSpan time, int number1, int number2) => Gcd(AlgorithmEuclideanNative, out time, number1, number2);

        /// <summary>
        /// The fourth Euclidean method
        /// </summary>
        /// <param name="time">The object of <see cref="TimeSpan"/></param>
        /// <param name="numbers">Array of parameters</param>
        /// <returns>The greatest common divisor number</returns>
        public static int GcdEuclideanNative(out TimeSpan time, params int[] numbers) => Gcd(AlgorithmEuclideanNative, out time, numbers);
        #endregion

        #region Stein call methods

        /// <summary>
        /// The first Stein method
        /// </summary>
        /// <param name="number1">The first parametr</param>
        /// <param name="number2">The second parametr</param>
        /// <returns>The greatest common divisor number</returns>
        public static int GcdSteinNative(int number1, int number2) => Gcd(AlgorithmSteinNative, number1, number2);

        /// <summary>
        /// The second Stein method
        /// </summary>
        /// <param name="numbers">Array of parameters</param>
        /// <returns>The greatest common divisor number</returns>
        public static int GcdSteinNative(params int[] numbers) => Gcd(AlgorithmSteinNative, numbers);

        /// <summary>
        /// The third Stein method
        /// </summary>
        /// <param name="time">The object of <see cref="TimeSpan"/></param>
        /// <param name="number1">The first parametr</param>
        /// <param name="number2">The second parametr</param>
        /// <returns>The greatest common divisor number</returns>
        public static int GcdSteinNative(out TimeSpan time, int number1, int number2) => Gcd(AlgorithmSteinNative, out time, number1, number2);

        /// <summary>
        /// The fourth Euclidean method
        /// </summary>
        /// <param name="time">The object of <see cref="TimeSpan"/></param>
        /// <param name="numbers">Array of parameters</param>
        /// <returns>The greatest common divisor number</returns>
        public static int GcdSteinNative(out TimeSpan time, params int[] numbers) => Gcd(AlgorithmSteinNative, out time, numbers);
        #endregion

        #region private methods

        /// <summary>
        /// The first method (add delegate and check values) 
        /// </summary>
        /// <param name="func">Object of <see cref="Func{T1, T2, TResult}"/></param>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <returns>The greatest common divisor number</returns>
        private static int Gcd(Func<int, int, int> func, int number1, int number2)
        {
            if (number1 == 0 || number2 == 0)
            {
                throw new ArgumentException($"{nameof(number1)} or {nameof(number2)} must be non-zero value.");
            }

            return func(number1, number2);
        }

        /// <summary>
        /// The first method (add delegate and check values) 
        /// </summary>
        /// <param name="func">Object of <see cref="Func{T1, T2, TResult}"/></param>
        /// <param name="numbers">Array of parameters</param>
        /// <returns>The greatest common divisor number</returns>
        private static int Gcd(Func<int, int, int> func, params int[] numbers)
        {
            if (numbers is null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length == 1)
            {
                throw new ArgumentException(nameof(numbers));
            }

            int result = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                result = func(result, numbers[i]);
            }

            return result;                       
        }

        /// <summary>
        /// The first method (add delegate and check values) 
        /// </summary>
        /// <param name="func">Object of <see cref="Func{T1, T2, TResult}"/></param>
        /// <param name="timeSpan">The object of <see cref="TimeSpan"/></param>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <returns>The greatest common divisor number</returns>
        private static int Gcd(Func<int, int, int> func, out TimeSpan timeSpan, int number1, int number2)
        {
            if (number1 == 0 || number2 == 0)
            {
                throw new ArgumentException($"{nameof(number1)} or {nameof(number2)} must be non-zero value.");
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            int result = func(number1, number2);

            stopwatch.Stop();

            timeSpan = stopwatch.Elapsed;

            return result;
        }

        /// <summary>
        /// The first method (add delegate and check values) 
        /// </summary>
        /// <param name="func">Object of <see cref="Func{T1, T2, TResult}"/></param>
        /// <param name="numbers">Array of parametres</param>
        /// <returns>The greatest common divisor number</returns>
        private static int Gcd(Func<int, int, int> func, out TimeSpan time, params int[] numbers)
        {
            if (numbers is null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length == 1)
            {
                throw new ArgumentException(nameof(numbers));
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            int result = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                result = func(result, numbers[i]);
            }

            stopwatch.Stop();

            time = stopwatch.Elapsed;

            return result;
        }
        #endregion

        #region NativeEuclideanAlgorithmImplementation
        /// <summary>
        /// Euclidean algorithm for two, three, etc. integers (Native implementation)
        /// </summary>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <returns>Value</returns>
        private static int AlgorithmEuclideanNative(int number1, int number2)
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
        #endregion

        #region AlgorithmSteinNativeImplementation
        /// <summary>
        /// Stein algorithm for two, three, etc. integers (Native implementation)
        /// </summary>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        /// <returns>Value</returns>
        private static int AlgorithmSteinNative(int number1, int number2)
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
        #endregion
    }
}