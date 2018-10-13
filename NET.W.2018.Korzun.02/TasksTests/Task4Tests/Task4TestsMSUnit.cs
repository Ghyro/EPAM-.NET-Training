using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tasks;

namespace TasksTests.Task4Tests
{
    [TestClass]
    public class Task4TestsMSUnit
    {
        [TestMethod]
        public void FilterDigit_InputCorrectValues()
        {
            //Arrange
            int currentDigit = 5;
            List<int> inputList = new List<int> { 1, 2, 5, 7, 3, 334, 566, 223, 66, 334, 54, 95, 8 };
            List<int> expected = new List<int> { 5, 566, 54, 95 };

            //Act
            List<int> result = Task4.FilterDigit(inputList, currentDigit);

            //Assert
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void FilterDigit_InputNegativeCurrentDigit()
        {
            //Arrange
            int currentDigit = -1;
            List<int> inputList = new List<int> { 1, 2, 5, 7, 3, 334, 566, 223, 66, 334, 54, 95, 8 };

            //Assert
            Assert.ThrowsException<ArgumentException>(() => Task4.FilterDigit(inputList, currentDigit));
        }

        [TestMethod]
        public void FilterDigit_InputGreatCurrentDigit()
        {
            //Arrange
            int currentDigit = 100;
            List<int> inputList = new List<int> { 1, 2, 5, 7, 3, 334, 566, 223, 66, 334, 54, 95, 8 };

            //Assert
            Assert.ThrowsException<ArgumentException>(() => Task4.FilterDigit(inputList, currentDigit));
        }

        [TestMethod]
        public void FilterDigit_InputNegativeList()
        {
            //Arrange
            int currentDigit = 5;
            List<int> inputList = null;

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => Task4.FilterDigit(inputList, currentDigit));
        }
    }
}
