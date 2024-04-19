using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class ExpertiseOptionFromFeature
    {
        [BsonElement("choice")]
        public ChoiceFeature? Choice { get; set; }

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("items")]
        public ItemsFeature? Items { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
    }
}
