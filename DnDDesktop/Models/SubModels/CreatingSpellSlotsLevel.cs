using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class CreatingSpellSlotsLevel
    {
        [BsonElement("sorcery_point_cost")]
        public int? SorceryPointCost { get; set; }

        [BsonElement("spell_slot_level")]
        public int? SpellSlotLevel { get; set; }
    }
}
