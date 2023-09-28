namespace MongoMflix.API.Models.Domain
{
    public class Movies
    {
        public string MoviesId { get; set; }
        public string Plot { get; set; }
        public string[] Genres { get; set; }
        public int RunTime { get; set; }
        public string[] Cast { get; set; }
        public string PosterLink { get; set; }
        public string Title { get; set; }
        public string FullPlot { get; set; }
        public string[] Languages { get; set; }
        public DateTime RealeaseDate { get; set; }
        public string[] Directors { get; set; }
        public string RatedBy { get; set; }
        public class Awards
        {
            public int Win { get; set; }
            public int Nominations { get; set; }
            public string Text { get; set; }
        }
        public DateTime Lastupdated { get; set; }
        public int Year { get; set; }
        public class IMDB
        {
            public float Rating { get; set; }
            public long Votes { get; set; }
            public long Id { get; set; }
        }
        public string[] Countries { get; set; }
        public string Type { get; set; }
        public class Tomatoes
        {
            public class Viewer
            {
                public float Rating { get; set; }
                public long NumOfReviews { get; set; }
                public int Meter { get; set; } = 0;
            }
            public int Fresh { get; set; }
            public class Critic
            {
                public float Rating { get; set; }
                public int NumOfReviews { get; set; }
                public int Meter { get; set; } = 0;
            }
            public int Rotten { get; set; }
        }
        public int NumberOfComments { get; set; }
    }
}
