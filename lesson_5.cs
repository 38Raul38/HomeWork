//TASK 1

using System.Diagnostics;


class Book
{
    public string Title { get; set; }
    public string Autor { get; set; }
    public int Year { get; set; }

    public Book(string title, string autor, int year)
    {
        Title = title;
        Autor = autor;
        Year = year;
    }
}

class Program
    {
        static List<Book> books = new List<Book>();
        static void Add_book()
        {
            Console.WriteLine("Enter Title: ");
            string books_title = Console.ReadLine();

            Console.WriteLine("Enter Autor: ");
            string books_autor = Console.ReadLine();

            Console.WriteLine("Enter Year: ");
            bool isParsed = int.TryParse(Console.ReadLine(), out var year);

            if (!isParsed) throw new Exception($"Cannot parse {nameof(year)}");
            
            books.Add(new Book(books_title, books_autor, year));
            Console.WriteLine("BOOK ADDED\n");
        }

        static void Remove_book()
        {
            Console.WriteLine("Enter book title: ");
            string rem_books = Console.ReadLine();

            for (int i = 0; i < books.Count; i++)
            {
                if (string.Equals(rem_books, books[i].Title, StringComparison.OrdinalIgnoreCase))
                {
                    books.RemoveAt(i);
                    Console.WriteLine($"Book '{rem_books}' has been removed.\n");
                    
                }
            }
        }

        static void Show_books()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Book list is empty!!!");
            }
            else
            {
                for (int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine($"Title: {books[i].Title}");
                    Console.WriteLine($"Autor: {books[i].Autor}");
                    Console.WriteLine($"Year: {books[i].Year}");
                    Console.WriteLine("____________________");
                }
            }
        }

        static void Main()
        {
            while (true)
            {
                Console.WriteLine
                ("Select action\n " +
                 "1. Add Book\n" +
                 "2. Delete Book\n" +
                 "3. Show Book\n" +
                 "4. Exit");

                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Add_book();
                        break;
                    case 2:
                        Remove_book();
                        break;
                    case 3:
                        Show_books();
                        break;
                    case 4:
                        Console.WriteLine("Exit to program");
                        return;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
            
        }
    }