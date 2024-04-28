using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class AbilityBonusesSubrace
    {
        [BsonElement("ability_score")]
        public From? AbilityScore { get; set; }

        [BsonElement("bonus")]
        public int? Bonus { get; set; }
    }
}
