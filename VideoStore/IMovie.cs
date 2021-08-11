namespace VideoStore
{
    public interface IMovie
    {
        string Title { get; }
        double GetMoviePrice(int daysRented);
        int GetMovieRentalFrequentRenterPoints(int daysRented);
    }
}