using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DnDDesktop.Models
{
    public class DamageType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("desc")]
        public string[]? Description { get; set; }

        [BsonElement("index")]
        public string Index {  get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
    }
}
