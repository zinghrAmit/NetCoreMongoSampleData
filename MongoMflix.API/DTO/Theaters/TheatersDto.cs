using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MongoMflix.API.DTO.Theaters
{
    public class TheatersDto
    {
        internal int theaterId;
        internal string Id;
        internal Location? location;
        [BsonIgnoreExtraElements]
        public class Theaters
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; internal set; }
            public int theaterId { get; internal set; }
            public Location location { get; internal set; } = new Location();
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
            public string zipcode { get; set; } = String.Empty;
        }

        [BsonIgnoreExtraElements]
        public class Geo
        {
            public string? type { get; set; }

            [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
            public float[]? coordinates { get; set; }
        }
    }
}
