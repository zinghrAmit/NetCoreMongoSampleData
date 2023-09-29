using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoMflix.API.Models.Domain
{
    [BsonIgnoreExtraElements]
    public class Theaters
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int theaterId { get; set; }
        public Location location { get; set; } = new Location();
    }

    [BsonIgnoreExtraElements]
    public class Location
    {
        public Address address { get; set; } = new Address();
        public Geo geo { get; set; } = new Geo();
    }

    [BsonIgnoreExtraElements]
    public class Address
    {
        public string street1 { get; set; } = String.Empty;
        public string city { get; set; } = String.Empty;
        public string state { get; set; } = String.Empty;
        public string zipcode { get; set;} = String.Empty;
    }

    [BsonIgnoreExtraElements]
    public class Geo
    {
        public string? type { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float[]? coordinates { get; set; }
    }
}
