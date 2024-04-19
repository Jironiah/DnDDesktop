using DnDDesktop.Models.Commons;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class AbilityScore
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("index")]
        public string Index { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("full_name")]
        public string FullName { get; set; } = string.Empty;

        [BsonElement("desc")]
        public string[]? Description { get; set; }

        [BsonElement("skills")]
        public From[]? Skills { get; set;}
    }
}
