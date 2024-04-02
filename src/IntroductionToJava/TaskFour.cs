using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToJava
{
    internal class TaskFour
    {
        internal void ParityCheck()
        {
            Console.WriteLine("Enter a number:");
            var inputText = Console.ReadLine();

            if (int.TryParse(inputText, out int enteredNumber))
            {
                Console.WriteLine(enteredNumber % 2 == 0 ? "Entered number is even." : "Entered number is odd.");
            }
            else
            {
                Console.WriteLine("Invalid value entered.");
            }
        }
    }
}
