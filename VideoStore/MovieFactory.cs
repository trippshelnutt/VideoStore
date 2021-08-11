namespace VideoStore
{
    public static class MovieFactory
    {
        public static IMovie CreateMovie(string title, int priceCode)
        {
            switch (priceCode)
            {
                case MovieConstants.Childrens:
                {
                    return new ChildrensMovie(title);
                }
                case MovieConstants.NewRelease:
                {
                    return new NewReleaseMovie(title);
                }
                default:
                {
                    return new RegularMovie(title);
                }
            }
        }
    }
}