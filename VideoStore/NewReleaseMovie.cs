namespace VideoStore
{
    public class NewReleaseMovie : IMovie
    {
        public NewReleaseMovie(string title)
        {
            Title = title;
        }

        public string Title { get; }

        public double GetMoviePrice(int daysRented)
        {
            return daysRented * 3;
        }

        public int GetMovieRentalFrequentRenterPoints(int daysRented)
        {
            return daysRented > 1 ? 2 : 1;
        }
    }
}
