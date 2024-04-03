using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntroductionToJava
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool proceedWithTasks = true;

            while (proceedWithTasks)
            {
                Console.WriteLine("Select Task (enter value from 1 top 7):");
                
                var sb = new StringBuilder();
                sb.AppendLine("Task 1 - Calculation of the Final Product Price Including VAT");
                sb.AppendLine("Task 2 - Average Temperature Calculation");
                sb.AppendLine("Task 3 - Counting Vowels in a String");
                sb.AppendLine("Task 4 - Even or Odd Number Checker");
                sb.AppendLine("Task 5 - Grade Calculator");
                sb.AppendLine("Task 6 - Simple Age Category Classifier");
                sb.AppendLine("Task 7 - Interest Calculator");

                Console.WriteLine(sb.ToString());

                var userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int selectedTask))
                {
                    switch (selectedTask)
                    {
                        case 1:
                        {
                            var task = new Task_1();
                            task.CalculateVAT();
                            break;
                        }

                        case 2:
                        {
                            var task = new Task_2();
                            task.CalculateTemp();
                            break;
                        }

                        case 3:
                        {
                            var task = new Task_3();
                            task.CalculateVowels();
                            break;
                        }

                        case 4:
                        {
                            var task = new Task_4();
                            task.ParityCheck();
                            break;
                        }

                        case 5:
                        {
                            var task = new Task_5();
                            task.CalculateGrade();
                            break;
                        }
                        
                        case 6:
                        {
                            var task = new Task_6();
                            task.CalculateAge();
                            break;
                        }

                        case 7:
                        {
                            var task = new Task_7();
                            task.CalculateInterest();
                            break;
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

                Console.WriteLine();
                Console.WriteLine("Continue ? (yes/no)");
                userInput = Console.ReadLine();
                Console.WriteLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    proceedWithTasks = userInput.ToLower().Equals("yes") || userInput.ToLower().Equals("y");
                }
                else
                {
                    proceedWithTasks = false;
                }
            }
        }
    }
}