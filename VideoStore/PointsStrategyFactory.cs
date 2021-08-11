using System;

namespace VideoStore
{
    public static class PointsStrategyFactory
    {
        public static Func<int, int> GetPointsStrategy(Rental rental)
        {
            if (rental.Type == RentalType.NewRelease)
            {
                return GetNewReleasePoints;
            }

            return GetRegularPoints;
        }

        private static int GetNewReleasePoints(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;
        }

        private static int GetRegularPoints(int daysRented)
        {
            return 1;
        }
    }
}