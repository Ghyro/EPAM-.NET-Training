using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task4
{
    /// <summary>
    /// <see cref="Fibonacci">consist implementation algorithm Fibonacc with yield</see>/>
    /// </summary>
    public class Fibonacci
    {        
        /// <summary>
        /// Implementation <see cref="Fibonacci"> class</see>/>
        /// </summary>
        /// <returns>Array of sequence</returns>
        public static IEnumerable<int> CalculationFibonacci()
        {
            // Previous
            int firstNumber = 0;

            // Current
            int secondNumber = 1;

            for (int i = 0; i < int.MaxValue; i++)
            {
                yield return firstNumber;

                var nextNumber = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = nextNumber;
            }
        }
    }
}
