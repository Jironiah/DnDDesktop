using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class MagicItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("desc")]
        public string[]? Desc { get; set; }

        [BsonElement("equipment_category")]
        public From? EquipmentCategory { get; set; }

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("rarity")]
        public RarityMagicItem? Rarity { get; set; }

        [BsonElement("variant")]
        public Boolean? Variant { get; set; }

        [BsonElement("variants")]
        public From[]? Variants { get; set;}
    }
}
