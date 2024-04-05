using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaPartTwo
{
    public class BookLibrary
    {
        public static List<Book> GetBooks()
        {
            var bookData = new List<Book>
            {
                new Book { Title = "The Great Gatsby",          Author = "F. Scott Fitzgerald", Genre = "Fiction",      Year = "1925" },
                new Book { Title = "To Kill a Mockingbird",     Author = "Harper Lee",          Genre = "Fiction",      Year = "1960" },
                new Book { Title = "1984",                      Author = "George Orwell",       Genre = "Science",      Year = "1949" },
                new Book { Title = "Pride and Prejudice",       Author = "Jane Austen",         Genre = "Classic",      Year = "1813" },
                new Book { Title = "The Catcher in the Rye",    Author = "J.D. Salinger",       Genre = "Fiction",      Year = "1951" },
                new Book { Title = "Harry Potter",              Author = "J.K. Rowling",        Genre = "Fantasy",      Year = "1997" },
                new Book { Title = "The Lord of the Rings",     Author = "J.R.R. Tolkien",      Genre = "Fantasy",      Year = "1954" },
                new Book { Title = "Animal Farm",               Author = "George Orwell",       Genre = "Political",    Year = "1945" },
                new Book { Title = "The Hobbit",                Author = "J.R.R. Tolkien",      Genre = "Fantasy",      Year = "1937" },
                new Book { Title = "Brave New World",           Author = "Aldous Huxley",       Genre = "Dystopian",    Year = "1932" },
                // Add more test data here
            };

            return bookData;
        }
    }
}
