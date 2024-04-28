using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Trait
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("desc")]
        public string[]? Description { get; set; }

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("language_options")]
        public LanguageOptionsCommon? LanguageOptions { get; set;}

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("parent")]
        public From? Parent { get; set; }

        [BsonElement("proficiencies")]
        public From[]? Proficiencies { get; set; }

        [BsonElement("proficiency_choices")]
        public ExpertiseOptionFeature? ProficiencyChoices { get; set; }

        [BsonElement("races")]
        public From[]? Race { get; set; }

        [BsonElement("subraces")]
        public From[]? Subrace { get; set; }

        [BsonElement("trait_specific")]
        public TraitSpecific? TraitSpecifics { get; set; }

    }
}
