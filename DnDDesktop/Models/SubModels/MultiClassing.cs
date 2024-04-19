using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class MultiClassing
    {
        [BsonElement("prerequisites")]
        public Prerequisites[]? Prerequisites { get; set; }

        [BsonElement("proficiencies")]
        public From[]? Proficiencies { get; set; }
    }
}
