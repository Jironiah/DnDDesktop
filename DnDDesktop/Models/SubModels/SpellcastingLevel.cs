using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class SpellcastingLevel
    {
        [BsonElement("cantrips_known")]
        public int? CantripsKnown { get; set; }

        [BsonElement("spell_slots_level_1")]
        public int? SpellSlotsLevel1 { get; set; }

        [BsonElement("spell_slots_level_2")]
        public int? SpellSlotsLevel2 { get; set; }

        [BsonElement("spell_slots_level_3")]
        public int? SpellSlotsLevel3 { get; set; }

        [BsonElement("spell_slots_level_4")]
        public int? SpellSlotsLevel4 { get; set; }

        [BsonElement("spell_slots_level_5")]
        public int? SpellSlotsLevel5 { get; set; }

        [BsonElement("spell_slots_level_6")]
        public int? SpellSlotsLevel6 { get; set; }

        [BsonElement("spell_slots_level_7")]
        public int? SpellSlotsLevel7 { get; set; }

        [BsonElement("spell_slots_level_8")]
        public int? SpellSlotsLevel8 { get; set; }

        [BsonElement("spell_slots_level_9")]
        public int? SpellSlotsLevel9 { get; set; }

        [BsonElement("spells_known")]
        public int? SpellsKnown { get; set; }
    }
}
