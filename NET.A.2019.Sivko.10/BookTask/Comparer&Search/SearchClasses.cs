// <copyright file="SearchClasses.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Books
{
    public class FindBooksByISBN : IFinder<Book>
    {
        private string isbn;

        public FindBooksByISBN(string isbn)
        {
            this.isbn = isbn;
        }

        public bool Find(Book book)
        {
            if (book.ISBN.Equals(this.isbn))
            {
                return true;
            }

            return false;
        }
    }

    public class FindBooksByAuthor : IFinder<Book>
    {
        private string author;

        public FindBooksByAuthor(string author)
        {
            this.author = author;
        }

        public bool Find(Book book)
        {
            if (book.Author.Equals(this.author))
            {
                return true;
            }

            return false;
        }
    }

    public class FindBooksByBookTitle : IFinder<Book>
    {
        private string bookTitle;

        public FindBooksByBookTitle(string bookTitle)
        {
            this.bookTitle = bookTitle;
        }

        public bool Find(Book book)
        {
            if (book.BookTitle.Equals(this.bookTitle))
            {
                return true;
            }

            return false;
        }
    }

    public class FindBooksByPublishing : IFinder<Book>
    {
        private string publish;

        public FindBooksByPublishing(string publish)
        {
            this.publish = publish;
        }

        public bool Find(Book book)
        {
            if (book.Publishing.Equals(this.publish))
            {
                return true;
            }

            return false;
        }
    }

    public class FindBooksByPublicationYear : IFinder<Book>
    {
        private int publYear;

        public FindBooksByPublicationYear(int publYear)
        {
            this.publYear = publYear;
        }

        public bool Find(Book book)
        {
            if (book.PublicationYear == this.publYear)
            {
                return true;
            }

            return false;
        }
    }

    public class FindBooksByNumberOfPages : IFinder<Book>
    {
        private int numberOfPages;

        public FindBooksByNumberOfPages(int numberOfPages)
        {
            this.numberOfPages = numberOfPages;
        }

        public bool Find(Book book)
        {
            if (book.NumberOfPages == this.numberOfPages)
            {
                return true;
            }

            return false;
        }
    }

    public class FindBooksByPrice : IFinder<Book>
    {
        private int price;

        public FindBooksByPrice(int price)
        {
            this.price = price;
        }

        public bool Find(Book book)
        {
            if (book.Price == this.price)
            {
                return true;
            }

            return false;
        }
    }
}
