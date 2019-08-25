using System;
using System.Collections.Generic;

namespace Books
{
    public class BookListService
    {
        public List<Book> BookList { get; private set; }

        public BookListService(List<Book> bookList)
        {
            BookList = bookList;
        }

        /// <summary>
        /// Adds a new book to the BookList
        /// </summary>
        /// <param name="book">The book object</param>
        public void AddBook(Book book)
        {
            if (BookList.Contains(book))
                throw new Exception("Attempt to add an existing object");

            BookList.Add(book);
        }

        /// <summary>
        /// Removes a book from BookList
        /// </summary>
        /// <param name="book">The book object</param>
        public void RemoveBook(Book book)
        {
            if (!BookList.Contains(book))
                throw new Exception("Attempt to delete a non-existing object");

            BookList.Remove(book);
        }

        /// <summary>
        /// Looking for books on a given criterion
        /// </summary>
        /// <param name="finder">Search criterion</param>
        /// <returns>Books matching the search criteria</returns>
        public List<Book> FindBookByTag(IFinder<Book> finder)
        {
            if (finder == null)
                throw new ArgumentNullException("IFinder<Book> finder");

            List<Book> temp = new List<Book>();
            foreach (Book book in BookList)
                if (finder.Find(book))
                    temp.Add(book);

            return temp;
        }

        /// <summary>
        /// Sorts books according to the specified criteria
        /// </summary>
        /// <param name="comparerTag">Sort criterion</param>
        public void SortBooksByTag(IComparer<Book> comparerTag)
        {
            if (comparerTag == null)
                throw new ArgumentNullException("IComparer<Book> comparerTag");

            BookList.Sort(comparerTag);
        }

        public void WriteToFile(string path)
        {
            BookListStorage.WriteBooksToBinFile(BookList, path);
        }
    }
}
