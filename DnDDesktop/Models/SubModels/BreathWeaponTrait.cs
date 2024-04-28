using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class BreathWeaponTrait
    {
        [BsonElement("area_of_effect")]
        public AreaOfEffect? AreaOfEffect { get; set; }

        [BsonElement("damage")]
        public DamageTrait[]? Damage { get; set; }

        [BsonElement("dc")]
        public DCTrait? DC { get; set; }

        [BsonElement("desc")]
        public string Description { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("usage")]
        public UsageTrait? Usage { get; set; }
    }
}
