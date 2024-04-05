using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace JavaPartTwo;

internal class Task_4
{
    private readonly IBookProvider _bookProvider;

    internal Task_4(IBookProvider bookProvider)
    {
        _bookProvider = bookProvider;
    }

    internal void BookOperations()
    {
        var proceedWithTasks = true;

        while (proceedWithTasks)
        {
            Console.WriteLine("Select Sub Task (enter value from 1 top 10):");

            var sb = new StringBuilder();
            sb.AppendLine("SubTask 1 -  Print List of Authors");
            sb.AppendLine("SubTask 2 -  List Authors by Genre");
            sb.AppendLine("SubTask 3 -  List Authors by Publication Year");
            sb.AppendLine("SubTask 4 -  Find Book by Author");
            sb.AppendLine("SubTask 5 -  Find Books by Publication Year");
            sb.AppendLine("SubTask 6 -  Find Books by Genre");
            sb.AppendLine("SubTask 7 -  Remove Books by Author");
            sb.AppendLine("SubTask 8 -  Sort Collection by Criterion");
            sb.AppendLine("SubTask 9 -  Merge Book Collections");
            sb.AppendLine("SubTask 10 - Subcollection of Books by Genre");

            Console.WriteLine(sb.ToString());

            var userInput = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(userInput, out var selectedTask))
                switch (selectedTask)
                {
                    case 1:
                    {
                        SubTask_1();
                        break;
                    }

                    case 2:
                    {
                        SubTask_2();
                        break;
                    }

                    case 3:
                    {
                        SubTask_3();
                        break;
                    }

                    case 4:
                    {
                        SubTask_4();
                        break;
                    }

                    case 5:
                    {
                        SubTask_5();
                        break;
                    }

                    case 6:
                    {
                        SubTask_6();
                        break;
                    }

                    case 7:
                    {
                        SubTask_7();
                        break;
                    }

                    case 8:
                    {
                        SubTask_8();
                        break;
                    }

                    case 9:
                    {
                        SubTask_9();
                        break;
                    }

                    case 10:
                    {
                        SubTask_10();
                        break;
                    }

                    default:
                    {
                        Console.WriteLine("Not supported option");
                        break;
                    }
                }
            else
                Console.WriteLine("Invalid value entered.");

            Console.WriteLine();
            Console.WriteLine("Continue ? (yes/no)");
            userInput = Console.ReadLine();
            Console.WriteLine();
            if (!string.IsNullOrEmpty(userInput))
                proceedWithTasks = userInput.ToLower().Equals("yes") || userInput.ToLower().Equals("y");
            else
                proceedWithTasks = false;
        }
    }

    private void SubTask_1()
    {
        Console.WriteLine("List of Authors:");
        _bookProvider.GetAuthors().ForEach(Console.WriteLine);
    }

    private void SubTask_2()
    {
        Console.WriteLine("Enter Genre:");
        var userInput = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Authors by Genre:");
        _bookProvider.GetAuthorsByGenre(userInput).ForEach(Console.WriteLine);
    }

    private void SubTask_3()
    {
        Console.WriteLine("Enter Year:");
        var userInput = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Authors by Publication Year:");
        _bookProvider.GetAuthorsByYear(userInput).ForEach(Console.WriteLine);
    }

    private void SubTask_4()
    {
        Console.WriteLine("Enter Author:");
        var userInput = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Book by Author:");
        PrintBooks(_bookProvider.GetBooksByAuthor(userInput));
    }

    private void SubTask_5()
    {
        Console.WriteLine("Enter Year:");
        var userInput = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Book by Year:");
        PrintBooks(_bookProvider.GetBooksByYear(userInput));
    }

    private void SubTask_6()
    {
        Console.WriteLine("Enter Genre:");
        var userInput = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Book by Genre:");
        PrintBooks(_bookProvider.GetBooksByGenre(userInput));
    }

    private void SubTask_7()
    {
        Console.WriteLine("Enter Author:");
        var userInput = Console.ReadLine();
        Console.WriteLine("");

        var removeCount = _bookProvider.RemoveBooksByAuthor(userInput);
        Console.WriteLine($"Removed books: {removeCount}");
        Console.WriteLine("");

        PrintBooks(_bookProvider.GetBooks());
    }

    private void SubTask_8()
    {
        Console.WriteLine("Choose sorting criterion: (enter value from 1 top 4):");
        var sb = new StringBuilder();
        sb.AppendLine("Option 1 - Title");
        sb.AppendLine("Option 2 - Author");
        sb.AppendLine("Option 3 - Genre");
        sb.AppendLine("Option 4 - Year");
        
        Console.WriteLine(sb.ToString());

        var userInput = Console.ReadLine();
        Console.WriteLine("");

        var sortedBooks = _bookProvider.SortBooksByCriterion(userInput);
        Console.WriteLine($"Sorted books:");
        Console.WriteLine("");

        PrintBooks(sortedBooks);
    }

    private void SubTask_9()
    {
        Console.WriteLine("Enter new books (in format - Title, Author, Genre, Year. One line per book, comma separated):");
        Console.WriteLine("Empty line indicating end of input");

        var multilineInput = new StringBuilder();

        // Read input until an empty line is encountered
        while (true)
        {
            string line = Console.ReadLine();

            // Check if the line is empty, indicating end of input
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }

            // Append the line to the string builder
            multilineInput.AppendLine(line);
        }

        var userInput = multilineInput.ToString();
        if (!string.IsNullOrEmpty(userInput))
        {
            var inputBooks = new List<Book>();
            var booksInfo = userInput.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
            
            booksInfo.ForEach(x =>
            {
                var parts = x.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(y => y.Trim())
                    .ToList();
                inputBooks.Add(new Book()
                {
                    Title = parts[0],
                    Author = parts[1],
                    Genre = parts[2],
                    Year = parts[3]
                });
            });

            var mergedBooks = _bookProvider.MergeBooks(inputBooks);
            PrintBooks(mergedBooks);
        }
        else
        {
            Console.WriteLine("Invalid value entered.");
        }
    }

    private void SubTask_10()
    {
        SubTask_6();
    }

    private void PrintBooks(List<Book> booksData)
    {
        // print headers
        int nameWidth = 30;
        int authorWidth = 20;
        int genreWidth = 10;
        int yearWidth = 1;

        var bookInfo = booksData.Select(x => $"{x.Title.PadRight(nameWidth)} {x.Author.PadRight(authorWidth)} {x.Genre.PadRight(genreWidth)} {x.Year.PadRight(yearWidth)}")
            .ToList();

        Console.WriteLine($"{"Name".PadRight(nameWidth)} {"Author".PadRight(authorWidth)} {"Genre".PadRight(genreWidth)} {"Year".PadRight(yearWidth)}");
        Console.WriteLine("");
        bookInfo.ForEach(Console.WriteLine);
    }
}