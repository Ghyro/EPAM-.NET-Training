using System;
using System.Diagnostics;
using NUnit.Framework;
using Tasks;

namespace TasksTests.Task3Tests
{
    [TestFixture]
    public class Task3TestsNUnir
    {
        [Test]
        [TestCase(12)]
        [TestCase(513)]
        [TestCase(2017)]
        [TestCase(2077)]
        [TestCase(414)]
        [TestCase(144)]
        [TestCase(1234126)]
        [TestCase(10)]
        [TestCase(20)]
        public void TimeFindNumber_TestTime_NUnit(int number)
        {
            //Arrange
            Stopwatch stopwatch = new Stopwatch();

            //Act
            stopwatch = Task3.TimeFindNumber(number);

            //Assert
            Assert.Pass("Time test is {0}", stopwatch.Elapsed.ToString());
        }
    }
}
