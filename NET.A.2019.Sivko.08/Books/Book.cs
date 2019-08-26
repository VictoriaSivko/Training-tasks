using System;

namespace Books
{
    public class Book: IComparable<Book>
    {
        private string isbn;
        private string author;
        private string bookTitle;
        private string publishing;
        private int publicationYear;
        private int numberOfPages;
        private double price;

        public string ISBN
        {
            get { return isbn; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Null isbn string");
                else
                    isbn = value;
            }
        }
        public string Author
        {
            get { return author; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Null author string");
                else
                    author = value;
            }
        }
        public string BookTitle
        {
            get { return bookTitle; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Null bookTitle string");
                else
                    bookTitle = value;
            }
        }
        public string Publishing
        {
            get { return publishing; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Null publishing string");
                else
                    publishing = value;
            }
        }
        public int PublicationYear
        {
            get { return publicationYear; }
            private set
            {
                if (value < 1)
                    throw new Exception("Negative publishing year");
                else
                    publicationYear = value;
            }
        }
        public int NumberOfPages
        {
            get { return numberOfPages; }
            private set
            {
                if (value < 1)
                    throw new Exception("Negative number of book pages");
                else
                    numberOfPages = value;
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value < 1)
                    throw new Exception("Negative price");
                else
                    price = value;
            }
        }

        public Book(string isbn, string author, string bookTitle, string publishing, int publYear, int pages, double price)
        {
            ISBN = isbn;
            Author = author;
            BookTitle = bookTitle;
            Publishing = publishing;
            PublicationYear = publYear;
            NumberOfPages = pages;
            Price = price;
        }

        /// <summary>
        /// Checks for equivalence an object of a book with an object type
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Returns true if the objects are equivalent and false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Book temp = obj as Book;

            if (temp == null)
                return false;

            return temp.isbn.Equals(isbn) && temp.author.Equals(author) && temp.bookTitle.Equals(bookTitle) && temp.publishing.Equals(publishing) && temp.publicationYear == publicationYear && temp.numberOfPages == numberOfPages && temp.price == price;
        }

        /// <summary>
        /// Checks for equivolence of two objects of type Book
        /// </summary>
        /// <param name="temp">An object of type Book</param>
        /// <returns>Returns true if the objects are equivalent and false otherwise</returns>
        public bool Equals(Book temp)
        {
            if (temp == null)
                return false;

            if (temp == this)
                return true;

            return temp.isbn.Equals(isbn) && temp.author.Equals(author) && temp.bookTitle.Equals(bookTitle) && temp.publishing.Equals(publishing) && temp.publicationYear == publicationYear && temp.numberOfPages == numberOfPages && temp.price == price;
        }

        public override int GetHashCode()
        {
            return ISBN.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format($"ISBN {isbn}\n{author} \"{bookTitle}\"\nИздательство {publishing} {publicationYear} год\nСтраниц {numberOfPages}\nЦена {price} руб.");
        }

        /// <summary>
        /// It is used to sort an array of objects of type Book
        /// </summary>
        public int CompareTo(Book other)
        {
            if (isbn.Length > other.isbn.Length)
                return 1;
            else if (isbn.Length < other.isbn.Length)
                return -1;
            else
                return 0;
        }
    }
}
