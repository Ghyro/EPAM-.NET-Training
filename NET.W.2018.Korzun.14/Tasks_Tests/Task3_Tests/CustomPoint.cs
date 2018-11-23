using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks_Tests.Task3_Tests
{
    public sealed class CustomPoint : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return x.X * x.Y - y.X * y.Y;
        }
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
