using ConsoleApp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class BowlingGameTests
    {
        BowlingGame game;

        [SetUp]
        public void Setup()
        {
            game = new BowlingGame();
        }

        [Test]
        public void CanRollGutterGame()
        {
            var expected = 0;

            RollMany(0, 20);


            Assert.AreEqual(expected, game.Score);
        }

        [Test]
        public void CanRollAllOnes()
        {
            var expected = 20;

            RollMany(1, 20);

            Assert.AreEqual(expected, game.Score);
        }

        [Test]
        public void CanRollSpare()
        {
            var expected = 16;

            game.Roll(5);
            game.Roll(5);
            game.Roll(3);
            RollMany(0, 17);

            Assert.AreEqual(expected, game.Score);
        }

        [Test]
        public void CanRollStrike()
        {
            var expected = 24;

            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            RollMany(0, 16);

            Assert.AreEqual(expected, game.Score);
        }

        [Test]
        public void CanRollPerfect()
        {
            var expected = 300;

            RollMany(12, 10);

            Assert.AreEqual(expected, game.Score);
        }

        private void RollMany(int rolls, int pins)
        {
            for (var i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
