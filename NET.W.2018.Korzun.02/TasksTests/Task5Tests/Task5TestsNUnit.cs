using System;
using NUnit.Framework;
using Tasks;

namespace TasksTests.Task5Tests
{
    [TestFixture]
    public class Task5TestsNUnit
    {
        [Test]
        [TestCase(1, 5, 0.0001)]
        [TestCase(8, 3, 0.0001)]
        [TestCase(0.001, 3, 0.0001)]
        [TestCase(0.04100625, 4, 0.0001)]
        [TestCase(8, 3, 0.0001)]
        [TestCase(0.0279936, 7, 0.0001)]
        [TestCase(0.0081, 4, 0.1)]
        [TestCase(0.004241979, 9, 0.00000001)]
        public void FindNthRoot_InputCorrectValues(double value, int root, double eps)
        {
            //Arrange
            //Test case

            ///Act
            double result = Task5.FindNthRoot(value, root, eps);

            //Arrange
            Assert.IsTrue(Math.Abs(result - Math.Pow(value, 1.0 / root)) < eps);
        }

        [Test]
        [TestCase(-0.008, 0, 0.1)]
        [TestCase(-8, 4, 0.0001)]
        [TestCase(8, 3, -0.0001)]
        public void FindNthRoot_InputValuesForException(double value, int root, double eps)
        {
            Assert.Throws<ArgumentException>(() => { Task5.FindNthRoot(value, root, eps); });
        }

    }
}
