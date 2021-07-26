using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.FizzBuzz
{
    public class FizzBuzzConsole
    {
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        private const string FizzBuzz = "FizzBuzz";

        public string WriteText(int number)
        {
            if (number < 1 || number > 100) throw new ArgumentException("provide a number: from 1 to 100");

            if (number % 15 == 0) return FizzBuzz;
            else if (number % 5 == 0) return Buzz;
            else if (number % 3 == 0) return Fizz;
            return number.ToString();
        }
    }
}
