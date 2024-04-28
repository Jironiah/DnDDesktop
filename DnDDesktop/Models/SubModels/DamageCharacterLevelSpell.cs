using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class DamageCharacterLevelSpell
    {
        [BsonElement("1")]
        public string DmChLcl1 { get; set; } = String.Empty;

        [BsonElement("5")]
        public string DmChLcl5 { get; set; } = String.Empty;

        [BsonElement("11")]
        public string DmChLcl11 { get; set; } = String.Empty;

        [BsonElement("17")]
        public string DmChLcl17 { get; set; } = String.Empty;
    }
}
