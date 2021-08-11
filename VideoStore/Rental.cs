using System;

namespace VideoStore
{
    public class Rental
    {
        public Movie Movie { get; }
        public int DaysRented { get; }
        public RentalType Type { get; }

        public Rental(Movie movie, int daysRented, RentalType type)
        {
            Movie = movie;
            DaysRented = daysRented;
            Type = type;
        }
    }
}
