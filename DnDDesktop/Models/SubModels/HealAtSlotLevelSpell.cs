using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class HealAtSlotLevelSpell
    {
        [BsonElement("1")]
        public string HealAtSlotLevel1 { get; set; } = String.Empty;

        [BsonElement("2")]
        public string HealAtSlotLevel2 { get; set; } = String.Empty;

        [BsonElement("3")]
        public string HealAtSlotLevel3 { get; set; } = String.Empty;

        [BsonElement("4")]
        public string HealAtSlotLevel4 { get; set; } = String.Empty;

        [BsonElement("5")]
        public string HealAtSlotLevel5 { get; set; } = String.Empty;

        [BsonElement("6")]
        public string HealAtSlotLevel6 { get; set; } = String.Empty;

        [BsonElement("7")]
        public string HealAtSlotLevel7 { get; set; } = String.Empty;

        [BsonElement("8")]
        public string HealAtSlotLevel8 { get; set; } = String.Empty;

        [BsonElement("9")]
        public string HealAtSlotLevel9 { get; set; } = String.Empty;
    }
}
