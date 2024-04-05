using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaPartTwo
{
    internal class Task_1
    {
        internal void StringMethods()
        {
            bool proceedWithTasks = true;

            while (proceedWithTasks)
            {
                Console.WriteLine("Select Sub Task (enter value from 1 top 7):");

                var sb = new StringBuilder();
                sb.AppendLine("SubTask 1 - Method that takes two strings and returns true if they are equal, and false otherwise");
                sb.AppendLine("SubTask 2 - Method that takes a string and two indices, and returns the substring that is contained between those indices");
                sb.AppendLine("SubTask 3 - Method that checks whether a certain substring is contained in a given string, and returns the index of its first occurrence");
                sb.AppendLine("SubTask 4 - Method that replaces all occurrences of one substring with another in a given string");
                sb.AppendLine("SubTask 5 - Method that determines whether a string contains digits");
                sb.AppendLine("SubTask 6 - Method that removes all leading and trailing spaces from a string");
                sb.AppendLine("SubTask 7 - Method that splits a string into an array of substrings according to a given delimiter");

                Console.WriteLine(sb.ToString());

                var userInput = Console.ReadLine();
                Console.WriteLine();

                if (int.TryParse(userInput, out int selectedTask))
                {
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

        private void SubTask_1()
        {
            Console.WriteLine("Enter first string:");
            var firstStr = Console.ReadLine();

            Console.WriteLine("Enter second string:");
            var secondStr = Console.ReadLine();

            Console.WriteLine("Use case-insensitive comparison ? (yes/no)");
            var ignoreCaseInput  = Console.ReadLine();
            
            bool ignoreCase;
            Console.WriteLine();
            if (!string.IsNullOrEmpty(ignoreCaseInput))
            {
                ignoreCase = ignoreCaseInput.ToLower().Equals("yes") || ignoreCaseInput.ToLower().Equals("y");
            }
            else
            {
                ignoreCase = false;
            }

            if (!string.IsNullOrEmpty(firstStr) && !string.IsNullOrEmpty(secondStr))
            {
                var compareRes = firstStr.Equals(secondStr, ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture);
                var stPart = compareRes ? " " : " not ";
                Console.WriteLine($"Provided strings are{stPart}equal");
            }
            else
            {
                Console.WriteLine("Invalid value entered.");
            }
        }

        private void SubTask_2()
        {
            Console.WriteLine("Enter string:");
            var inputStr = Console.ReadLine();

            Console.WriteLine("Enter first index:");
            var firstIndexStr = Console.ReadLine(); 
            
            Console.WriteLine("Enter second index:");
            var secondIndexStr = Console.ReadLine();

            if (string.IsNullOrEmpty(inputStr))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            if (!int.TryParse(firstIndexStr, out int firstIndex))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            if (!int.TryParse(secondIndexStr, out int secondIndex))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            if (firstIndex > secondIndex)
            {
                Console.WriteLine("Invalid value entered. First index should be smaller then second index.");
                return;
            }

            var substring = string.Join("", inputStr.Skip(firstIndex).Take(secondIndex - firstIndex + 1).ToList());
            Console.WriteLine($"Substring between provided indexes - {substring}");
        }

        private void SubTask_3()
        {
            Console.WriteLine("Enter main string:");
            var mainStr = Console.ReadLine();

            Console.WriteLine("Enter sub string:");
            var subStr = Console.ReadLine();
           
            if (string.IsNullOrEmpty(mainStr))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            if (string.IsNullOrEmpty(subStr))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            var matchIndex = mainStr.IndexOf(subStr, StringComparison.InvariantCultureIgnoreCase);

            if (matchIndex > 0)
            {
                Console.WriteLine($"The index of first sub string occurrence is: {matchIndex}.");
                return;
            }

            Console.WriteLine("Main string does not contain such sub string.");
        }

        private void SubTask_4()
        {
            Console.WriteLine("Enter main string:");
            var mainStr = Console.ReadLine();

            Console.WriteLine("Enter sub string to be replaced:");
            var subStrToReplace = Console.ReadLine();

            Console.WriteLine("Enter sub string to replace with:");
            var subStrToReplaceWith = Console.ReadLine();

            if (string.IsNullOrEmpty(mainStr))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            if (string.IsNullOrEmpty(subStrToReplace))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            if (string.IsNullOrEmpty(subStrToReplaceWith))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            var resultStr = mainStr.Replace(subStrToReplace, subStrToReplaceWith, true, CultureInfo.InvariantCulture);
            Console.WriteLine($"Result: {resultStr}");
        }

        private void SubTask_5()
        {
            Console.WriteLine("Enter string:");
            var mainStr = Console.ReadLine();
           
            if (string.IsNullOrEmpty(mainStr))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            var checkRes = mainStr.Any(char.IsDigit);
            var stPart = checkRes ? " " : " does not ";

            Console.WriteLine($"Provided string{stPart}contains digits");
        }

        private void SubTask_6()
        {
            Console.WriteLine("Enter string:");
            var mainStr = Console.ReadLine();

            if (string.IsNullOrEmpty(mainStr))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            var trimmedStr = mainStr.Trim();
            
            Console.WriteLine($"Result: {trimmedStr}");
        }

        private void SubTask_7()
        {
            Console.WriteLine("Enter string:");
            var mainStr = Console.ReadLine();

            Console.WriteLine("Enter delimiter:");
            var delimiter = Console.ReadLine();

            if (string.IsNullOrEmpty(mainStr))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            if (string.IsNullOrEmpty(delimiter))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            Console.WriteLine($"Result:");
            mainStr.Split(delimiter, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x}"));
        }
    }
}
