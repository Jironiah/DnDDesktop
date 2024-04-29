using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Level
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("ability_score_bonuses")]
        public int? AbilityScoreBonuses { get; set; }

        [BsonElement("class")]
        public From? Class { get; set; }

        [BsonElement("classLevels")]
        public From? ClassLevels { get; set; }

        [BsonElement("class_specific")]
        public ClassSpecificLevel? ClassSpecific { get; set; }

        [BsonElement("features")]
        public ArrayedFrom[]? Features { get; set; }

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;
        
        [BsonElement("level")]
        public int? LevelN { get; set; }

        [BsonElement("prof_bonus")]
        public int? ProficiencyBonus { get; set; }

        [BsonElement("spellcasting")]
        public SpellcastingLevel? Spellcasting { get; set;}

        [BsonElement("subclass")]
        public From? Subclass { get; set; }

        [BsonElement("subclass_specific")]
        public SubclassSpecificLevel? Subcategories { get; set; }
    }
}
