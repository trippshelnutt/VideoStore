namespace VideoStore
{
    public class ChildrensMovie : IMovie
    {
        public ChildrensMovie(string title)
        {
            Title = title;
        }

        public string Title { get; }

        public double GetMoviePrice(int daysRented)
        {
            var thisAmount = 1.5;

            if (daysRented > 3)
            {
                thisAmount += (daysRented - 3) * 1.5;
            }

            return thisAmount;
        }

        public int GetMovieRentalFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}