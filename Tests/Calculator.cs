using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    internal class Calculator
    {
        public Calculator()
        {
        }

        internal int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiters = new List<char> { ',', '\n' };
            var newDelimiterIndex = numbers.LastIndexOf("//");
            var firstDigit = numbers.FirstOrDefault(c => char.IsDigit(c));
            var firstDigitIndex = numbers.IndexOf(firstDigit);

            if (newDelimiterIndex != -1)
            {
                delimiters.Add(numbers[newDelimiterIndex + 2]);
            }

            numbers = numbers.Substring(firstDigitIndex);

            var negativeNumbers = numbers.Split(delimiters.ToArray()).Where(number => int.Parse(number) < 0).Select(number => int.Parse(number));

            if (negativeNumbers.Count() > 0)
            {
                var negativeNumbersText = string.Join(',', negativeNumbers);
                throw new ArgumentException($"negatives not allowed: {negativeNumbersText}");
            }

            var numbersArray = Array.ConvertAll(numbers.Split(delimiters.ToArray()), int.Parse);
            var result = numbersArray.Sum();

            return result;
        }
    }
}