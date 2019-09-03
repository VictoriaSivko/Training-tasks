using System;
using NUnit.Framework;
using BookLib;

namespace BookTest
{
    [TestFixture]
    public class BookFormatterTest
    {
        /// <summary>
        /// Check the basic methods of the client formatting.
        /// </summary>
        /// <param name="format">The format of the string representation of the book.</param>
        /// <returns>The string representation of the book according to the required format.</returns>
        [TestCase("Default", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826., 59,99.")]
        [TestCase("Price", ExpectedResult = "This book costs 59,99 rub.")]
        [TestCase("Pages", ExpectedResult = "This book can be read in 4 days")]
        public string FormatsTest(string format)
        {
            Book book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            return String.Format(new BookFormatter(), "{0:" + format + "}", book);
        }
    }
}
