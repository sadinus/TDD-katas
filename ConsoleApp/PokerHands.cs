using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class PokerHands
    {
        public string DetermineWinner(string input)
        {
            var inputArray = input.Split();
            if (inputArray.Length != inputArray.Distinct().Count())
            {
                throw new ArgumentException("Cards or players are duplicated.");
            }

            var playerOne = new Player(inputArray[0].Remove(inputArray[0].Length - 1), new List<Card>() { new Card(inputArray[1][0], (CardSuit)inputArray[1][1]),
                                                                                                new Card(inputArray[2][0], (CardSuit)inputArray[2][1]),
                                                                                                new Card(inputArray[3][0], (CardSuit)inputArray[3][1]),
                                                                                                new Card(inputArray[4][0], (CardSuit)inputArray[4][1]),
                                                                                                new Card(inputArray[5][0], (CardSuit)inputArray[5][1])});

            var playerTwo = new Player(inputArray[6].Remove(inputArray[0].Length - 1), new List<Card>() { new Card(inputArray[7][0],  (CardSuit)inputArray[7][1]),
                                                                                                new Card(inputArray[8][0],  (CardSuit)inputArray[8][1]),
                                                                                                new Card(inputArray[9][0],  (CardSuit)inputArray[9][1]),
                                                                                                new Card(inputArray[10][0], (CardSuit)inputArray[10][1]),
                                                                                                new Card(inputArray[11][0], (CardSuit)inputArray[11][1])});

            var playerOneHighCard = playerOne.Cards.Max(x => x.Value);
            var playerTwoHighCard = playerTwo.Cards.Max(x => x.Value);

            if (playerOneHighCard < playerTwoHighCard)
            {
                return "White wins - high card: Ace";
            }

            return "Black wins - high card: Ace";
        }
    }

    public class Player
    {
        public Player(string name, List<Card> cards)
        {
            Name = name;
            Cards = cards;
        }

        string Name { get; set; }
        public List<Card> Cards { get; set; }
    }

    public class Card
    {
        public Card(char symbol, CardSuit suit)
        {
            Symbol = symbol;
            Suit = suit;
        }

        CardSuit Suit { get; set; }
        char Symbol { get; set; }

        public int Value { get => MapToInt(Symbol); }

        private int MapToInt(char symbol)
        {
            switch (symbol)
            {
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'T':
                    return 10;
                case 'J':
                    return 11;
                case 'Q':
                    return 12;
                case 'K':
                    return 13;
                case 'A':
                    return 14;
                default:
                    break;
            }

            return -1;
        }
    }

    public enum CardSuit
    {
        Club = 'C',
        Diamond = 'D',
        Hearth = 'H',
        Spades = 'S'
    }
}