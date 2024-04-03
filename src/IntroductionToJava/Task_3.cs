using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToJava
{
    internal class Task_3
    {
        internal void CalculateVowels()
        {
            Console.WriteLine("Enter string to count vowels:");
            var inputText = Console.ReadLine();

            var vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };

            if (!string.IsNullOrEmpty(inputText))
            {
                var textData = inputText.ToLower();
                var vowelsTotal = 0;

                Console.WriteLine("Vowels count:");
                vowels.ForEach(x =>
                {
                    var vowelCount = textData.Count(y => x == y);
                    Console.WriteLine($"{x} - {vowelCount}");
                    vowelsTotal += vowelCount;
                });

                Console.WriteLine($"Vowels total count: - {vowelsTotal}");
            }
            else
            {
                Console.WriteLine("Invalid string entered");
            }
        }
    }
}
