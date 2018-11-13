using System;
using NUnit.Framework;
using Tasks.Task3;

namespace Tests.Task3
{
    [TestFixture]
    public class BinarySearchTests
    {
        [Test]
        public void Search_InpuCorrectNumbers_NUnit()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            // Assert
            Assert.AreEqual(BinarySearch.GenericSearch(array, 4), 3);

        }

        [Test]
        public void Search_InputWrongNumbers_NUnit()
        {
            // Arrange
            int[] array = { 0 };

            // Assert
            Assert.AreEqual(BinarySearch.GenericSearch(array, 4), -1);
        }

        [Test]
        public void Search_InputEmptyNumbers_NUnit()
        {
            // Arrange
            int[] array = { };

            // Assert
            Assert.AreEqual(BinarySearch.GenericSearch(array, 4), -1);
        }

        [Test]
        public void Search_InputCorrectCharElements_NUnit()
        {
            // Arrange
            char[] symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            // Assert
            Assert.AreEqual(BinarySearch.GenericSearch(symbols, 'F'), 5);
        }

        [Test]
        public void Search_InputWrongCharElements_NUnit()
        {
            // Arrange
            char[] symbols = "A".ToCharArray();

            // Assert
            Assert.AreEqual(BinarySearch.GenericSearch(symbols, 'F'), -1);
        }

        [Test]
        public void Search_InputEmptyCharElements_NUnit()
        {
            // Arrange
            char[] symbols = "".ToCharArray();

            // Assert
            Assert.AreEqual(BinarySearch.GenericSearch(symbols, 'F'), -1);
        }
    }
}
