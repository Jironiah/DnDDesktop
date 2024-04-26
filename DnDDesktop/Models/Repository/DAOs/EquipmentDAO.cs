using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDesktop.Models.Repository.DAOs
{
    public class EquipmentDAO
    {
        public string Id { get; set; }
        public string index { get; set; }
        public string name { get; set; }
        public string? armorCategory { get; set; }
        public string? capacity { get; set; }
        public string? categoryRange { get; set; }
        public string? contentsName { get; set; }
        public double? costQuantity { get; set; }
        public string? equipmentCategoryName { get; set; }
        public string? gearCategoryName { get; set; }
        public int? rangeLong { get; set; }
        public int? rangeNormal { get; set; }
        public bool? stealthDisadvantage { get; set; }
        public int? strMinimum { get; set; }
        public int? throwRangeLong { get; set; }
        public int? throwRangeNormal { get; set; }
        public string? toolCategory { get; set; }
        public string? twoHandedDamageDice { get; set; }
        public string? twoHandedDamageTypeName { get; set; }
        public string? vehicleCategory { get; set; }
        public string? weaponCategory { get; set; }
        public double? weight { get; set; }
        public EquipmentDAO()
        {

        }

        public EquipmentDAO(Equipment equipment)
        {
            this.Id = equipment.Id;
            this.index = equipment.Index;
            this.name = equipment.Name;
            this.armorCategory = equipment.ArmorCategory;
            this.capacity = equipment.Capacity;
            this.categoryRange = equipment?.CategoryRange;
            this.contentsName = equipment?.Contents?.Item?.Select(a => a.Name).FirstOrDefault();
            this.costQuantity = equipment?.Cost?.Quantity;
            this.equipmentCategoryName = equipment?.EquipmentCategory?.Name;
            this.gearCategoryName = equipment?.GearCategory?.Name;
            this.rangeLong = equipment?.Range?.Long;
            this.rangeNormal = equipment?.Range?.Normal;
            this.stealthDisadvantage = equipment?.StealthDisadvantage;
            this.strMinimum = equipment?.StrengthMinimum;
            this.throwRangeLong = equipment?.ThrowRange?.Long;
            this.throwRangeNormal = equipment?.ThrowRange?.Normal;
            this.toolCategory = equipment?.ToolCategory;
            this.twoHandedDamageDice = equipment?.TwoHandedDamage?.DamageDice;
            this.twoHandedDamageTypeName = equipment?.TwoHandedDamage?.DamageType?.Name;
            this.vehicleCategory = equipment?.VehicleCategory;
            this.weaponCategory = equipment?.WeaponCategory;
            this.weight = equipment?.Weight;
        }

    }
}
