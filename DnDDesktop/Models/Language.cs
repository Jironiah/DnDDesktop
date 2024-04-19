using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Language
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("desc")]
        public string Description { get; set; } = String.Empty;

        [BsonElement("script")]
        public string Script { get; set; } = String.Empty;

        [BsonElement("type")]
        public string Type { get; set; } = String.Empty;

        [BsonElement("typical_speakers")]
        public string[]? TypicalSpeakesr { get; set; }
    }
}
