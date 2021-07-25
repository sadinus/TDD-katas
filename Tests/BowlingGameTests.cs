using ConsoleApp;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class BowlingGameTests
    {
        BowlingGame bowlingGame;

        [SetUp]
        public void Setup()
        {
            bowlingGame = new BowlingGame();
        }

        [Test]
        public void GetScore_AllRollsMissed_ReturnsZero()
        {
            var expected = 0;

            bowlingGame.Roll(0);
            bowlingGame.Roll(0);
            bowlingGame.Roll(0);
            bowlingGame.Roll(0);
            bowlingGame.Roll(0);

            var result = bowlingGame.GetScore();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetScore_AllRollsOnePin_ReturnsTwenty()
        {
            var expected = 20;

            for(var i = 0; i < 20; i++)
            {
                bowlingGame.Roll(1);
            }

            var result = bowlingGame.GetScore();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetScore_AfterSpare_NextRollDoubles()
        {
            var expected = 16;

            bowlingGame.Roll(10);
            bowlingGame.Roll(3);

            var result = bowlingGame.GetScore();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetScore_AfterSpare_NextTwoRollsDoubles()
        {
            var expected = 24;

            bowlingGame.Roll(10);
            bowlingGame.Roll(3);
            bowlingGame.Roll(4);

            var result = bowlingGame.GetScore();

            Assert.AreEqual(expected, result);
        }
    }
}
