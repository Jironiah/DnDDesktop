using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class StartingEquipmentOptionClasses
    {
        [BsonElement("desc")]
        public string Description { get; set; } = String.Empty;

        [BsonElement("choose")]
        public int? Choose { get; set; }

        [BsonElement("from")]
        public List<OptionItemClasses[]>? From { get; set; }
    }
}
