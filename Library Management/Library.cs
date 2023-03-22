using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management
{
    class Library
    {
        static protected List<Book> books;
        //To store record of student and author
        private static List<Student> students;
        private static List<Author> authors;
        public Library()
        {
            books = new List<Book>();
            students = new List<Student>();
            authors = new List<Author>();
        }

        public void AddBook(Book book)
        {
            if (books.Contains(book))
            {
                throw new LibraryException("Book already exists in library.");
            }

            books.Add(book);
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public void SearchBooks(string search)
        {
            bool found = false;
            foreach (Book book in books)
            {
                if ((book.GetTitle().ToLower()==search.ToLower())
                    || book.GetAuthor().ToLower()==search.ToLower()
                    || book.GetISBN().ToLower() == search.ToLower())
                {
                    Console.WriteLine(book);
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Book Not Found");
            }
        }

        public void RemoveBook(string isbn)
        {
            foreach (Book book in books)
            {
                if (book.GetISBN() == isbn)
                {
                    if (book.getIsIsued())
                    {
                        throw new LibraryException("Book is issued to a student and cannot be removed.");
                    }
                    books.Remove(book);
                    return;
                }
            }

            throw new LibraryException("Book not found.");
        }

        public void AddStudent(Student student)
        {
            if (!students.Contains(student))
            {
                students.Add(student);
            }
            Console.WriteLine("Enter Title of the book you want to acquire : ");
            string title = Console.ReadLine();
            foreach (Book book in books)
            {

                if (book.GetTitle().ToLower() == title.ToLower() && !book.getIsIsued())
                {
                    book.setIsIssued(true);
                    student.AcquireBook(book);
                    return;
                }
            }
            Console.WriteLine("Book You want to acquire doesn't exist");
        }
        public void returnBook()
        {
            Console.WriteLine("Enter Your Name : ");
            string n = Console.ReadLine();
            foreach (Student s in students)
            {
                string N = s.GetName();
                if ( N == n)
                {
                    Console.WriteLine("Enter Title of the book you want to Return : ");
                    string title = Console.ReadLine();
                    foreach (Book book in books)
                    {

                        if (book.GetTitle().ToLower() == title.ToLower() && book.getIsIsued())
                        {
                            book.setIsIssued(false);
                            s.ReturnBook(book);
                            return;
                        }
                    }
                }
            }
 
            Console.WriteLine("You are not registered OR you didn't acquire any book");
        }
        public List<Student> GetStudents()
        {
            return students.ToList();
        }

        public void AddAuthor(Author author)
        {
            if (!authors.Contains(author))
            {
                authors.Add( author);
            }
            Console.WriteLine("Enter Title of your book : ");
            string t=Console.ReadLine();
            Console.WriteLine("Enter ISBN : ");
            string isbn=Console.ReadLine();
            err:
            Console.WriteLine("Enter book genre(fiction,philosophy,religion):");
            string genre = Console.ReadLine();

            switch (genre.ToLower())
            {
                case "fiction":
                    Book book = new Fiction(t, author.GetName(), isbn);
                    books.Add(book);
                    author.SubmitBook(book);
                    break;
                case "philosophy":
                    Book book1 = new Philosophy(t, author.GetName(), isbn);
                    books.Add(book1);
                    author.SubmitBook(book1);
                    break;
                case "religion":
                    Book book2 = new Religion(t, author.GetName(), isbn);
                    books.Add(book2);
                    author.SubmitBook(book2);

                    break;
                default:
                    Console.WriteLine("Enter valid genre ");
                    goto err;
                    break;

            }
            

            
        }

        public List<Author> GetAuthors()
        {
            return authors.ToList();
        }

        public List<Book> GetIssuedBooks()
        {
            List<Book> issuedBooks = new List<Book>();

            foreach (Student student in students)
            {
                issuedBooks.AddRange(student.GetIssuedBooks());
            }

            return issuedBooks;
        }
        public List<Book> GetBooksByAuthor(string author)
        {
            List<Book> booksByAuthor = new List<Book>();

            foreach (Book book in books)
            {
                if (book.GetAuthor().ToLower() == author.ToLower())
                {
                    booksByAuthor.Add(book);
                }
            }

            return booksByAuthor;
        }
        public void SearchBooksByGenre(string genre)
        {
            foreach (Book book in books)
            {
                int count = 1;
                if (book.GetGenre().ToLower() == genre.ToLower())
                {
                    Console.WriteLine("    -------[Book {0} ]--------", count);
                    Console.WriteLine(book);
                    count++;
                }
            }
        }
    }
    
}