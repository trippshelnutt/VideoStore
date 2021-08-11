namespace VideoStore
{
    public class Rental
    {
        private readonly IMovie movie;
        private readonly int daysRented;

        public Rental(IMovie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public string GetMovieTitle()
        {
            return movie.Title;
        }

        public double GetRentalPrice()
        {
            return movie.GetMoviePrice(daysRented);
        }

        public int GetRentalFrequentRenterPoints()
        {
            return movie.GetMovieRentalFrequentRenterPoints(daysRented);
        }
    }
}
