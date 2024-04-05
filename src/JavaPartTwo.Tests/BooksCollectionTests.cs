using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions.Execution;
using FluentAssertions;
using NUnit.Framework;

namespace JavaPartTwo.Tests
{
    [TestFixture]
    public class BooksCollectionTests
    {
        private List<Book> _booksData;

        [SetUp]
        public void TestSetUp()
        {
            _booksData = BookLibrary.GetBooks();
        }

        [Test]
        public void GetAuthorsByGenre_WhenCollectionNotEmpty_ReturnValidAuthors()
        {
            // Arrange 
            IBookProvider bookProvider = new BookProvider(_booksData);

            // Act
            var bookAuthors = bookProvider.GetAuthorsByGenre("fic");

            // Assert
            var expectedAuthors = new List<string>() { "F. Scott Fitzgerald", "Harper Lee", "J.D. Salinger" };
            
            using (new AssertionScope())
            {
                bookAuthors.Should().BeEquivalentTo(expectedAuthors);
            }
        }

        [Test]
        public void GetAuthorsByYear_WhenCollectionNotEmpty_ReturnValidAuthors()
        {
            // Arrange 
            IBookProvider bookProvider = new BookProvider(_booksData);

            // Act
            var bookAuthors = bookProvider.GetAuthorsByYear("1997");

            // Assert
            var expectedAuthors = new List<string>() { "J.K. Rowling" };
            
            using (new AssertionScope())
            {
                bookAuthors.Should().BeEquivalentTo(expectedAuthors);
            }

        }

        [Test]
        public void GetBooksByAuthor_WhenCollectionNotEmpty_ReturnValidBooks()
        {
            // Arrange 
            IBookProvider bookProvider = new BookProvider(_booksData);

            // Act
            var booksByAuthor = bookProvider.GetBooksByAuthor("Tolkien");

            // Assert
            var expectedBooks = new List<Book>()
            {
                new() { Title = "The Lord of the Rings",     Author = "J.R.R. Tolkien",      Genre = "Fantasy",      Year = "1954" },
                new() { Title = "The Hobbit",                Author = "J.R.R. Tolkien",      Genre = "Fantasy",      Year = "1937" },
            };
            
            using (new AssertionScope())
            {
                booksByAuthor.Should().BeEquivalentTo(expectedBooks);
            }
        }
        
        [Test]
        public void GetBooksByYear_WhenCollectionNotEmpty_ReturnValidBooks()
        {
            // Arrange 
            IBookProvider bookProvider = new BookProvider(_booksData);

            // Act
            var booksByYear = bookProvider.GetBooksByYear("1954");

            // Assert
            var expectedBooks = new List<Book>()
            {
                new() { Title = "The Lord of the Rings",     Author = "J.R.R. Tolkien",      Genre = "Fantasy",      Year = "1954" },
            };
            
            using (new AssertionScope())
            {
                booksByYear.Should().BeEquivalentTo(expectedBooks);
            }
        }

        [Test]
        public void GetBooksByGenre_WhenCollectionNotEmpty_ReturnValidBooks()
        {
            // Arrange 
            IBookProvider bookProvider = new BookProvider(_booksData);

            // Act
            var booksByGenre = bookProvider.GetBooksByGenre("fan");

            // Assert
            var expectedBooks = new List<Book>()
            {
                new() { Title = "Harry Potter",              Author = "J.K. Rowling",        Genre = "Fantasy",      Year = "1997" },
                new() { Title = "The Lord of the Rings",     Author = "J.R.R. Tolkien",      Genre = "Fantasy",      Year = "1954" },
                new() { Title = "The Hobbit",                Author = "J.R.R. Tolkien",      Genre = "Fantasy",      Year = "1937" },

            };

            using (new AssertionScope())
            {
                booksByGenre.Should().BeEquivalentTo(expectedBooks);
            }
        }

        [Test]
        public void RemoveBooksByAuthor_WhenCollectionNotEmpty_ReturnValidBooks()
        {
            // Arrange 
            IBookProvider bookProvider = new BookProvider(_booksData);

            // Act
            var removedBooks = bookProvider.RemoveBooksByAuthor("Tolkien");
            var actualBooks = bookProvider.GetBooks();

            // Assert
            var expectedBooks = new List<Book>()
            {
                new() { Title = "The Great Gatsby",          Author = "F. Scott Fitzgerald", Genre = "Fiction",      Year = "1925" },
                new() { Title = "To Kill a Mockingbird",     Author = "Harper Lee",          Genre = "Fiction",      Year = "1960" },
                new() { Title = "1984",                      Author = "George Orwell",       Genre = "Science",      Year = "1949" },
                new() { Title = "Pride and Prejudice",       Author = "Jane Austen",         Genre = "Classic",      Year = "1813" },
                new() { Title = "The Catcher in the Rye",    Author = "J.D. Salinger",       Genre = "Fiction",      Year = "1951" },
                new() { Title = "Harry Potter",              Author = "J.K. Rowling",        Genre = "Fantasy",      Year = "1997" },
                new() { Title = "Animal Farm",               Author = "George Orwell",       Genre = "Political",    Year = "1945" },
                new() { Title = "Brave New World",           Author = "Aldous Huxley",       Genre = "Dystopian",    Year = "1932" },
            };

            using (new AssertionScope())
            {
                removedBooks.Should().Be(2);
                actualBooks.Should().BeEquivalentTo(expectedBooks);
            }
        }

        [Test]
        public void SortBooksByCriterion_WhenCollectionNotEmpty_ReturnValidOrder()
        {
            // Arrange 
            IBookProvider bookProvider = new BookProvider(_booksData);

            // Act
            var sortedBooks = bookProvider.SortBooksByCriterion("4");

            using (new AssertionScope())
            {
                sortedBooks.Should().BeInAscendingOrder(x => x.Year, StringComparer.InvariantCultureIgnoreCase);
            }
        }

        [Test]
        public void MergeBooks_WhenCollectionNotEmpty_ReturnValidBooks()
        {
            // Arrange 
            IBookProvider bookProvider = new BookProvider(_booksData);
            var booksToMerge = new List<Book>()
            {
                new() { Title = "ABC 1", Author = "Test Author 1", Genre = "Fantasy", Year = "2020" },
                new() { Title = "ABC 2", Author = "Test Author 2", Genre = "Fantasy", Year = "2021" },
                new() { Title = "ABC 3", Author = "Test Author 3", Genre = "Fantasy", Year = "2022" },
            };

            // Act
            var mergedBooks = bookProvider.MergeBooks(booksToMerge);
            //var actualBooks = bookProvider.GetBooks();

            // Assert
            var expectedBooks = new List<Book>();
            expectedBooks.AddRange(BookLibrary.GetBooks());
            expectedBooks.AddRange(new Book[]
            {
                new() { Title = "ABC 1", Author = "Test Author 1", Genre = "Fantasy", Year = "2020" },
                new() { Title = "ABC 2", Author = "Test Author 2", Genre = "Fantasy", Year = "2021" },
                new() { Title = "ABC 3", Author = "Test Author 3", Genre = "Fantasy", Year = "2022" }
            });

            using (new AssertionScope())
            {
                mergedBooks.Should().BeEquivalentTo(expectedBooks);
            }
        }
    }
}
