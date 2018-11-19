using System;
using NUnit.Framework;
using Tasks.Task_2.Matrix;

namespace Tasks_Tests.Task2_Tests
{
    [TestFixture]
    class DiagonalMatrix_Tests
    {
        [Test]
        public void DiagonalMatrix_Event_ValueChange_NUnit()
        {
            // Arrange
            DiagonalMatrix<int> symmetricalMatrix = new DiagonalMatrix<int>(10);

            // Act
            symmetricalMatrix.Change += (s, e) => {
                Assert.Pass("The elements have been changed");
            };
            symmetricalMatrix[0, 0] = 20;
        }

        [Test]
        public void DioganalMatrix_InputCorrectIsDioganal_Succed()
        {
            // Arrange
            DiagonalMatrix<int> dioganalMatrix = new DiagonalMatrix<int>(10);
            dioganalMatrix[0, 0] = 1;

            // Assert
            Assert.Pass();
        }

        [Test]
        public void DioganalMatrix_InputWrongIsDioganal_Succed()
        {
            // Arrange
            DiagonalMatrix<int> dioganalMatrix = new DiagonalMatrix<int>(10);

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => dioganalMatrix[0, 2] = 2);
        }

        [Test]
        public void DiagonalMatrix_InputWrongArraySize_NUnit()
        {
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new DiagonalMatrix<int>(-1));
        }
    }
}
