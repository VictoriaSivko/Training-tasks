// <copyright file="Book.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Books
{
    using System;
    using System.Globalization;

    /// <summary>
    /// The class describes the book object.
    /// </summary>
    public class Book : IComparable<Book>, IFormattable
    {
        private string isbn;
        private string author;
        private string bookTitle;
        private string publishing;
        private int publicationYear;
        private int numberOfPages;
        private double price;

        /// <summary>
        /// Gets the book identification number.
        /// </summary>
        public string ISBN
        {
            get
            {
                return this.isbn;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null isbn string");
                }
                else
                {
                    this.isbn = value;
                }
            }
        }

        /// <summary>
        /// Gets the author of the book.
        /// </summary>
        public string Author
        {
            get
            {
                return this.author;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null author string");
                }
                else
                {
                    this.author = value;
                }
            }
        }

        /// <summary>
        /// Gets the title of the book.
        /// </summary>
        public string BookTitle
        {
            get
            {
                return this.bookTitle;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null bookTitle string");
                }
                else
                {
                    this.bookTitle = value;
                }
            }
        }

        /// <summary>
        /// Gets the book publisher.
        /// </summary>
        public string Publishing
        {
            get
            {
                return this.publishing;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null publishing string");
                }
                else
                {
                    this.publishing = value;
                }
            }
        }

        /// <summary>
        /// Gets the year of publication of the book.
        /// </summary>
        public int PublicationYear
        {
            get
            {
                return this.publicationYear;
            }

            private set
            {
                if (value < 1)
                {
                    throw new Exception("Negative publishing year");
                }
                else
                {
                    this.publicationYear = value;
                }
            }
        }

        /// <summary>
        /// Gets the number of pages of a book.
        /// </summary>
        public int NumberOfPages
        {
            get
            {
                return this.numberOfPages;
            }

            private set
            {
                if (value < 1)
                {
                    throw new Exception("Negative number of book pages");
                }
                else
                {
                    this.numberOfPages = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the price of the book.
        /// </summary>
        public double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 1)
                {
                    throw new Exception("Negative price");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">Book identification number.</param>
        /// <param name="author">Author of the book.</param>
        /// <param name="bookTitle">Title of the book.</param>
        /// <param name="publishing">Publishing of thr book.</param>
        /// <param name="publYear">Year of publication.</param>
        /// <param name="pages">Number of pages of the book.</param>
        /// <param name="price"> The price of the book.</param>
        public Book(string isbn, string author, string bookTitle, string publishing, int publYear, int pages, double price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.BookTitle = bookTitle;
            this.Publishing = publishing;
            this.PublicationYear = publYear;
            this.NumberOfPages = pages;
            this.Price = price;
        }

        /// <summary>
        /// Checks for equivalence an object of a book with an object type.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Returns true if the objects are equivalent and false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Book temp = obj as Book;

            if (temp == null)
            {
                return false;
            }

            return temp.isbn.Equals(this.isbn) && temp.author.Equals(this.author) && temp.bookTitle.Equals(this.bookTitle) && temp.publishing.Equals(this.publishing) && temp.publicationYear == this.publicationYear && temp.numberOfPages == this.numberOfPages && temp.price == this.price;
        }

        /// <summary>
        /// Checks for equivolence of two objects of type Book.
        /// </summary>
        /// <param name="temp">An object of type Book.</param>
        /// <returns>Returns true if the objects are equivalent and false otherwise.</returns>
        public bool Equals(Book temp)
        {
            if (temp == null)
            {
                return false;
            }

            if (temp == this)
            {
                return true;
            }

            return temp.isbn.Equals(this.isbn) && temp.author.Equals(this.author) && temp.bookTitle.Equals(this.bookTitle) && temp.publishing.Equals(this.publishing) && temp.publicationYear == this.publicationYear && temp.numberOfPages == this.numberOfPages && temp.price == this.price;
        }

        /// <summary>
        /// Generates the hash code of the book.
        /// </summary>
        /// <returns>Hash Code of the book.</returns>
        public override int GetHashCode()
        {
            return this.ISBN.GetHashCode();
        }

        /// <summary>
        /// Creates a string view of the book.
        /// </summary>
        /// <returns>The string representation of the book.</returns>
        public override string ToString()
        {
            return $"ISBN {this.isbn}\n{this.author} \"{this.bookTitle}\"\nPublishing {this.publishing} {this.publicationYear} year\nPages: {this.numberOfPages}\nPrice {this.price} rub.";
        }

        /// <summary>
        /// It is used to sort an array of objects of type Book.
        /// </summary>
        /// <param name="other">The object to which the book instance is compared.</param>
        /// <returns>Сomparison result.</returns>
        public int CompareTo(Book other)
        {
            if (this.isbn.Length > other.isbn.Length)
            {
                return 1;
            }
            else if (this.isbn.Length < other.isbn.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Creates a string representation of the book according to the required format.
        /// </summary>
        /// <param name="format">The format of the string representation of the book.</param>
        /// <param name="formatProvider">The object refers to a culture.</param>
        /// <returns>The string representation of the book according to the required format.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                format = "Default";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            switch (format)
            {
                case "AT":
                    return $"{this.author}, {this.bookTitle}";
                case "ATPPY":
                    return $"{this.author}, {this.bookTitle}, \"{this.publishing}\", {this.publicationYear.ToString(formatProvider)}";
                case "IATPPYP":
                    return $"ISBN 13: {this.isbn}, {this.author}, {this.bookTitle}, \"{this.publishing}\", {this.publicationYear.ToString(formatProvider)}, P. {this.numberOfPages}.";
                case "Default":
                    return $"ISBN 13: {this.isbn}, {this.author}, {this.bookTitle}, \"{this.publishing}\", {this.publicationYear.ToString(formatProvider)}, P. {this.numberOfPages}., {this.price.ToString(formatProvider)}.";
                default:
                    throw new Exception("No string representation of the required format was found. Acceptable formats: AT, ATPPY, IATPPYP, Default");
            }
        }
    }
}
