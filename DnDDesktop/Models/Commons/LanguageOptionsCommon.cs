using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.Commons
{
    [BsonNoId]
    public class LanguageOptionsCommon
    {
        [BsonElement("choose")]
        public int? Choose { get; set; }

        [BsonElement("from")]
        public From[]? From { get; set; }
    }
}
