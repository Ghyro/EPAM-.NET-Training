using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tasks;

namespace TasksTests.Task1Tests
{
    [TestClass]
    public class Task1TestsMSUnit
    {
        [TestMethod]
        [DataRow(15, 15, 0, 0, 15)]
        [DataRow(8, 15, 0, 0, 9)]
        [DataRow(8, 15, 3, 8, 120)]
        public void InsertNumber_InputCorrectValuesMSUnit(int value1, int value2, int startPosition, int endPosition, int expectationValue)
        {
            //Arrange
            //Data row

            //Act
            int resultValue = Task1.InsertNumber(value1, value2, startPosition, endPosition);

            //Assert
            Assert.AreEqual(expectationValue, resultValue);
        }

        [TestMethod]
        [DataRow(15, 15, 3, 2)]
        [DataRow(8, 15, -2, 33)]
        [DataRow(8, 15, 32, -2)]
        public void InsertNumber_InputValuesForExceptionMSUnit(int value1, int value2, int startPosition, int endPosition)
        {
            Assert.ThrowsException<ArgumentException>(() => Task1.Validation(startPosition, endPosition));
        }
    }
}
