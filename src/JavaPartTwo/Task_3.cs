using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaPartTwo;

internal class Task_3
{
    private readonly INumberProvider _numberProvider;

    internal Task_3(INumberProvider numberProvider)
    {
        _numberProvider = numberProvider;
    }

    internal void NumberAnalysis()
    {
        var proceedWithTasks = true;

        while (proceedWithTasks)
        {
            Console.WriteLine("Select Sub Task (enter value from 1 top 7):");

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
        Console.WriteLine("Collection elements:");
        _numberProvider.GetNumbers().ForEach(Console.WriteLine);
    }

    private void SubTask_2()
    {
        Console.WriteLine($"Minimum element: {_numberProvider.GetMinimumNumber()}");
        Console.WriteLine($"Maximum element: {_numberProvider.GetMaximumNumber()}");
    }

    private void SubTask_3()
    {
        Console.WriteLine($"Average value: {_numberProvider.GetAverageNumber()}");
    }

    private void SubTask_4()
    {
        _numberProvider.GetEvenNumbers()
            .ForEach(Console.WriteLine);
    }

    private void SubTask_5()
    {
        Console.WriteLine("Enter number to check:");
        var userInput = Console.ReadLine();

        if (!int.TryParse(userInput, out var numberToCheck))
        {
            Console.WriteLine("Invalid value entered.");
            return;
        }

        var compareRes = _numberProvider.ContainsNumber(numberToCheck);
        var stPart = compareRes.Value ? " " : " does not ";
        Console.WriteLine($"Collection{stPart}contains a given number");
    }

    private void SubTask_6()
    {
        _numberProvider.OrderNumbersByAsc()
            .ForEach(Console.WriteLine);
    }

    private void SubTask_7()
    {
        GenerateData();
    }

    private void GenerateData()
    {
        _numberProvider.UpdateNumbers(NumberGenerator.GenerateData(20));
    }
}