using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Background
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("bonds")]
        public ChooseFrom? Bonds { get; set; }

        [BsonElement("feature")]
        public FeatureBackground? Feature {  get; set; }

        [BsonElement("flaws")]
        public ChooseFrom? Flaws { get; set; }

        [BsonElement("ideals")]
        public IdealsBackground? Ideals { get; set; }

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("language_options")]
        public int? LanguageOptions { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("personality_traits")]
        public ChooseFrom? PersonalityTraits { get; set; }

        [BsonElement("starting_equipment")]
        public StartingEquipmentBa[]? StartingEquipment { get; set; }

        [BsonElement("starting_equipment_options")]
        public StartingEquipmentOptionBa[]? StartingEquipmentOption { get; set;}

        [BsonElement("starting_proficiencies")]
        public List<From>? StartingProficiencies { get; set; }
    }
}
