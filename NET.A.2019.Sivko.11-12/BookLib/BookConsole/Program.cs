using System;
using BookLib;
using System.Collections.Generic;
using NLog;

namespace BookConsole
{
    class Program
    {
        
        private static Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            logger.Trace("Start Main method");

            List<Book> books = new List<Book>();
            books.Add(new Book("903", "Oscar Wilde", "The picture Of Dorian Grey", "ACT", 2018, 273, 9.53));
            books.Add(new Book("93", "Markus Zusak", "The book thief", "ACT", 2019, 509, 10.99));
            books.Add(new Book("1023", "Stephen King", "The Green Mile", "Azbuka", 2016, 623, 13.28));

            BookListService bookListService = new BookListService(books);

            bookListService.AddBook(new Book("904", "author", "bookTitle", "ACT", 2018, 273, 9.53));

            try
            {
                bookListService.AddBook(new Book("904", "author", "bookTitle", "ACT", 2018, 273, 9.53));
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
                logger.Error(ex.StackTrace);
            }

            bookListService.RemoveBook(new Book("904", "author", "bookTitle", "ACT", 2018, 273, 9.53));

            try
            {
                bookListService.RemoveBook(new Book("904", "author", "bookTitle", "ACT", 2018, 273, 9.53));
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
                logger.Error(ex.StackTrace);
            }

            Console.WriteLine("\nThe original collection of books:\n");
            Output(bookListService.BookList);

            List<Book> answer = bookListService.FindBookByTag(new FindBooksByPublishing("ACT"));
            Console.WriteLine("\nBooks of the publishing house AСT:\n");
            Output(answer);

            bookListService.SortBooksByTag(new SortByAuthor());
            Console.WriteLine("\nBooks are sorted by author:\n");
            Output(bookListService.BookList);

            bookListService.SortBooksByTag(new SortByPrice());
            Console.WriteLine("\nBooks are sorted by price:\n");
            Output(bookListService.BookList);

            bookListService.WriteToFile(@"D:\BookListStorage.bin");

            BookListService bookList = new BookListService(BookListStorage.GetBooks(@"D:\BookListStorage.bin"));

            Console.ReadKey();
        }

        private static void Output(List<Book> temp)
        {
            logger.Trace("Display a list of books");
            foreach (Book book in temp)
            {
                Console.WriteLine(book.ToString() + "\n");
            }
        }
    }
}
