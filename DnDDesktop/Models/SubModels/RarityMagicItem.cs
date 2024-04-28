using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class RarityMagicItem
    {
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
    }
}
