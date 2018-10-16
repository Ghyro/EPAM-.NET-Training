using System;
using System.Diagnostics;
using NUnit.Framework;
using Tasks;

namespace TasksTests
{
    [TestFixture]
    public class Task1_2Tests
    {
        [Test]
        [TestCase(6, 12, 7, 55, ExpectedResult = 1)]
        [TestCase(24, 3, 48, 213, ExpectedResult = 3)]
        [TestCase(20, 40, 48, ExpectedResult = 4)]
        public int AlgorithmEuclidean_InputCorrentValuesParams_NUnit(int number1, int number2, params int[] numbers)
        {
            //Assert
            return Task1_2.AlgorithmEuclidean(number1, number2, numbers);
        }

        [Test]
        [TestCase(20, 40, ExpectedResult = 20)]
        [TestCase(5, 40, ExpectedResult = 5)]
        [TestCase(124, 40, ExpectedResult = 4)]
        [TestCase(24, 123, ExpectedResult = 3)]
        [TestCase(22, 44, ExpectedResult = 22)]
        public int AlgorithmEuclidean_InputCorrentValuesTwoNumber_NUnit(int number1, int number2)
        {
            //Assert
            return Task1_2.AlgorithmEuclidean(number1, number2);
        }

        [Test]
        public void AlgorithmEuclidean_InputNull_NUnit()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => Task1_2.AlgorithmEuclidean(6, 12, null));
        }

        [Test]
        [TestCase(20, 40)]
        [TestCase(5, 40)]
        [TestCase(124, 40)]
        [TestCase(24, 123)]
        [TestCase(22, 44)]
        public void AlgorithmEuclideanTime_GetTimeTwoNumber_NUnit(int number1, int number2)
        {
            //Arrange
            TimeSpan timeSpan = new TimeSpan();

            //Act
            int result = Task1_2.AlgorithmEuclideanTime(out timeSpan, number1, number2);

            //Assert
            Assert.IsTrue(timeSpan.Seconds <= 1, $"Time is {timeSpan.ToString()}");
        }

        [Test]
        [TestCase(6, 12, 7, 55)]
        [TestCase(24, 3, 48, 213)]
        [TestCase(20, 40, 48)]
        public void AlgorithmEuclideanTime_GetTimeParam_NUnit(int number1, int number2, params int[] numbers)
        {
            //Arrange
            TimeSpan timeSpan = new TimeSpan();

            //Act
            int result = Task1_2.AlgorithmEuclideanTime(out timeSpan, number1, number2, numbers);

            //Assert
            Assert.IsTrue(timeSpan.Seconds <= 1, $"Time is {timeSpan.ToString()}");
        }

        [Test]
        [TestCase(6, 12, 7, 55, ExpectedResult = 1)]
        [TestCase(24, 3, 48, 213, ExpectedResult = 3)]
        [TestCase(4, 16, 8, ExpectedResult = 4)]
        [TestCase(5, 40, 20, ExpectedResult = 5)]
        public int AlgorithmStein_InputCorrentValuesParams_NUnit(int number1, int number2, params int[] numbers)
        {
            //Assert
            return Task1_2.AlgorithmStein(number1, number2, numbers);
        }

        [Test]
        [TestCase(20, 40, ExpectedResult = 20)]
        [TestCase(5, 40, ExpectedResult = 5)]
        [TestCase(24, 123, ExpectedResult = 3)]
        [TestCase(22, 44, ExpectedResult = 22)]
        public int AlgorithmStein_InputCorrentValuesTwoNumber_NUnit(int number1, int number2)
        {
            //Assert
            return Task1_2.AlgorithmStein(number1, number2);
        }

        [Test]
        public void AlgorithmStein_InputNull_NUnit()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => Task1_2.AlgorithmEuclidean(6, 12, null));
        }

        [Test]
        [TestCase(20, 40)]
        [TestCase(5, 40)]
        [TestCase(124, 40)]
        [TestCase(24, 123)]
        [TestCase(22, 44)]
        public void AlgorithmSteinTime_GetTimeTwoNumber_NUnit(int number1, int number2)
        {
            //Arrange
            TimeSpan timeSpan = new TimeSpan();

            //Act
            int result = Task1_2.AlgorithmSteinTime(out timeSpan, number1, number2);

            //Assert
            Assert.IsTrue(timeSpan.Seconds <= 1, $"Time is {timeSpan.ToString()}");
        }

        [Test]
        [TestCase(6, 12, 7, 55)]
        [TestCase(24, 3, 48, 213)]
        [TestCase(20, 40, 48)]
        public void AlgorithmSteinTime_GetTimeParam_NUnit(int number1, int number2, params int[] numbers)
        {
            //Arrange
            TimeSpan timeSpan = new TimeSpan();

            //Act
            int result = Task1_2.AlgorithmSteinTime(out timeSpan, number1, number2, numbers);

            //Assert
            Assert.IsTrue(timeSpan.Seconds <= 1, $"Time is {timeSpan.ToString()}");
        }
    }
}
