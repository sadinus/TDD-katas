using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class PrimeFactorTests
    {
        PrimeFactors primeFactors;

        [SetUp]
        public void Setup()
        {
            primeFactors = new PrimeFactors();
        }

        private static readonly object[] DATA =
        {
            new object[] {1, new List<int> {}},
            new object[] {2, new List<int> {2}},
            new object[] {3, new List<int> {3}},
            new object[] {4, new List<int> {2, 2}},
            new object[] {6, new List<int> {2, 3}},
            new object[] {8, new List<int> {2, 2, 2}},
            new object[] {24, new List<int> { 2, 2, 3, 2} }
        };

        [Test]
        [TestCaseSource(nameof(DATA))]
        public void Generate_ShouldReturnPrimeNumbers(int number, List<int> expected)
        {
            var actual = primeFactors.Generate(number);

            expected.Sort();

            Assert.AreEqual(expected, actual);
        }
    }
}
