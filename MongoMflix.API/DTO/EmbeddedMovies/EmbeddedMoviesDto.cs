using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoMflix.API.DTO.EmbeddedMovies
{
    public class EmbeddedMoviesDto
    {
        public string[]? genres { get; set; }
        public string[]? cast { get; set; }
        public int num_mflix_comments { get; set; } = 0;
        public string poster { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string fullplot { get; set; } = string.Empty;
        public string[]? languages { get; set; }
        public DateTime released { get; set; }
        public string[]? directors { get; set; }
        public Awards awards { get; set; } = new Awards();
        public string[]? writers { get; set; }
        public int year { get; set; }
        public Imdb imdb { get; set; } = new Imdb();
        public string[]? countries { get; set; }
        public string type { get; set; } = string.Empty;
        public Tomatoes tomatoes { get; set; } = new Tomatoes();
    }

    [BsonIgnoreExtraElements]
    public class Awards
    {
        public int wins { get; set; }
        public int nominations { get; set; }
        public string? text { get; set; }

        //public static explicit operator Awards(Models.Domain.Awards v)
        //{
        //    throw new NotImplementedException();
        //}
    }

    [BsonIgnoreExtraElements]
    public class Imdb
    {
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float rating { get; set; }
        public int votes { get; set; }
        public int id { get; set; }

        //public static explicit operator Imdb(Models.Domain.Imdb v)
        //{
        //    throw new NotImplementedException();
        //}
    }

    [BsonIgnoreExtraElements]
    public class Tomatoes
    {
        public Viewer viewer { get; set; } = new Viewer();
        public string? production { get; set; }
        public DateTime lastUpdated { get; set; }
        //public static explicit operator Tomatoes(Models.Domain.Tomatoes v)
        //{
        //    throw new NotImplementedException();
        //}
    }

    [BsonIgnoreExtraElements]
    public class Viewer
    {
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float rating { get; set; }
        public int numReviews { get; set; }
        public int meter { get; set; }
    }
}

