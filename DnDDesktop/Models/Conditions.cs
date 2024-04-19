using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Conditions
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("desc")]
        public string[]? Desc { get; set; }
    }
}
