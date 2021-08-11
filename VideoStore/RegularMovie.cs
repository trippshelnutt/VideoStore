namespace VideoStore
{
    public class RegularMovie : IMovie
    {
        public RegularMovie(string title)
        {
            Title = title;
        }

        public string Title { get; }

        public double GetMoviePrice(int daysRented)
        {
            double thisAmount = 2;

            if (daysRented > 2)
            {
                thisAmount += (daysRented - 2) * 1.5;
            }

            return thisAmount;
        }

        public int GetMovieRentalFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}