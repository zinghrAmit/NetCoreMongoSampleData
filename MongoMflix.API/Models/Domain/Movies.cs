using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoMflix.API.Models.Domain
{
    [BsonIgnoreExtraElements]
    public class Movies
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        public string? plot { get; set; }
        public string[]? genres { get; set; }
        public int runtime { get; set; }
        public string[]? cast { get; set; }
        public string? poster { get; set; }
        public string? title { get; set; }
        public string? fullplot { get; set; }
        public string[]? languages { get; set; }
        public DateTime released { get; set; }
        public string[]? directors { get; set; }
        public string? rated { get; set; }
        public Award awards { get; set; } = new Award();
        public string? lastupdated { get; set; }
        public int year { get; set; }
        public Imdbs imdb { get; set; } = new Imdbs();
        public string[]? countries { get; set; }
        public string? type { get; set; }
        public Tomatoe tomatoes { get; set; } = new Tomatoe();
        public int num_mflix_comments { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Award
    {
        public int wins { get; set; }
        public int nominations { get; set; }
        public string? text { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Imdbs
    {
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float rating { get; set; }
        public int votes { get; set; }
        public int id { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Tomatoe
    {
        public View viewer { get; set; } = new View();
        public int fresh { get; set; }
        public Criti critic { get; set; } = new Criti();
        public int rotten { get; set; }
        public DateTime lastUpdated { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class View
    {
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float rating { get; set; }
        public int numReviews { get; set; }
        public int meter { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Criti
    {
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float rating { get; set; }
        public int numReviews { get; set; }
        public int meter { get; set; }
    }
}
