using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Alignment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        
        [BsonElement("abbreviation")]
        public string Abbreviation { get; set; } = String.Empty;

        [BsonElement("desc")]
        public string Description { get; set; } = String.Empty;

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
    }
}
