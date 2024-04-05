using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaPartTwo
{
    public interface IBookProvider
    {
        List<Book> GetBooks();

        List<string> GetAuthors();

        List<string> GetAuthorsByGenre(string genre);

        List<string> GetAuthorsByYear(string year);

        List<Book> GetBooksByAuthor(string author);

        List<Book> GetBooksByYear(string year);

        List<Book> GetBooksByGenre(string genre);

        int RemoveBooksByAuthor(string author);

        List<Book> SortBooksByCriterion(string criterion);
        
        List<Book> MergeBooks(List<Book> books);

        List<Book> GetSubcollectionByGenre(string genre);
    }


    public class BookProvider : IBookProvider
    {
        private readonly List<Book> _booksData;

        public BookProvider(List<Book> books)
        {
            _booksData = books;
        }

        public List<Book> GetBooks()
        {
            return _booksData;
        }

        public List<string> GetAuthors()
        {
            return _booksData.Select(x => x.Author).ToList();
        }

        public List<string> GetAuthorsByGenre(string genre)
        {
            return _booksData.Where(x => x.Genre.Contains(genre,StringComparison.InvariantCultureIgnoreCase))
                .Select(x => x.Author).ToList();
        }

        public List<string> GetAuthorsByYear(string year)
        {
            return _booksData.Where(x => x.Year.Equals(year, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => x.Author).ToList();
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            return _booksData.Where(x => x.Author.Contains(author, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }

        public List<Book> GetBooksByYear(string year)
        {
            return _booksData.Where(x => x.Year.Equals(year, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }

        public List<Book> GetBooksByGenre(string genre)
        {
            return _booksData.Where(x => x.Genre.Contains(genre, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

        }

        public int RemoveBooksByAuthor(string author)
        {
            return _booksData.RemoveAll(x => x.Author.Contains(author, StringComparison.InvariantCultureIgnoreCase));
        }

        public List<Book> SortBooksByCriterion(string criterion)
        {
            if (int.TryParse(criterion, out var selectedOption))
            {
                switch (selectedOption)
                {
                    case 1:
                    {
                        return _booksData.OrderBy(x => x.Title).ToList();
                    }

                    case 2:
                    {
                        return _booksData.OrderBy(x => x.Author).ToList();
                    }

                    case 3:
                    {
                        return _booksData.OrderBy(x => x.Genre).ToList();
                    }

                    case 4:
                    {
                        return _booksData.OrderBy(x => x.Year).ToList();
                    }

                    default:
                    {
                        Console.WriteLine("Not supported option");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid value entered.");
            }
            
            return _booksData;
        }

        public List<Book> MergeBooks(List<Book> books)
        {
            _booksData.AddRange(books);
            return _booksData;
        }

        public List<Book> GetSubcollectionByGenre(string genre)
        {
            return GetBooksByGenre(genre);
        }
    }
}
