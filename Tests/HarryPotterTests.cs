using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class HarryPotterTests
    {
        [Test]
        public void CalculatePrice_TwoSameBooksShouldNotApplyDiscount()
        {
            var books = new List<Volume>();
            books.Add(Volume.First);
            books.Add(Volume.First);

            var expected = "16,00 EUR";

            var harryPotter = new HarryPotter();

            var actual = harryPotter.CalculatePrice(books);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculatePrice_SingleSetShouldApplyDiscount()
        {
            var books = new List<Volume>();
            books.Add(Volume.First);
            books.Add(Volume.Second);

            var expected = "15,20 EUR";

            var harryPotter = new HarryPotter();

            var actual = harryPotter.CalculatePrice(books);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculatePrice_TwoDifferentBookSetsShouldApplyDiscount()
        {
            var books = new List<Volume>();
            books.Add(Volume.First);
            books.Add(Volume.Second);
            books.Add(Volume.Third);
            books.Add(Volume.First);
            books.Add(Volume.Second);

            var expected = "36,80 EUR";

            var harryPotter = new HarryPotter();

            var actual = harryPotter.CalculatePrice(books);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculatePrice_ShouldApplyDiscountOnlyForSets()
        {
            var books = new List<Volume>();
            books.Add(Volume.First);
            books.Add(Volume.First);
            books.Add(Volume.Second);
            books.Add(Volume.Second);
            books.Add(Volume.Third);
            books.Add(Volume.Third);
            books.Add(Volume.Fourth);
            books.Add(Volume.Fifth);

            var expected = "51,60 EUR";

            var harryPotter = new HarryPotter();

            var actual = harryPotter.CalculatePrice(books);

            Assert.AreEqual(expected, actual);
        }
    }
}
