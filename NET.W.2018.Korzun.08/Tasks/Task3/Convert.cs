using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task3
{
    public static class Convert
    {
        public static int Converting(this string number, Notation notation)
        {
            if (string.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException(nameof(number));
            }

            int rank = 1;
            int result = 0;

            for (var i = number.Length - 1; i >= 0; i--)
            {
                var index = notation.Symbol.IndexOf(number[i]);

                if (index < 0 || index >= notation.Basic)
                {
                    throw new ArgumentException();
                }

                result = result + (rank * index);
                rank = rank * notation.Basic;
            }

            return result;
        }
    }      
}
