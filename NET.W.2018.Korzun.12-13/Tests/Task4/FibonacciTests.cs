using NUnit.Framework;
using System.Linq;
using Tasks.Task4;

namespace Tests.Task4
{
    [TestFixture]
    public class FibonacciTests
    {
        [Test]
        [TestCase(6, new int[] { 0, 1, 1, 2, 3, 5 })]
        [TestCase(0, new int[] { })]
        public void CalculationFibonacci_InputCorrectValues(int count, int[] expected)
        {
            // Assert
            Assert.IsTrue(Fibonacci.CalculationFibonacci().Take(count).SequenceEqual(expected));
        }
    }
}
