using System.Collections.Generic;

namespace Books
{
    public class SortByISBN : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.ISBN.Length > y.ISBN.Length)
                return 1;
            else if (x.ISBN.Length < y.ISBN.Length)
                return -1;
            else
                return 0;
        }
    }

    public class SortByAuthor : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Author.CompareTo(y.Author);
        }
    }

    public class SortByBookTitle : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.BookTitle.CompareTo(y.BookTitle);
        }
    }

    public class SortByPublishing : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Publishing.CompareTo(y.Publishing);
        }
    }

    public class SortByPublicationYear : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.PublicationYear > y.PublicationYear)
                return 1;
            else if (x.PublicationYear < y.PublicationYear)
                return -1;
            else
                return 0;
        }
    }

    public class SortByNumberOfPages : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.NumberOfPages > y.NumberOfPages)
                return 1;
            else if (x.NumberOfPages < y.NumberOfPages)
                return -1;
            else
                return 0;
        }
    }

    public class SortByPrice : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Price > y.Price)
                return 1;
            else if (x.Price < y.Price)
                return -1;
            else
                return 0;
        }
    }
}
