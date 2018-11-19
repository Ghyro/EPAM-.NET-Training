using System;
using NUnit.Framework;
using Tasks.Task_2.Matrix;

namespace Tasks_Tests.Task2_Tests
{
    [TestFixture]
    class SymmetricMatrix_Tests
    {
        [Test]
        public void SymmetricalMatrix_Event_ValueChange_NUnit()
        {
            // Arrange
            SymmetricalMatrix<int> symmetricalMatrix = new SymmetricalMatrix<int>(10);

            // Act
            symmetricalMatrix.Change += (s, e) => {
                Assert.Pass("The elements have been changed");
            };
            symmetricalMatrix[0, 0] = 20;
        }

        [Test]
        public void SymmetricalMatrix_InputCorrectSymMatrix_CheckIsMatrix_NUnit()
        {
            // Arrange
            int[,] matrix = new int[,]
            {
                { 3, 5, 4},
                { 5, 6, 8},
                { 4, 8, 7}
            };

            SymmetricalMatrix<int> symmetricalMatrix = new SymmetricalMatrix<int>(matrix);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void SymmetricalMatrix_InputWrongMatrix_CheckIsMatrix_NUnit()
        {
            // Arrange
            int[,] matrix = new int[,]
            {
                { -1, 2, -9},
                { 1, -1, 3},
                { 7, 0, 3}
            };

            // Assert
            Assert.Throws<ArgumentException>(() => new SymmetricalMatrix<int>(matrix));
        }

        [Test]
        public void SymmetricalMatrix_InputNullMatrix_CheckIsMatrix_NUnit()
        {
            // Arrange
            int[,] matrix = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => new SymmetricalMatrix<int>(matrix));
        }

        [Test]
        public void SymmetricalMatrix_InputWrongArraySize_NUnit()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SymmetricalMatrix<int>(-1));
        }
    }
}
