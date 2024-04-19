using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class FeatureSpecific
    {
        [BsonElement("expertise_options")]
        public ExpertiseOptionFeature? ExpertiseOption { get; set; }

        [BsonElement("invocations")]
        public InvocationFeature? Invocations { get; set; }

        [BsonElement("subfeature_options")]
        public SubFeatureOptions? SubfeatureOptions { get; set; }
    }
}
