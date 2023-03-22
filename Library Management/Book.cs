using Library_Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management
{
    abstract class Book
    {
        protected string title;
        protected string author;
        protected string isbn;
        protected string genre;
        protected bool isIsued;

        public Book(string title, string author, string isbn)
        {
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            isIsued = false;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetAuthor()
        {
            return author;
        }

        public string GetISBN()
        {
            return isbn;
        }
        public bool getIsIsued()
        {
            return isIsued;
        }
        public void setIsIssued(bool var)
        {
            isIsued = var;
        }

        public abstract string GetGenre();

        public override string ToString()
        {
            return $"   Title: {title}\n    Author: {author}\n  ISBN: {isbn}\n  Genre: {GetGenre()}";
        }

        //public override bool Equals(object obj)
        //{
        //    //if (obj == null || GetType() != obj.GetType())
        //    //{
        //    //    return false;
        //    //}

        //    //Book other = (Book)obj;
        //    //return isbn == other.isbn;
        //}

        public override int GetHashCode()
        {
            return isbn.GetHashCode();
        }

    }
}
class Fiction : Book
{
    public Fiction(string title, string author, string isbn) : base(title, author, isbn)
    {
        this.genre = "Fiction";
    }
    public override string GetGenre()
    {
        return genre;
    }
}

class Philosophy : Book
{
    public Philosophy(string title, string author, string isbn) : base(title, author, isbn)
    {
        genre = "Philosophy";
    }
    public override string GetGenre()
    {
        return genre;
    }
}

class Religion : Book
{
    public Religion(string title, string author, string isbn) : base(title, author, isbn)
    {
        genre = "Religion";
    }
    public override string GetGenre()
    {
        return genre;
    }
}
