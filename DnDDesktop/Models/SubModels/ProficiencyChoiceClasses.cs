using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class ProficiencyChoiceClasses
    {
        [BsonElement("choose")]
        public int? Choose { get; set; }

        [BsonElement("desc")]
        public string Description { get; set; }

        [BsonElement("from")]
        public From[]? From { get; set; }
    }
}
