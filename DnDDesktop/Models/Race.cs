using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Race
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("age")]
        public string age { get; set; } = String.Empty;

        [BsonElement("size")]
        public string size { get; set; } = String.Empty;

        [BsonElement("size_description")]
        public string SizeDescription { get; set; } = String.Empty;

        [BsonElement("alignment")]
        public string Alignment { get; set; } = String.Empty;

        [BsonElement("speed")]
        public int? Speed { get; set; }

        [BsonElement("ability_bonus_options")]
        public AbilityBonusOptionRace? AbilityBonusOptions { get; set; }

        [BsonElement("ability_bonuses")]
        public AbilityBonusRace[]? AbilityBonus { get; set; }

        [BsonElement("language_desc")]
        public string LanguageDesc { get; set; } = String.Empty;

        [BsonElement("language_options")]
        public LanguageOptionsRace? LanguageOptions { get; set; }

        [BsonElement("languages")]
        public From[]? Languages { get; set; }

        [BsonElement("starting_proficiencies")]
        public From[]? StartingProficiencies { get; set; }

        [BsonElement("starting_proficiency_options")]
        public StartingProficiencyOptionsRace? StartingProficienciesOptions { get; set; }

        [BsonElement("subraces")]
        public From[]? Subraces { get; set; }

        [BsonElement("traits")]
        public From[]? Traits { get; set; }
    }
}
