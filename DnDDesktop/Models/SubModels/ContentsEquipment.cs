using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class ContentsEquipment
    {
        [BsonElement("item")]
        public From[]? Item { get; set; }

        [BsonElement("quantity")]
        public int? Quantity { get; set; }
    }
}
