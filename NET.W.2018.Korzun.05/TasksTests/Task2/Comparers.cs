using System.Collections.Generic;
using System.Linq;

namespace TasksTests.Task2
{
        public class SortBySumElements : IComparer<int[]>
        {
            public int Compare(int[] arr1, int[] arr2)
            {
                return arr1.Sum() - arr2.Sum();
            }
        }

        public class SortByMaxElements : IComparer<int[]>
        {
            public int Compare(int[] arr1, int[] arr2)
            {
                return arr1.Max() - arr2.Max();
            }
        }

        public class SortByMinElements : IComparer<int[]>
        {
            public int Compare(int[] arr1, int[] arr2)
            {
                return arr1.Min() - arr2.Min();
            }
        }
        
 }
