using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class PrimeFactors
    {
        public List<int> Generate(int number)
        {
            var primeFactors = new List<int>();

            if (number == 1) return primeFactors;
            for (int divider = 2; divider <= number; divider++)
            {
                while (number % divider == 0)
                {
                    primeFactors.Add(divider);
                    number = number / divider;
                }
            }

            primeFactors.Sort();

            return primeFactors;
        }
    }
}