using NET.A._2019.Sivko._02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestDay02
{
    [TestClass]
    public class RootTest
    {
        [TestMethod]
        public void RootTest1()
        {
            double number = 1;
            double root = 5;
            double eps = 0.0001;

            double expected = 1;
            double actual = Root.FindNthRoot(number, root, eps);

            Assert.AreEqual(expected, Math.Round(actual,0));
        }

        [TestMethod]
        public void RootTest2()
        {
            double number = 8;
            double root = 3;
            double eps = 0.0001;

            double expected = 2;
            double actual = Root.FindNthRoot(number, root, eps);

            Assert.AreEqual(expected, Math.Round(actual, 0));
        }

        [TestMethod]
        public void RootTest3()
        {
            double number = 0.001;
            double root = 3;
            double eps = 0.0001;

            double expected = 0.1;
            double actual = Root.FindNthRoot(number, root, eps);

            Assert.AreEqual(expected, Math.Round(actual, 1));
        }

        [TestMethod]
        public void RootTest4()
        {
            double number = 0.04100625;
            double root = 4;
            double eps = 0.0001;

            double expected = 0.45;
            double actual = Root.FindNthRoot(number, root, eps);

            Assert.AreEqual(expected, Math.Round(actual, 2));
        }

        [TestMethod]
        public void RootTest5()
        {
            double number = -0.008;
            double root = 3;
            double eps  = 0.1;

            double expected = -0.2;
            double actual = Root.FindNthRoot(number, root, eps);

            Assert.AreEqual(expected, Math.Round(actual, 1));
        }
    }
}
