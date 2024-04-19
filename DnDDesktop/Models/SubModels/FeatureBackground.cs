using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class FeatureBackground
    {
        [BsonElement("desc")]
        public string[]? Description { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
    }
}
