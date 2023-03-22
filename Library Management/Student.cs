using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management
{
    class Student
    {
        private string id;
        private string name;
        private static List<Book> issuedBooks;
        public Student(string id, string name)
        {
            this.id = id;
            this.name = name;
            issuedBooks = new List<Book>();
        }

        public string GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public void AcquireBook(Book book)
        {
            
            issuedBooks.Add(book);
            Console.WriteLine("       You Acquired A Book : {0}",book.GetTitle());
        }

        public void ReturnBook(Book book)
        {
            if (issuedBooks.Contains(book))
            {
                issuedBooks.Remove(book);
                Console.WriteLine("       Book Returned");
            } 
            else {
                Console.WriteLine("      You didn't acquire this book");
            }
        }

        public List<Book> GetIssuedBooks()
        {
            return issuedBooks;
        }

        public bool HasBook(Book book)
        {
            return issuedBooks.Contains(book);
        }

    }
}