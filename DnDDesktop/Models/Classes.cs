using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models
{
    public class Classes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("hit_die")]
        public int? HitDie { get; set; }

        [BsonElement("index")]
        public string Index { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("multi_classing")]
        public MultiClassing? MultiClassing { get; set; }

        [BsonElement("proficiencies")]
        public From[]? Proficiencies { get; set; }

        [BsonElement("proficiency_choices")]
        public ProficiencyChoiceClasses[]? ProficienciesChoices { get; set; }

        [BsonElement("saving_throws")]
        public From[]? SavingThrows { get; set; }

        [BsonElement("spellcasting")]
        public SpellcastingClass? Spellcasting { get; set;}

        [BsonElement("starting_equipment")]
        public StartingEquipmentClasses[]? StartingEquipment { get; set; }

        [BsonElement("starting_equipment_options")]
        public StartingEquipmentOptionClasses[]? StartingEquipmentOption { get; set; }

        [BsonElement("subclasses")]
        public From[]? Subclasses { get; set; }
    }
}
