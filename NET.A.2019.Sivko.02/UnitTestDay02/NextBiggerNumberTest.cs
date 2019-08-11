using NET.A._2019.Sivko._02;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDay02
{
    [TestClass]
    public class NextBiggerNumberTest
    {
        [TestMethod]
        public void BiggerNumberTest1()
        {
            int source = 12;
            int expected = 21;

            int actual = NextBiggerNumber.FindNextBiggerNumber(source);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BiggerNumberTest2()
        {
            int source = 513;
            int expected = 531;

            int actual = NextBiggerNumber.FindNextBiggerNumber(source);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BiggerNumberTest3()
        {
            int source = 2017;
            int expected = 2071;

            int actual = NextBiggerNumber.FindNextBiggerNumber(source);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BiggerNumberTest4()
        {
            int source = 144;
            int expected = 414;

            int actual = NextBiggerNumber.FindNextBiggerNumber(source);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BiggerNumberTest5()
        {
            int source = 1234321;
            int expected = 1241233;

            int actual = NextBiggerNumber.FindNextBiggerNumber(source);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BiggerNumberTest6()
        {
            int source = 1234126;
            int expected = 1234162;

            int actual = NextBiggerNumber.FindNextBiggerNumber(source);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BiggerNumberTest7()
        {
            int source = 3456432;
            int expected = 3462345;

            int actual = NextBiggerNumber.FindNextBiggerNumber(source);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BiggerNumberTest8()
        {
            int source = 10;
            int expected = -1;

            int actual = NextBiggerNumber.FindNextBiggerNumber(source);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BiggerNumberTest9()
        {
            int source = 221;
            int expected = -1;

            int actual = NextBiggerNumber.FindNextBiggerNumber(source);

            Assert.AreEqual(expected, actual);
        }
    }
}
