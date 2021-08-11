using System;

namespace VideoStore
{
    public static class PriceStrategyFactory
    {
        public static Func<int, double> GetPriceStrategy(Rental rental)
        {
            if (rental.Movie.Type == MovieType.Childrens)
            {
                return GetChildrensPrice;
            }

            if (rental.Type == RentalType.NewRelease)
            {
                return GetNewReleasePrice;
            }

            return GetRegularPrice;
        }

        private static double GetRegularPrice(int daysRented)
        {
            double thisAmount = 2;

            if (daysRented > 2)
            {
                thisAmount += (daysRented - 2) * 1.5;
            }

            return thisAmount;
        }

        private static double GetNewReleasePrice(int daysRented)
        {
            return daysRented * 3;
        }

        private static double GetChildrensPrice(int daysRented)
        {
            var thisAmount = 1.5;

            if (daysRented > 3)
            {
                thisAmount += (daysRented - 3) * 1.5;
            }

            return thisAmount;
        }
    }
}