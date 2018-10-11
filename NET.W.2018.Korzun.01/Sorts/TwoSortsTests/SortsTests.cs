using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorts;

namespace TwoSortsTests
{
    /// <summary>
    /// Tests Sorts:
    /// 1. Quick Sort
    /// 2. Merge Sort
    /// File: TwoSorts.cs
    /// </summary>
    [TestClass]
    public class SortsTests
    {
        /// <summary>
        /// Quick Sort
        /// </summary>
        [TestMethod]
        public void QuickSort_InputCorrectValues_ReturnedSortedArray()
        {
            //arrange
            int[] arrayExcpected = new int[] { 1, 2, 3, 4, 5, };
            int[] arrayInput = new int[] { 2, 3, 1, 4, 5, };

            //act
            TwoSorts.QuickSort(arrayInput);

            //assert
            Assert.IsTrue(arrayExcpected.SequenceEqual(arrayInput));
        }

        /// <summary>
        /// Merge Sort
        /// </summary>
        [TestMethod]
        public void MergeSort_InputCorrectValues_ReturnSortedArray()
        {
            //arrange
            int[] arrayExcpected = new int[] { 1, 2, 3, 4, 5 };
            int[] arrayInput = new int[] { 2, 3, 1, 4, 5 };

            //act
            arrayInput = TwoSorts.MergeSort(arrayInput);

            //assert
            Assert.IsTrue(arrayExcpected.SequenceEqual(arrayInput));
        }

        /// <summary>
        /// NullReferenceException Quick Sort
        /// </summary>
        [TestMethod]
        public void QuickSort_Check_NullReferenceException()
        {
            int[] arrayNull = null;
            Assert.ThrowsException<NullReferenceException>(() => TwoSorts.QuickSort(null));
        }

        /// <summary>
        /// ArgumentException Quick Sort
        /// </summary>
        [TestMethod]
        public void QuickSort_Check_ArgumentException()
        {
            int[] arrayZero = new int[0];
            Assert.ThrowsException<ArgumentException>(() => TwoSorts.QuickSort(arrayZero));
        }

        /// <summary>
        /// NullReferenceException Merge Sort
        /// </summary>
        [TestMethod]
        public void MergeSort_Check_NullReferenceException()
        {
            int[] arrayNull = null;
            Assert.ThrowsException<NullReferenceException>(() => TwoSorts.MergeSort(arrayNull));
        }

        /// <summary>
        /// ArgumentException Merge Sort
        /// </summary>
        [TestMethod]
        public void MergeSort_Check_ArgumentException()
        {
            int[] arrayZero = new int[0];
            Assert.ThrowsException<ArgumentException>(() => TwoSorts.MergeSort(arrayZero));
        }

    }
}
