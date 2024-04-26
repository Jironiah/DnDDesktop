using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Equipment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("armor_category")]
        public string ArmorCategory { get; set; } = String.Empty;

        [BsonElement("armor_class")]
        public ArmorClassEquipment? ArmorName { get; set; }

        [BsonElement("capacity")]
        public string Capacity {  get; set; } = String.Empty;

        [BsonElement("category_range")]
        public string CategoryRange { get; set; } = String.Empty;

        [BsonElement("contents")]
        public ContentsEquipment? Contents { get; set; }

        [BsonElement("cost")]
        public UnitQuantity? Cost { get; set; }

        [BsonElement("damage")]
        public DamageEquipment? UnitQuantity { get; set; }

        [BsonElement("desc")]
        public string[]? Description { get; set; }

        [BsonElement("equipment_category")]
        public From? EquipmentCategory { get; set; }

        [BsonElement("gear_category")]
        public From? GearCategory { get; set; }

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("properties")]
        public From[]? Properties { get; set; }

        [BsonElement("quantity")]
        public int? Quantity { get; set; }

        [BsonElement("range")]
        public DnDDesktop.Models.Commons.Range? Range { get; set; }

        [BsonElement("special")]
        public string[]? Special { get; set; }

        [BsonElement("speed")]
        public UnitQuantity? Speed { get; set; }

        [BsonElement("stealth_disadvantage")]
        public bool? StealthDisadvantage { get; set; }

        [BsonElement("str_minimum")]
        public int? StrengthMinimum { get; set; }

        [BsonElement("throw_range")]
        public DnDDesktop.Models.Commons.Range? ThrowRange { get; set; }

        [BsonElement("tool_category")]
        public string ToolCategory { get; set; } = String.Empty;

        [BsonElement("two_handed_damage")]
        public TwoHandedDamageEquipment? TwoHandedDamage { get; set; }

        [BsonElement("vehicle_category")]
        public string VehicleCategory { get; set; } = String.Empty;

        [BsonElement("weapon_category")]
        public string WeaponCategory { get; set; } = String.Empty;

        [BsonElement("weapon_range")]
        public string WeaponRange { get; set; } = String.Empty;

        [BsonElement("weight")]
        public double? Weight { get; set;}
    }
}
