using NLog;
using System;
using System.Collections.Generic;

namespace BookLib
{
    /// <summary>
    /// Allows to work with a set of books.
    /// </summary>
    public class BookListService
    {
        /// <summary>
        /// Gets list of books.
        /// </summary>
        public List<Book> BookList { get; private set; }
        private readonly Logger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        /// <param name="bookList">The List of books.</param>
        public BookListService(List<Book> bookList)
        {
            this.BookList = bookList;
            logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Adds a new book to the BookList.
        /// </summary>
        /// <param name="book">The book object.</param>
        public void AddBook(Book book)
        {
            if (this.BookList.Contains(book))
            {
                logger.Error("Re-add an existing workbook");
                throw new Exception("Attempt to add an existing object");
            }

            this.BookList.Add(book);
            logger.Trace("The book is added to BookList");
        }

        /// <summary>
        /// Removes a book from BookList.
        /// </summary>
        /// <param name="book">The book object.</param>
        public void RemoveBook(Book book)
        {
            if (!this.BookList.Contains(book))
            {
                logger.Error("Deleting a non-existing book");
                throw new Exception("Attempt to delete a non-existing object");
            }

            this.BookList.Remove(book);
            logger.Trace("The book has been removed from the BookList");
        }

        /// <summary>
        /// Looking for books on a given criterion.
        /// </summary>
        /// <param name="finder">Search criterion.</param>
        /// <returns>Books matching the search criteria.</returns>
        public List<Book> FindBookByTag(IFinder<Book> finder)
        {
            logger.Trace("Book search by tag");
            
            if (finder == null)
            {
                logger.Error("Null IFinder object");
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
            logger.Trace("Sort books by tag");

            if (comparerTag == null)
            {
                logger.Error("Null IComparer object");
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
            logger.Trace("Transition to the method of writing data to a file");    
            BookListStorage.WriteBooksToBinFile(this.BookList, path);
        }
    }
}
