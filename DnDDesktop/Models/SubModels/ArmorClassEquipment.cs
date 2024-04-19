using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class ArmorClassEquipment
    {
        [BsonElement("base")]
        public int? Base { get; set; }

        [BsonElement("dex_bonus")]
        public bool DexBonus { get; set; }

        [BsonElement("max_bonus")]
        public int? MaxBonus { get; set; }
    }
}
