using System;
using NUnit.Framework;
using Tasks;

namespace TasksTests.Task2Tests
{
    [TestFixture]
    public class Task2TestsNUnit
    {
        [Test]
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(2077, ExpectedResult = 2707)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumber_InputCorrectValue_NUnit(int number)
        {
            //Assert
            return Task2.FindNextBiggerNumber(number);
        }   

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-2)]
        [TestCase(-100)]
        public void FindNextBiggerNumber_InputValueForException_NUnit(int number)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => Task2.FindNextBiggerNumber(number));
        }

    }
}
