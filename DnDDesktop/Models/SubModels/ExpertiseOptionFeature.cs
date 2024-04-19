using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class ExpertiseOptionFeature
    {
        [BsonElement("choose")]
        public double? Choose { get; set; }

        [BsonElement("from")]
        public ExpertiseOptionFromFeature[]? From { get; set; }
    }
}
