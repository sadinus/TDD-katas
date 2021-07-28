using NUnit.Framework;
using ConsoleApp;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class CalculatorTests
    {
        Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_WithNoParameters_ReturnsZero()
        {
            var expected = 0;
            var parameters = "";

            var result = calculator.Add(parameters);

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Add_WithOneParameter_ReturnsItsValue()
        {
            var expected = 1;
            var parameters = "1";

            var result = calculator.Add(parameters);

            Assert.AreEqual(result, expected);
        }

        [Test]
        [TestCase("1,2", 3)]
        [TestCase("1,2,3,4,5,6,7,8,9,10", 55)]
        public void Add_WithTwoOrMoreParameters_ReturnsItsSum(string numbers, int expected)
        {
            var result = calculator.Add(numbers);

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Add_WithNewLine_ReturnsItsSum()
        {
            var expected = 6;
            var numbers = "1\n2,3";
            var result = calculator.Add(numbers);

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Add_WithNewDelimiter_ReturnsItsSum()
        {
            var expected = 3;
            var numbers = "//;\n1;2";
            var result = calculator.Add(numbers);

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Add_WithDelimiterAndAtLeastOneNegativeParameter_ThrowsError()
        {
            var numbers = "//$8$-1";
            var delimiter = '$';
            var numbersWithDelimiterOnly = numbers.Substring(3);
            var negativeNumbers = numbersWithDelimiterOnly.Split(delimiter).Where(number => int.Parse(number) < 0).Select(number => int.Parse(number));
            var negativeNumbersText = string.Join(',', negativeNumbers);

            Assert.That(() => calculator.Add(numbers), Throws.TypeOf<ArgumentException>()
                              .With
                              .Property("Message")
                              .EqualTo($"negatives not allowed: {negativeNumbersText}"));
        }

        [Test]
        public void Add_WithAtLeastOneNegativeParameter_ThrowsError()
        {
            var numbers = "4,-3";
            var negativeNumbers = numbers.Split(',').Where(number => int.Parse(number) < 0).Select(number => int.Parse(number));
            var negativeNumbersText = string.Join(',', negativeNumbers);

            Assert.That(() => calculator.Add(numbers), Throws.TypeOf<ArgumentException>()
                              .With
                              .Property("Message")
                              .EqualTo($"negatives not allowed: {negativeNumbersText}"));
        }
    }
}