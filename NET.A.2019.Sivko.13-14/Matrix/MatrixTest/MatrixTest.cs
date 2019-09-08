using System;
using NUnit.Framework;
using Day13Lib.Matrix;

namespace Day13Test
{
    [TestFixture]
    public class MatrixTest
    {
        [Test]
        public static void MatrSizeException()
        {
            SquareMatrix<string> temp;
            var ex = Assert.Catch<Exception>(() => temp = new SquareMatrix<string>(-3));
            StringAssert.Contains("Cannot create a negative dimension matrix", ex.Message);
        }

        [Test]
        public static void AddDifSizeException()
        {
            SquareMatrix<int> temp = new SquareMatrix<int>(3);
            DiagonalMatrixt<int> temp2 = new DiagonalMatrixt<int>(4);

            Func<int, int, int> func = (x, y) => x + y; 

            var ex = Assert.Catch<Exception>(() => MatrixExtension<int>.Add(temp, temp2, func));
            StringAssert.Contains("Cannot add matrices of different dimensions.", ex.Message);
        }

        [Test]
        public static void SymmetrException()
        {
            SymmetricalMatrix<int> temp = new SymmetricalMatrix<int>(3);
            var ex = Assert.Catch<Exception>(() => temp.SetElement(2, 0, 4));
            StringAssert.Contains("An attempt to break the symmetry of the matrix", ex.Message);
        }

        [Test]
        public static void DiagonalException()
        {
            DiagonalMatrixt<int> temp = new DiagonalMatrixt<int>(3);
            var ex = Assert.Catch<Exception>(() => temp.SetElement(2, 1, 4));
            StringAssert.Contains("Only diagonal elements of the matrix can be changed.", ex.Message);
        }

        [TestCase(4, 23, 3, 2, ExpectedResult = 4)]
        public static int SetTest(params int[] parameter)
        {
            SquareMatrix<int> temp = new SquareMatrix<int>(2);
            for(int i = 0; i<parameter.Length/2; i++)
            {
                for(int j = 0; j<parameter.Length/2; j++)
                temp.SetElement(i, j, parameter[i+j]);
            }

            return temp.GetElement(0, 0);
        }
    }
}
