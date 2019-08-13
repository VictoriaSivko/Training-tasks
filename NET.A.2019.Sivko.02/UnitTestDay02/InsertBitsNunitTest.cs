using NUnit.Framework;
using NET.A._2019.Sivko._02;
using System;

namespace UnitTestDay02
{
    [TestFixture]
    public class InsertBitsNunitTest
    {
        [TestCase(15, 8, 17, 2)]
        [TestCase(15, 8, -1, 17)]
        [TestCase(15, 8, 7, -1)]
        [TestCase(15, 8, 5, 32)]
        [TestCase(15, 8, 37, 7)]
        public void InsertBits_ThrowExceptionTest(int numberSource, int numberIn, int i, int j)
        {
            var ex = Assert.Catch<Exception>(() => InsertBits.InsertNumber(numberSource, numberIn, i, j));
            StringAssert.Contains("Wrong indices of the bits to insert", ex.Message);
        }
    }
}
