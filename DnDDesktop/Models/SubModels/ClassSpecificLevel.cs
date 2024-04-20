using DNDAPI.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DNDAPI.Models.SubModels
{
    [BsonNoId]
    public class ClassSpecificLevel
    {
        [BsonElement("action_surges")]
        public int? ActionSurge { get; set; }

        [BsonElement("arcane_recovery_levels")]
        public int? ArcaneRecoveryLevel { get; set; }

        [BsonElement("aura_range")]
        public int? AuraRange { get; set;}

        [BsonElement("bardic_inspiration_die")]
        public int? BardicInspirationDie { get; set; }

        [BsonElement("brutal_critical_dice")]
        public int? BrutalCriticalDie { get; set; }

        [BsonElement("channel_divinity_charges")]
        public int? ChannelDivinityCharges { get; set; }

        [BsonElement("creating_spell_slots")]
        public CreatingSpellSlotsLevel[]? CreatingSpellSlots { get; set; }

        [BsonElement("destroy_undead_cr")]
        public double? DestroyUndeadCr { get; set; }

        [BsonElement("extra_attacks")]
        public int? ExtraAttacks { get; set; }

        [BsonElement("favored_enemies")]
        public int? FavoredEnemies { get; set;}

        [BsonElement("favored_terrain")]
        public int? FavoredTerrain { get; set; }

        [BsonElement("indomitable_uses")]
        public int? IndomitableUses { get; set; }

        [BsonElement("invocations_known")]
        public int? InvocationsKnown { get; set; }

        [BsonElement("ki_points")]
        public int? KiPoints { get; set; }

        [BsonElement("magical_secrets_max_5")]
        public int? MagicSecretsMax5 { get; set; }

        [BsonElement("magical_secrets_max_7")]
        public int? MagicSecretsMax7 { get; set; }

        [BsonElement("magical_secrets_max_9")]
        public int? MagicSecretsMax9 { get; set; }

        [BsonElement("martial_arts")]
        public DiceCountValueCommon? MartialArts { get; set; }

        [BsonElement("metamagic_known")]
        public int? MetamagicKnown { get; set; }

        [BsonElement("mystic_arcanum_level_6")]
        public int? MysticArcanumLevel6 { get; set; }

        [BsonElement("mystic_arcanum_level_7")]
        public int? MysticArcanumLevel7 { get; set; }

        [BsonElement("mystic_arcanum_level_8")]
        public int? MysticArcanumLevel8 { get; set; }

        [BsonElement("mystic_arcanum_level_9")]
        public int? MysticArcanumLevel9 { get; set; }

        [BsonElement("rage_count")]
        public int? RageCount { get; set; }

        [BsonElement("rage_damage_bonus")]
        public int? RageDamaageBonus { get; set; }

        [BsonElement("sneak_attack")]
        public DiceCountValueCommon? SneakAttack { get; set; }

        [BsonElement("song_of_rest_die")]
        public int? SongOfRestDie { get; set; }

        [BsonElement("sorcery_points")]
        public int? SorceryPoints { get; set; }

        [BsonElement("unarmored_movement")]
        public int? UnarmoredMovement { get; set; }

        [BsonElement("wild_shape_fly")]
        public bool? WildShapeFly { get; set; }

        [BsonElement("wild_shape_max_cr")]
        public double? WildShapeMaxCr { get; set; }

        [BsonElement("wild_shape_swim")]
        public bool? WildShapeSwim { get; set; }
    }
}
