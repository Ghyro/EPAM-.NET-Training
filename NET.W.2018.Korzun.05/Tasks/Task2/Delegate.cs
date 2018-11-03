using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task2
{
    public class Delegate : IComparer<int[]>
    {
        private Comparison<int[]> _myDelegate;

        public Delegate(Comparison<int[]> myDelegate)
        {
            if (myDelegate is null)
            {
                throw new ArgumentNullException(nameof(myDelegate));
            }

            this._myDelegate = myDelegate;
        }

        public int Compare(int[] x, int[] y)
        {
            return this._myDelegate(x, y);
        }
    }
}
