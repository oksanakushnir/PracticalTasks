using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaPartTwo
{
    internal class NumberGenerator
    {
        internal static List<int> GenerateData(int amount)
        {
            var numbersData = new List<int>();
            var random = new Random();
            for (var i = 0; i < amount; i++)
            {
                var randomNumber = random.Next(1, 101);
                numbersData.Add(randomNumber);
            }

            return numbersData;
        }
    }
}
