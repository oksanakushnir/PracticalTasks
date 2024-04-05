using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaPartTwo.Tests
{
    [TestFixture]
    public class NumbersCollectionTests
    {
        [Test]
        public void GetMinimumNumber_WhenCollectionNotEmpty_ReturnValidMinValue()
        {
            // Arrange 
            var numbers = new List<int>() {1, 2, 3};
            INumberProvider numberProvider = new NumberProvider(numbers);
            
            // Act
            var minValue = numberProvider.GetMinimumNumber();
            
            // Assert
            Assert.AreEqual(1, minValue);
        }

        [Test]
        public void GetMinimumNumber_WhenCollectionEmpty_ReturnNull()
        {
            // Arrange 
            var numbers = new List<int>();
            INumberProvider numberProvider = new NumberProvider(numbers);

            // Act
            var minValue = numberProvider.GetMinimumNumber();
            
            // Assert
            Assert.Null(minValue);
        }

        [Test]
        public void GetMinimumNumber_WhenCollectionNull_ReturnNull()
        {
            // Arrange 
            INumberProvider numberProvider = new NumberProvider(null);

            // Act
            var minValue = numberProvider.GetMinimumNumber();

            // Assert
            Assert.Null(minValue);
        }

        [Test]
        public void GetMaximumNumber_WhenCollectionNotEmpty_ReturnValidMaxValue()
        {
            // Arrange 
            var numbers = new List<int>() { 1, 2, 3 };
            INumberProvider numberProvider = new NumberProvider(numbers);

            // Act
            var minValue = numberProvider.GetMaximumNumber();

            // Assert
            Assert.AreEqual(3, minValue);
        }

        [Test]
        public void GetMaximumNumber_WhenCollectionEmpty_ReturnNull()
        {
            // Arrange 
            var numbers = new List<int>();
            INumberProvider numberProvider = new NumberProvider(numbers);

            // Act
            var minValue = numberProvider.GetMaximumNumber();

            // Assert
            Assert.Null(minValue);
        }

        [Test]
        public void GetMaximumNumber_WhenCollectionNull_ReturnNull()
        {
            // Arrange 
            INumberProvider numberProvider = new NumberProvider(null);

            // Act
            var minValue = numberProvider.GetMaximumNumber();

            // Assert
            Assert.Null(minValue);
        }

        [Test]
        public void GetAverageNumber_WhenCollectionNotEmpty_ReturnValidAverageValue()
        {
            // Arrange 
            var numbers = new List<int>() { 1, 2, 3 };
            INumberProvider numberProvider = new NumberProvider(numbers);

            // Act
            var minValue = numberProvider.GetAverageNumber();

            // Assert
            Assert.AreEqual(2, minValue);
        }

        [Test]
        public void GetAverageNumber_WhenCollectionEmpty_ReturnNull()
        {
            // Arrange 
            var numbers = new List<int>();
            INumberProvider numberProvider = new NumberProvider(numbers);

            // Act
            var minValue = numberProvider.GetAverageNumber();

            // Assert
            Assert.Null(minValue);
        }

        [Test]
        public void GetAverageNumber_WhenCollectionNull_ReturnNull()
        {
            // Arrange 
            INumberProvider numberProvider = new NumberProvider(null);

            // Act
            var minValue = numberProvider.GetAverageNumber();

            // Assert
            Assert.Null(minValue);
        }

        [Test]
        public void GetEvenNumbers_WhenCollectionNotEmpty_ReturnValidEvenNumbers()
        {
            // Arrange 
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            INumberProvider numberProvider = new NumberProvider(numbers);

            // Act
            var evenNumbers = numberProvider.GetEvenNumbers();

            // Assert
            var expectedNumbers = new List<int>() { 1, 3, 5 };
            Assert.AreEqual(expectedNumbers, evenNumbers);
        }
        
        [Test]
        public void ContainsNumber_WhenCollectionNotEmpty_NumberContains_ReturnTrue()
        {
            // Arrange 
            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            INumberProvider numberProvider = new NumberProvider(numbers);

            // Act
            var containsNumber = numberProvider.ContainsNumber(3);

            // Assert
            Assert.AreEqual(containsNumber, true);
        }

        [Test]
        public void OrderNumbers_WhenCollectionNotEmpty_ReturnOrderASC()
        {
            // Arrange 
            var numbers = new List<int>() { 5, 4, 3, 2, 1 };
            INumberProvider numberProvider = new NumberProvider(numbers);

            // Act
            var orderedNumbers = numberProvider.OrderNumbersByAsc();

            // Assert
            var expectedOrder = new List<int>() { 1, 2, 3, 4, 5 };
            Assert.AreEqual(expectedOrder, orderedNumbers);
        }
    }
}
