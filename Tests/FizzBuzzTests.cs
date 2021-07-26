using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.FizzBuzz;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class FizzBuzzTests
    {
        FizzBuzzConsole console;
        private const string Fizz = "Fizz";
        private const string Buzz = "Buzz";
        private const string FizzBuzz = "FizzBuzz";

        [SetUp]
        public void Setup()
        {
            console = new FizzBuzzConsole();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(101)]
        public void WriteText_ShouldReturnInvalidNumberWhenOutOfRange(int number)
        {
            Assert.That(() => console.WriteText(number), Throws.TypeOf<ArgumentException>()
                              .With
                              .Property("Message")
                              .EqualTo("provide a number: from 1 to 100"));
        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, Fizz)]
        [TestCase(4, "4")]
        [TestCase(5, Buzz)]
        [TestCase(9, Fizz)]
        [TestCase(10, Buzz)]
        [TestCase(15, FizzBuzz)]
        public void Output_ShouldReturnCorrectValues(int number, string expected)
        {
            var actual = console.WriteText(number);
            Assert.AreEqual(expected, actual);
        }
    }
}
