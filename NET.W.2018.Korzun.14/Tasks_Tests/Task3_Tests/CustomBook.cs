using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks_Tests.Task3_Tests
{
    public class CustomBook : IComparable<CustomBook>, IComparable
    {
        public int ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int CompareTo(CustomBook other)
        {
            return string.Compare(this.Author, other.Author);
        }

        public int CompareTo(object obj)
        {
            return CompareTo((CustomBook)obj);
        }
    }
}
