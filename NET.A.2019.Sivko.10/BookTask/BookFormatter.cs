namespace Books
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Implements custom formatting of the book object.
    /// </summary>
    public class BookFormatter : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Determine whether custom formatting object is requested.
        /// </summary>
        /// <param name="formatType">Format type.</param>
        /// <returns>Its GetFormat method returns a reference to the current BookFormatter instance if the formatType parameter refers to a class that implements ICustomFormatter; 
        /// otherwise, GetFormat returns null.</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Creates a string representation of the book according to the customer format.
        /// </summary>
        /// <param name="format">The format of the string representation of the book.</param>
        /// <param name="arg">Object for string representation.</param>
        /// <param name="formatProvider">Object of the IFormatProvider interface.</param>
        /// <returns>The string representation of the book according to the required format.</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null)
            {
                throw new ArgumentNullException("arg");
            }

            if (arg.GetType() != typeof(Book))
            {
                return arg.ToString();
            }

            if (string.IsNullOrWhiteSpace(format))
            {
                format = "Default";
            }

            Book book = arg as Book;

            switch (format.ToLower())
            {
                case "price":
                    return $"This book costs {book.Price.ToString(CultureInfo.CurrentCulture)} rub.";
                case "pages":
                    return $"This book can be read in {Math.Round(book.NumberOfPages / 200.0)} days";
                case "ATP":
                    return $"{book.Author}, {book.BookTitle}, {book.Price.ToString(formatProvider)}";
                default:
                    return book.ToString(format, null);
            }
        }
    }
}
