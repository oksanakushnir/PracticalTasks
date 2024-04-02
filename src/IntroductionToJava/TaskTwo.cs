using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToJava
{
    internal class TaskTwo
    {
        internal void CalculateTemp()
        {
            Console.WriteLine("Enter the temperature for five days:");

            var tempDataInput = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"The temperature for {i + 1} day:");
                tempDataInput.Add(Console.ReadLine());
            }

            var tempData = tempDataInput.Select(x =>
            {
                double.TryParse(x, out double temp);
                return temp;
            }).ToList();

            var avgTemp = tempData.Sum() / tempData.Count;

            Console.WriteLine($"The average temperature over those days is: {avgTemp}");
        }
    }
}
