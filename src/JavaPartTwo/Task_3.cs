using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaPartTwo;

internal class Task_3
{
    private readonly List<int> _numbersData = new();

    internal void NumberAnalysis()
    {
        GenerateData();

        var proceedWithTasks = true;

        while (proceedWithTasks)
        {
            Console.WriteLine("Select Sub Task (enter value from 1 top 6):");

            var sb = new StringBuilder();
            sb.AppendLine("SubTask 1 - Print all elements of the collection to the console");
            sb.AppendLine("SubTask 2 - Find and print the minimum and maximum numbers in the collection");
            sb.AppendLine("SubTask 3 - Calculate and print the average value of the numbers in the collection");
            sb.AppendLine("SubTask 4 - Remove all even numbers from the collection, and then print the updated collection to the console");
            sb.AppendLine("SubTask 5 - Check if the collection contains a given number (for example, 50), and print the result to the console");
            sb.AppendLine("SubTask 6 - Sort the collection in ascending order and print the sorted collection to the console");
            sb.AppendLine("SubTask 7 - Generate new random numbers");
            
            Console.WriteLine(sb.ToString());

            var userInput = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(userInput, out var selectedTask))
                switch (selectedTask)
                {
                    case 1:
                    {
                        SubTaskOne();
                        break;
                    }

                    case 2:
                    {
                        SubTaskTwo();
                        break;
                    }

                    case 3:
                    {
                        SubTaskThree();
                        break;
                    }

                    case 4:
                    {
                        SubTaskFour();
                        break;
                    }

                    case 5:
                    {
                        SubTaskFive();
                        break;
                    }

                    case 6:
                    {
                        SubTaskSix();
                        break;
                    }

                    case 7:
                    {
                        SubTaskSeven();
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

    private void GenerateData()
    {
        _numbersData.Clear();

        var random = new Random();
        for (var i = 0; i < 20; i++)
        {
            var randomNumber = random.Next(1, 101);
            _numbersData.Add(randomNumber);
        }
    }

    private void SubTaskOne()
    {
        Console.WriteLine("Collection elements:");
        _numbersData.ForEach(Console.WriteLine);
    }

    private void SubTaskTwo()
    {
        Console.WriteLine($"Minimum element: {_numbersData.Min()}");
        Console.WriteLine($"Maximum element: {_numbersData.Max()}");
    }

    private void SubTaskThree()
    {
        Console.WriteLine($"Average value: {_numbersData.Average()}");
    }

    private void SubTaskFour()
    {
        _numbersData.Where(x => x % 2 != 0)
            .ToList()
            .ForEach(Console.WriteLine);
    }

    private void SubTaskFive()
    {
        Console.WriteLine("Enter number to check:");
        var userInput = Console.ReadLine();

        if (!int.TryParse(userInput, out var numberToCheck))
        {
            Console.WriteLine("Invalid value entered.");
            return;
        }

        var compareRes = _numbersData.Contains(numberToCheck);
        var stPart = compareRes ? " " : " does not ";
        Console.WriteLine($"Collection{stPart}contains a given number");
    }

    private void SubTaskSix()
    {
        _numbersData.Order()
            .ToList()
            .ForEach(Console.WriteLine);
    }

    private void SubTaskSeven()
    {
        GenerateData();
    }
}