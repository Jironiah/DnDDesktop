using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Feats
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("desc")]
        public string[]? Description { get; set; }

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("prerequisites")]
        public Prerequisites[]? Prerequisites { get; set; }
    }
}
