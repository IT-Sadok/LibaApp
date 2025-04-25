using System;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryManager library = new LibraryManager();
            while (true)
            {
                Console.WriteLine("\n=== Library ===");
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Dell book");
                Console.WriteLine("3. Searh");
                Console.WriteLine("4. All books");
                Console.WriteLine("5. Get book");
                Console.WriteLine("6. Return book");//charge1__!!!
                Console.WriteLine("0. Exit");

                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    
                    case "1":
                        Console.Clear();
                        Console.Write("Name: ");
                        string title = Console.ReadLine();
                        Console.Write("Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Yer: ");
                        int year = int.Parse(Console.ReadLine());
                        Console.Write("Code: ");
                        string code = Console.ReadLine();
                        library.AddBook(new Book { Title = title, Author = author, Year = year, Code = code });
                        Console.WriteLine("Book has been add.");
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("Enter book's code: ");
                        library.DeleteBook(Console.ReadLine());
                        Console.WriteLine("Book has been dell.");
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Search: "); // test1
                        var results = library.Search(Console.ReadLine());
                        foreach (var b in results)
                            Console.WriteLine($"{b.Title} - {b.Author} ({b.Year}) | {(b.IsAvailable ? "Avalible" : "Not Avalible")}");
                        break;

                    case "4":
                        Console.Clear();
                        var all = library.GetAll();
                        foreach (var b in all)
                            Console.WriteLine($"{b.Title} - {b.Author} ({b.Year}) | {(b.IsAvailable ? "Avalible" : "Not Avalible")}");
                        break;

                    case "5":
                        Console.Clear();
                        Console.Write("Book's code");
                        library.BorrowBook(Console.ReadLine());//teest4
                        Console.WriteLine("Book got.");
                        break;

                    case "6":
                        Console.Clear();
                        Console.Write("Book's code: ");
                        library.ReturnBook(Console.ReadLine());
                        Console.WriteLine("Book returned");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Uknwn");
                        break;
                }
            }
        }
    }
}
