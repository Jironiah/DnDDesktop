using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Subrace
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("ability_bonuses")]
        public AbilityBonusesSubrace[]? AbilityBonuses { get; set; }

        [BsonElement("desc")]
        public string Description { get; set; } = String.Empty;

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("language_options")]
        public LanguageOptionsCommon? LanguageOptions { get; set; }

        [BsonElement("languages")]
        public From[]? Languages { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("race")]
        public From? Race { get; set; }

        [BsonElement("racial_traits")]
        public From[]? RacialTraits { get; set; }

        [BsonElement("starting_proficiencies")]
        public From[]? RaceTraits { get; set; }
    }
}
