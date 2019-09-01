// <copyright file="ComparerClasses.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Books
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for sorting books by their identification number.
    /// </summary>
    public class SortByISBN : IComparer<Book>
    {
        /// <summary>
        /// Compares two book objects by length of their identification number.
        /// </summary>
        /// <param name="x">First book object.</param>
        /// <param name="y">Second book object.</param>
        /// <returns>Сomparison result.</returns>
        public int Compare(Book x, Book y)
        {
            if (x.ISBN.Length > y.ISBN.Length)
            {
                return 1;
            }
            else if (x.ISBN.Length < y.ISBN.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Class for sorting books by their authors.
    /// </summary>
    public class SortByAuthor : IComparer<Book>
    {
        /// <summary>
        /// Compares two book objects by their authors.
        /// </summary>
        /// <param name="x">First book object.</param>
        /// <param name="y">Second book object.</param>
        /// <returns>Сomparison result.</returns>
        public int Compare(Book x, Book y)
        {
            return x.Author.CompareTo(y.Author);
        }
    }

    /// <summary>
    /// Class for sorting books by their titles.
    /// </summary>
    public class SortByBookTitle : IComparer<Book>
    {
        /// <summary>
        /// Compares two book objects by their titles.
        /// </summary>
        /// <param name="x">First book object.</param>
        /// <param name="y">Second book object.</param>
        /// <returns>Сomparison result.</returns>
        public int Compare(Book x, Book y)
        {
            return x.BookTitle.CompareTo(y.BookTitle);
        }
    }

    /// <summary>
    /// Class for sorting books by their publishing.
    /// </summary>
    public class SortByPublishing : IComparer<Book>
    {
        /// <summary>
        /// Compares two book objects by their publishing.
        /// </summary>
        /// <param name="x">First book object.</param>
        /// <param name="y">Second book object.</param>
        /// <returns>Сomparison result.</returns>
        public int Compare(Book x, Book y)
        {
            return x.Publishing.CompareTo(y.Publishing);
        }
    }

    /// <summary>
    /// Class for sorting books by year of publication.
    /// </summary>
    public class SortByPublicationYear : IComparer<Book>
    {
        /// <summary>
        /// Compares two book objects by their year of publication.
        /// </summary>
        /// <param name="x">First book object.</param>
        /// <param name="y">Second book object.</param>
        /// <returns>Сomparison result.</returns>
        public int Compare(Book x, Book y)
        {
            if (x.PublicationYear > y.PublicationYear)
            {
                return 1;
            }
            else if (x.PublicationYear < y.PublicationYear)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Class for sorting books by number of pages.
    /// </summary>
    public class SortByNumberOfPages : IComparer<Book>
    {
        /// <summary>
        /// Compares two book objects by their number of pages.
        /// </summary>
        /// <param name="x">First book object.</param>
        /// <param name="y">Second book object.</param>
        /// <returns>Сomparison result.</returns>
        public int Compare(Book x, Book y)
        {
            if (x.NumberOfPages > y.NumberOfPages)
            {
                return 1;
            }
            else if (x.NumberOfPages < y.NumberOfPages)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Class for sorting books by their price.
    /// </summary>
    public class SortByPrice : IComparer<Book>
    {
        /// <summary>
        /// Compares two book objects by their price.
        /// </summary>
        /// <param name="x">First book object.</param>
        /// <param name="y">Second book object.</param>
        /// <returns>Сomparison result.</returns>
        public int Compare(Book x, Book y)
        {
            if (x.Price > y.Price)
            {
                return 1;
            }
            else if (x.Price < y.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
