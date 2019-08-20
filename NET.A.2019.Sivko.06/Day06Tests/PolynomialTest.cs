using NUnit.Framework;
using NET.A._2019.Sivko._06;
using System;

namespace Day06Tests
{
    [TestFixture]
    public class PolynomialTest
    {
        [TestCase(null)]
        [TestCase(new double[] { })]
        public static void NullExceptionTest(double[] array)
        {
            var ex = Assert.Catch<Exception>(() => new Polynomial(new double[] { }));
            StringAssert.Contains("Received a null array", ex.Message);
        }

        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, ExpectedResult = "0,23 + 9,13*(x^1) + 4,1284*(x^2)")]
        [TestCase(new double[] { 0.23, -9.13, 4.1284 }, ExpectedResult = "0,23 - 9,13*(x^1) + 4,1284*(x^2)")]
        [TestCase(new double[] { 0.23, -9.13, 4.1284, -0.0 }, ExpectedResult = "0,23 - 9,13*(x^1) + 4,1284*(x^2) - 0*(x^3)")]
        public static string ToStringTest(double[] array)
        {
            Polynomial polynomial = new Polynomial(array);

            return polynomial.ToString();
        }

        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, ExpectedResult = 255)]
        [TestCase(new double[] { 0.23, 9.13, -4.1284 }, ExpectedResult = 99)]
        public static int GetHashCodeTest(double[] array)
        {
            Polynomial p = new Polynomial(array);

            return p.GetHashCode();
        }

        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, ExpectedResult = false)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, "Hello World!", ExpectedResult = false)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, 6d, ExpectedResult = false)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, 534, ExpectedResult = false)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, ExpectedResult = false)]
        public static bool EqualsToObjectTest(double[] array, object obj = null)
        {
            Polynomial p1 = new Polynomial(array);

            return p1.Equals(obj);
        }

        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, new double[] { 0.23, 14, 5 }, ExpectedResult = false)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, new double[] { 0.23, 9.13, 4.1284 }, ExpectedResult = true)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, new double[] { 9.13, 0.23, 4.1284 }, ExpectedResult = false)]
        public static bool PolinomEqualsTest(double[] array, double[] array2)
        {
            Polynomial p1 = new Polynomial(array);
            Polynomial p2 = new Polynomial(array2);

            return p1.Equals(p2);
        }

        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, new double[] { 0.23, 14, 5 }, ExpectedResult = false)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, new double[] { 0.23, 9.13, 4.1284 }, ExpectedResult = true)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, new double[] { 9.13, 0.23, 4.1284 }, ExpectedResult = false)]
        public static bool EqualityOperatorTest(double[] array, double[] array2)
        {
            Polynomial p1 = new Polynomial(array);
            Polynomial p2 = new Polynomial(array2);

            return p1 == p2;
        }

        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, new double[] { 0.23, 14, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, new double[] { 0.23, 9.13, 4.1284 }, ExpectedResult = false)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, new double[] { 9.13, 0.23, 4.1284 }, ExpectedResult = true)]
        public static bool InequalityOperatorTest(double[] array, double[] array2)
        {
            Polynomial p1 = new Polynomial(array);
            Polynomial p2 = new Polynomial(array2);

            return p1 != p2;
        }

        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, ExpectedResult = false)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, "Hello World!", ExpectedResult = false)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, 6d, ExpectedResult = false)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, 534, ExpectedResult = false)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, ExpectedResult = false)]
        public static bool ObjectEqualityOperatorTest(double[] array, object obj = null)
        {
            Polynomial p1 = new Polynomial(array);

            return p1 == obj;
        }

        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, ExpectedResult = true)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, "Hello World!", ExpectedResult = true)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, 6d, ExpectedResult = true)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, 534, ExpectedResult = true)]
        [TestCase(new double[] { 0.23, 9.13, 4.1284 }, ExpectedResult = true)]
        public static bool ObjectInequalityOperatorTest(double[] array, object obj = null)
        {
            Polynomial p1 = new Polynomial(array);

            return p1 != obj;
        }

        [TestCase(new double[] { 1.23, 4, -0.2 }, new double[] { 1, 14, 5, 5 }, new double[] { 2.23, 18, 4.8, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 14, 5, 5 }, new double[] { 1.23, 4, -0.2 }, new double[] { 2.23, 18, 4.8, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 5, 10, 7 }, new double[] { -3, 1.5, -4.2, -2 }, new double[] { 2, 11.5, 2.8, -2 }, ExpectedResult = true)]
        public static bool PolynomSumTest(double[] array, double[] array2, double[] array3)
        {
            Polynomial p1 = new Polynomial(array);
            Polynomial p2 = new Polynomial(array2);

            Polynomial expected = new Polynomial(array3);

            return (p1 + p2).Equals(expected);
        }

        [TestCase(new double[] { 5, 10, 7 }, "__")]
        [TestCase(new double[] { 5, 10, 7 }, new int[] {1, 4})]
        [TestCase(new double[] { 5, 10, 7 }, null)]
        public static void PolynomPlusObjectExceptionTest(double[] array, object obj)
        {
            Polynomial p1 = new Polynomial(array);

            try
            {
                Polynomial polynomial = p1 + obj;
            }
            catch (Exception ex)
            {
                StringAssert.Contains("The second parameter is not a number", ex.Message);
            }
        }

        [TestCase(new double[] { 1.23, 4, -0.2 }, 5, new double[] { 6.23, 9, 4.8 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 4, -0.2, 5 }, 1d, new double[] { 2, 5, 0.8, 6 }, ExpectedResult = true)]
        [TestCase(new double[] { 5, 10, 7 }, -1, new double[] { 4, 9, 6 }, ExpectedResult = true)]
        public static bool PolynomPlusObjectTest(double[] array, object obj, double[] array3)
        {
            Polynomial p1 = new Polynomial(array);

            Polynomial expected = new Polynomial(array3);

            return (p1 + obj).Equals(expected);
        }

        [TestCase(new double[] { 5, 4, 1}, new double[] { 0.4, 0 }, new double[] { 4.6, 4, 1 }, ExpectedResult = true)]
        [TestCase(new double[] { 5, 10, 7 }, new double[] { -3, 1.5, -4.2, -2 }, new double[] { 8, 8.5, 11.2, 2 }, ExpectedResult = true)]
        public static bool PolynomMinusTest(double[] array, double[] array2, double[] array3)
        {
            Polynomial p1 = new Polynomial(array);
            Polynomial p2 = new Polynomial(array2);

            Polynomial expected = new Polynomial(array3);

            return (p1 - p2).Equals(expected);
        }

        [TestCase(new double[] { 5, 10, 7 }, "__")]
        [TestCase(new double[] { 5, 10, 7 }, new int[] { 1, 4 })]
        [TestCase(new double[] { 5, 10, 7 }, null)]
        public static void PolynomMinusObjectExceptionTest(double[] array, object obj)
        {
            Polynomial p1 = new Polynomial(array);

            try
            {
                Polynomial polynomial = p1 + obj;
            }
            catch (Exception ex)
            {
                StringAssert.Contains("The second parameter is not a number", ex.Message);
            }
        }

        [TestCase(new double[] { 1.23, 4, -0.2 }, 0.2, new double[] { 1.03, 3.8, -0.4 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 4, -0.2, 5 }, 1d, new double[] { 0, 3, -1.2, 4 }, ExpectedResult = true)]
        [TestCase(new double[] { 5, 10, 7 }, -1, new double[] { 6, 11, 8 }, ExpectedResult = true)]
        public static bool PolynomMinusObjectTest(double[] array, object obj, double[] array3)
        {
            Polynomial p1 = new Polynomial(array);

            Polynomial expected = new Polynomial(array3);

            return (p1 - obj).Equals(expected);
        }

        [TestCase(new double[] { 5, -10, 0}, new double[] { -5, 10, -0}, ExpectedResult = true)]
        public static bool MinusOperatorTest(double[] array, double[] array2)
        {
            Polynomial p1 = new Polynomial(array);

            Polynomial expected = new Polynomial(array2);

            return (-p1).Equals(expected);
        }

        [TestCase(new double[] { 5, -10, 0 })]
        public static void DivideByZeroException(double[] array)
        {
            Polynomial p1 = new Polynomial(array);

            try
            {
                Polynomial polynomial = p1 / 0;
            }
            catch (Exception ex)
            {
                StringAssert.Contains("Division by zero is prohibited", ex.Message);
            }
        }

        [TestCase(new double[] { 0.17, -8, 4 }, new double[] { 3, 1.14 }, new double[] { 0.51, -23.81, 2.88, 4.56, 0.00 }, ExpectedResult = "0,51 - 23,8062*(x^1) + 2,88*(x^2) + 4,56*(x^3) + 0*(x^4)")]
        public static string PolynomMulTest(double[] array1, double[] array2, double[] array3)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);

            Polynomial expected = new Polynomial(array3);

            return (p1 * p2).ToString();
        }
    }
}
