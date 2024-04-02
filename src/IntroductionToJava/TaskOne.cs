using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToJava
{
    internal class TaskOne
    {
        internal void CalculateVAT()
        {
            Console.WriteLine("Enter product price:");
            var price = Console.ReadLine();

            if (double.TryParse(price, out double productPrice))
            {
                Console.WriteLine($"Product price - {productPrice}");
                Console.WriteLine($"Product price with VAT - {productPrice * 1.2}");
            }
            else
            {
                Console.WriteLine("Input is not a valid price.");
            }
        }
    }
}
