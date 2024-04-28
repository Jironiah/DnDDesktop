using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class SubclassSpecificLevel
    {
        [BsonElement("additional_magical_secrets_max_lvl")]
        public int? AdditionalMagicalSecretsMaxLevel { get; set; }

        [BsonElement("aura_range")]
        public int? AuraRange { get; set; }
    }
}
