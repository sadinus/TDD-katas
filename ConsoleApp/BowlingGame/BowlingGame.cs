using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class BowlingGame
    {
        public List<int> Rolls { get; set; } = new List<int>();
        public bool IsSpare { get; private set; }
        public int Multiplier
        {
            get => IsSpare ? 2 : 1;
        }
        public int GetScore()
        {
            return Rolls.Sum();
        }

        public void Roll(int score)
        {
            Rolls.Add(score * Multiplier);

            IsSpare = score == 10;
        }
    }
}