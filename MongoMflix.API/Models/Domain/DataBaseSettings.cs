namespace MongoMflix.API.Models.Domain
{
    public class DataBaseSettings
    {
        public string? ConnectionString { get; set; }
        public string? DataBaseName { get; set;}
        public string? CommentsCollectionName { get; set; }
        public string? EmbeddedMoviesCollectionName { get; set; }
        public string? MoviesCollectionName {  get; set; }
        public string? SessionsCollectionName { get; set; }
        public string? TheatersCollectionName { get; set; }
        public string? UsersCollectonName { get; set;}
    }
}
