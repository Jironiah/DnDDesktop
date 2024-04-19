using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class FromBackground
    {
        [BsonElement("equipment_category")]
        public From? EquipmentCategory { get; set; }
    }
}
