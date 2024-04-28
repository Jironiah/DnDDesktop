using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class OptionRace
    {
        [BsonElement("options")]
        public OptionsRace? Options { get; set; }
    }
}
