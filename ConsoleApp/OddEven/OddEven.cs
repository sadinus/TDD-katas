using System;

namespace ConsoleApp
{
    public class OddEven
    {
        private const string Even = "Even";
        private const string Odd = "Odd";

        public string CheckNumber(int number, int bottomLimit = 1, int topLimit = 100)
        {
            if (IsOutOfRange(number, bottomLimit, topLimit)) throw new ArgumentException($"You can only provide number from {bottomLimit} to {topLimit}.");
            if (isPrime(number)) { return number.ToString(); }
            if (IsEven(number)) return Even;
            if (IsOdd(number)) return Odd;

            throw new ArgumentException();
        }

        private bool isPrime(int number)
        {
            if (number == 1 || number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        private bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        private bool IsOutOfRange(int number, int bottomLimit, int topLimit)
        {
            return number > topLimit || number < bottomLimit;
        }
    }
}