using System.Collections.Generic;
using System.Linq;

namespace TasksTests.Task2
{
        public class SumComparer : IComparer<int[]>
        {
            public int Compare(int[] arr1, int[] arr2)
            {
                return arr1.Sum() - arr2.Sum();
            }
        }

        public class SumDescendingComparer : IComparer<int[]>
        {
            public int Compare(int[] arr1, int[] arr2)
            {
                return -arr1.Sum() + arr2.Sum();
            }
        }
        public class MaxElementComparer : IComparer<int[]>
        {
            public int Compare(int[] arr1, int[] arr2)
            {
                return arr1.Max() - arr2.Max();
            }
        }

        public class MaxElementDescendingComparer : IComparer<int[]>
        {
            public int Compare(int[] arr1, int[] arr2)
            {
                return -arr1.Max() + arr2.Max();
            }
        }

        public class MinElementComparer : IComparer<int[]>
        {
            public int Compare(int[] arr1, int[] arr2)
            {
                return arr1.Min() - arr2.Min();
            }
        }

        public class MinElementDescendingComparer : IComparer<int[]>
        {
            public int Compare(int[] arr1, int[] arr2)
            {
                return -arr1.Min() + arr2.Min();
            }
        }
        
 }
