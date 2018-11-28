using System;
using System.Collections.Generic;
using No3.Solution.Calculate;
using No3.Solution.Ways;
using NUnit.Framework;

namespace No3.Solution.Tests
{
    [TestFixture]
    public class CalculateTests
    {
        [Test]
        public void Calculate_InputCorrectValues_Mean_NUnit()
        {
            // Arrange
            Calculator calculator = new Calculator();
            List<double> list = new List<double>() { 1.0, 2.0, 1.0, 2.0 };
            double expected = 1.5;

            // Act
            double result = calculator.CalculateAverage(list, new Mean());

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_InputCorrectValues_Median_NUnit()
        {
            // Arrange
            Calculator calculator = new Calculator();
            List<double> list = new List<double>() { 1.0, 2.0, 1.0, 2.0 };
            double expected = 1.5;

            // Act
            double result = calculator.CalculateAverage(list, new Median());

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Calculate_InputWrongValues_Median_NUnit()
        {
            // Arrange
            Calculator calculator = new Calculator();
            List<double> list = new List<double>() { 1.0, 2.0, 1.0, 2.0 };

            // Assert
            Assert.Throws<ArgumentNullException>(() => calculator.CalculateAverage(null, new Median()));
        }
    }
}
