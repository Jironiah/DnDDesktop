using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class PrerequisiteFeature
    {
        [BsonElement("feature")]
        public string feature { get; set; } = String.Empty;

        [BsonElement("level")]
        public int? level { get; set; }

        [BsonElement("spell")]
        public string Spell { get; set; } = String.Empty;

        [BsonElement("type")]
        public string Type { get; set; } = String.Empty;
    }
}
