using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Feature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("class")]
        public From? Class { get; set; }

        [BsonElement("desc")]
        public string[]? Description { get; set; }

        [BsonElement("feature_specific")]
        public FeatureSpecific? FeatureSpecific { get; set; }

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("level")]
        public int? level { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("parent")]
        public From? Parent { get; set; }

        [BsonElement("prerequisites")]
        public PrerequisiteFeature[]? PrerequisiteFeatures { get; set; }

        [BsonElement("subclass")]
        public From? Subclass { get; set; }
    }
}
