namespace VideoStore
{
    public class Movie
    {
        public string Title { get; }
        public MovieType Type { get; }
        
        public Movie(string title, MovieType type)
        {
            Title = title;
            Type = type;
        }
    }
}