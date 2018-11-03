using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task3
{
    public class Notation
    {
        private const string SYM = "0123456789ABCDEF";
        private int p;
        private int minBase = 2;
        private int maxBase = 16;        

        public Notation(int p)
        {
            if (p < minBase || p > maxBase)
            {
                throw new ArgumentException(nameof(p));
            }

            this.p = p;
        }

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
                return SYM;
            }
        }        
    }
}
