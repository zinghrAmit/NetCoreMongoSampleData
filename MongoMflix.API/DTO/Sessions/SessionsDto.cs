using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoMflix.API.DTO.Sessions
{
    public class SessionsDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? user_id { get; set; }
        public string? jwt { get; set; }
    }
}
