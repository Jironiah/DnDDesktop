using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class AbilityBonusOptionRace
    {
        [BsonElement("choose")]
        public int? Choose { get; set; }

        [BsonElement("from")]
        public OptionsRace[]? From { get; set; }

        [BsonElement("type")]
        public string Type { get; set; } = String.Empty;
    }
}
