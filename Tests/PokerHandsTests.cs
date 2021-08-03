using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class PokerHandsTests
    {
        PokerHands pokerHands;

        [SetUp]
        public void Setup()
        {
            pokerHands = new PokerHands();
        }

        [Test]
        public void Card_duplicate_throws_argument_error()
        {
            var input = "Black: 2H 2H 5S 9C KD White: 2C 3H 4S 8C AH";

            Assert.That(() => pokerHands.DetermineWinner(input), 
                Throws.TypeOf<ArgumentException>()
                .With
                .Property("Message")
                .EqualTo("Cards or players are duplicated."));
        }

        [Test]
        public void HighCard_wins_with_lowerCard()
        {
            var input = "Black: 2H 3D 5S 9C KD White: 2C 3H 4S 8C AH";
            var actual = pokerHands.DetermineWinner(input);

            Assert.That(actual, Is.EqualTo("White wins - high card: Ace"));
        }
    }
}
