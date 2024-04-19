using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class ChoiceFeature
    {
        [BsonElement("choose")]
        public int? Choose { get; set; }

        [BsonElement("from")]
        public From[]? Froms { get; set; }
    }
}
