namespace DnDDesktop.Models
{
    public interface IDndStoreDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName {  get; set; }
        string DndDamageTypeCollectionName { get; set; }
        string DndAlignmentCollectionName { get; set; }
        string DndWeaponPropertyCollectionName { get; set; }
        string DndConditionsCollectionName { get; set; }
        string DndLanguageCollectionName { get; set; }
        string DndSkillCollectionName { get; set; }
        string DndAbilityScoreCollectionName { get; set; }
        string DndBackgroundCollectionName { get; set; }
        string DndClassCollectionName { get; set; }
        string DndEquipmentCollectionName { get; set; }
        string DndEquipmentCategoriesCollectionName { get; set; }
        string DndFeatsCollectionName { get; set; }
        string DndFeaturesCollectionName { get; set; }
    }
}
