using System;
using System.Text;

namespace JavaPartTwo;

internal class Program
{
    private static void Main(string[] args)
    {
        var proceedWithTasks = true;

        while (proceedWithTasks)
        {
            Console.WriteLine("Select Task (enter value from 1 top 4):");

            var sb = new StringBuilder();
            sb.AppendLine("Task 1 - Basic methods of the String class");
            sb.AppendLine("Task 2 - Rectangle Properties Calculation");
            sb.AppendLine("Task 3 - Analysis of a Collection of Numbers");
            sb.AppendLine("Task 4 - Operations with a Book Collection");

            Console.WriteLine(sb.ToString());

            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out var selectedTask))
                switch (selectedTask)
                {
                    case 1:
                    {
                        var task = new Task_1();
                        task.StringMethods();
                        break;
                    }

                    case 2:
                    {
                        var task = new Task_2();
                        task.CalculateRectangle();
                        break;
                    }

                    case 3:
                    {
                        var numData = NumberGenerator.GenerateData(20);
                        var task = new Task_3(new NumberProvider(numData));
                        task.NumberAnalysis();
                        break;
                    }

                    case 4:
                    {
                        var task = new Task_4(new BookProvider(BookLibrary.GetBooks()));
                        task.BookOperations();
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
}