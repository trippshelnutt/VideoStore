using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoStore
{
    public static class StatementService
    {
        private class LineItem
        {
            public string Title { get; set; }
            public double Price { get; set; }
            public int Points { get; set; }
        }
        
        public static string BuildStatement(Customer customer)
        {
            var lineItems = GetLineItems(customer);

            var totalAmount = lineItems.Sum(l => l.Price);
            var frequentRenterPoints = lineItems.Sum(l => l.Points);
            
            var statement = new StringBuilder();
            statement.Append($"Rental Record for {customer.Name}\n");
            lineItems.ForEach(l => statement.Append($"\t{l.Title}\t{l.Price}\n"));
            statement.Append($"You owed {totalAmount}\n");
            statement.Append($"You earned {frequentRenterPoints} frequent renter points\n");

            return statement.ToString();
        }

        private static List<LineItem> GetLineItems(Customer customer)
        {
            return customer.Rentals
                .Select(r => new LineItem
                {
                    Title = r.Movie.Title,
                    Price = PriceStrategyFactory.GetPriceStrategy(r)(r.DaysRented),
                    Points = PointsStrategyFactory.GetPointsStrategy(r)(r.DaysRented)
                })
                .ToList();
        }
    }
}