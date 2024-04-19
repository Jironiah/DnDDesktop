using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class InvocationFeature
    {
        [BsonElement("name")]
        public string[]? Name { get; set; }
    }
}
