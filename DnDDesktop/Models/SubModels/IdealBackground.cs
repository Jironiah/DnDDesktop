using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class IdealBackground
    {
        [BsonElement("alignments")]
        public AlignmentsBackground? Alignments { get; set; }

        [BsonElement("desc")]
        public string Description { get; set; } = String.Empty;
    }
}
