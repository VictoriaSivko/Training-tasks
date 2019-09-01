// <copyright file="BookListStorage.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Books
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Contains methods for writing and retrieving objects from a file.
    /// </summary>
    public static class BookListStorage
    {
        /// <summary>
        /// Retrieves books from a file.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>List of books.</returns>
        public static List<Book> GetBooks(string path)
        {
            List<Book> temp = new List<Book>();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string isbn = reader.ReadString();
                    string author = reader.ReadString();
                    string title = reader.ReadString();
                    string publishing = reader.ReadString();
                    int publYear = reader.ReadInt32();
                    int pages = reader.ReadInt32();
                    double price = reader.ReadDouble();
                    temp.Add(new Book(isbn, author, title, publishing, publYear, pages, price));
                }
            }

            return temp;
        }

        /// <summary>
        /// Saves a list of books to a file.
        /// </summary>
        /// <param name="bookList">List of books.</param>
        /// <param name="path">File path.</param>
        public static void WriteBooksToBinFile(List<Book> bookList, string path)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Book book in bookList)
                {
                    binaryWriter.Write(book.ISBN);
                    binaryWriter.Write(book.Author);
                    binaryWriter.Write(book.BookTitle);
                    binaryWriter.Write(book.Publishing);
                    binaryWriter.Write(book.PublicationYear);
                    binaryWriter.Write(book.NumberOfPages);
                    binaryWriter.Write(book.Price);
                }
            }
        }
    }
}
