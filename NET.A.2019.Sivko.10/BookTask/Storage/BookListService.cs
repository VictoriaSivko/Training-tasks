// <copyright file="BookListService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Books
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Allows to work with a set of books.
    /// </summary>
    public class BookListService
    {
        /// <summary>
        /// Gets list of books.
        /// </summary>
        public List<Book> BookList { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        /// <param name="bookList">The List of books.</param>
        public BookListService(List<Book> bookList)
        {
            this.BookList = bookList;
        }

        /// <summary>
        /// Adds a new book to the BookList.
        /// </summary>
        /// <param name="book">The book object.</param>
        public void AddBook(Book book)
        {
            if (this.BookList.Contains(book))
            {
                throw new Exception("Attempt to add an existing object");
            }

            this.BookList.Add(book);
        }

        /// <summary>
        /// Removes a book from BookList.
        /// </summary>
        /// <param name="book">The book object.</param>
        public void RemoveBook(Book book)
        {
            if (!this.BookList.Contains(book))
            {
                throw new Exception("Attempt to delete a non-existing object");
            }

            this.BookList.Remove(book);
        }

        /// <summary>
        /// Looking for books on a given criterion.
        /// </summary>
        /// <param name="finder">Search criterion.</param>
        /// <returns>Books matching the search criteria.</returns>
        public List<Book> FindBookByTag(IFinder<Book> finder)
        {
            if (finder == null)
            {
                throw new ArgumentNullException("IFinder<Book> finder");
            }

            List<Book> temp = new List<Book>();
            foreach (Book book in this.BookList)
            {
                if (finder.Find(book))
                {
                    temp.Add(book);
                }
            }

            return temp;
        }

        /// <summary>
        /// Sorts books according to the specified criteria.
        /// </summary>
        /// <param name="comparerTag">Sort criterion.</param>
        public void SortBooksByTag(IComparer<Book> comparerTag)
        {
            if (comparerTag == null)
            {
                throw new ArgumentNullException("IComparer<Book> comparerTag");
            }

            this.BookList.Sort(comparerTag);
        }

        /// <summary>
        /// Directed to a method for recording objects books in file.
        /// </summary>
        /// <param name="path">File path.</param>
        public void WriteToFile(string path)
        {
            BookListStorage.WriteBooksToBinFile(this.BookList, path);
        }
    }
}
