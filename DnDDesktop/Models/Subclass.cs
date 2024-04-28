using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Subclass
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("class")]
        public From? Class { get; set; }

        [BsonElement("desc")]
        public string[]? Description { get; set; }

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("spells")]
        public SpellsSubclass[]? Spells { get; set; }

        [BsonElement("subclass_flavor")]
        public string SubclassFlavor { get; set; } = String.Empty;

        [BsonElement("subclass_levels")]
        public string SubclassLevels { get; set; } = String.Empty;
    }
}
