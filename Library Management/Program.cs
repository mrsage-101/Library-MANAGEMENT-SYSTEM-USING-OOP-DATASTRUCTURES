using Library_Management;
using System;

class Program
{
    static void Display()
    {
        Console.Title="Library Management System";
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.SetCursorPosition(18, 0);
        Console.WriteLine("-------------| Library Management System |-------------\n\n");
        Console.SetCursorPosition(22, 4);
        Console.Write("Loading __ ");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(".");
            Thread.Sleep(200);
        }
        Console.Clear();
        Console.SetCursorPosition(30, 4);
        Console.WriteLine("Press Any Key to Continue.");
    }
    static Library library = new Library();
    static void Main(string[] args)
    {
        Display();
        Console.ReadLine();
        
        bool cont = true;
        while (cont)
        {
            Console.Clear();
            Console.SetCursorPosition(18, 0);
            Console.WriteLine("-------------| Main Menu |-------------");
            Console.SetCursorPosition(18, 1);
            Console.WriteLine("1. As a Librarian");
            Console.SetCursorPosition(18, 3);
            Console.WriteLine("2. As a Author");
            Console.SetCursorPosition(18, 5);
            Console.WriteLine("3. As a Student");
            Console.SetCursorPosition(18, 7);
            Console.WriteLine("0. Exit.");
            Console.SetCursorPosition(19, 9);
            Console.WriteLine("Enter Your Choice : ");
            int choice1 = int.Parse(Console.ReadLine());
            switch (choice1)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("         Exited!!!!");
                    cont= false;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 1:
                    LibrarianFunction();
                    break;
                case 2:
                    AuthorFunction();
                    break;
                case 3:
                    StudentFunction();
                    break;
            }
        }
        Console.ReadLine();
    }
    static void StudentFunction()
    {
        while (true)
        {
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("     -------------| Student Menu |-------------\n");
            Console.WriteLine("     1. View all books.\n");
            Console.WriteLine("     2. Search Book by genre. \n");
            Console.WriteLine("     3. Acquire Book.\n");
            Console.WriteLine("     4. Return Book.\n");
            Console.WriteLine("     0. Back");
            Console.WriteLine("     Enter Your Choice : ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ViewBooks();
                    break;
                case 2:
                    ViewBooksByGenre();

                    break;
                case 3:
                    Console.WriteLine("Enter Your Name : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Your Id :");
                    string id = Console.ReadLine();
                    Student S = new Student(id,name);
                    library.AddStudent(S);
                    break;
                case 4:

                    library.returnBook();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static void AuthorFunction()
    {
        while (true)
        {
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("-------------| Author Menu |-------------\n");
            Console.WriteLine("      1. Submit a book\n");
            Console.WriteLine("      2. Withdraw a book.\n");
            Console.WriteLine("      0. Back\n");
            Console.WriteLine("      Enter Your Choice : ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Your Name : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Your Id :");
                    string id = Console.ReadLine();
                    Author a = new Author(id, name);
                    library.AddAuthor(a);
                    break;
                case 2:
                    RemoveBook();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static void LibrarianFunction()
    {

        while (true)
        {
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(" -------------| Librarian Menu |-------------\n");
            Console.WriteLine("      1. Add a book.\n");
            Console.WriteLine("      2. View all books.\n");
            Console.WriteLine("      3. Search for a book.\n");
            Console.WriteLine("      4. Remove a book.\n");
            Console.WriteLine("      5. View issued books.\n");
            Console.WriteLine("      6. View books by author.\n");
            Console.WriteLine("      0. Back");
            Console.WriteLine("      Enter Your Choice : ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    ViewBooks();
                    break;
                case 3:
                    SearchBooks();
                    break;
                case 4:
                    RemoveBook();
                    break;
                case 5:
                    ViewIssuedBooks();
                    break;
                case 6:
                    ViewBooksByAuthor();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static void AddBook()
    {
        Console.WriteLine("      Enter book title:");
        string title = Console.ReadLine();

        Console.WriteLine("      Enter book author:");
        string author = Console.ReadLine();

        Console.WriteLine("      Enter book ISBN:");
        string isbn = Console.ReadLine();
        Err:
        Console.WriteLine("      Enter book genre(fiction,philosophy,religion):");
        string genre = Console.ReadLine();

        switch(genre.ToLower())
        {
            case "fiction":
                Book book = new Fiction(title, author, isbn);
                library.AddBook(book);
                break;
            case "philosophy":
                Book book1 = new Philosophy(title, author, isbn);
                library.AddBook(book1);
                break;
            case "religion":
                Book book2 = new Religion(title, author, isbn);
                library.AddBook(book2);
                break;
            default:
                Console.WriteLine("Enter valid genre ");
                goto Err;
                break;

        }
        Console.WriteLine("Book added successfully.");
    }

    static void ViewBooks()
    {
        int count = 1;
        foreach (Book book in library.GetBooks())
        {
            Console.WriteLine(" -------[Book {0} ]--------", count);
            Console.WriteLine(book);
            count++;
        }
    }

    static void SearchBooks()
    {
        string search1;
        Console.WriteLine("      Enter (Title,ISBN,Author) to search a book ");
        search1 = Console.ReadLine();
        library.SearchBooks(search1);
    }

    static void RemoveBook()
    {
        Console.WriteLine("Enter book ISBN:");
        string isbn = Console.ReadLine();

        try
        {
            library.RemoveBook(isbn);
            Console.WriteLine("  Book removed successfully.");
        }
        catch (LibraryException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void ViewIssuedBooks()
    {
        int count = 1;
        foreach (Book book in library.GetIssuedBooks())
        {
            Console.WriteLine(" -------[Book {0} ]--------", count);
            Console.WriteLine(book);
            count++;
        }
    }

    static void ViewBooksByAuthor()
    {
        Console.WriteLine("      Enter author name:");
        string author = Console.ReadLine();
        int count = 1;
        foreach (Book book in library.GetBooksByAuthor(author))
        {
            Console.WriteLine(" -------[Book {0} ]--------", count);
            Console.WriteLine(book);
            count++;
        }
    }
    static void ViewBooksByGenre()
    {
        Console.WriteLine("Enter Genre to See Books(fiction,philosophy,religion) : ");
        string genre = Console.ReadLine();
        library.SearchBooksByGenre(genre);
    }
}
