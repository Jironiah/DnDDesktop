using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class DamageEquipment
    {
        [BsonElement("damage_dice")]
        public string DamageDice { get; set; } = String.Empty;

        [BsonElement("damage_type")]
        public From? DamageType { get; set; }
    }
}
