using NET.A._2019.Sivko._02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace UnitTestDay02
{
    [TestClass]
    public class FilterMSTest
    {
        [TestMethod]
        public void FilterDigitTest1()
        {
            List<int> source = new List<int> { 7, 1, 2, 3, 4, 5, 7, 68, 70, 15, 17 };
            int number = 7;

            List<int> expected = new List<int> { 7, 70, 17 };
            List<int> actual = Filter.FilterDigit(source, number);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterDigitTest2()
        {
            List<int> source = new List<int> { 23, 1, 17, 3, 4, 1, 1, 68, 1741, 15, 17 };
            int number = 1;

            List<int> expected = new List<int> { 1, 17, 1741, 15 };
            List<int> actual = Filter.FilterDigit(source, number);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FilterExceptionTest1()
        {
            List<int> source = new List<int>();

            try
            {
                List<int> result = Filter.FilterDigit(source, 4);
            }
            catch (Exception ex)
            {
                StringAssert.Contains("Null object", ex.Message);
            }
        }

        [TestMethod]
        public void FilterExceptionTest2()
        {
            List<int> source = new List<int>() { 3, 4};

            try
            {
                List<int> result = Filter.FilterDigit(source, 45);
            }
            catch (Exception ex)
            {
                StringAssert.Contains("Number must be a digit", ex.Message);
            }
        }
    }
}
