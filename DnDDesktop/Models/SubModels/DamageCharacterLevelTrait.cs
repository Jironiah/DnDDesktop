using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class DamageCharacterLevelTrait
    {
        [BsonElement("1")]
        public string ChLcl1 { get; set; } = String.Empty;

        [BsonElement("11")]
        public string ChLcl11 { get; set; } = String.Empty;

        [BsonElement("16")]
        public string ChLcl16 { get; set; } = String.Empty;

        [BsonElement("6")]
        public string ChLcl6 { get; set; } = String.Empty;
    }
}
