using System;
using NUnit.Framework;
using Tasks.Task_2.Matrix;

namespace Tasks_Tests.Task2_Tests
{
    [TestFixture]
    class SquareMatrix_Tests
    {
        [Test]
        public void SquareMatrix_Event_ValueChange_NUnit()
        {
            // Arrange
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(5);

            // Act
            squareMatrix.Change += (s, e) => {
                Assert.Pass("The elements have been changed");
            };
            squareMatrix[0, 0] = 10;
        }

        [Test]
        public void SquareMatrix_InputCorrectMatrix_CheckIsMatrix_NUnit()
        {
            // Arrange
            int[,] matrix = new int[,]
            {
                { 3, 5, 4},
                { 5, 6, 8},
                { 4, 8, 7}
            };

            SquareMatrix<int> square = new SquareMatrix<int>(matrix);

            Assert.Pass();
        }

        [Test]
        public void SquareMatrix_InputWrongMatrix_CheckIsMatrix_NUnit()
        {
            // Arrange
            int[,] matrix = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => new SquareMatrix<int>(matrix));
        }

        [Test]
        public void SquareMatrix_InputWrongArraySize_NUnit()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SquareMatrix<int>(-1));
        }
    }
}
