using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToJava
{
    internal class TaskFive
    {
        internal void CalculateGrade()
        {
            Console.WriteLine("Enter a score:");
            var inputText = Console.ReadLine();

            var scoreData = new List<Tuple<int, int, string>>()
            {
                new(90, 100, "A" ),
                new(80, 89,  "B" ),
                new(70, 79,  "C" ),
                new(60, 69,  "D" ),
                new(0,  59,  "F" ),

            };

            if (int.TryParse(inputText, out int enteredScore))
            {
                string grade;

                if (enteredScore > 100)
                {
                    grade = "A";
                } 
                else if (enteredScore < 0)
                {
                    grade = "F";
                }
                else
                {
                    grade = scoreData.Where(x => ScoreConvertor(enteredScore, x.Item1, x.Item2))
                        .Select(x => x.Item3).FirstOrDefault();
                }
                
                Console.WriteLine($"Letter grade is - {grade}");
            }
            else
            {
                Console.WriteLine("Invalid value entered.");
            }
        }

        private bool ScoreConvertor(int inputScore, int lowerScore, int upperScore)
        {
            return inputScore >= lowerScore && inputScore <= upperScore;
        }
    }
}
