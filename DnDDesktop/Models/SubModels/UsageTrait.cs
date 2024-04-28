using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class UsageTrait
    {
        [BsonElement("times")]
        public int? Times { get; set; }

        [BsonElement("type")]
        public string Type { get; set; } = String.Empty;
    }
}
