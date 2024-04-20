using MongoDB.Bson.Serialization.Attributes;

namespace DNDAPI.Models.Commons
{
    [BsonNoId]
    public class DiceCountValueCommon
    {
        [BsonElement("dice_count")]
        public int? DiceCount { get; set; }

        [BsonElement("dice_value")]
        public int? DiceValues { get; set; }
    }
}
