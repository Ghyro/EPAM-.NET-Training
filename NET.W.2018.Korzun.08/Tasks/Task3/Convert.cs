using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task3
{    
    public class Notation
    {
        private int p;
        private int minBase = 2;
        private int maxBase = 16;
        private const string sym = "0123456789ABCDEF";

        public int Basic
        {
            get
            {
                return p;
            }
        }

        public string Symbol
        {
            get
            {
                return sym;
            }
        }

        public Notation(int p)
        {
            if (p < minBase || p > maxBase)
            {
                throw new ArgumentException(nameof(p));
            }

            this.p = p;
        }
    }

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
                    

                result = rank * index;
                rank = rank * notation.Basic;
            }

            return result;
        }
    }


}
