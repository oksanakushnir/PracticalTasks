using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToJava
{
    internal class TaskSix
    {
        internal void CalculateAge()
        {
            Console.WriteLine("Enter a person age:");
            var inputText = Console.ReadLine();

            var ageTypes = new List<Tuple<int, int, string>>()
            {
                new(0,  12,  "Child"),
                new(13, 19,  "Teenager"),
                new(20, 59,  "Adult"),
                new(60, 100, "Senior")
            };

            if (int.TryParse(inputText, out int enteredAge))
            {
                string personType;

                if (enteredAge > 100)
                {
                    personType = "Senior";
                }
                else if (enteredAge < 0)
                {
                    personType = "Child";
                }
                else
                {
                    personType = ageTypes.Where(x => AgeConvertor(enteredAge, x.Item1, x.Item2))
                        .Select(x => x.Item3).FirstOrDefault();
                }

                Console.WriteLine($"Person type is - {personType}");
            }
            else
            {
                Console.WriteLine("Invalid value entered.");
            }
        }

        private bool AgeConvertor(int inputScore, int lowerScore, int upperScore)
        {
            return inputScore >= lowerScore && inputScore <= upperScore;
        }
    }
}
