using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class DamageSlotLevelSpell
    {
        [BsonElement("1")]
        public string DmSlLvl1 { get; set; } = String.Empty;

        [BsonElement("2")]
        public string DmSlLvl2 { get; set; } = String.Empty;

        [BsonElement("3")]
        public string DmSlLvl3 { get; set; } = String.Empty;

        [BsonElement("4")]
        public string DmSlLvl4 { get; set; } = String.Empty;

        [BsonElement("5")]
        public string DmSlLvl5 { get; set; } = String.Empty;

        [BsonElement("6")]
        public string DmSlLvl6 { get; set; } = String.Empty;

        [BsonElement("7")]
        public string DmSlLvl7 { get; set; } = String.Empty;

        [BsonElement("8")]
        public string DmSlLvl8 { get; set; } = String.Empty;

        [BsonElement("9")]
        public string DmSlLvl9 { get; set; } = String.Empty;
    }
}
