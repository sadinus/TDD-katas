using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class LeapYearTests
    {
        [Test]
        [TestCase(1, false)]
        [TestCase(4, true)]
        [TestCase(8, true)]
        [TestCase(100, false)]
        [TestCase(200, false)]
        [TestCase(400, true)]
        [TestCase(800, true)]
        [TestCase(2001, false)]
        [TestCase(1996, true)]
        [TestCase(1900, false)]
        [TestCase(2000, true)]
        public void IsLeapYear_ShouldBeOK(int year, bool expected)
        {
            var leapYear = new LeapYear();

            var actual = leapYear.Get(year);

            Assert.AreEqual(expected, actual);
        }
    }
}
