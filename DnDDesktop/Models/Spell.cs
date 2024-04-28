using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Spell
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("area_of_effect")]
        public AreaOfEffect? AreaOfEffect { get; set; }

        [BsonElement("attack_type")]
        public string AttackType { get; set; } = String.Empty;

        [BsonElement("casting_time")]
        public string CastingTime { get; set;} = String.Empty;

        [BsonElement("classes")]
        public From[]? Classes { get; set;}

        [BsonElement("components")]
        public string[]? Components { get; set;}

        [BsonElement("concentration")]
        public bool Concentration { get; set; }

        [BsonElement("damage")]
        public DamageSpell? DamageSpell { get; set; }

        [BsonElement("dc")]
        public DCSpell? DC { get; set;}

        [BsonElement("desc")]
        public string[]? Description { get; set; }

        [BsonElement("duration")]
        public string Duration { get; set; } = String.Empty;

        [BsonElement("heal_at_slot_level")]
        public HealAtSlotLevelSpell? HealAtSlotLevel { get; set; }

        [BsonElement("higher_level")]
        public string[]? HigherLevel { get; set; }

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("level")]
        public int? Level { get; set; }

        [BsonElement("material")]
        public string Material { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("range")]
        public string Range { get; set; } = String.Empty;

        [BsonElement("ritual")]
        public bool? Ritual { get; set; }

        [BsonElement("school")]
        public From? From { get; set; }

        [BsonElement("subclasses")]
        public From[]? Subclasses { get; set; }
    }
}
