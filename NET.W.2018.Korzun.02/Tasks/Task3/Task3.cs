using System;
using System.Diagnostics;

namespace Tasks
{
    /// <summary>
    /// Task 3 (implementation)
    /// </summary>
    public class Task3
    {
        #region FindNumberStopWatch
        /// <summary>
        /// Add to the FindNextBiggerNumber method the ability to return the time
        /// of finding a given number by considering various language features.
        /// </summary>
        /// <param name="number">Input value</param>
        /// <returns>Time test</returns>
        public static Stopwatch TimeFindNumber (int number)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            Task2.FindNextBiggerNumber(number);

            stopwatch.Stop();

            return stopwatch;
        }
        #endregion
    }
}
