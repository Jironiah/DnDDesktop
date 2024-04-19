using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class StartingEquipmentClasses
    {
        [BsonElement("equipment")]
        public From? Equipment { get; set; }

        [BsonElement("quantity")]
        public int? quantity { get; set;}
    }
}
