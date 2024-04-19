using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.Commons
{
    [BsonNoId]
    public class Range
    {
        [BsonElement("long")]
        public int? Long { get; set; }

        [BsonElement("normal")]
        public int? Normal { get; set; }
    }
}
