using NET.A._2019.Sivko._02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestDay02
{
    [TestClass]
    public class InsertBitsMSTest
    {
        [TestMethod]
        public void InsertNumberTest1()
        {
            int numberSource = 15;
            int numberIn = 15;
            int i = 0, j = 0;

            int expected = 15;
            int actual = InsertBits.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumberTest2()
        {
            int numberSource = 8;
            int numberIn = 15;
            int i = 0, j = 0;

            int expected = 9;
            int actual = InsertBits.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumberTest3()
        {
            int numberSource = 8;
            int numberIn = 15;
            int i = 3, j = 8;

            int expected = 120;
            int actual = InsertBits.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumberTest4()
        {
            int numberSource = -8;
            int numberIn = 15;
            int i = 3, j = 8;

            int expected = -120;
            int actual = InsertBits.InsertNumber(numberSource, numberIn, i, j);

            Assert.AreEqual(expected, actual);
        }
    }
}
