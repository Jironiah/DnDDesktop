using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class StartingEquipmentBa
    {
        [BsonElement("equipment")]
        public From? Equipment { get; set; }

        [BsonElement("quantity")]
        public int? Quantity { get; set; }
    }
}
