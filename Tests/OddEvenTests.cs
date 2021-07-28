using ConsoleApp;
using NUnit.Framework;
using System;

namespace Tests
{
    class OddEvenTests
    {
        private const string Even = "Even";
        private const string Odd = "Odd";
        private OddEven oddEven;

        [SetUp]
        public void Setup()
        {
            oddEven = new OddEven();
        }

        [Test]
        [TestCase(1, Odd)]
        [TestCase(2, "2")]
        [TestCase(3, "3")]
        [TestCase(4, Even)]
        [TestCase(5, "5")]
        [TestCase(6, Even)]
        [TestCase(9, Odd)]
        [TestCase(15, Odd)]
        [TestCase(100, Even)]
        public void OddEven_ShouldPrintNumbers(int number, string expected)
        {
            var actual = oddEven.CheckNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(101, 0, 100)]
        [TestCase(-1, 0, 100)]
        [TestCase(50, -20, 20)]
        [TestCase(7, 4, 6)]
        public void OddEven_ShouldNotPrintNumbersOutOfRange(int number, int bottomLimit, int topLimit)
        {
            Assert.That(() => oddEven.CheckNumber(number, bottomLimit, topLimit), Throws.TypeOf<ArgumentException>()
                .With
                .Property("Message")
                .EqualTo($"You can only provide number from {bottomLimit} to {topLimit}."));
        }

        [Test]
        [TestCase(150, -20, 200, Even)]
        [TestCase(5, 4, 6, "5")]
        public void OddEven_ShouldPrintNumbersInRange(int number, int bottomLimit, int topLimit, string expected)
        {
            var actual = oddEven.CheckNumber(number, bottomLimit, topLimit);

            Assert.AreEqual(expected, actual);
        }
    }
}
