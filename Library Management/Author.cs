using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management
{
    class Author
    {
        private string id;
        private string name;
        private static List<Book> booksWritten;
        public Author(string id, string name)
        {
            this.id = id;
            this.name = name;
            booksWritten = new List<Book>();
        }

        public string GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public void SubmitBook(Book book)
        {
            if (booksWritten.Contains(book))
            {
                throw new LibraryException("Book already submitted by author.");
            }
            booksWritten.Add(book);
        }

        public void WithdrawBook(Book book)
        {
            if (!booksWritten.Contains(book))
            {
                throw new LibraryException("Book not submitted by author.");
            }

            booksWritten.Remove(book);
        }
    }

    class LibraryException : Exception
    {
        public LibraryException(string message) : base(message)
        {
        }
    }
}
