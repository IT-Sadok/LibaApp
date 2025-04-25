using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace LibraryApp
{
    public class LibraryManager
    {
        private readonly string filePath = "books.json";
        private List<Book> books = new List<Book>();

        public LibraryManager()
        {
            LoadBooks();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            SaveBooks();
        }

        public void DeleteBook(string code)
        {
            books = books.Where(b => b.Code != code).ToList();
            SaveBooks();
        }

        public List<Book> Search(string query)
        {
            return books.Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                    b.Author.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Book> GetAll()
        {
            return books;
        }

        public void BorrowBook(string code)
        {
            var book = books.FirstOrDefault(b => b.Code == code);
            if (book != null) book.IsAvailable = false;
            SaveBooks();
        }

        public void ReturnBook(string code)
        {
            var book = books.FirstOrDefault(b => b.Code == code);
            if (book != null) book.IsAvailable = true;
            SaveBooks();
        }

        private void SaveBooks()
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true }));
        }

        private void LoadBooks()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
            }
        }
    }
}
