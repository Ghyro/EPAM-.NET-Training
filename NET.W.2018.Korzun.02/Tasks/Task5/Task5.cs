using System;

namespace Tasks
{
    /// <summary>
    /// Task 5 (implementation)
    /// </summary>
    public class Task5
    {
        /// <summary>
        /// Calculate the root of the n-th degree (n∈N) from among (a∈R) by the Newton method.
        /// </summary>
        /// <param name="value">Some number</param>
        /// <param name="root">Root</param>
        /// <param name="eps">Some accuracy</param>
        /// <returns>Root of some number</returns>
        public static double FindNthRoot(double value, int root, double eps)
        {
            //Call method for checking input values
            Validation(value, root, eps);

            double x0 = value / root;
            double x1 = (1.0 / root) * (((root - 1) * x0) + (value / Math.Pow(x0, root - 1)));

            while (Math.Abs(x0 - x1) > eps)
            {
                x0 = x1;
                x1 = 1.0 / root * ((root - 1) * x0 + value / Math.Pow(x0, root - 1));
            }

            return x1;
        }

        /// <summary>
        /// Check input values
        /// </summary>
        /// <param name="value">Some number</param>
        /// <param name="root">Root</param>
        /// <param name="eps">Some accuracy</param>
        /// <exception cref="ArgumentException">if value, eps <= 0, root == 0</exception>
        public static void Validation(double value, int root, double eps)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Number mustn't be less than 0!");
            }

            if (root == 0)
            {
                throw new ArgumentNullException("Root mustn't be equal to 0!");
            }

            if (eps <= 0)
            {
                throw new ArgumentException("Eps mustn't be less than 0!");
            }
        }


    }
}
