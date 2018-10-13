using System;
using Tasks;
using NUnit.Framework;

namespace TasksTests.Task1Tests
{
    [TestFixture]
    public class Task1TestsNUnit
    {
        [Test]
        [TestCase(15, 15, 0, 0, 15)]
        [TestCase(8, 15, 0, 0, 9)]
        [TestCase(8, 15, 3, 8, 120)]
        public void TestMeInsertNumber_InputCorrectValuesNUnit(int value1, int value2, int startPosition, int endPosition, int expectationValue)
        {
            //Arrange
            //Test case

            //Act
            int resultValue = Task1.InsertNumber(value1, value2, startPosition, endPosition);

            //Assert
            Assert.AreEqual(expectationValue, resultValue);
        }

        [Test]
        [TestCase(15, 15, 3, 2)]
        [TestCase(8, 15, -2, 33)]
        [TestCase(8, 15, 32, -2)]
        public void InsertNumber_InputValuesForExceptionNUnit(int value1, int value2, int startPosition, int endPosition)
        {
            Assert.Throws<ArgumentException>(() => Task1.Validation(startPosition, endPosition));
        }
    }
}
