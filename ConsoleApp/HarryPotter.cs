using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class HarryPotter
    {
        private const decimal BASIC_PRICE = 8;
        private const string CURRENCY = "EUR";

        public string CalculatePrice(List<Volume> books)
        {
            var basket = (from b in books
                          group b by b into g
                          select new BooksVolume { Volume = g.Key, Total = g.Count() }).ToList();

            var totalPrice = CalculateTotalPrice(basket);
            var result = FormatPrice(totalPrice);

            return result;
        }

        private decimal CalculateTotalPrice(List<BooksVolume> basket)
        {
            decimal totalPrice = 0M;
            var booksSets = GetBooksSetsFromBasket(basket);

            foreach (var booksSet in booksSets)
            {
                var booksInSet = booksSet.Count;
                var discount = CalculateDiscount(booksInSet);
                totalPrice += booksInSet * discount * BASIC_PRICE;
            }

            return totalPrice;
        }

        private List<HashSet<Volume>> GetBooksSetsFromBasket(List<BooksVolume> basket)
        {
            var booksSets = new List<HashSet<Volume>>();

            while (basket.Any(booksSet => booksSet.Total > 0))
            {
                var booksSet = new HashSet<Volume>();
                foreach (var volumeGroup in basket)
                {
                    if (volumeGroup.Total > 0 && !booksSet.Contains(volumeGroup.Volume))
                    {
                        booksSet.Add(volumeGroup.Volume);
                        volumeGroup.Total--;
                    }
                }

                booksSets.Add(booksSet);
            }

            return booksSets;
        }

        private decimal CalculateDiscount(int booksTypeNumber)
        {
            switch (booksTypeNumber)
            {
                case 2:
                    return 0.95M;
                case 3:
                    return 0.9M;
                case 4:
                    return 0.8M;
                case 5:
                    return 0.75M;
                default:
                    return 1;
            }
        }

        private string FormatPrice(decimal price)
        {
            var priceWithTwoDecimalPlaces = string.Format("{0:0.00}", price);
            return $"{priceWithTwoDecimalPlaces} {CURRENCY}";
        }
    }

    public class BooksVolume
    {
        public Volume Volume { get; set; }
        public int Total { get; set; }
    }

    public enum Volume
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth
    }
}