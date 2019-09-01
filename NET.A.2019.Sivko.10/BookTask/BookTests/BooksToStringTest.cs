// <copyright file="BooksToStringTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BooksTest
{
    using System;
    using Books;
    using NUnit.Framework;

    /// <summary>
    /// Verifies that the string representation of books is correct.
    /// </summary>
    [TestFixture]
    public class BooksToStringTest
    {
        /// <summary>
        /// Check the basic methods of the client formatting.
        /// </summary>
        /// <param name="format">The format of the string representation of the book.</param>
        /// <param name="formatProvider">The object refers to a culture.</param>
        /// <returns>The string representation of the book according to the required format.</returns>
        [TestCase(null, null, ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826., 59,99.")]
        [TestCase("Default", null, ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826., 59,99.")]
        [TestCase("AT", null, ExpectedResult = "Jeffrey Richter, CLR via C#")]
        [TestCase("ATPPY", null, ExpectedResult = "Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012")]
        [TestCase("IATPPYP", null, ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, \"Microsoft Press\", 2012, P. 826.")]
        public string FormatsTest(string format, IFormatProvider formatProvider)
        {
            Book book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            return book.ToString(format, formatProvider);
        }

        /// <summary>
        /// Tests the operation of exceptions.
        /// </summary>
        /// <param name="format">The format of the string representation of the book.</param>
        /// <param name="formatProvider">The object refers to a culture.</param>
        [TestCase("dw", null)]
        public void WrongFormatExceptionTest(string format, IFormatProvider formatProvider)
        {
            Book book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            var ex = Assert.Catch<Exception>(() => book.ToString(format, formatProvider));
            StringAssert.Contains("No string representation of the required format was found", ex.Message);
        }
    }
}