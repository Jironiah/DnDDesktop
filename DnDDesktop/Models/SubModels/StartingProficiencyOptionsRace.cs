using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class StartingProficiencyOptionsRace
    {
        [BsonElement("choose")]
        public int? Choose { get; set; }

        [BsonElement("desc")]
        public string Description { get; set; } = String.Empty;

        [BsonElement("from")]
        public From[]? From { get; set; }

        [BsonElement("type")]
        public string Type { get; set; } = String.Empty;
    }
}
