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
            if (book.ISBN.Equals(isbn))
                return true;
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
            if (book.Author.Equals(author))
                return true;
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
            if (book.BookTitle.Equals(bookTitle))
                return true;
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
            if (book.Publishing.Equals(publish))
                return true;
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
            if (book.PublicationYear == publYear)
                return true;
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
            if (book.NumberOfPages == numberOfPages)
                return true;
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
            if (book.Price == price)
                return true;
            return false;
        }
    }
}
