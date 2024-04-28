using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class SpellsSubclass
    {
        [BsonElement("prerequisites")]
        public PrerequisiteItemSubclass[]? Name { get; set; }

        [BsonElement("spell")]
        public From? Spell { get; set; }
    }
}
