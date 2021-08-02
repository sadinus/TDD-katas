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
                          select new BooksVolume { Volume = g.Key, Total = g.Count() }).OrderBy(x => x.Total).ToList();

            var totalPrice = CalculateSetOfBooksPrice(basket);
            var result = FormatPrice(totalPrice);

            return result;
        }

        private decimal CalculateSetOfBooksPrice(List<BooksVolume> basket)
        {
            decimal totalPrice = 0M;

            while (basket.Count > 0)
            {
                var groupNumber = basket.FirstOrDefault().Total;

                var booksInSet = basket.Count();

                var discount = CalculateDiscount(booksInSet);

                totalPrice += groupNumber * discount * booksInSet * BASIC_PRICE;

                basket.RemoveAll(x => x.Total == groupNumber);
                basket.ForEach(x => x.Total -= groupNumber);
            }

            return totalPrice;
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