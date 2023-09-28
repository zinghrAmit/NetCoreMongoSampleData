using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoMflix.API.Models.Domain;
public class Comments
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string movie_id { get; set; }

    public string name { get; set; }
    public string email { get; set; }
    public string text { get; set; }
    public DateTime date { get; set; }
}
