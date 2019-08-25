using System;
using System.Collections.Generic;

namespace Books
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("903", "Oscar Wilde", "The picture Of Dorian Grey", "ACT", 2018, 273, 9.53));
            books.Add(new Book("93", "Markus Zusak", "The book thief", "ACT", 2019, 509, 10.99));
            books.Add(new Book("1023", "Stephen King", "The Green Mile", "Azbuka", 2016, 623, 13.28));

            BookListService bookListService = new BookListService(books);

            bookListService.AddBook(new Book("904", "author", "bookTitle", "ACT", 2018, 273, 9.53));

            bookListService.RemoveBook(new Book("904", "author", "bookTitle", "ACT", 2018, 273, 9.53));

            Console.WriteLine("The original collection of books:\n");
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

            bookListService.WriteToFile(@"D:\BookListStorage.txt");

            BookListService bookList = new BookListService(BookListStorage.GetBooks(@"D:\BookListStorage.txt"));

            Console.ReadKey();
        }

        private static void Output(List<Book> temp)
        {
            foreach (Book book in temp)
            {
                Console.WriteLine(book.ToString() + "\n");
            }
        }
    }
}
