using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task_2.Event
{
    public class ChangeMatrixElementsEventArgs<T> : EventArgs
    {
        public readonly int I;

        public readonly int J;

        public ChangeMatrixElementsEventArgs(int i, int j)
        {
            this.I = i;
            this.J = j;
        }
    }
}
