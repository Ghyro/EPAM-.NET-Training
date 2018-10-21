using System;
using Tasks;
using NUnit.Framework;

namespace TasksTests
{
    [TestFixture]
    public class Task1Tests
    {
        [Test]
        [TestCase(new double[] { 2, 0, 0, 0, 0 }, ExpectedResult = 0)]
        [TestCase(new double[] { 0, 0, 0, 0, 0 }, ExpectedResult = 0)]
        public static int Polynomial_InputCorrectValuesOrder_NUnit(double[] array)
        {
            //Arrange
            Polynomial p = new Polynomial(array);

            //Act
            return p.Exponent;

        }

        [Test]
        [TestCase(new double[] { 1, 4, 3, 7, 5 }, 0, ExpectedResult = 1)]
        [TestCase(new double[] { 1, 4, 3, 7, 5 }, 1, ExpectedResult = 4)]
        [TestCase(new double[] { 1, 4, 3, 7, 5 }, 2, ExpectedResult = 3)]
        public static double Polynomial_InputCorrectValuesCoefficients_NUnit(double[] array, int factor)
        {
            //Arrange
            Polynomial pln = new Polynomial(array);

            //Act
            return pln[factor];

        }

        [Test]
        [TestCase(new double[] { 1, 4, 3 }, new double[] { 0, 0, 0, 1, 4, 3 })]
        public static void Polynomial_OperationPlus_NUnit(double[] array1, double[] array2)
        {
            //Arrange
            Polynomial pln1 = new Polynomial(array1);
            Polynomial pln2 = new Polynomial(array2);

            //Act
            Polynomial pln = pln1 + pln2;

            double[] expected = new double[pln2.Exponent + 1];

            for (int i = 0; i < array1.Length; i++)
            {
                expected[i] = array1[i] + array2[i];
            }
                
            for (int i = array1.Length; i < array2.Length; i++)
            {
                expected[i] = array2[i];
            }
            
            //Assert            
            CollectionAssert.AreEqual(expected, pln.Coefficients);
        }

        [Test]
        [TestCase(new double[] { 1, 4, 3 }, new double[] { 0, 0, 0, 1, 4, 3 })]
        public static void Polynomial_OperationMinus_NUnit(double[] array1, double[] array2)
        {
            //Arrange
            Polynomial pln1 = new Polynomial(array1);
            Polynomial pln2 = new Polynomial(array2);

            //Act
            Polynomial pln = pln1 - pln2;

            double[] expected = new double[pln2.Exponent + 1];

            for (int i = 0; i < array1.Length; i++)
            {
                expected[i] = array1[i] - array2[i];
            }
                
            for (int i = array1.Length; i < array2.Length; i++)
            {
                expected[i] = -array2[i];
            }
                
            //Assert
            CollectionAssert.AreEqual(expected, pln.Coefficients);
        }

        [Test]
        [TestCase(new double[] { 1, 4, 3 }, 2.0)]
        [TestCase(new double[] { 1, 4, 3 }, -2)]
        public static void Polynomial_OperationMultiply_NUnit(double[] array, double n)
        {
            //Arrange
            Polynomial pln = new Polynomial(array);

            //Act
            pln = pln * n;

            double[] expected = new double[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                expected[i] = array[i] * n;
            }
               
            //Assert
            CollectionAssert.AreEqual(expected, pln.Coefficients);
        }

        [Test]
        [TestCase(new double[] { 1, 4 }, new double[] { 1, 8, 16 })]
        public static void Polynomial_OperationMultiplyPolynomial_NUnit(double[] array, double[] expected)
        {
            //Arrange
            Polynomial pln = new Polynomial(array);

            //Act
            pln = pln * pln;

            //Assert
            CollectionAssert.AreEqual(expected, pln.Coefficients);
        }

        [Test]
        [TestCase(new double[] { 1, 2 }, ExpectedResult = "1 + 2*x^1")]
        [TestCase(new double[] { 1, 0, 2 }, ExpectedResult = "1 + 2*x^2")]
        public static string Polynomial_GetToString_NUnit(double[] array)
        {
            //Arrange
            Polynomial p = new Polynomial(array);

            //Act
            return p.ToString();
        }
    }
}
