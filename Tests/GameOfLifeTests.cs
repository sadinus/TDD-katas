using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class GameOfLifeTests
    {
        GameOfLife gameOfLife;

        [SetUp]
        public void Setup()
        {
            gameOfLife = new GameOfLife();
        }

        [Test]
        public void NextGeneration_ShouldKillCellsWithLessThanTwoNeighbours()
        {
            var input = new char[4, 4] { { '.', '.', '.', '.' },
                                         { '.', '*', '*', '.' },
                                         { '.', '.', '.', '.' },
                                         { '.', '.', '.', '.' } };

            var expected = new char[4, 4] { { '.', '.', '.', '.' },
                                            { '.', '.', '.', '.' },
                                            { '.', '.', '.', '.' },
                                            { '.', '.', '.', '.' } };

            var actual = gameOfLife.NextGeneration(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NextGeneration_ShouldKillCellsWithMoreThanThreeNeighbours()
        {
            var input = new char[3, 4] { { '.', '*', '*', '*' },
                                         { '.', '.', '*', '.' },
                                         { '.', '*', '*', '*' } };

            var expected = new char[3, 4] { { '.', '*', '*', '*' },
                                            { '.', '.', '.', '.' },
                                            { '.', '*', '*', '*' } };

            var actual = gameOfLife.NextGeneration(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NextGeneration_ShouldIdleAliveCellsWithTwoOrThreeNeighbours()
        {
            var input = new char[4, 4] { { '*', '*', '*', '*' },
                                         { '*', '.', '.', '*' },
                                         { '*', '.', '.', '*' },
                                         { '*', '*', '*', '*' } };

            var expected = new char[4, 4] { { '*', '*', '*', '*' },
                                            { '*', '.', '.', '*' },
                                            { '*', '.', '.', '*' },
                                            { '*', '*', '*', '*' } };

            var actual = gameOfLife.NextGeneration(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NextGeneration_ShouldBornDeadCellsWithThreeNeighbours()
        {
            var input = new char[5, 4] { { '*', '*', '*', '*' },
                                         { '*', '.', '.', '*' },
                                         { '*', '.', '.', '*' },
                                         { '*', '.', '.', '*' },
                                         { '*', '*', '*', '*' }};

            var expected = new char[5, 4] { { '*', '*', '*', '*' },
                                            { '*', '.', '.', '*' },
                                            { '*', '*', '*', '*' },
                                            { '*', '.', '.', '*' },
                                            { '*', '*', '*', '*' }};

            var actual = gameOfLife.NextGeneration(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
