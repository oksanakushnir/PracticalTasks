using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToJava
{
    internal class TaskSeven
    {
        internal void CalculateInterest()
        {
            Console.WriteLine("Enter the initial deposit amount:");
            var inputDepositAmount = Console.ReadLine();

            Console.WriteLine("Enter the annual interest rate:");
            var inputInterestRate = Console.ReadLine();

            Console.WriteLine("Enter the number of years:");
            var inputYears = Console.ReadLine();

            if (!int.TryParse(inputDepositAmount, out int depositAmount))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            if (!decimal.TryParse(inputInterestRate, out decimal interestRate))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            if (!int.TryParse(inputYears, out int years))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            var rate = interestRate / 100;
            for (int i = 0; i < years; i++)
            {
                var investedTime = i + 1;
                var compoundInterest = depositAmount * Math.Pow((double)(1 + rate), investedTime);
                Console.WriteLine($"Compound interest for {investedTime} year - {compoundInterest}");
            }
        }
    }
}
