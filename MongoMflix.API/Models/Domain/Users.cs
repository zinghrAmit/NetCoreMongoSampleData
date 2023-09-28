using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoMflix.API.Models.Domain
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
