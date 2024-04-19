using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class ItemsFeature
    {
        [BsonElement("choice")]
        public ItemsChoiceFeature? Choice { get; set; }

        [BsonElement("item")]
        public ArrayedFrom? Item { get; set; }
    }
}
