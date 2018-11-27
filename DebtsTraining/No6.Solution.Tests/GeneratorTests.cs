using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace No6.Solution.Tests
{
    [TestFixture]
    public class GeneratorTests
    {
        [Test]
        public void Generate_InputCorrectValues_TheFirstIntValues()
        {
            var input = new Generator().Generate(1, 2, 3, (a, b) => a + b);
        }

        [Test]
        public void Generate_InputCorrectValues_TheSecondIntValues()
        {
            var input = new Generator().Generate(1, 2, 3, (x, y) => 6 * x - 8 * y);
        }

        [Test]
        public void Generate_InputCorrectValues_DoubleValues()
        {
            var input = new Generator().Generate(1.0, 2.0, 3, (x, y) => x + (y / x));
        }
    }
}
