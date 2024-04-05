using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaPartTwo
{
    public interface INumberProvider
    {
        int? GetMinimumNumber();
        
        int? GetMaximumNumber();
        
        double? GetAverageNumber();
        
        List<int> GetEvenNumbers();

        bool? ContainsNumber(int valueToCheck);

        List<int> OrderNumbersByAsc();

        List<int> GetNumbers();

        void UpdateNumbers(List<int> updatedNumbers);
    }

    public class NumberProvider : INumberProvider
    {
        private readonly List<int> _numbersData;

        public NumberProvider(List<int> numbersData)
        {
            _numbersData = numbersData;
        }

        public int? GetMinimumNumber()
        {
            return _numbersData != null && _numbersData.Any() ? _numbersData.Min() : null;
        }

        public int? GetMaximumNumber()
        {
            return _numbersData != null && _numbersData.Any() ? _numbersData.Max() : null;
        }

        public double? GetAverageNumber()
        {
            return _numbersData != null && _numbersData.Any() ? _numbersData.Average() : null;
        }

        public List<int> GetEvenNumbers()
        {
            return _numbersData?.Where(x => x % 2 != 0).ToList();
        }

        public bool? ContainsNumber(int valueToCheck)
        {
            return _numbersData?.Contains(valueToCheck);
        }

        public List<int> OrderNumbersByAsc()
        {
            return _numbersData?.Order().ToList();
        }

        public List<int> GetNumbers()
        {
            return _numbersData;
        }

        public void UpdateNumbers(List<int> updatedNumbers)
        {
            _numbersData.Clear();
            _numbersData.AddRange(updatedNumbers);
        }
    }
}
