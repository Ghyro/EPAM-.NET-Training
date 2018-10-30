using System;
using Tasks.Task3;
using NUnit.Framework;
using Convert = Tasks.Task3.Convert;

namespace ConverterNUnitTests
{
    [TestFixture]
    public class ConvertTests
    {
        [Test]
        [TestCase("0110111101100001100001010111111", 2, ExpectedResult = 934331071)]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        [TestCase("11101101111011001100001010", 2, ExpectedResult = 62370570)]
        [TestCase("1AEF101", 16, ExpectedResult = 28242177)]
        [TestCase("1ACB67", 16, ExpectedResult = 1756007)]
        [TestCase("764241", 8, ExpectedResult = 256161)]
        public int Convert_InputCorrectValues_NUnit(string number, int p)
        {
            //Arrange
            Notation notation = new Notation(p);

            //Assert
            return Convert.Converting(number, notation);
        }

        [TestCase(null, 2)]
        [TestCase("", 2)]
        public void Convert_InputWrongValues_NUnit(string number, int p)
        {
            //Arrange
            Notation not = new Notation(p);

            //Assert
            Assert.Throws<ArgumentNullException>(() => Convert.Converting(number, not));
        }
    }
}
