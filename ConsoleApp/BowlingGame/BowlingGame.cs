using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class BowlingGame
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;
        public int Score
        {
            get
            {
                var score = 0;
                var rollIndex = 0;
                for (int frame = 0; frame < 10; frame++)
                {
                    if (IsStrike(rollIndex))
                    {
                        score += GetStrikeScore(rollIndex);
                        rollIndex++;
                    }
                    else if (IsSpare(rollIndex))
                    {
                        score += GetSpareScore(rollIndex);
                        rollIndex += 2;
                    }
                    else
                    {
                        score += GetStandardScore(rollIndex);
                        rollIndex += 2;
                    }
                }

                return score;
            }
        }
        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }
        private bool IsSpare(int index)
        {
            return rolls[index] + rolls[index + 1] == 10;
        }

        private bool IsStrike(int index)
        {
            return rolls[index] == 10;
        }

        private int GetStandardScore(int index)
        {
            return rolls[index] + rolls[index + 1];
        }

        private int GetSpareScore(int index)
        {
            return rolls[index] + rolls[index + 1] + rolls[index + 2];
        }

        private int GetStrikeScore(int index)
        {
            return rolls[index] + rolls[index + 1] + rolls[index + 2];
        }


    }
}