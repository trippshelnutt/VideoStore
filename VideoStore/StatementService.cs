using System.Text;

namespace VideoStore
{
    public static class StatementService
    {
        public static string BuildStatement(Customer customer)
        {
            double totalAmount = 0;
            var frequentRenterPoints = 0;

            var statement = new StringBuilder();
            statement.Append($"Rental Record for {customer.Name}\n");

            foreach (var rental in customer.Rentals)
            {
                var thisAmount = rental.GetRentalPrice();

                frequentRenterPoints += rental.GetRentalFrequentRenterPoints();

                statement.Append($"\t{rental.GetMovieTitle()}\t{thisAmount}\n");
                totalAmount += thisAmount;
            }

            statement.Append($"You owed {totalAmount}\n");
            statement.Append($"You earned {frequentRenterPoints} frequent renter points\n");

            return statement.ToString();
        }
    }
}