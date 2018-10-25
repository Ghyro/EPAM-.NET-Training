using Tasks;
using NUnit.Framework;
using System;

namespace TasksTests.Task2
{
    [TestFixture]
    public static class Task2Tests
    {
        #region CurrentValues
        private static int[][] currentArr =
        {
            new int[] {5,4,6,7,3,5},
            new int[] {3,7,2,5,8}, 
            new int[] {1,2,9,6,3}
        };

        private static int[][][]nullArr =
        {
            null,
            new int[][]{new int[6], null},
        };

        #endregion

        #region Positive tests


        [Test]
        public static void JaggedArray_SumComparer_NUnit()
        {
            //Arrange
            int[][] expectedArr =
            {
               new int[] {1,2,9,6,3},
               new int[] {3,7,2,5,8},
               new int[] {5,4,6,7,3,5}
            };

            int[][] sortArr = (int[][])currentArr.Clone();

            //Act
            Jagged.SortArray(sortArr, new SortBySumElements());

            //Assert
            CollectionAssert.AreEqual(sortArr, expectedArr);
        }

        [Test]
        public static void JaggedArray_MaxElementComparer_NUnit()
        {
            //Arrange
            int[][] expectedArr =
            {
                new int[] {5,4,6,7,3,5},
                new int[] {3,7,2,5,8},
                new int[] {1,2,9,6,3}
            };

            int[][] sortArr = (int[][])currentArr.Clone();

            //Act
            Jagged.SortArray(sortArr, new SortByMaxElements());

            //Assert
            CollectionAssert.AreEqual(sortArr, expectedArr);
        }

        [Test]
        public static void JaggedArray_MinElementComparer_NUnit()
        {
            //Arrange
            int[][] expectedArr =
            {
                new int[] {1,2,9,6,3},
                new int[] {3,7,2,5,8},
                new int[] {5,4,6,7,3,5}
            };

            int[][] sortArr = (int[][])currentArr.Clone();

            //Act
            Jagged.SortArray(sortArr, new SortByMinElements());

            //Assert
            CollectionAssert.AreEqual(sortArr, expectedArr);
        }
        
        #endregion
        #region Negative tests
        [Test]
        [TestCaseSource(nameof(nullArr))]
        public static void JaggedArray_CheckNull_NUnit(int[][] sortArr)
        {
            //Arrange
            Assert.Throws<ArgumentNullException>(() => Jagged.SortArray(sortArr, new SortBySumElements()));
        }

        [Test]
        public static void JaggedArray_LengthHasZero_NUnit()
        {
            //Assert
            int[][] sortArr = { };

            //Arrange
            Assert.Throws<ArgumentException>(() => Jagged.SortArray(sortArr, new SortBySumElements()));
        }

        #endregion
    }
}
