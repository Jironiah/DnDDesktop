using DnDDesktop.Models;
using DnDDesktop.Models.Commons;
using DnDDesktop.Models.Repository;
using DnDDesktop.Models.SubModels;
using Extensions = DnDDesktop.Models.Extensions;
using DnDDesktop.Models.Repository.DAOs;
using System.Diagnostics;


namespace DnDDesktop.Controllers
{
    public class Controlador
    {
        Form1 f = new Form1();

        //Repositories
        AbilityScoreRepository abilityScoreRepository = new AbilityScoreRepository();
        AlignmentsRepository alignmentsRepository = new AlignmentsRepository();
        WeaponPropertiesRepository weaponPropertiesRepository = new WeaponPropertiesRepository();
        ClassesRepository classesRepository = new ClassesRepository();
        BackgroundsRepository backgroundsRepository = new BackgroundsRepository();
        ConditionsRepository conditionsRepository = new ConditionsRepository();
        DamageTypeRepository DamageTypeRepository = new DamageTypeRepository();
        EquipmentRepository EquipmentRepository = new EquipmentRepository();
        EquipmentCategoriesRepository EquipmentCategoriesRepository = new EquipmentCategoriesRepository();
        FeatRepository FeatsRepository = new FeatRepository();
        FeaturesRepository FeaturesRepository = new FeaturesRepository();
        LanguageRepository LanguageRepository = new LanguageRepository();
        LevelRepository LevelRepository = new LevelRepository();
        MagicItemsRepository MagicItemsRepository = new MagicItemsRepository();
        MagicSchoolRepository MagicSchoolRepository = new MagicSchoolRepository();
        ProficiencyRepository ProficiencyRepository = new ProficiencyRepository();
        RacesRepository RacesRepository = new RacesRepository();

        //Listas

        //AbilityScores
        List<From> listaAbilityScoreSkills = new List<From>();
        List<AbilityScore> abilityScores = new List<AbilityScore>();

        //Alignments
        List<Alignments> alignments = new List<Alignments>();

        //WeaponProperties
        List<WeaponProperty> weapons = new List<WeaponProperty>();

        //Classes
        List<Classes> classes = new List<Classes>();

        //Backgrounds
        List<Background> backgrounds = new List<Background>();

        //Conditions
        List<Conditions> conditions = new List<Conditions>();

        //DamageType
        List<DamageType> damageTypes = new List<DamageType>();

        //Equipment
        List<Equipment> equipments = new List<Equipment>();

        //EquipmentCategories
        List<EquipmentCategory> equipmentCategories = new List<EquipmentCategory>();

        //Feats
        List<Feats> feats = new List<Feats>();

        //Feature
        List<Feature> features = new List<Feature>();

        //Language
        List<Language> languages = new List<Language>();

        //Level
        List<Level> levels = new List<Level>();

        //MagicItem
        List<MagicItem> magicItems = new List<MagicItem>();

        //MagicSchool
        List<MagicSchool> magicSchools = new List<MagicSchool>();

        //Proficiency
        List<Proficiency> proficiencies = new List<Proficiency>();

        //Races
        List<Race> races = new List<Race>();

        public Controlador()
        {
            LoadData();
            InitListeners();
            Application.Run(f);
        }

        private void LoadData()
        {
            LoadDataAbilityScore();
            LoadDataAlignments();
            LoadDataWeaponProperties();
            LoadDataClasses();
            LoadDataBackgrounds();
            LoadDataConditions();
            LoadDataDamageType();
            LoadDataEquipment();
            LoadDataEquipmentCategories();
            LoadDataFeat();
            LoadDataFeatures();
            LoadDataLanguages();
            LoadDataLevels();
            LoadDataMagicItems();
            LoadDataMagicSchools();
            LoadDataProficiency();
            LoadDataRace();
        }

        private void LoadDataAbilityScore()
        {
            listaAbilityScoreSkills = abilityScoreRepository.GetAbilityScores().SelectMany(a => a.Skills).ToList();
            f.cbSkillsAbilityScore.DataSource = listaAbilityScoreSkills;
            f.cbSkillsAbilityScore.DisplayMember = "Name";
            abilityScores = abilityScoreRepository.GetAbilityScores();
            f.dgvAbilityScore.DataSource = abilityScores;
        }
        private void LoadDataAlignments()
        {
            alignments = alignmentsRepository.GetAlignments();
            f.dgvAlignments.DataSource = alignments;
        }
        private void LoadDataWeaponProperties()
        {
            weapons = weaponPropertiesRepository.GetWeaponProperties();
            f.dgvWeaponProperties.DataSource = weapons;
        }
        private void LoadDataClasses()
        {
            classes = classesRepository.GetClasses();
            f.dgvClasses.DataSource = classes;
            //listaclassesMultiClassings = classesRepository.GetClasses().Select(a => a.MultiClassing).ToList();
            //listaclassesProficiencies = classesRepository.GetClasses().SelectMany(a => a.Proficiencies).ToList();
            //listaclassesProficiencyChoice = classesRepository.GetClasses().SelectMany(a => a.ProficienciesChoices).ToList();
            //listaclassesSavingThrows = classesRepository.GetClasses().SelectMany(a => a.SavingThrows).ToList();
            //listaclassesSpellcasting = classesRepository.GetClasses().Select(a => a.Spellcasting).ToList();
            //listaclassesStartingEquipment = classesRepository.GetClasses().SelectMany(a => a.StartingEquipment).ToList();
            //listaclassesStartingEquipmentOption = classesRepository.GetClasses().SelectMany(a => a.StartingEquipmentOption).ToList();
            //listaclassesSubclasses = classesRepository.GetClasses().SelectMany(a => a.Subclasses).ToList();
        }
        private void LoadDataBackgrounds()
        {
            backgrounds = backgroundsRepository.GetBackgrounds();
            f.dgvBackgrounds.DataSource = backgrounds.Select(a => new BackgroundsDAO(a)).ToList();
            f.dgvBackgrounds.Columns["ideals"].Visible = false;
            f.dgvBackgrounds.Columns["startingEquipmentEquipment"].Visible = false;
            f.dgvBackgrounds.Columns["startingEquipmentOptionsFrom"].Visible = false;
            f.dgvBackgrounds.Columns["startingEquipmentOptionsType"].Visible = false;
        }
        private void LoadDataConditions()
        {
            conditions = conditionsRepository.GetConditions();
            f.dgvConditions.DataSource = conditions;
        }
        private void LoadDataDamageType()
        {
            damageTypes = DamageTypeRepository.GetDamageTypes();
            f.dgvDamageType.DataSource = damageTypes;
        }
        private void LoadDataEquipment()
        {
            equipments = EquipmentRepository.GetEquipments();
            f.dgvEquipment.DataSource = equipments.Select(a => new EquipmentDAO(a)).ToList();
        }
        private void LoadDataEquipmentCategories()
        {
            equipmentCategories = EquipmentCategoriesRepository.GetEquipmentCategories();
            f.dgvEquipmentCategories.DataSource = equipmentCategories;
        }
        private void LoadDataFeat()
        {
            feats = FeatsRepository.GetFeats();
            f.dgvFeats.DataSource = feats;
        }
        private void LoadDataFeatures()
        {
            features = FeaturesRepository.GetFeatures();
            f.dgvFeatures.DataSource = features.Select(a => new FeaturesDAO(a)).ToList();
        }
        private void LoadDataLanguages()
        {
            languages = LanguageRepository.GetLanguages();
            f.dgvLanguages.DataSource = languages;
        }
        private void LoadDataLevels()
        {
            levels = LevelRepository.GetLevels();
            f.dgvLevels.DataSource = levels;
            f.dgvLevels.Columns["Class"].Visible = false;
            f.dgvLevels.Columns["ClassSpecific"].Visible = false;
            f.dgvLevels.Columns["Spellcasting"].Visible = false;
            f.dgvLevels.Columns["Subclass"].Visible = false;
            f.dgvLevels.Columns["Subcategories"].Visible = false;
            f.dgvLevels.Columns["Index"].DisplayIndex = 1;
            //Tal vez cargar todos los dgv
            f.cbFeaturesIndexLevels.DataSource = LevelRepository.GetLevels()?.SelectMany(a => a.Features)?.Select(a => a.Index.FirstOrDefault()).ToList();
            f.cbFeaturesNameLevels.DataSource = LevelRepository.GetLevels()?.SelectMany(a => a.Features)?.Select(a => a.Name.FirstOrDefault()).ToList();
            f.dgvClassEspecificLevels.DataSource = LevelRepository.GetLevels()?.Select(a => a.ClassSpecific).ToList();
            f.dgvClassSpecificMartialArtsLevels.DataSource = LevelRepository.GetLevels()?.Select(a => a.ClassSpecific?.MartialArts)?.ToList();
            f.dgvClassSpecificSneakAttackLevels.DataSource = LevelRepository.GetLevels()?.Select(a => a.ClassSpecific?.SneakAttack)?.ToList();
            f.dgvClassSpecificCreatingSpellSlotsLevels.DataSource = LevelRepository.GetLevels()?.Select(a => a.ClassSpecific?.CreatingSpellSlots?.FirstOrDefault()).ToList();
            f.dgvSpellcastingLevels.DataSource = LevelRepository.GetLevels()?.Select(a => a.Spellcasting).ToList();
            f.dgvSubcategoriesLevels.DataSource = LevelRepository.GetLevels()?.Select(a => a.Subcategories).ToList();
        }
        private void LoadDataMagicItems()
        {
            magicItems = MagicItemsRepository.GetMagicItems();
            f.dgvMagicItems.DataSource = magicItems;
            f.dgvMagicItems.Columns["EquipmentCategory"].Visible = false;
            f.dgvMagicItems.Columns["Rarity"].Visible = false;
            f.cbVariantsMagicItems.DataSource = magicItems?.SelectMany(a => a.Variants).ToList();
            f.cbVariantsMagicItems.DisplayMember = "Name";
            f.cbRarityMagicItems.DataSource = magicItems?.Select(a => a.Rarity).ToList();
            f.cbRarityMagicItems.DisplayMember = "Name";
        }
        private void LoadDataMagicSchools()
        {
            magicSchools = MagicSchoolRepository.GetMagicSchools();
            f.dgvMagicSchools.DataSource = magicSchools;
        }
        private void LoadDataProficiency()
        {
            proficiencies = ProficiencyRepository.GetProficiencies();
            f.dgvProficiency.DataSource = proficiencies;
            f.cbClassesProficiency.DataSource = proficiencies?.SelectMany(a => a.Classes)?.ToList();
            f.cbClassesProficiency.DisplayMember = "Name";
            f.cbRacesProficiency.DataSource = proficiencies?.SelectMany(a => a.Races)?.ToList();
            f.cbRacesProficiency.DisplayMember = "Name";
            f.cbReferenceProficiency.DataSource = proficiencies?.Select(a => a.Reference)?.ToList();
            f.cbReferenceProficiency.DisplayMember = "Name";
        }
        private void LoadDataRace()
        {
            races = RacesRepository.GetRaces();
            f.dgvRaces.DataSource = races;
            f.dgvRaces.Columns["LanguageOptions"].Visible = false;
            f.dgvRaces.Columns["StartingProficienciesOptions"].Visible = false;

            f.cbLanguagesRaces.DataSource = races?.SelectMany(a => a.Languages)?.ToList();
            f.cbLanguagesRaces.DisplayMember = "Name";
            f.cbStartingProficienciesRaces.DataSource = races?.SelectMany(a => a.StartingProficiencies)?.ToList();
            f.cbStartingProficienciesRaces.DisplayMember = "Name";
            f.cbSubracesRaces.DataSource = races?.SelectMany(a => a.Subraces)?.ToList();
            f.cbSubracesRaces.DisplayMember = "Name";
            f.cbTraitsRaces.DataSource = races?.SelectMany(a => a.Traits).ToList();
            f.cbTraitsRaces.DisplayMember = "Name";

            f.dgvAbilityBonusOptionRace.DataSource = races?.Select(a => a.AbilityBonusOptions)?.ToList();
            f.dgvAbilityBonusOptionFromRace.DataSource = races?.Select(a => a.AbilityBonusOptions?.From?.FirstOrDefault())?.ToList();
            f.dgvAbilityBonusOptionFromRace.Columns["AbilityScore"].Visible = false;
            f.dgvAbilityBonusOptionsAbilityScoreRace.DataSource = races?.Select(a => a.AbilityBonusOptions?.From?.Select(a => a.AbilityScore).FirstOrDefault())?.ToList();
            f.dgvAbilityBonusRace.DataSource = races?.Select(a => a.AbilityBonus?.FirstOrDefault())?.ToList();
            f.dgvAbilityBonusRace.Columns["AbilityScore"].Visible = false;
            f.cbAbilityBonusAbilityScoreRace.DataSource = races?.FirstOrDefault()?.AbilityBonus?.Select(a => a.AbilityScore).ToList();
            f.cbAbilityBonusAbilityScoreRace.DisplayMember = "Name";
            f.dgvLanguageOptionsRace.DataSource = races?.Select(a => a.LanguageOptions).ToList();
            f.dgvLanguageOptionsFromRace.DataSource = races?.Select(a=>a.LanguageOptions?.From?.FirstOrDefault())?.ToList();
            f.dgvStartingProficienciesOptionsRace.DataSource = races?.Select(a=>a.StartingProficienciesOptions).ToList();
            f.cbStartingProficienciesOptionsFromRace.DataSource = races?.FirstOrDefault()?.StartingProficienciesOptions?.From;
            f.cbStartingProficienciesOptionsFromRace.DisplayMember = "Name";

        }
        private void InitListeners()
        {
            //AbilityScore
            f.btInsertarAbilityScore.Click += BtInsertarAbilityScore_Click;
            f.btInsertarAbilityScore.MouseUp += btInsertarAbilityScore_MouseUp;
            f.btBuscarAbilityScore.Click += BtBuscarAbilityScore_Click;
            f.btEliminarAbilityScore.Click += BtEliminarAbilityScore_Click;
            f.tbModificarAbilityScore.Click += BtModificarAbilityScore_Click;
            f.dgvAbilityScore.SelectionChanged += DgvAbilityScore_SelectionChanged;
            //Alignments
            f.btInsertarAlignments.Click += BtInsertarAlignments_Click;
            f.btBuscarAlignments.Click += BtBuscarAlignments_Click;
            f.btEliminarAlignments.Click += BtEliminarAlignments_Click;
            f.btModificarAlignments.Click += BtModificarAlignment_Click;
            f.dgvAlignments.SelectionChanged += DgvAlignments_SelectionChanged;
            ////WeaponProperties
            f.btInsertarWeaponProperties.Click += BtInsertarWeaponProperties_Click;
            f.btBuscarWeaponProperties.Click += BtBuscarWeaponProperties_Click;
            f.btEliminarWeaponProperties.Click += BtEliminarWeaponProperties_Click;
            f.btModificarWeaponProperties.Click += BtModificarWeaponProperties_Click;
            f.dgvWeaponProperties.SelectionChanged += DgvWeaponProperties_SelectionChanged;
            //Classes
            f.btInsertarClasses.Click += BtInsertarClasses_Click;
            //f.btInsertarClasses.MouseUp += BtInsertarClasses_MouseUp;
            f.btBuscarClasses.Click += BtBuscarClasses_Click;
            f.btEliminarClasses.Click += BtEliminarClasses_Click;
            f.btModificarClasses.Click += BtModificarClasses_Click;
            f.dgvClasses.SelectionChanged += DgvClasses_SelectionChanged;
            //Backgrounds
            f.btInsertarBackgrounds.Click += BtInsertarBackgrounds_Click;
            f.btInsertarBackgrounds.MouseUp += BtInsertarBackgrounds_MouseUp;
            f.btBuscarBackgrounds.Click += BtBuscarBackgrounds_Click;
            f.btEliminarBackgrounds.Click += BtEliminarBackgrounds_Click;
            f.btModificarBackgrounds.Click += BtModificarBackgrounds_Click;
            f.dgvBackgrounds.SelectionChanged += DgvBackgrounds_SelectionChanged;
            //Conditions
            f.dgvConditions.SelectionChanged += DgvConditions_SelectionChanged;
            f.btInsertarConditions.Click += BtInsertarConditions_Click;
            f.btBuscarConditions.Click += BtBuscarConditions_Click;
            f.btEliminarConditions.Click += BtEliminarConditions_Click;
            f.btModificarConditions.Click += BtModificarConditions_Click;
            //DamageType
            f.btBuscarDamageType.Click += BtBuscarDamageType_Click;
            f.btInsertarDamageType.Click += BtInsertarDamageType_Click;
            f.btModificarDamageType.Click += BtModificarDamageType_Click;
            f.btEliminarDamageType.Click += BtEliminarDamageType_Click;
            f.dgvDamageType.SelectionChanged += DgvDamageType_SelectionChanged;
            //Equipment
            f.dgvEquipment.SelectionChanged += DgvEquipment_SelectionChanged;
            f.btBuscarEquipment.Click += BtBuscarEquipment_Click;
            f.btEliminarEquipment.Click += BtEliminarEquipment_Click;
            f.btInsertarEquipment.Click += BtInsertarEquipment_Click;
            f.btModificarEquipment.Click += BtModificarEquipment_Click;
            //EquipmentCategories
            f.dgvEquipmentCategories.SelectionChanged += DgvEquipmentCategories_SelectionChanged;
            f.btBuscarEquipmentCategories.Click += BtBuscarEquipmentCategories_Click;
            f.btEliminarEquipmentCategories.Click += BtEliminarEquipmentCategories_Click;
            f.btInsertarEquipmentCategories.Click += BtInsertarEquipmentCategories_Click;
            f.btInsertarEquipmentCategories.MouseUp += BtInsertarEquipmentCategories_MouseUp;
            f.btModificarEquipmentCategories.Click += BtModificarEquipmentCategories_Click;
            //Feat
            f.dgvFeats.SelectionChanged += DgvFeats_SelectionChanged;
            f.btBuscarFeats.Click += BtBuscarFeats_Click;
            f.btEliminarFeats.Click += BtEliminarFeats_Click;
            f.btInsertarFeats.Click += BtInsertarFeats_Click;
            f.btInsertarFeats.MouseUp += BtInsertarFeats_MouseUp;
            f.btModificarFeats.Click += BtModificarFeats_Click;
            //Features
            f.dgvFeatures.SelectionChanged += DgvFeatures_SelectionChanged;
            f.btBuscarFeatures.Click += BtBuscarFeatures_Click;
            f.btInsertarFeatures.Click += BtInsertarFeatures_Click;
            f.btInsertarFeatures.MouseUp += BtInsertarFeatures_MouseUp;
            f.btEliminarFeatures.Click += BtEliminarFeatures_Click;
            f.btModificarFeatures.Click += BtModificarFeatures_Click;
            //Languages
            f.dgvLanguages.SelectionChanged += DgvLanguages_SelectionChanged;
            f.btBuscarLanguages.Click += BtBuscarLanguages_Click;
            f.btInsertarLanguages.Click += BtInsertarLanguages_Click;
            f.btEliminarLanguages.Click += BtEliminarLanguages_Click;
            f.btModificarLanguages.Click += BtModificarLanguages_Click;
            //Levels
            f.dgvLevels.SelectionChanged += DgvLevels_SelectionChanged;
            f.btModificarLevels.Click += BtModificarLevels_Click;
            f.btEliminarLevels.Click += BtEliminarLevels_Click;
            f.btInsertarLevels.Click += BtInsertarLevels_Click;
            f.btBuscarLevels.Click += BtBuscarLevels_Click;
            //MagicItem
            f.dgvMagicItems.SelectionChanged += DgvMagicItems_SelectionChanged;
            f.btBuscarMagicItems.Click += BtBuscarMagicItems_Click;
            f.btInsertarMagicItems.Click += BtInsertarMagicItems_Click;
            f.btEliminarMagicItems.Click += BtEliminarMagicItems_Click;
            f.btModificarMagicItems.Click += BtModificarMagicItems_Click;
            //MagicSchools
            f.dgvMagicSchools.SelectionChanged += DgvMagicSchools_SelectionChanged;
            f.btBuscarMagicSchools.Click += BtBuscarMagicSchools_Click;
            f.btEliminarMagicSchools.Click += BtEliminarMagicSchools_Click;
            f.btModificarMagicSchools.Click += BtModificarMagicSchools_Click;
            f.btInsertarMagicSchools.Click += BtInsertarMagicSchools_Click;
            //Proficiency
            f.dgvProficiency.SelectionChanged += DgvProficiency_SelectionChanged;
            f.btBuscarProficiency.Click += BtBuscarProficiency_Click;
            f.btInsertarProficiency.Click += BtInsertarProficiency_Click;
            f.btEliminarProficiency.Click += BtEliminarProficiency_Click;
            f.btModificarProficiency.Click += BtModificarProficiency_Click;
        }

        //AbilityScore

        private void DgvAbilityScore_SelectionChanged(object? sender, EventArgs e)
        {
            DataGridViewRow row = f.dgvAbilityScore.CurrentRow;
            if (row != null)
            {
                AbilityScore absc = (AbilityScore)row.DataBoundItem;
                f.tbIndexAbilityScore.Text = absc.Index;
                f.tbNameAbilityScore.Text = absc.Name;
                f.tbFullNameAbilityScore.Text = absc.FullName;
                f.rtbDescriptionAbilityScore.Text = absc.Description.FirstOrDefault();
                f.cbSkillsAbilityScore.DataSource = absc.Skills;
            }
        }
        private void BtInsertarAbilityScore_Click(object? sender, EventArgs e)
        {
            try
            {
                AbilityScore score = new AbilityScore();
                string index = f.tbIndexAbilityScore.Text.ToString();
                string name = f.tbNameAbilityScore.Text.ToString();
                string fullName = f.tbFullNameAbilityScore.Text.ToString();
                string[] description = new string[] { f.rtbDescriptionAbilityScore.Text };

                From selectedSkill = (From)f.cbSkillsAbilityScore.SelectedItem;

                if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(fullName))
                {
                    score.Index = index;
                    score.Name = name;
                    score.FullName = fullName;
                    score.Description = description;
                    if (selectedSkill != null)
                    {
                        score.Skills = new From[] { selectedSkill };
                    }
                    abilityScoreRepository.CreateAbilityScore(score);
                    MessageBox.Show("AbilityScore introducido");
                }
                else
                {
                    MessageBox.Show("No puedes dejar espacios vacíos");
                }
                LoadDataAbilityScore();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btInsertarAbilityScore_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                try
                {
                    string index = f.tbIndexAbilityScore.Text.ToString();
                    string name = f.tbNameAbilityScore.Text.ToString();
                    string fullName = f.tbFullNameAbilityScore.Text.ToString();
                    string[] description = new string[] { f.rtbDescriptionAbilityScore.Text };

                    From emptySkill = new From
                    {
                        Index = string.Empty,
                        Name = string.Empty
                    };

                    if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(fullName))
                    {
                        abilityScoreRepository.CreateAbilityScore(new AbilityScore
                        {
                            Index = index,
                            Name = name,
                            FullName = fullName,
                            Description = description,
                            Skills = new From[] { emptySkill }
                        });

                        listaAbilityScoreSkills = abilityScoreRepository.GetAbilityScores().SelectMany(a => a.Skills).ToList();
                        listaAbilityScoreSkills.Insert(0, emptySkill);

                        f.cbSkillsAbilityScore.DataSource = listaAbilityScoreSkills;
                        MessageBox.Show("AbilityScore sin skills introducido");
                    }
                    LoadDataAbilityScore();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void BtBuscarAbilityScore_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarAbilityScore.Text))
                {
                    string idBuscar = abilityScores.Where(a => a.Index.Equals(f.tbFiltrarAbilityScore.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        AbilityScore newAbilityScore = abilityScoreRepository.GetAbilityScore(idBuscar.ToString());
                        f.tbIndexAbilityScore.Text = newAbilityScore.Index;
                        f.tbNameAbilityScore.Text = newAbilityScore.Name;
                        f.tbFullNameAbilityScore.Text = newAbilityScore.FullName;
                        f.rtbDescriptionAbilityScore.Text += newAbilityScore.Description.FirstOrDefault();
                        f.cbSkillsAbilityScore.DataSource = newAbilityScore.Skills;
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BtEliminarAbilityScore_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarAbilityScore.Text))
                {
                    string idBuscar = abilityScores.Where(a => a.Index.Equals(f.tbFiltrarAbilityScore.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        abilityScoreRepository.DeleteAbilityScore(idBuscar);
                        MessageBox.Show(f.tbFiltrarAbilityScore.Text.ToString() + " eliminado");
                        LoadDataAbilityScore();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BtModificarAbilityScore_Click(object? sender, EventArgs e)
        {
            try
            {
                string index = f.tbIndexAbilityScore.Text.ToString();
                string name = f.tbNameAbilityScore.Text.ToString();
                string fullName = f.tbFullNameAbilityScore.Text.ToString();
                string[] description = new string[] { f.rtbDescriptionAbilityScore.Text };
                AbilityScore abilityScoreModificar = new AbilityScore();

                if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(fullName))
                {
                    From selectedSkill = (From)f.cbSkillsAbilityScore.SelectedItem;
                    string idBuscar = abilityScores.Where(a => a.Index.Equals(f.tbFiltrarAbilityScore.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        abilityScoreModificar.Id = idBuscar;
                        abilityScoreModificar.Index = index;
                        abilityScoreModificar.Name = name;
                        abilityScoreModificar.FullName = fullName;
                        abilityScoreModificar.Description = description;
                        if (selectedSkill != null)
                        {
                            abilityScoreModificar.Skills = new From[] { selectedSkill };
                        }
                        abilityScoreRepository.UpdateAbilityScore(abilityScoreModificar);
                        MessageBox.Show("Modificado correctamente");
                        LoadDataAbilityScore();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Alignments
        private void BtInsertarAlignments_Click(object? sender, EventArgs e)
        {
            try
            {
                Alignments alignment = new Alignments();
                string index = f.tbIndexAlignments.Text.ToString();
                string name = f.tbNameAlignments.Text.ToString();
                string abbreviation = f.tbAbbreviationAlignments.Text.ToString();
                string description = f.rtbDescriptionAlignments.Text;
                if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(abbreviation))
                {
                    alignment.Index = index;
                    alignment.Name = name;
                    alignment.Abbreviation = abbreviation;
                    alignment.Description = description;

                    alignmentsRepository.CreateAlignment(alignment);
                    MessageBox.Show("Alignments introducido");
                    LoadDataAlignments();
                }
                else
                {
                    MessageBox.Show("No puedes dejar espacios vacíos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void BtBuscarAlignments_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarAlignments.Text))
                {
                    string idBuscar = alignments.Where(a => a.Index.Equals(f.tbFiltrarAlignments.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    //MessageBox.Show(idBuscar);
                    if (idBuscar != null)
                    {
                        Alignments newAlignments = alignmentsRepository.GetAlignment(idBuscar.ToString());
                        f.tbIndexAlignments.Text = newAlignments.Index;
                        f.tbNameAlignments.Text = newAlignments.Name;
                        f.tbAbbreviationAlignments.Text = newAlignments.Abbreviation;
                        f.rtbDescriptionAlignments.Text = newAlignments.Description;
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BtEliminarAlignments_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarAlignments.Text))
                {
                    string idBuscar = alignments.Where(a => a.Index.Equals(f.tbFiltrarAlignments.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        alignmentsRepository.DeleteAlignment(idBuscar);
                        MessageBox.Show(f.tbFiltrarAlignments.Text.ToString() + " eliminado");
                        LoadDataAlignments();
                    }
                    else
                    {
                        MessageBox.Show("Lo que quieres eliminar no puede estar vacío o no existe");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void BtModificarAlignment_Click(object? sender, EventArgs e)
        {
            try
            {
                string index = f.tbIndexAlignments.Text.ToString();
                string name = f.tbNameAlignments.Text.ToString();
                string abbreviation = f.tbAbbreviationAlignments.Text.ToString();
                string description = f.rtbDescriptionAlignments.Text;

                Alignments alignmentModificar = new Alignments();

                if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(abbreviation))
                {
                    string idBuscar = alignments.Where(a => a.Index.Equals(f.tbFiltrarAlignments.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        alignmentModificar.Id = idBuscar;
                        alignmentModificar.Index = index;
                        alignmentModificar.Name = name;
                        alignmentModificar.Abbreviation = abbreviation;
                        alignmentModificar.Description = description;

                        alignmentsRepository.UpdateAlignment(alignmentModificar);
                        MessageBox.Show("Modificado correctamente");
                        LoadDataAlignments();
                    }
                    else
                    {
                        MessageBox.Show("Lo que quieres modificar no puede estar vacío");
                    }
                }
                else
                {
                    MessageBox.Show("No puedes dejar espacíos vacíos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void DgvAlignments_SelectionChanged(object? sender, EventArgs e)
        {
            DataGridViewRow row = f.dgvAlignments.CurrentRow;
            if (row != null)
            {
                Alignments alig = (Alignments)row.DataBoundItem;
                f.tbIndexAlignments.Text = alig.Index;
                f.tbAbbreviationAlignments.Text = alig.Abbreviation;
                f.tbNameAlignments.Text = alig.Name;
                f.rtbDescriptionAlignments.Text = alig.Description;
            }
        }

        //WeaponProperties
        private void DgvWeaponProperties_SelectionChanged(object? sender, EventArgs e)
        {
            DataGridViewRow row = f.dgvWeaponProperties.CurrentRow;
            if (row != null)
            {
                WeaponProperty weapon = (WeaponProperty)row.DataBoundItem;
                f.tbIndexWeaponProperties.Text = weapon.Index;
                f.tbNameWeaponProperties.Text = weapon.Name;
                f.rtbDescriptionWeaponProperties.Text = weapon.Description.FirstOrDefault();
            }
        }
        private void BtInsertarWeaponProperties_Click(object? sender, EventArgs e)
        {
            WeaponProperty weaponProperty = new WeaponProperty();
            string index = f.tbIndexWeaponProperties.Text.ToString();
            string name = f.tbNameWeaponProperties.Text.ToString();
            string[] description = new string[] { f.rtbDescriptionWeaponProperties.Text };

            if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name))
            {
                weaponProperty.Index = index;
                weaponProperty.Name = name;
                weaponProperty.Description = description;
                weaponPropertiesRepository.CreateWeaponProperty(weaponProperty);
                MessageBox.Show("WeaponPropierties introducido");
                LoadDataWeaponProperties();
            }
            else
            {
                MessageBox.Show("No puedes dejar espacios vacíos");
            }
        }
        private void BtBuscarWeaponProperties_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarWeaponProperties.Text))
                {
                    string idBuscar = weapons.Where(a => a.Index.Equals(f.tbFiltrarWeaponProperties.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        WeaponProperty newWeaponProperty = weaponPropertiesRepository.GetWeaponProperty(idBuscar.ToString());
                        f.tbIndexWeaponProperties.Text = newWeaponProperty.Index;
                        f.tbNameWeaponProperties.Text = newWeaponProperty.Name;
                        f.rtbDescriptionWeaponProperties.Text = newWeaponProperty.Description.FirstOrDefault();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void BtEliminarWeaponProperties_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarWeaponProperties.Text))
                {
                    string idBuscar = weapons.Where(a => a.Index.Equals(f.tbFiltrarWeaponProperties.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        weaponPropertiesRepository.DeleteWeaponProperty(idBuscar);
                        MessageBox.Show(f.tbFiltrarWeaponProperties.Text.ToString() + " eliminado");
                        LoadDataWeaponProperties();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void BtModificarWeaponProperties_Click(object? sender, EventArgs e)
        {
            try
            {
                string index = f.tbIndexWeaponProperties.Text.ToString();
                string name = f.tbNameWeaponProperties.Text.ToString();
                string[] description = new string[] { f.rtbDescriptionWeaponProperties.Text };
                WeaponProperty weaponPropertiesModificar = new WeaponProperty();

                if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name))
                {
                    string idBuscar = weapons.Where(a => a.Index.Equals(f.tbFiltrarWeaponProperties.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        weaponPropertiesModificar.Id = idBuscar;
                        weaponPropertiesModificar.Index = index;
                        weaponPropertiesModificar.Name = name;
                        weaponPropertiesModificar.Description = description;
                        weaponPropertiesRepository.UpdateWeaponProperty(weaponPropertiesModificar);
                        MessageBox.Show("Modificado correctamente");
                        LoadDataWeaponProperties();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Classes
        private void DgvClasses_SelectionChanged(object? sender, EventArgs e)
        {
            DataGridViewRow row = f.dgvClasses.CurrentRow;
            if (row != null)
            {
                Classes classes = (Classes)row.DataBoundItem;
                f.dgvClasses.Columns["MultiClassing"].Visible = false;
                f.dgvClasses.Columns["Spellcasting"].Visible = false;
                f.tbIndexClasses.Text = classes.Index;
                f.tbNameClasses.Text = classes.Name;
                f.tbHitDieClasses.Text = classes.HitDie.ToString();
                f.dgvMultiClassingPrerequisitesClasses.DataSource = classes.MultiClassing?.Prerequisites.Select(a => new ClassesMultiClassingDAO(a)).ToList();
                f.dgvMultiClassingProficienciesClasses.DataSource = classes.MultiClassing?.Proficiencies;
                f.cbProficienciesClasses.DataSource = classes.Proficiencies;
                f.dgvProficiencyChoicesClasses.DataSource = classes.ProficienciesChoices;
                f.cbSavingThrowsClasses.DataSource = classes.SavingThrows;
                f.tbSpellCastingAbilityClasses.Text = classes.Spellcasting?.SpellcastingAbility.Name;
                f.dgvSpellCastingInfoNameClasses.DataSource = classes.Spellcasting?.Info.ToList();
                f.rtbSpellCastingInfoDescClasses.Text = classes.Spellcasting?.Info.SelectMany(a => a.Description).FirstOrDefault();
                f.cbStartingEquipmentClasses.DataSource = classes.StartingEquipment.Select(a => a.Equipment).ToList();
                f.dgvStartingEquipmentOptionsChooseDescClasses.DataSource = classes.StartingEquipmentOption;
                f.dgvStartingEquipmentOptionsFromClasses.DataSource = classes.StartingEquipmentOption.SelectMany(a => a.From.SelectMany(a => a).ToList()).ToList();
                f.cbSubclassesClasses.DataSource = classes.Subclasses;

                f.cbProficienciesClasses.DisplayMember = "Name";
                f.cbSavingThrowsClasses.DisplayMember = "Name";
                f.cbStartingEquipmentClasses.DisplayMember = "Name";
                f.cbSubclassesClasses.DisplayMember = "Name";
            }
        }
        private void BtBuscarClasses_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarClasses.Text))
                {
                    string idBuscar = classes.Where(a => a.Index.Equals(f.tbFiltrarClasses.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        Classes newClasses = classesRepository.GetClass(idBuscar);
                        f.dgvClasses.Columns["MultiClassing"].Visible = false;
                        f.dgvClasses.Columns["Spellcasting"].Visible = false;
                        f.tbIndexClasses.Text = newClasses.Index;
                        f.tbNameClasses.Text = newClasses.Name;
                        f.tbHitDieClasses.Text = newClasses.HitDie.ToString();
                        f.dgvMultiClassingPrerequisitesClasses.DataSource = newClasses.MultiClassing?.Prerequisites.Select(a => new ClassesMultiClassingDAO(a)).ToList();
                        f.dgvMultiClassingProficienciesClasses.DataSource = newClasses.MultiClassing?.Proficiencies;
                        f.cbProficienciesClasses.DataSource = newClasses.Proficiencies;
                        f.dgvProficiencyChoicesClasses.DataSource = newClasses.ProficienciesChoices;
                        f.cbSavingThrowsClasses.DataSource = newClasses.SavingThrows;
                        f.tbSpellCastingAbilityClasses.Text = newClasses.Spellcasting?.SpellcastingAbility.Name;
                        f.dgvSpellCastingInfoNameClasses.DataSource = newClasses.Spellcasting?.Info.ToList();
                        f.rtbSpellCastingInfoDescClasses.Text = newClasses.Spellcasting?.Info.SelectMany(a => a.Description).FirstOrDefault();
                        f.cbStartingEquipmentClasses.DataSource = newClasses.StartingEquipment.Select(a => a.Equipment).ToList();
                        f.dgvStartingEquipmentOptionsChooseDescClasses.DataSource = newClasses.StartingEquipmentOption;
                        f.dgvStartingEquipmentOptionsFromClasses.DataSource = newClasses.StartingEquipmentOption.SelectMany(a => a.From.SelectMany(a => a).ToList()).ToList();
                        f.cbSubclassesClasses.DataSource = newClasses.Subclasses;

                        f.cbProficienciesClasses.DisplayMember = "Name";
                        f.cbSavingThrowsClasses.DisplayMember = "Name";
                        f.cbStartingEquipmentClasses.DisplayMember = "Name";
                        f.cbSubclassesClasses.DisplayMember = "Name";
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtInsertarClasses_Click(object? sender, EventArgs e)
        {
            try
            {
                Classes classeInsertar = new Classes();

                // Asignación de valores básicos
                classeInsertar.Index = f.tbIndexClasses.Text;
                classeInsertar.Name = f.tbNameClasses.Text;
                classeInsertar.HitDie = int.Parse(f.tbHitDieClasses.Text);

                // Proficiencies
                From selectedProficiencies = (From)f.cbProficienciesClasses.SelectedItem;
                classeInsertar.Proficiencies = new From[] { selectedProficiencies };

                // SavingThrows
                From selectedSavingThrows = (From)f.cbSavingThrowsClasses.SelectedItem;
                classeInsertar.SavingThrows = new From[] { selectedSavingThrows };

                // StartingEquipment
                From selectedStartingEquipment = (From)f.cbStartingEquipmentClasses.SelectedItem;
                classeInsertar.StartingEquipment = new StartingEquipmentClasses[]
                {
            new StartingEquipmentClasses
            {
                Equipment = selectedStartingEquipment,
                quantity = 1  // Ajusta la cantidad según tu lógica
            }
                };

                // Subclasses
                From selectedSubclasses = (From)f.cbSubclassesClasses.SelectedItem;
                classeInsertar.Subclasses = new From[] { selectedSubclasses };

                // MultiClassingPrerequisites
                ClassesMultiClassingDAO selectedMultiClassingPrerequisite = (ClassesMultiClassingDAO)f.dgvMultiClassingPrerequisitesClasses.CurrentRow.DataBoundItem;
                Prerequisites MultiClassingPrerequisites = new Prerequisites
                {
                    AbilityScore = new From
                    {
                        Index = selectedMultiClassingPrerequisite.index,
                        Name = selectedMultiClassingPrerequisite.name
                    },
                    MinimumScore = selectedMultiClassingPrerequisite.minimum_score
                };
                classeInsertar.MultiClassing = new MultiClassing
                {
                    Prerequisites = new Prerequisites[] { MultiClassingPrerequisites }
                };

                // MultiClassingProficiencies
                From MultiClassingProficiencies = (From)f.dgvMultiClassingProficienciesClasses.CurrentRow.DataBoundItem;
                classeInsertar.MultiClassing.Proficiencies = new From[] { MultiClassingProficiencies };

                // ProficiencyChoices
                ProficiencyChoiceClasses ProficiencyChoices = (ProficiencyChoiceClasses)f.dgvProficiencyChoicesClasses.CurrentRow.DataBoundItem;
                classeInsertar.ProficienciesChoices = new ProficiencyChoiceClasses[] { ProficiencyChoices };

                // SpellCasting
                DataGridViewRow rowSpellCastingInfoName = f.dgvSpellCastingInfoNameClasses.CurrentRow;
                if (rowSpellCastingInfoName != null)
                {
                    InfoClasses SpellCastingInfoName = (InfoClasses)rowSpellCastingInfoName.DataBoundItem;

                    classeInsertar.Spellcasting = new SpellcastingClass
                    {
                        Info = new InfoClasses[] { SpellCastingInfoName },
                        SpellcastingAbility = new From { Name = f.tbSpellCastingAbilityClasses.Text } // Asignación del SpellcastingAbility
                    };
                }


                // StartingEquipmentOptionsChooseDesc
                StartingEquipmentOptionClasses StartingEquipmentOptionsChooseDesc = (StartingEquipmentOptionClasses)f.dgvStartingEquipmentOptionsChooseDescClasses.CurrentRow.DataBoundItem;
                classeInsertar.StartingEquipmentOption = new StartingEquipmentOptionClasses[] { StartingEquipmentOptionsChooseDesc };

                // StartingEquipmentOptionsFrom
                OptionItemClasses StartingEquipmentOptionsFrom = (OptionItemClasses)f.dgvStartingEquipmentOptionsFromClasses.CurrentRow.DataBoundItem;
                classeInsertar.StartingEquipmentOption[0].From = new List<OptionItemClasses[]>
        {
            new OptionItemClasses[] { StartingEquipmentOptionsFrom }
        };

                classesRepository.CreateClass(classeInsertar);
                MessageBox.Show("Classes introducido");
                LoadDataClasses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        //private void BtInsertarClasses_MouseUp(object? sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        Classes classeInsertar = new Classes();

        //        //Rows de todos los datagridviews
        //        DataGridViewRow rowMultiClassingPrerequisitesClasses = f.dgvMultiClassingPrerequisitesClasses.CurrentRow;
        //        DataGridViewRow rowMultiClassingProficienciesClasses = f.dgvMultiClassingProficienciesClasses.CurrentRow;
        //        DataGridViewRow rowProficiencyChoicesClasses = f.dgvProficiencyChoicesClasses.CurrentRow;
        //        DataGridViewRow rowSpellCastingInfoNameClasses = f.dgvSpellCastingInfoNameClasses.CurrentRow;
        //        DataGridViewRow rowStartingEquipmentOptionsChooseDescClasses = f.dgvStartingEquipmentOptionsChooseDescClasses.CurrentRow;
        //        DataGridViewRow rowStartingEquipmentOptionsFromClasses = f.dgvStartingEquipmentOptionsFromClasses.CurrentRow;

        //        //Elementos de todos los combobox
        //        From? selectedProficiencies = (From?)f.cbProficienciesClasses.SelectedItem;
        //        From? selectedSavingThrows = (From?)f.cbSavingThrowsClasses.SelectedItem;
        //        From? selectedStartingEquipment = (From?)f.cbStartingEquipmentClasses.SelectedItem;
        //        From? selectedSubclasses = (From?)f.cbSubclassesClasses.SelectedItem;

        //        if (/*Comprobacion null dgv*/rowMultiClassingPrerequisitesClasses != null && rowMultiClassingProficienciesClasses != null && rowProficiencyChoicesClasses != null &&
        //            rowSpellCastingInfoNameClasses != null && rowStartingEquipmentOptionsChooseDescClasses != null && rowStartingEquipmentOptionsFromClasses != null
        //            /*Comprobacion null cb*/&& selectedProficiencies != null && selectedSavingThrows != null && selectedStartingEquipment != null && selectedSubclasses != null)
        //        {
        //            //DGV
        //            Prerequisites MultiClassingPrerequisites = (Prerequisites)rowMultiClassingPrerequisitesClasses.DataBoundItem;//Esta clase es DTO
        //            From MultiClassingProficiencies = (From)rowMultiClassingProficienciesClasses.DataBoundItem;
        //            ProficiencyChoiceClasses ProficiencyChoices = (ProficiencyChoiceClasses)rowProficiencyChoicesClasses.DataBoundItem;
        //            InfoClasses SpellCastingInfoName = (InfoClasses)rowSpellCastingInfoNameClasses.DataBoundItem;
        //            StartingEquipmentOptionClasses StartingEquipmentOptionsChooseDesc = (StartingEquipmentOptionClasses)rowStartingEquipmentOptionsChooseDescClasses.DataBoundItem;
        //            OptionItemClasses StartingEquipmentOptionsFrom = (OptionItemClasses)rowStartingEquipmentOptionsFromClasses.DataBoundItem;

        //            //Transformacion objetos para insertar

        //            //Proficiencies
        //            List<From> proficiencies = new List<From>();
        //            proficiencies.Add(selectedProficiencies);
        //            classeInsertar.Proficiencies = proficiencies.ToArray();
        //            //SavingThrows
        //            List<From> savingThrows = new List<From>();
        //            savingThrows.Add(selectedSavingThrows);
        //            classeInsertar.SavingThrows = savingThrows.ToArray();
        //            //StartingEquipment
        //            List<StartingEquipmentClasses> startingEquipment = new List<StartingEquipmentClasses>();
        //            StartingEquipmentClasses startingEquipmentClasses = new StartingEquipmentClasses();
        //            startingEquipmentClasses.Equipment = selectedStartingEquipment;
        //            startingEquipment.Add(startingEquipmentClasses);
        //            classeInsertar.StartingEquipment = startingEquipment.ToArray();
        //            //Subclasses
        //            List<From> subclasses = new List<From>();
        //            subclasses.Add(selectedSubclasses);
        //            classeInsertar.Subclasses = subclasses.ToArray();

        //            //MultiClassingPrerequisites/Proficiencies
        //            List<Prerequisites> multiClassingPrerequisites = new List<Prerequisites>();
        //            Prerequisites prerequisites = new Prerequisites();
        //            From abScore = new From();
        //            abScore = MultiClassingPrerequisites.AbilityScore;
        //            prerequisites.AbilityScore = abScore;
        //            prerequisites = MultiClassingPrerequisites;
        //            //prerequisites.AbilityScore = multiClassingPrerequisites.Select(a=>a.AbilityScore).FirstOrDefault();
        //            multiClassingPrerequisites.Add(prerequisites);
        //            MultiClassing multiClassing = new MultiClassing();
        //            multiClassing.Prerequisites = multiClassingPrerequisites.ToArray();
        //            //MultiClassingProficiencies
        //            List<From> multiClassingProficiencies = new List<From>();
        //            From proficiency = new From();
        //            proficiency.Index = MultiClassingProficiencies.Index;
        //            proficiency.Name = MultiClassingProficiencies.Name;
        //            multiClassing.Proficiencies = multiClassingProficiencies.ToArray();
        //            //ProficiencyChoices
        //            List<ProficiencyChoiceClasses> proficiencyChoices = new List<ProficiencyChoiceClasses>();
        //            proficiencyChoices.Add(ProficiencyChoices);
        //            classeInsertar.ProficienciesChoices = proficiencyChoices.ToArray();
        //            //SpellCasting
        //            //SpellCastingInfoName
        //            List<SpellcastingClass> spellcastingInfo = new List<SpellcastingClass>();
        //            List<InfoClasses> spellcastingClasses = new List<InfoClasses>();
        //            SpellcastingClass spellcastingClass = new SpellcastingClass();
        //            spellcastingClasses.Add(SpellCastingInfoName);
        //            spellcastingClass.Info = spellcastingClasses.ToArray();
        //            spellcastingInfo.Add(spellcastingClass);
        //            classeInsertar.Spellcasting = spellcastingClass;
        //            //StartingEquipmentOptionsChooseDesc
        //            List<StartingEquipmentOptionClasses> startingEquipmentOptionClassesList = new List<StartingEquipmentOptionClasses>();
        //            StartingEquipmentOptionClasses startingEquipmentOptionClasses = new StartingEquipmentOptionClasses();
        //            classeInsertar.StartingEquipmentOption = startingEquipmentOptionClassesList.ToArray();
        //            //StartingEquipmentOptionsFrom
        //            List<OptionItemClasses> optionItemClasses = new List<OptionItemClasses>();
        //            OptionItemClasses optionItemClass = new OptionItemClasses();
        //            optionItemClass = StartingEquipmentOptionsFrom;
        //            startingEquipmentOptionClasses.From.Add(optionItemClasses.ToArray());
        //            startingEquipmentOptionClasses = StartingEquipmentOptionsChooseDesc;
        //            classesRepository.CreateClass(classeInsertar);
        //            MessageBox.Show("Classes introducido");
        //            LoadDataClasses();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(Extensions.GetaAllMessages(ex));
        //    }
        //}
        private void BtModificarClasses_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarClasses.Text))
                {
                    string idBuscar = classes.Where(a => a.Index.Equals(f.tbFiltrarClasses.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {

                        Classes classeOld = new Classes();

                        // Asignación de valores básicos
                        classeOld.Index = f.tbIndexClasses.Text;
                        classeOld.Name = f.tbNameClasses.Text;
                        classeOld.HitDie = int.Parse(f.tbHitDieClasses.Text);

                        // Proficiencies
                        From selectedProficiencies = (From)f.cbProficienciesClasses.SelectedItem;
                        classeOld.Proficiencies = new From[] { selectedProficiencies };

                        // SavingThrows
                        From selectedSavingThrows = (From)f.cbSavingThrowsClasses.SelectedItem;
                        classeOld.SavingThrows = new From[] { selectedSavingThrows };

                        // StartingEquipment
                        From selectedStartingEquipment = (From)f.cbStartingEquipmentClasses.SelectedItem;
                        classeOld.StartingEquipment = new StartingEquipmentClasses[]
                        {
                            new StartingEquipmentClasses
                            {
                                Equipment = selectedStartingEquipment,
                                quantity = 1  // Ajusta la cantidad según tu lógica
                            }
                        };

                        // Subclasses
                        From selectedSubclasses = (From)f.cbSubclassesClasses.SelectedItem;
                        classeOld.Subclasses = new From[] { selectedSubclasses };

                        // MultiClassingPrerequisites
                        ClassesMultiClassingDAO selectedMultiClassingPrerequisite = (ClassesMultiClassingDAO)f.dgvMultiClassingPrerequisitesClasses.CurrentRow.DataBoundItem;
                        Prerequisites MultiClassingPrerequisites = new Prerequisites
                        {
                            AbilityScore = new From
                            {
                                Index = selectedMultiClassingPrerequisite.index,
                                Name = selectedMultiClassingPrerequisite.name
                            },
                            MinimumScore = selectedMultiClassingPrerequisite.minimum_score
                        };
                        classeOld.MultiClassing = new MultiClassing
                        {
                            Prerequisites = new Prerequisites[] { MultiClassingPrerequisites }
                        };

                        // MultiClassingProficiencies
                        From MultiClassingProficiencies = (From)f.dgvMultiClassingProficienciesClasses.CurrentRow.DataBoundItem;
                        classeOld.MultiClassing.Proficiencies = new From[] { MultiClassingProficiencies };

                        // ProficiencyChoices
                        ProficiencyChoiceClasses ProficiencyChoices = (ProficiencyChoiceClasses)f.dgvProficiencyChoicesClasses.CurrentRow.DataBoundItem;
                        classeOld.ProficienciesChoices = new ProficiencyChoiceClasses[] { ProficiencyChoices };

                        // SpellCasting
                        InfoClasses SpellCastingInfoName = (InfoClasses)f.dgvSpellCastingInfoNameClasses.CurrentRow.DataBoundItem;
                        classeOld.Spellcasting = new SpellcastingClass
                        {
                            Info = new InfoClasses[] { SpellCastingInfoName },
                            SpellcastingAbility = new From { Name = f.tbSpellCastingAbilityClasses.Text } // Asignación del SpellcastingAbility
                        };

                        // StartingEquipmentOptionsChooseDesc
                        StartingEquipmentOptionClasses StartingEquipmentOptionsChooseDesc = (StartingEquipmentOptionClasses)f.dgvStartingEquipmentOptionsChooseDescClasses.CurrentRow.DataBoundItem;
                        classeOld.StartingEquipmentOption = new StartingEquipmentOptionClasses[] { StartingEquipmentOptionsChooseDesc };

                        // StartingEquipmentOptionsFrom
                        OptionItemClasses StartingEquipmentOptionsFrom = (OptionItemClasses)f.dgvStartingEquipmentOptionsFromClasses.CurrentRow.DataBoundItem;
                        classeOld.StartingEquipmentOption[0].From = new List<OptionItemClasses[]>
                        {
                            new OptionItemClasses[] { StartingEquipmentOptionsFrom }
                        };



                        Classes classeModificar = classeOld;
                        classeModificar.Id = idBuscar;
                        // Actualizar el objeto Classes en la base de datos
                        classesRepository.UpdateClass(classeModificar);
                        MessageBox.Show("Classes modificado correctamente");
                        LoadDataClasses();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres modificar no puede estar vacío");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtEliminarClasses_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarClasses.Text))
                {
                    string idBuscar = classes.Where(a => a.Index.Equals(f.tbFiltrarClasses.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        classesRepository.DeleteClass(idBuscar);
                        MessageBox.Show(f.tbFiltrarClasses.Text.ToString() + " eliminado");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //Backgrounds
        private void DgvBackgrounds_SelectionChanged(object? sender, EventArgs e)
        {
            DataGridViewRow row = f.dgvBackgrounds.CurrentRow;
            if (row != null)
            {
                BackgroundsDAO backgroundsDAO = (BackgroundsDAO)row.DataBoundItem;

                f.tbIndexBackgrounds.Text = backgroundsDAO.index;
                f.tbNameBackgrounds.Text = backgroundsDAO.name;
                f.tbLanguageOptionsBackgrounds.Text = backgroundsDAO.languageOptions.ToString();

                ChooseFrom personalityTraits = new ChooseFrom();
                personalityTraits.From = backgroundsDAO.personalityTraitsFrom;
                personalityTraits.Choose = backgroundsDAO.personalityTraitsChoose;
                List<ChooseFrom> añadirpersonalityTraits = new List<ChooseFrom>();
                añadirpersonalityTraits.Add(personalityTraits);
                f.cbPersonalityTraitsBackgrounds.DataSource = añadirpersonalityTraits;
                f.cbPersonalityTraitsBackgrounds.DisplayMember = "Choose";

                StartingEquipmentBa startingEquipment = new StartingEquipmentBa();
                startingEquipment.Equipment = backgroundsDAO.startingEquipmentEquipment;
                startingEquipment.Quantity = backgroundsDAO.startingEquipmentQuantity;
                List<StartingEquipmentBa> añadirstartingEquipment = new List<StartingEquipmentBa>();
                añadirstartingEquipment.Add(startingEquipment);
                f.cbStartingEquipmentBackgrounds.DataSource = añadirstartingEquipment;
                f.cbStartingEquipmentBackgrounds.DisplayMember = "Quantity";

                StartingEquipmentOptionBa startingEquipmentOptionBa = new StartingEquipmentOptionBa();
                startingEquipmentOptionBa.Choose = backgroundsDAO.startingEquipmentOptionsChoose;
                startingEquipmentOptionBa.From = backgroundsDAO.startingEquipmentOptionsFrom;
                startingEquipmentOptionBa.Type = backgroundsDAO.startingEquipmentOptionsType;
                List<StartingEquipmentOptionBa> añadirStartingEquipmentOptionBa = new List<StartingEquipmentOptionBa>();
                añadirStartingEquipmentOptionBa.Add(startingEquipmentOptionBa);
                f.cbStartingEquipmentOptionsBackgrounds.DataSource = añadirStartingEquipmentOptionBa;
                f.cbStartingEquipmentOptionsBackgrounds.DisplayMember = "Choose";

                From startingProficiencies = new From();
                startingProficiencies.Index = backgroundsDAO.startingProficienciesIndex;
                startingProficiencies.Name = backgroundsDAO.startingProficienciesName;
                List<From> añadirStartingProficiencies = new List<From>();
                añadirStartingProficiencies.Add(startingProficiencies);
                f.cbStartingProficienciesBackgrounds.DataSource = añadirStartingProficiencies;
                f.cbStartingProficienciesBackgrounds.DisplayMember = "Name";

                ChooseFrom bonds = new ChooseFrom();
                bonds.Choose = backgroundsDAO.bondsChoose;
                bonds.From = backgroundsDAO.bondsFrom;
                List<ChooseFrom> añadirBonds = new List<ChooseFrom>();
                añadirBonds.Add(bonds);
                f.cbBondsBackgrounds.DataSource = añadirBonds;
                f.cbBondsBackgrounds.DisplayMember = "Choose";

                FeatureBackground features = new FeatureBackground();
                features.Description = backgroundsDAO.featureDesc;
                features.Name = backgroundsDAO.featureName;
                List<FeatureBackground> añadirFeatures = new List<FeatureBackground>();
                añadirFeatures.Add(features);
                f.cbFeatureBackgrounds.DataSource = añadirFeatures;
                f.cbFeatureBackgrounds.DisplayMember = "Name";

                ChooseFrom flaws = new ChooseFrom();
                flaws.Choose = backgroundsDAO.flawsChoose;
                flaws.From = backgroundsDAO.flawsFrom;
                List<ChooseFrom> añadirFlaws = new List<ChooseFrom>();
                añadirFlaws.Add(flaws);
                f.cbFlawsBackgrounds.DataSource = añadirFlaws;
                f.cbFlawsBackgrounds.DisplayMember = "Choose";

                IdealsBackground ideals = new IdealsBackground();
                List<IdealsBackground> añadirIdeals = new List<IdealsBackground>();
                ideals = backgroundsDAO.ideals;
                añadirIdeals.Add(ideals);
                f.cbIdealsBackgrounds.DataSource = añadirIdeals;
                f.cbIdealsBackgrounds.DisplayMember = "Choose";
            }
        }

        private void BtModificarBackgrounds_Click(object? sender, EventArgs e)
        {
            Background background = new Background();
            List<ChooseFrom> listPersonalityTraits = new List<ChooseFrom>();
            List<StartingEquipmentBa> listStartingEquipmentBa = new List<StartingEquipmentBa>();
            List<StartingEquipmentOptionBa> listStartingEquipmentOptionBa = new List<StartingEquipmentOptionBa>();
            List<From> listStartingProficiencies = new List<From>();
            List<ChooseFrom> listBonds = new List<ChooseFrom>();
            List<FeatureBackground> listFeatureBackground = new List<FeatureBackground>();
            List<ChooseFrom> listFlaws = new List<ChooseFrom>();
            List<IdealsBackground> listIdealsBackground = new List<IdealsBackground>();

            string index = f.tbIndexBackgrounds.Text;
            string name = f.tbNameBackgrounds.Text;
            int languageOptions = int.Parse(f.tbLanguageOptionsBackgrounds.Text);
            ChooseFrom PersonalityTraits = (ChooseFrom)f.cbPersonalityTraitsBackgrounds.SelectedItem;
            StartingEquipmentBa StartingEquipment = (StartingEquipmentBa)f.cbStartingEquipmentBackgrounds.SelectedItem;
            StartingEquipmentOptionBa StartingEquipmentOptions = (StartingEquipmentOptionBa)f.cbStartingEquipmentOptionsBackgrounds.SelectedItem;
            From StartingProficiencies = (From)f.cbStartingProficienciesBackgrounds.SelectedItem;
            ChooseFrom Bonds = (ChooseFrom)f.cbBondsBackgrounds.SelectedItem;
            FeatureBackground Feature = (FeatureBackground)f.cbFeatureBackgrounds.SelectedItem;
            ChooseFrom Flaws = (ChooseFrom)f.cbFlawsBackgrounds.SelectedItem;
            IdealsBackground Ideals = (IdealsBackground)f.cbIdealsBackgrounds.SelectedItem;

            if (!string.IsNullOrEmpty(f.tbFiltrarBackgrounds.Text))
            {
                string idBuscar = backgrounds.Where(a => a.Index.Equals(f.tbFiltrarBackgrounds.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                if (idBuscar != null)
                {
                    if (PersonalityTraits != null && StartingEquipment != null && StartingEquipmentOptions != null && StartingProficiencies != null && Bonds != null && Feature != null &&
                    Flaws != null && Ideals != null)
                    {

                        listStartingEquipmentBa.Add(StartingEquipment);
                        listStartingEquipmentOptionBa.Add(StartingEquipmentOptions);
                        listStartingProficiencies.Add(StartingProficiencies);
                        listBonds.Add(Bonds);
                        listFeatureBackground.Add(Feature);
                        listFlaws.Add(Flaws);
                        listIdealsBackground.Add(Ideals);
                        background.Id = idBuscar;
                        background.Index = index;
                        background.Name = name;
                        background.LanguageOptions = languageOptions;
                        background.PersonalityTraits = PersonalityTraits;
                        background.StartingEquipment = listStartingEquipmentBa.ToArray();
                        background.StartingEquipmentOption = listStartingEquipmentOptionBa.ToArray();
                        background.StartingProficiencies = listStartingProficiencies;
                        background.Bonds = Bonds;
                        background.Feature = Feature;
                        background.Flaws = Flaws;
                        background.Ideals = Ideals;

                        backgroundsRepository.UpdateBackground(background);
                        MessageBox.Show("Background introducido");
                        LoadDataBackgrounds();
                    }

                }
                else
                {
                    MessageBox.Show("No existe una referencia con ese index");
                }

            }
            {
                MessageBox.Show("Lo que quieres modificar no puede estar vacío");
            }

        }

        private void BtEliminarBackgrounds_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarBackgrounds.Text))
                {
                    string idBuscar = backgrounds.Where(a => a.Index.Equals(f.tbFiltrarBackgrounds.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        backgroundsRepository.DeleteBackground(idBuscar);
                        MessageBox.Show(f.tbFiltrarBackgrounds.Text.ToString() + " eliminado");
                        LoadDataBackgrounds();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres eliminar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BtBuscarBackgrounds_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarBackgrounds.Text))
                {
                    string idBuscar = backgrounds.Where(a => a.Index.Equals(f.tbFiltrarBackgrounds.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        Background newBackground = backgroundsRepository.GetBackground(idBuscar.ToString());
                        f.tbIndexBackgrounds.Text = newBackground.Index;
                        f.tbNameBackgrounds.Text = newBackground.Name;
                        f.tbLanguageOptionsBackgrounds.Text = newBackground.LanguageOptions.ToString();

                        List<ChooseFrom> listPersonalityTraits = new List<ChooseFrom>();
                        List<StartingEquipmentBa> listStartingEquipmentBa = new List<StartingEquipmentBa>();
                        List<StartingEquipmentOptionBa> listStartingEquipmentOptionBa = new List<StartingEquipmentOptionBa>();
                        List<List<From>> listStartingProficiencies = new List<List<From>>();
                        List<ChooseFrom> listBonds = new List<ChooseFrom>();
                        List<FeatureBackground> listFeatureBackground = new List<FeatureBackground>();
                        List<ChooseFrom> listFlaws = new List<ChooseFrom>();
                        List<IdealsBackground> listIdealsBackground = new List<IdealsBackground>();

                        listPersonalityTraits.Add(newBackground.PersonalityTraits);
                        listStartingEquipmentBa.Add(newBackground.StartingEquipment.FirstOrDefault());
                        listStartingEquipmentOptionBa.Add(newBackground.StartingEquipmentOption.FirstOrDefault());
                        listStartingProficiencies.Add(newBackground.StartingProficiencies);
                        listBonds.Add(newBackground.Bonds);
                        listFeatureBackground.Add(newBackground.Feature);
                        listFlaws.Add(newBackground.Flaws);
                        listIdealsBackground.Add(newBackground.Ideals);

                        f.cbPersonalityTraitsBackgrounds.DataSource = listPersonalityTraits;
                        f.cbStartingEquipmentBackgrounds.DataSource = listStartingEquipmentBa;
                        f.cbStartingEquipmentOptionsBackgrounds.DataSource = listStartingEquipmentOptionBa;
                        f.cbStartingProficienciesBackgrounds.DataSource = listStartingProficiencies;
                        f.cbBondsBackgrounds.DataSource = listBonds;
                        f.cbFeatureBackgrounds.DataSource = listFeatureBackground;
                        f.cbFlawsBackgrounds.DataSource = listFlaws;
                        f.cbIdealsBackgrounds.DataSource = listIdealsBackground;

                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BtInsertarBackgrounds_MouseUp(object? sender, MouseEventArgs e)
        {

        }

        private void BtInsertarBackgrounds_Click(object? sender, EventArgs e)
        {
            Background background = new Background();
            List<ChooseFrom> listPersonalityTraits = new List<ChooseFrom>();
            List<StartingEquipmentBa> listStartingEquipmentBa = new List<StartingEquipmentBa>();
            List<StartingEquipmentOptionBa> listStartingEquipmentOptionBa = new List<StartingEquipmentOptionBa>();
            List<From> listStartingProficiencies = new List<From>();
            List<ChooseFrom> listBonds = new List<ChooseFrom>();
            List<FeatureBackground> listFeatureBackground = new List<FeatureBackground>();
            List<ChooseFrom> listFlaws = new List<ChooseFrom>();
            List<IdealsBackground> listIdealsBackground = new List<IdealsBackground>();

            string index = f.tbIndexBackgrounds.Text;
            string name = f.tbNameBackgrounds.Text;
            int languageOptions = int.Parse(f.tbLanguageOptionsBackgrounds.Text);
            ChooseFrom PersonalityTraits = (ChooseFrom)f.cbPersonalityTraitsBackgrounds.SelectedItem;
            StartingEquipmentBa StartingEquipment = (StartingEquipmentBa)f.cbStartingEquipmentBackgrounds.SelectedItem;
            StartingEquipmentOptionBa StartingEquipmentOptions = (StartingEquipmentOptionBa)f.cbStartingEquipmentOptionsBackgrounds.SelectedItem;
            From StartingProficiencies = (From)f.cbStartingProficienciesBackgrounds.SelectedItem;
            ChooseFrom Bonds = (ChooseFrom)f.cbBondsBackgrounds.SelectedItem;
            FeatureBackground Feature = (FeatureBackground)f.cbFeatureBackgrounds.SelectedItem;
            ChooseFrom Flaws = (ChooseFrom)f.cbFlawsBackgrounds.SelectedItem;
            IdealsBackground Ideals = (IdealsBackground)f.cbIdealsBackgrounds.SelectedItem;

            if (PersonalityTraits != null && StartingEquipment != null && StartingEquipmentOptions != null && StartingProficiencies != null && Bonds != null && Feature != null &&
                Flaws != null && Ideals != null)
            {

                //listPersonalityTraits.Add(newBackground.PersonalityTraits);
                listStartingEquipmentBa.Add(StartingEquipment);
                listStartingEquipmentOptionBa.Add(StartingEquipmentOptions);
                listStartingProficiencies.Add(StartingProficiencies);
                listBonds.Add(Bonds);
                listFeatureBackground.Add(Feature);
                listFlaws.Add(Flaws);
                listIdealsBackground.Add(Ideals);
                background.Index = index;
                background.Name = name;
                background.LanguageOptions = languageOptions;
                background.PersonalityTraits = PersonalityTraits;
                background.StartingEquipment = listStartingEquipmentBa.ToArray();
                background.StartingEquipmentOption = listStartingEquipmentOptionBa.ToArray();
                background.StartingProficiencies = listStartingProficiencies;
                background.Bonds = Bonds;
                background.Feature = Feature;
                background.Flaws = Flaws;
                background.Ideals = Ideals;

                backgroundsRepository.CreateBackground(background);
                MessageBox.Show("Background introducido");
                LoadDataBackgrounds();
            }
            else
            {
                MessageBox.Show("No puedes dejar espacios vacíos");
            }

        }

        //Conditions
        private void DgvConditions_SelectionChanged(object? sender, EventArgs e)
        {
            DataGridViewRow row = f.dgvConditions.CurrentRow;
            if (row != null)
            {
                Conditions condition = (Conditions)row.DataBoundItem;
                f.tbIndexConditions.Text = condition.Index;
                f.tbNameConditions.Text = condition.Name;
                f.rtbDescriptionConditions.Text = condition.Desc.FirstOrDefault();
            }
        }
        private void BtBuscarConditions_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarConditions.Text))
                {
                    string idBuscar = conditions.Where(a => a.Index.Equals(f.tbFiltrarConditions.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        Conditions conditions = conditionsRepository.GetCondition(idBuscar);
                        f.tbIndexConditions.Text = conditions.Index;
                        f.tbNameConditions.Text = conditions.Name;
                        f.rtbDescriptionConditions.Text = conditions.Desc.FirstOrDefault();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        private void BtInsertarConditions_Click(object? sender, EventArgs e)
        {
            Conditions conditions = new Conditions();
            string index = f.tbIndexConditions.Text;
            string name = f.tbNameConditions.Text;
            string[] des = new string[] { f.rtbDescriptionConditions.Text };

            if (!string.IsNullOrEmpty(index) != null && !string.IsNullOrEmpty(name) != null && des.Length > 0)
            {
                conditions.Index = index;
                conditions.Name = name;
                conditions.Desc = des;
                conditionsRepository.CreateCondition(conditions);
                LoadDataConditions();
                MessageBox.Show("Conditions introducido");
            }
            else
            {
                MessageBox.Show("No puedes dejar espacios vacíos");
            }
        }
        private void BtEliminarConditions_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(f.tbFiltrarConditions.Text))
            {
                string idBuscar = conditions.Where(a => a.Index.Equals(f.tbFiltrarConditions.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                if (idBuscar != null)
                {
                    conditionsRepository.DeleteCondition(idBuscar);
                    MessageBox.Show(f.tbFiltrarConditions.Text + " eliminado");
                    LoadDataConditions();
                }
                else
                {
                    MessageBox.Show("No existe una referencia con ese index");
                }
            }
            else
            {
                MessageBox.Show("Lo que quieres eliminar no puede estar vacío");
            }
        }
        private void BtModificarConditions_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(f.tbFiltrarConditions.Text))
            {
                string idBuscar = conditions.Where(a => a.Index.Equals(f.tbFiltrarConditions.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                if (idBuscar != null)
                {
                    Conditions conditions = conditionsRepository.GetCondition(idBuscar);
                    conditions.Index = f.tbIndexConditions.Text;
                    conditions.Name = f.tbNameConditions.Text;
                    conditions.Desc = new string[] { f.rtbDescriptionConditions.Text };
                    conditionsRepository.UpdateCondition(conditions);
                    MessageBox.Show("Modificado correctamente");
                    LoadDataConditions();
                }
                else
                {
                    MessageBox.Show("No existe una referencia con ese index");
                }
            }
            else
            {
                MessageBox.Show("Lo que quieres modificar no puede estar vacío");
            }
        }

        //DamageType
        private void DgvDamageType_SelectionChanged(object? sender, EventArgs e)
        {
            DataGridViewRow row = f.dgvDamageType.CurrentRow;
            if (row != null)
            {
                DamageType damageType = (DamageType)row.DataBoundItem;
                f.tbIndexDamageType.Text = damageType.Index;
                f.tbNameDamageType.Text = damageType.Name;
                f.rtbDescriptionDamageType.Text = damageType.Description.FirstOrDefault();
            }
        }
        private void BtInsertarDamageType_Click(object? sender, EventArgs e)
        {
            try
            {
                DamageType damageType = new DamageType();
                string index = f.tbIndexDamageType.Text;
                string name = f.tbNameDamageType.Text;
                string[] description = new string[] { f.rtbDescriptionDamageType.Text };

                if (!string.IsNullOrEmpty(index) != null && !string.IsNullOrEmpty(name) != null && description.Length > 0)
                {
                    damageType.Index = index;
                    damageType.Name = name;
                    damageType.Description = description;
                    DamageTypeRepository.CreateDamageType(damageType);
                    LoadDataDamageType();
                    MessageBox.Show("DamageType introducido");
                }
                else
                {
                    MessageBox.Show("No puedes dejar espacios vacíos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }

        }
        private void BtBuscarDamageType_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarDamageType.Text))
                {
                    string idBuscar = damageTypes.Where(a => a.Index.Equals(f.tbFiltrarDamageType.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        DamageType damageType = DamageTypeRepository.GetDamageType(idBuscar);
                        f.tbIndexDamageType.Text = damageType.Index;
                        f.tbNameDamageType.Text = damageType.Name;
                        f.rtbDescriptionDamageType.Text = damageType.Description.FirstOrDefault();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtEliminarDamageType_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarDamageType.Text))
                {
                    string idBuscar = damageTypes.Where(a => a.Index.Equals(f.tbFiltrarDamageType.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        DamageTypeRepository.DeleteDamageType(idBuscar);
                        MessageBox.Show(f.tbFiltrarDamageType.Text + " eliminado");
                        LoadDataDamageType();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres eliminar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }

        }
        private void BtModificarDamageType_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarDamageType.Text))
                {
                    string idBuscar = damageTypes.Where(a => a.Index.Equals(f.tbFiltrarDamageType.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        DamageType damageType = DamageTypeRepository.GetDamageType(idBuscar);
                        damageType.Index = f.tbIndexDamageType.Text;
                        damageType.Name = f.tbNameDamageType.Text;
                        damageType.Description = new string[] { f.rtbDescriptionDamageType.Text };
                        DamageTypeRepository.UpdateDamageType(damageType);
                        MessageBox.Show("Modificado correctamente");
                        LoadDataDamageType();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres modificar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }

        }

        //Equipment
        private void DgvEquipment_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = f.dgvEquipment.CurrentRow;
                if (row != null)
                {
                    EquipmentDAO eq = (EquipmentDAO)row.DataBoundItem;
                    string idBuscar = eq.Id;
                    Equipment newEq = EquipmentRepository.GetEquipment(idBuscar);
                    f.tbIndexEquipment.Text = newEq?.Index;
                    f.tbNameEquipment.Text = newEq?.Name;
                    f.tbSTRMinimumEquipment.Text = newEq?.StrengthMinimum.ToString();
                    f.chbStealthDisadvantageEquipment.Checked = (newEq.StealthDisadvantage.HasValue);
                    f.tbToolCategoryEquipment.Text = newEq?.ToolCategory;
                    f.tbVehicleCategoryEquipment.Text = newEq?.VehicleCategory;
                    f.tbWeightEquipment.Text = newEq?.Weight.ToString();
                    f.tbCapacityEquipment.Text = newEq?.Capacity;
                    f.tbCategoryRangeEquipment.Text = newEq?.CategoryRange;
                    f.tbWeapongCategoryEquipment.Text = newEq?.WeaponCategory;
                    f.tbQuantityEquipment.Text = newEq?.Quantity.ToString();
                    f.tbArmorCategoryEquipment.Text = newEq?.ArmorCategory;
                    f.tbTwoHandedDamageDiceEquipment.Text = newEq?.TwoHandedDamage?.DamageDice;
                    f.tbWeaponRangeEquipment.Text = newEq?.WeaponRange;
                    f.rtbSpecialEquipment.Text += newEq?.Special;

                    //dgv
                    List<ArmorClassEquipment> armorName = new List<ArmorClassEquipment>();
                    armorName.Add(newEq?.ArmorName);
                    f.dgvArmorNameEquipment.DataSource = armorName;

                    List<DamageEquipment> unitQuantity = new List<DamageEquipment>();
                    unitQuantity.Add(newEq?.UnitQuantity);
                    f.dgvUnitQuantityEquipment.DataSource = unitQuantity;

                    List<Models.Commons.Range> range = new List<Models.Commons.Range>();
                    range.Add(newEq?.Range);
                    f.dgvRangeEquipment.DataSource = range;

                    List<Models.Commons.Range> throwRange = new List<Models.Commons.Range>();
                    throwRange.Add(newEq?.ThrowRange);
                    f.dgvThrowRangeEquipment.DataSource = throwRange;

                    List<From> damageType = new List<From>();
                    damageType.Add(newEq?.TwoHandedDamage?.DamageType);
                    f.dgvTwoHandedDamageDamageTypeEquipment.DataSource = damageType;

                    List<From[]> properties = new List<From[]>();
                    properties.Add(newEq?.Properties);
                    f.dgvPropertiesEquipment.DataSource = properties.FirstOrDefault();

                    List<From> gearCategory = new List<From>();
                    gearCategory.Add(newEq?.GearCategory);
                    f.dgvGearCategoryEquipment.DataSource = gearCategory;

                    //cb
                    List<UnitQuantity> speed = new List<UnitQuantity>();
                    speed.Add(newEq?.Speed);
                    f.cbSpeedEquipment.DataSource = speed;

                    List<From> equipmentCategory = new List<From>();
                    equipmentCategory.Add(newEq?.EquipmentCategory);
                    f.cbEquipmentCategoryEquipment.DataSource = equipmentCategory;
                    f.cbEquipmentCategoryEquipment.DisplayMember = "Name";



                    List<ContentsEquipment> contents = new List<ContentsEquipment>();
                    contents.Add(newEq?.Contents);
                    f.cbContentsEquipment.DataSource = contents;
                    f.cbContentsEquipment.DisplayMember = "Quantity";

                    List<UnitQuantity> cost = new List<UnitQuantity>();
                    cost.Add(newEq?.Cost);
                    f.cbCostEquipment.DataSource = cost;
                    f.cbCostEquipment.DisplayMember = "Quantity";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtBuscarEquipment_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarEquipment.Text))
                {
                    string idBuscar = equipments.Where(a => a.Index.Equals(f.tbFiltrarEquipment.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        Equipment equipment = EquipmentRepository.GetEquipment(idBuscar);
                        f.tbIndexEquipment.Text = equipment.Index;
                        f.tbNameEquipment.Text = equipment.Name;
                        f.tbSTRMinimumEquipment.Text = equipment.StrengthMinimum.ToString();
                        f.chbStealthDisadvantageEquipment.Checked = equipment.StealthDisadvantage.HasValue;
                        f.tbToolCategoryEquipment.Text = equipment.ToolCategory;
                        f.tbVehicleCategoryEquipment.Text = equipment.VehicleCategory;
                        f.tbWeightEquipment.Text = equipment.Weight.ToString();
                        f.tbCapacityEquipment.Text = equipment.Capacity;
                        f.tbCategoryRangeEquipment.Text = equipment.CategoryRange;
                        f.tbWeapongCategoryEquipment.Text = equipment.WeaponCategory;
                        f.tbQuantityEquipment.Text = equipment.Quantity.ToString();
                        f.tbArmorCategoryEquipment.Text = equipment.ArmorCategory;
                        f.tbTwoHandedDamageDiceEquipment.Text = equipment.TwoHandedDamage?.DamageDice;
                        f.tbWeaponRangeEquipment.Text = equipment.WeaponRange;
                        f.rtbSpecialEquipment.Text += equipment.Special;

                        //dgv
                        List<ArmorClassEquipment> armorName = new List<ArmorClassEquipment>();
                        armorName.Add(equipment.ArmorName);
                        f.dgvArmorNameEquipment.DataSource = armorName;

                        List<DamageEquipment> unitQuantity = new List<DamageEquipment>();
                        unitQuantity.Add(equipment.UnitQuantity);
                        f.dgvUnitQuantityEquipment.DataSource = unitQuantity;

                        List<Models.Commons.Range> range = new List<Models.Commons.Range>();
                        range.Add(equipment.Range);
                        f.dgvRangeEquipment.DataSource = range;

                        List<Models.Commons.Range> throwRange = new List<Models.Commons.Range>();
                        throwRange.Add(equipment.ThrowRange);
                        f.dgvThrowRangeEquipment.DataSource = throwRange;

                        List<From> damageType = new List<From>();
                        damageType.Add(equipment.TwoHandedDamage?.DamageType);
                        f.dgvTwoHandedDamageDamageTypeEquipment.DataSource = damageType;

                        List<From[]> properties = new List<From[]>();
                        properties.Add(equipment?.Properties);
                        if (properties != null)
                        {
                            f.dgvPropertiesEquipment.DataSource = properties.FirstOrDefault();
                        }
                        else
                        {
                            f.dgvPropertiesEquipment.DataSource = new List<From>();
                        }

                        //cb
                        List<UnitQuantity> speed = new List<UnitQuantity>();
                        speed.Add(equipment?.Speed);
                        f.cbSpeedEquipment.DataSource = speed;
                        //f.cbSpeedEquipment.DisplayMember = "Unit";

                        List<From> equipmentCategory = new List<From>();
                        equipmentCategory.Add(equipment?.EquipmentCategory);
                        f.cbEquipmentCategoryEquipment.DataSource = equipmentCategory;
                        f.cbEquipmentCategoryEquipment.DisplayMember = "Name";

                        List<From> gearCategory = new List<From>();
                        gearCategory.Add(equipment?.GearCategory);
                        f.dgvGearCategoryEquipment.DataSource = gearCategory;

                        List<ContentsEquipment> contents = new List<ContentsEquipment>();
                        contents.Add(equipment?.Contents);
                        f.cbContentsEquipment.DataSource = contents;
                        f.cbContentsEquipment.DisplayMember = "Quantity";

                        List<UnitQuantity> cost = new List<UnitQuantity>();
                        cost.Add(equipment.Cost);
                        f.cbCostEquipment.DataSource = cost;
                        f.cbCostEquipment.DisplayMember = "Quantity";

                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtInsertarEquipment_Click(object? sender, EventArgs e)
        {
            try
            {
                Equipment equipment = new Equipment();

                equipment.Index = f.tbIndexEquipment.Text;
                equipment.Name = f.tbNameEquipment.Text;
                if (!string.IsNullOrEmpty(f.tbSTRMinimumEquipment?.Text))
                {
                    equipment.StrengthMinimum = int.Parse(f.tbSTRMinimumEquipment?.Text);
                }
                else
                {
                    equipment.StrengthMinimum = null;
                }
                equipment.StealthDisadvantage = f.chbStealthDisadvantageEquipment.Checked;
                equipment.ToolCategory = f.tbToolCategoryEquipment.Text;
                equipment.VehicleCategory = f.tbVehicleCategoryEquipment.Text;
                equipment.Weight = int.Parse(f.tbWeightEquipment.Text);
                equipment.Capacity = f.tbCapacityEquipment.Text;
                equipment.CategoryRange = f.tbCategoryRangeEquipment.Text;
                equipment.WeaponCategory = f.tbWeapongCategoryEquipment.Text;
                if (!string.IsNullOrEmpty(f.tbQuantityEquipment.Text))
                {
                    equipment.Quantity = int.Parse(f.tbQuantityEquipment.Text);
                }
                else
                {
                    equipment.Quantity = null;
                }
                equipment.ArmorCategory = f.tbArmorCategoryEquipment.Text;

                DataGridViewRow rowArmorName = f.dgvArmorNameEquipment.CurrentRow;
                DataGridViewRow rowUnitQuantity = f.dgvUnitQuantityEquipment.CurrentRow;
                DataGridViewRow rowRange = f.dgvRangeEquipment.CurrentRow;
                DataGridViewRow rowThrowRange = f.dgvThrowRangeEquipment.CurrentRow;
                DataGridViewRow rowGearCategory = f.dgvGearCategoryEquipment.CurrentRow;
                DataGridViewRow rowProperties = f.dgvPropertiesEquipment.CurrentRow;

                if (rowArmorName != null)
                {
                    equipment.ArmorName = (ArmorClassEquipment)rowArmorName.DataBoundItem;

                }
                if (rowUnitQuantity != null)
                {
                    equipment.UnitQuantity = (DamageEquipment)rowUnitQuantity.DataBoundItem;

                }
                if (rowRange != null)
                {
                    equipment.Range = (Models.Commons.Range)rowRange.DataBoundItem;

                }
                if (rowThrowRange != null)
                {
                    equipment.ThrowRange = (Models.Commons.Range)rowThrowRange.DataBoundItem;

                }
                if (rowGearCategory != null)
                {
                    equipment.GearCategory = (From)rowGearCategory.DataBoundItem;

                }
                if (rowProperties != null)
                {
                    From propertiesEquipment = (From)rowProperties.DataBoundItem;
                    List<From> propertiesEquipmentList = new List<From>();
                    propertiesEquipmentList.Add(propertiesEquipment);
                    equipment.Properties = propertiesEquipmentList.ToArray();

                }
                else
                {
                    List<From> propertiesEquipmentList = new List<From>();
                    From emptyPropertiesEquipment = new From();
                    emptyPropertiesEquipment.Name = string.Empty;
                    emptyPropertiesEquipment.Index = string.Empty;
                    propertiesEquipmentList.Add(emptyPropertiesEquipment);
                    equipment.Properties = propertiesEquipmentList.ToArray();
                }
                equipment.TwoHandedDamage = new TwoHandedDamageEquipment
                {
                    DamageDice = f.tbTwoHandedDamageDiceEquipment.Text,
                    DamageType = (From)f.dgvTwoHandedDamageDamageTypeEquipment.CurrentRow.DataBoundItem
                };
                equipment.WeaponRange = f.tbWeaponRangeEquipment.Text;

                equipment.Speed = (UnitQuantity)f.cbSpeedEquipment.SelectedItem;
                equipment.EquipmentCategory = (From)f.cbEquipmentCategoryEquipment.SelectedItem;



                equipment.Contents = (ContentsEquipment)f.cbContentsEquipment.SelectedItem;
                equipment.Cost = (UnitQuantity)f.cbCostEquipment.SelectedItem;
                EquipmentRepository.CreateEquipment(equipment);
                MessageBox.Show("Equipment introducido");
                LoadDataEquipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtEliminarEquipment_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarEquipment.Text))
                {
                    string idBuscar = equipments.Where(a => a.Index.Equals(f.tbFiltrarEquipment.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        EquipmentRepository.DeleteEquipment(idBuscar);
                        MessageBox.Show(f.tbFiltrarEquipment.Text.ToString() + " eliminado");
                        LoadDataEquipment();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres eliminar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void BtModificarEquipment_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarEquipment.Text))
                {
                    string idBuscar = equipments.Where(a => a.Index.Equals(f.tbFiltrarEquipment.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();
                    if (idBuscar != null)
                    {
                        Equipment equipment = new Equipment();

                        equipment.Id = idBuscar;
                        equipment.Index = f.tbIndexEquipment.Text;
                        equipment.Name = f.tbNameEquipment.Text;
                        if (!string.IsNullOrEmpty(f.tbSTRMinimumEquipment?.Text))
                        {
                            equipment.StrengthMinimum = int.Parse(f.tbSTRMinimumEquipment?.Text);
                        }
                        else
                        {
                            equipment.StrengthMinimum = null;
                        }
                        equipment.StealthDisadvantage = f.chbStealthDisadvantageEquipment.Checked;
                        equipment.ToolCategory = f.tbToolCategoryEquipment.Text;
                        equipment.VehicleCategory = f.tbVehicleCategoryEquipment.Text;
                        equipment.Weight = int.Parse(f.tbWeightEquipment.Text);
                        equipment.Capacity = f.tbCapacityEquipment.Text;
                        equipment.CategoryRange = f.tbCategoryRangeEquipment.Text;
                        equipment.WeaponCategory = f.tbWeapongCategoryEquipment.Text;
                        if (!string.IsNullOrEmpty(f.tbQuantityEquipment.Text))
                        {
                            equipment.Quantity = int.Parse(f.tbQuantityEquipment.Text);
                        }
                        else
                        {
                            equipment.Quantity = null;
                        }
                        equipment.ArmorCategory = f.tbArmorCategoryEquipment.Text;

                        DataGridViewRow rowArmorName = f.dgvArmorNameEquipment.CurrentRow;
                        DataGridViewRow rowUnitQuantity = f.dgvUnitQuantityEquipment.CurrentRow;
                        DataGridViewRow rowRange = f.dgvRangeEquipment.CurrentRow;
                        DataGridViewRow rowThrowRange = f.dgvThrowRangeEquipment.CurrentRow;
                        DataGridViewRow rowGearCategory = f.dgvGearCategoryEquipment.CurrentRow;
                        DataGridViewRow rowProperties = f.dgvPropertiesEquipment.CurrentRow;

                        if (rowArmorName != null)
                        {
                            equipment.ArmorName = (ArmorClassEquipment)rowArmorName.DataBoundItem;

                        }
                        if (rowUnitQuantity != null)
                        {
                            equipment.UnitQuantity = (DamageEquipment)rowUnitQuantity.DataBoundItem;

                        }
                        if (rowRange != null)
                        {
                            equipment.Range = (Models.Commons.Range)rowRange.DataBoundItem;

                        }
                        if (rowThrowRange != null)
                        {
                            equipment.ThrowRange = (Models.Commons.Range)rowThrowRange.DataBoundItem;

                        }
                        if (rowGearCategory != null)
                        {
                            equipment.GearCategory = (From)rowGearCategory.DataBoundItem;

                        }
                        if (rowProperties != null)
                        {
                            From propertiesEquipment = (From)rowProperties.DataBoundItem;
                            List<From> propertiesEquipmentList = new List<From>();
                            propertiesEquipmentList.Add(propertiesEquipment);
                            equipment.Properties = propertiesEquipmentList.ToArray();

                        }
                        else
                        {
                            List<From> propertiesEquipmentList = new List<From>();
                            From emptyPropertiesEquipment = new From();
                            emptyPropertiesEquipment.Name = string.Empty;
                            emptyPropertiesEquipment.Index = string.Empty;
                            propertiesEquipmentList.Add(emptyPropertiesEquipment);
                            equipment.Properties = propertiesEquipmentList.ToArray();
                        }
                        equipment.TwoHandedDamage = new TwoHandedDamageEquipment
                        {
                            DamageDice = f.tbTwoHandedDamageDiceEquipment.Text,
                            DamageType = (From)f.dgvTwoHandedDamageDamageTypeEquipment.CurrentRow.DataBoundItem
                        };
                        equipment.WeaponRange = f.tbWeaponRangeEquipment.Text;

                        equipment.Speed = (UnitQuantity)f.cbSpeedEquipment.SelectedItem;
                        equipment.EquipmentCategory = (From)f.cbEquipmentCategoryEquipment.SelectedItem;



                        equipment.Contents = (ContentsEquipment)f.cbContentsEquipment.SelectedItem;
                        equipment.Cost = (UnitQuantity)f.cbCostEquipment.SelectedItem;
                        EquipmentRepository.UpdateEquipment(equipment);
                        MessageBox.Show("Modificado correctamente");
                        LoadDataEquipment();
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        //EquipmentCategories
        private void DgvEquipmentCategories_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = f.dgvEquipmentCategories.CurrentRow;
                if (row != null)
                {
                    EquipmentCategory eqCat = (EquipmentCategory)row.DataBoundItem;
                    EquipmentCategory newEqCat = EquipmentCategoriesRepository.GetEquipmentCategory(eqCat.Id);

                    f.tbIndexEquipmentCategories.Text = newEqCat?.Index;
                    f.tbNameEquipmentCategories.Text = newEqCat?.Name;
                    f.cbEquipmentEquipmentCategories.DataSource = newEqCat?.Equipment;
                    f.cbEquipmentEquipmentCategories.DisplayMember = "Name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtBuscarEquipmentCategories_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarEquipmentCategories.Text))
                {
                    string idBuscar = equipmentCategories.Where(a => a.Index.Equals(f.tbFiltrarEquipmentCategories.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        EquipmentCategory newEquipmentCategory = EquipmentCategoriesRepository.GetEquipmentCategory(idBuscar.ToString());
                        f.tbIndexEquipmentCategories.Text = newEquipmentCategory.Index;
                        f.tbNameEquipmentCategories.Text = newEquipmentCategory.Name;
                        f.cbEquipmentEquipmentCategories.DataSource = newEquipmentCategory.Equipment;
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtModificarEquipmentCategories_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarEquipmentCategories.Text))
                {
                    string idBuscar = equipmentCategories.Where(a => a.Index.Equals(f.tbFiltrarEquipmentCategories.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        From selectedEquipment = (From)f.cbEquipmentEquipmentCategories.SelectedItem;
                        if (selectedEquipment != null)
                        {
                            EquipmentCategory eqCat = new EquipmentCategory();
                            eqCat.Id = idBuscar;
                            eqCat.Index = f.tbIndexEquipmentCategories.Text;
                            eqCat.Name = f.tbNameEquipmentCategories.Text;
                            eqCat.Equipment = new From[] { selectedEquipment };
                            EquipmentCategoriesRepository.UpdateEquipmentCategory(eqCat);
                            LoadDataEquipmentCategories();
                        }

                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres modificar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtInsertarEquipmentCategories_Click(object? sender, EventArgs e)
        {
            try
            {
                From selectedEquipment = (From)f.cbEquipmentEquipmentCategories.SelectedItem;
                if (selectedEquipment != null)
                {
                    EquipmentCategory eqCat = new EquipmentCategory();
                    eqCat.Index = f.tbIndexEquipmentCategories.Text;
                    eqCat.Name = f.tbNameEquipmentCategories.Text;
                    eqCat.Equipment = new From[] { selectedEquipment };
                    EquipmentCategoriesRepository.CreateEquipmentCategory(eqCat);
                    MessageBox.Show("");
                    LoadDataEquipmentCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtInsertarEquipmentCategories_MouseUp(object? sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    EquipmentCategory eqCat = new EquipmentCategory();
                    eqCat.Index = f.tbIndexEquipmentCategories.Text;
                    eqCat.Name = f.tbNameEquipmentCategories.Text;
                    From emptyEquipment = new From();
                    emptyEquipment.Index = string.Empty;
                    eqCat.Equipment = new From[] { emptyEquipment };
                    EquipmentCategoriesRepository.CreateEquipmentCategory(eqCat);
                    MessageBox.Show("Classes introducido sin equipment");
                    LoadDataEquipmentCategories();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtEliminarEquipmentCategories_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarEquipmentCategories.Text))
                {
                    string idBuscar = equipmentCategories.Where(a => a.Index.Equals(f.tbFiltrarEquipmentCategories.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        EquipmentCategoriesRepository.DeleteEquipmentCategory(idBuscar);
                        MessageBox.Show(f.tbIndexEquipmentCategories.Text.ToString() + " eliminado");
                        LoadDataEquipmentCategories();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres eliminar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        //Feat
        private void DgvFeats_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = f.dgvFeats.CurrentRow;
                if (row != null)
                {
                    Feats feat = (Feats)row.DataBoundItem;
                    f.tbIndexFeats.Text = feat.Index;
                    f.tbNameFeats.Text = feat.Name;
                    f.rtbDescriptionFeats.Text = feat.Description.FirstOrDefault();
                    f.cbPrerequisitesFeats.DataSource = feat.Prerequisites;
                    f.cbPrerequisitesFeats.DisplayMember = "MinimumScore";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtBuscarFeats_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarFeats.Text))
                {
                    string idBuscar = feats.Where(a => a.Index.Equals(f.tbFiltrarFeats.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        Feats feat = FeatsRepository.GetFeat(idBuscar.ToString());
                        f.tbIndexFeats.Text = feat.Index;
                        f.tbNameFeats.Text = feat.Name;
                        f.rtbDescriptionFeats.Text = feat.Description?.FirstOrDefault();
                        f.cbPrerequisitesFeats.DataSource = feat.Prerequisites;
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }

                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtInsertarFeats_Click(object? sender, EventArgs e)
        {
            try
            {
                Feats feat = new Feats();
                string index = f.tbIndexFeats.Text;
                string name = f.tbNameFeats.Text;
                string[] description = new string[] { f.rtbDescriptionFeats.Text };
                Prerequisites prerequisites = (Prerequisites)f.cbPrerequisitesFeats.SelectedItem;
                List<Prerequisites> prerequisitesList = new List<Prerequisites>();
                prerequisitesList.Add(prerequisites);
                if (prerequisites != null)
                {
                    feat.Index = index;
                    feat.Name = name;
                    feat.Description = description;
                    feat.Prerequisites = prerequisitesList.ToArray();
                    FeatsRepository.CreateFeat(feat);
                    MessageBox.Show("Feat añadido");
                    LoadDataFeat();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtInsertarFeats_MouseUp(object? sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Middle)
                {
                    Feats feat = new Feats();
                    string index = f.tbIndexFeats.Text;
                    string name = f.tbNameFeats.Text;
                    string[] description = new string[] { f.rtbDescriptionFeats.Text };
                    From emptyAbilityScore = new From();
                    emptyAbilityScore.Index = string.Empty;
                    emptyAbilityScore.Name = string.Empty;
                    Prerequisites prerequisites = new Prerequisites();
                    prerequisites.AbilityScore = emptyAbilityScore;
                    prerequisites.MinimumScore = 0;

                    List<Prerequisites> prerequisitesList = new List<Prerequisites>();
                    prerequisitesList.Add(prerequisites);

                    feat.Index = index;
                    feat.Name = name;
                    feat.Description = description;
                    feat.Prerequisites = prerequisitesList.ToArray();
                    FeatsRepository.CreateFeat(feat);
                    MessageBox.Show("Feat añadido");
                    LoadDataFeat();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtEliminarFeats_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarFeats.Text))
                {
                    string idBuscar = feats.Where(a => a.Index.Equals(f.tbFiltrarFeats.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        Feats feat = FeatsRepository.GetFeat(idBuscar.ToString());
                        MessageBox.Show(f.tbIndexFeats.Text.ToString() + " eliminado");
                        LoadDataFeat();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres eliminar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtModificarFeats_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarFeats.Text))
                {
                    string idBuscar = feats.Where(a => a.Index.Equals(f.tbFiltrarFeats.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        Feats feat = new Feats();
                        string index = f.tbIndexFeats.Text;
                        string name = f.tbNameFeats.Text;
                        string[] description = new string[] { f.rtbDescriptionFeats.Text };
                        Prerequisites prerequisites = (Prerequisites)f.cbPrerequisitesFeats.SelectedItem;
                        List<Prerequisites> prerequisitesList = new List<Prerequisites>();
                        prerequisitesList.Add(prerequisites);
                        if (prerequisites != null)
                        {
                            feat.Id = idBuscar;
                            feat.Index = index;
                            feat.Name = name;
                            feat.Description = description;
                            feat.Prerequisites = prerequisitesList.ToArray();
                            FeatsRepository.UpdateFeat(feat);
                            MessageBox.Show("Feat modificado");
                            LoadDataFeat();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        //Features
        private void DgvFeatures_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = f.dgvFeatures.CurrentRow;
                if (row != null)
                {
                    FeaturesDAO featureDAO = (FeaturesDAO)row.DataBoundItem;
                    Feature feature = FeaturesRepository.GetFeature(featureDAO.id);
                    f.tbIndexFeatures.Text = feature?.Index;
                    f.tbNameFeatures.Text = feature?.Name;
                    f.cbExpertiseOptionsInvocationsFeatures.DataSource = feature?.FeatureSpecific?.Invocations?.Name;
                    f.tbLevelFeatures.Text = feature?.level.ToString();
                    f.tbExpertiseOptionChooseFeature.Text = feature?.FeatureSpecific?.ExpertiseOption?.Choose.ToString();

                    List<From> featureClass = new List<From>();
                    featureClass.Add(feature?.Class);
                    f.dgvClassFeatures.DataSource = featureClass;

                    List<From> featureParent = new List<From>();
                    featureParent.Add(feature?.Parent);
                    f.dgvParentFeatures.DataSource = featureParent;

                    List<From> featureSubclass = new List<From>();
                    featureSubclass.Add(feature?.Subclass);
                    f.dgvSubclassFeatures.DataSource = featureSubclass;

                    //ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromIndex
                    var indexList = new List<string>();
                    if (feature?.FeatureSpecific?.ExpertiseOption?.From?.Any() ?? false)
                    {
                        var expertiseOptions = feature.FeatureSpecific.ExpertiseOption.From;

                        foreach (var option in expertiseOptions)
                        {
                            if (option?.Items?.Choice?.Item?.Any() ?? false)
                            {
                                var items = option.Items.Choice.Item;

                                foreach (var item in items)
                                {
                                    if (item?.Index?.Any() ?? false)
                                    {
                                        indexList.AddRange(item.Index.ToList());
                                    }
                                }
                            }
                        }
                    }

                    f.dgvExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureIndex.DataSource = indexList;

                    //ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromName
                    var nameList = new List<string>();
                    if (feature?.FeatureSpecific?.ExpertiseOption?.From?.Any() ?? false)
                    {
                        var expertiseOptions = feature.FeatureSpecific.ExpertiseOption.From;

                        foreach (var option in expertiseOptions)
                        {
                            if (option?.Items?.Choice?.Item?.Any() ?? false)
                            {
                                var items = option.Items.Choice.Item;

                                foreach (var item in items)
                                {
                                    if (item?.Name?.Any() ?? false)
                                    {
                                        nameList.AddRange(item.Name.ToList());
                                    }
                                }
                            }
                        }
                    }

                    f.dgvExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureName.DataSource = nameList;

                    //ExpertiseOptionFromFeatureChoiceFeatureFroms
                    f.dgvExpertiseOptionsFromFeatureChoiceFeatureFromsFeature.DataSource = feature?.FeatureSpecific?.ExpertiseOption?.From?.SelectMany(a => a.Choice?.Froms?.ToList());

                    //ExpertiseOptionsSubfeaturesOptionsFrom
                    f.dgvExpertiseOptionsSubfeaturesOptionsFromFeatures.DataSource = feature?.FeatureSpecific?.SubfeatureOptions?.From?.ToList();

                    //PrerequisiteFeature
                    f.dgvPrerequisitesFeatures.DataSource = feature?.PrerequisiteFeatures?.ToList();

                    List<string> indexList2 = new List<string>();
                    List<string> nameList2 = new List<string>();

                    if (feature?.FeatureSpecific?.ExpertiseOption?.From != null)
                    {
                        foreach (var from in feature.FeatureSpecific.ExpertiseOption.From)
                        {
                            if (from.Items != null && from.Items.Item != null)
                            {
                                indexList2.AddRange(from.Items.Item.Index.Select(a => a).ToList());
                                nameList2.AddRange(from.Items.Item.Name);
                            }
                        }
                    }

                    f.dgvExpertiseOptionsFromFeatureItemsFeatureArrayedFromIndexFeature.DataSource = indexList;
                    f.dgvExpertiseOptionsFromFeatureItemsFeatureArrayedFromNameFeature.DataSource = nameList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtInsertarFeatures_Click(object? sender, EventArgs e)
        {
            try
            {
                string index = f.tbIndexFeatures.Text;
                string name = f.tbNameFeatures.Text;
                string featureSpecificInvocations = f.cbExpertiseOptionsInvocationsFeatures.Text;
                string level = f.tbLevelFeatures.Text;
                string[] description = new string[] { f.rtbDescriptionFeatures.Text };
                string expertiseOptionsFromFeatureIndex = f.tbExpertiseOptionsFromFeatureIndex.Text;
                string expertiseOptionsFromFeatureName = f.tbExpertiseOptionsFromFeatureName.Text;

                Feature insertarFeature = new Feature();

                if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(level))
                {
                    insertarFeature.Index = index;
                    insertarFeature.Name = name;
                    insertarFeature.level = int.Parse(level);
                    insertarFeature.Description = description;

                    // Prerequisites
                    DataGridViewRow prerequisitesRow = f.dgvPrerequisitesFeatures.CurrentRow;
                    if (prerequisitesRow != null)
                    {
                        PrerequisiteFeature prerequisiteFeature = (PrerequisiteFeature)prerequisitesRow.DataBoundItem;
                        insertarFeature.PrerequisiteFeatures = new[] { prerequisiteFeature };
                    }
                    else
                    {
                        insertarFeature.PrerequisiteFeatures = new PrerequisiteFeature[] { new PrerequisiteFeature() };
                    }

                    // Parent
                    DataGridViewRow parentRow = f.dgvParentFeatures.CurrentRow;
                    if (parentRow != null)
                    {
                        From parent = (From)parentRow.DataBoundItem;
                        insertarFeature.Parent = parent;
                    }
                    else
                    {
                        insertarFeature.Parent = new From { Index = string.Empty, Name = string.Empty };
                    }

                    // Subclass
                    DataGridViewRow subclassRow = f.dgvSubclassFeatures.CurrentRow;
                    if (subclassRow != null)
                    {
                        From subclass = (From)subclassRow.DataBoundItem;
                        insertarFeature.Subclass = subclass;
                    }
                    else
                    {
                        insertarFeature.Subclass = new From { Index = string.Empty, Name = string.Empty };
                    }

                    // Class
                    DataGridViewRow classRow = f.dgvClassFeatures.CurrentRow;
                    if (classRow != null)
                    {
                        From Class = (From)classRow.DataBoundItem;
                        insertarFeature.Class = Class;
                    }
                    else
                    {
                        insertarFeature.Class = new From { Index = string.Empty, Name = string.Empty };
                    }

                    // Expertise Options
                    DataGridViewRow expertiseOptionsChooseRow = f.dgvExpertiseOptionsFromFeatureChoiceFeatureFromsFeature.CurrentRow;
                    if (expertiseOptionsChooseRow != null)
                    {
                        ExpertiseOptionFeature expertiseOptionFeature = new ExpertiseOptionFeature();
                        expertiseOptionFeature.Choose = int.Parse(f.tbExpertiseOptionChooseFeature.Text);
                        expertiseOptionFeature.From = ((ExpertiseOptionFromFeature[])expertiseOptionsChooseRow.DataBoundItem);
                        insertarFeature.FeatureSpecific = new FeatureSpecific { ExpertiseOption = expertiseOptionFeature };
                    }
                    else
                    {
                        insertarFeature.FeatureSpecific = new FeatureSpecific { ExpertiseOption = new ExpertiseOptionFeature() };
                    }

                    // Expertise Options Subfeature Options
                    DataGridViewRow expertiseOptionSubfeatureOptionsRow = f.dgvExpertiseOptionsSubfeaturesOptionsFromFeatures.CurrentRow;
                    if (expertiseOptionSubfeatureOptionsRow != null)
                    {
                        From[] expertiseOptionSubfeatureOptions = (From[])expertiseOptionSubfeatureOptionsRow.DataBoundItem;

                        insertarFeature.FeatureSpecific.SubfeatureOptions = new SubFeatureOptions { From = expertiseOptionSubfeatureOptions.ToArray() };
                    }
                    else
                    {
                        insertarFeature.FeatureSpecific.SubfeatureOptions = new SubFeatureOptions { From = new List<From>().ToArray() };
                    }

                    // Expertise Options From Feature Items
                    DataGridViewRow ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureIndex = f.dgvExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureIndex.CurrentRow;
                    DataGridViewRow ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureName = f.dgvExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureName.CurrentRow;
                    DataGridViewRow ExpertiseOptionsFromFeatureItemsFeatureArrayedFromIndexFeature = f.dgvExpertiseOptionsFromFeatureItemsFeatureArrayedFromIndexFeature.CurrentRow;
                    DataGridViewRow ExpertiseOptionsFromFeatureItemsFeatureArrayedFromNameFeature = f.dgvExpertiseOptionsFromFeatureItemsFeatureArrayedFromNameFeature.CurrentRow;

                    if (ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureIndex != null && ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureName != null)
                    {
                        ArrayedFrom arrayedFrom = new ArrayedFrom();
                        arrayedFrom.Index = new[] { ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureIndex.Cells[0].Value.ToString() };
                        arrayedFrom.Name = new[] { ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureName.Cells[0].Value.ToString() };

                        ItemsFeature itemsFeature = new ItemsFeature();
                        itemsFeature.Choice = new ItemsChoiceFeature();
                        itemsFeature.Choice.Item = new ArrayedFrom[] { arrayedFrom };

                        ExpertiseOptionFromFeature expertiseOptionFromFeature = new ExpertiseOptionFromFeature();
                        expertiseOptionFromFeature.Items = itemsFeature;

                        insertarFeature.FeatureSpecific.ExpertiseOption.From = new[] { expertiseOptionFromFeature };
                    }
                    else if (ExpertiseOptionsFromFeatureItemsFeatureArrayedFromIndexFeature != null && ExpertiseOptionsFromFeatureItemsFeatureArrayedFromNameFeature != null)
                    {
                        ArrayedFrom arrayedFrom = new ArrayedFrom();
                        arrayedFrom.Index = new[] { ExpertiseOptionsFromFeatureItemsFeatureArrayedFromIndexFeature.Cells[0].Value.ToString() };
                        arrayedFrom.Name = new[] { ExpertiseOptionsFromFeatureItemsFeatureArrayedFromNameFeature.Cells[0].Value.ToString() };

                        ExpertiseOptionFromFeature expertiseOptionFromFeature = new ExpertiseOptionFromFeature();
                        expertiseOptionFromFeature.Items = new ItemsFeature();
                        expertiseOptionFromFeature.Items.Choice = new ItemsChoiceFeature();
                        expertiseOptionFromFeature.Items.Choice.Item = new ArrayedFrom[] { arrayedFrom };

                        insertarFeature.FeatureSpecific.ExpertiseOption.From = new[] { expertiseOptionFromFeature };
                    }
                    else
                    {
                        insertarFeature.FeatureSpecific.ExpertiseOption.From = new ExpertiseOptionFromFeature[] { new ExpertiseOptionFromFeature() };
                    }
                }
                // Insertar la feature en la base de datos
                FeaturesRepository.CreateFeature(insertarFeature);
                MessageBox.Show("Has insertado Feature");
                LoadDataFeatures();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtInsertarFeatures_MouseUp(object? sender, MouseEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtBuscarFeatures_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarFeatures.Text))
                {
                    string idBuscar = features.Where(a => a.Index.Equals(f.tbFiltrarFeatures.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        Feature feature = FeaturesRepository.GetFeature(idBuscar);
                        f.tbIndexFeatures.Text = feature?.Index;
                        f.tbNameFeatures.Text = feature?.Name;
                        f.cbExpertiseOptionsInvocationsFeatures.DataSource = feature?.FeatureSpecific?.Invocations?.Name;
                        f.tbLevelFeatures.Text = feature?.level.ToString();
                        f.tbExpertiseOptionChooseFeature.Text = feature?.FeatureSpecific?.ExpertiseOption?.Choose.ToString();

                        List<From> featureClass = new List<From>();
                        featureClass.Add(feature?.Class);
                        f.dgvClassFeatures.DataSource = featureClass;

                        List<From> featureParent = new List<From>();
                        featureParent.Add(feature?.Parent);
                        f.dgvParentFeatures.DataSource = featureParent;

                        List<From> featureSubclass = new List<From>();
                        featureSubclass.Add(feature?.Subclass);
                        f.dgvSubclassFeatures.DataSource = featureSubclass;

                        //ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromIndex
                        var indexList = new List<string>();
                        if (feature?.FeatureSpecific?.ExpertiseOption?.From?.Any() ?? false)
                        {
                            var expertiseOptions = feature.FeatureSpecific.ExpertiseOption.From;

                            foreach (var option in expertiseOptions)
                            {
                                if (option?.Items?.Choice?.Item?.Any() ?? false)
                                {
                                    var items = option.Items.Choice.Item;

                                    foreach (var item in items)
                                    {
                                        if (item?.Index?.Any() ?? false)
                                        {
                                            indexList.AddRange(item.Index.ToList());
                                        }
                                    }
                                }
                            }
                        }

                        f.dgvExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureIndex.DataSource = indexList;

                        //ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromName
                        var nameList = new List<string>();
                        if (feature?.FeatureSpecific?.ExpertiseOption?.From?.Any() ?? false)
                        {
                            var expertiseOptions = feature.FeatureSpecific.ExpertiseOption.From;

                            foreach (var option in expertiseOptions)
                            {
                                if (option?.Items?.Choice?.Item?.Any() ?? false)
                                {
                                    var items = option.Items.Choice.Item;

                                    foreach (var item in items)
                                    {
                                        if (item?.Name?.Any() ?? false)
                                        {
                                            nameList.AddRange(item.Name.ToList());
                                        }
                                    }
                                }
                            }
                        }

                        f.dgvExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureName.DataSource = nameList;

                        //ExpertiseOptionFromFeatureChoiceFeatureFroms
                        f.dgvExpertiseOptionsFromFeatureChoiceFeatureFromsFeature.DataSource = feature?.FeatureSpecific?.ExpertiseOption?.From?.SelectMany(a => a.Choice?.Froms?.ToList());

                        //ExpertiseOptionsSubfeaturesOptionsFrom
                        f.dgvExpertiseOptionsSubfeaturesOptionsFromFeatures.DataSource = feature?.FeatureSpecific?.SubfeatureOptions?.From?.ToList();

                        //PrerequisiteFeature
                        f.dgvPrerequisitesFeatures.DataSource = feature?.PrerequisiteFeatures?.ToList();

                        List<string> indexList2 = new List<string>();
                        List<string> nameList2 = new List<string>();

                        if (feature?.FeatureSpecific?.ExpertiseOption?.From != null)
                        {
                            foreach (var from in feature.FeatureSpecific.ExpertiseOption.From)
                            {
                                if (from.Items != null && from.Items.Item != null)
                                {
                                    indexList2.AddRange(from.Items.Item.Index.Select(a => a).ToList());
                                    nameList2.AddRange(from.Items.Item.Name);
                                }
                            }
                        }

                        f.dgvExpertiseOptionsFromFeatureItemsFeatureArrayedFromIndexFeature.DataSource = indexList;
                        f.dgvExpertiseOptionsFromFeatureItemsFeatureArrayedFromNameFeature.DataSource = nameList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtModificarFeatures_Click(object? sender, EventArgs e)
        {
            try
            {
                string index = f.tbIndexFeatures.Text;
                string name = f.tbNameFeatures.Text;
                string featureSpecificInvocations = f.cbExpertiseOptionsInvocationsFeatures.Text;
                string level = f.tbLevelFeatures.Text;
                string[] description = new string[] { f.rtbDescriptionFeatures.Text };
                string expertiseOptionsFromFeatureIndex = f.tbExpertiseOptionsFromFeatureIndex.Text;
                string expertiseOptionsFromFeatureName = f.tbExpertiseOptionsFromFeatureName.Text;

                Feature modificarFeature = new Feature();

                if (!string.IsNullOrEmpty(f.tbFiltrarFeatures.Text))
                {
                    string idBuscar = features.Where(a => a.Index.Equals(f.tbFiltrarFeatures.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(level))
                        {
                            modificarFeature.Id = idBuscar;
                            modificarFeature.Index = index;
                            modificarFeature.Name = name;
                            modificarFeature.level = int.Parse(level);
                            modificarFeature.Description = description;

                            // Prerequisites
                            DataGridViewRow prerequisitesRow = f.dgvPrerequisitesFeatures.CurrentRow;
                            if (prerequisitesRow != null)
                            {
                                PrerequisiteFeature prerequisiteFeature = (PrerequisiteFeature)prerequisitesRow.DataBoundItem;
                                modificarFeature.PrerequisiteFeatures = new[] { prerequisiteFeature };
                            }
                            else
                            {
                                modificarFeature.PrerequisiteFeatures = new PrerequisiteFeature[] { new PrerequisiteFeature() };
                            }

                            // Parent
                            DataGridViewRow parentRow = f.dgvParentFeatures.CurrentRow;
                            if (parentRow != null)
                            {
                                From parent = (From)parentRow.DataBoundItem;
                                modificarFeature.Parent = parent;
                            }
                            else
                            {
                                modificarFeature.Parent = new From { Index = string.Empty, Name = string.Empty };
                            }

                            // Subclass
                            DataGridViewRow subclassRow = f.dgvSubclassFeatures.CurrentRow;
                            if (subclassRow != null)
                            {
                                From subclass = (From)subclassRow.DataBoundItem;
                                modificarFeature.Subclass = subclass;
                            }
                            else
                            {
                                modificarFeature.Subclass = new From { Index = string.Empty, Name = string.Empty };
                            }

                            // Class
                            DataGridViewRow classRow = f.dgvClassFeatures.CurrentRow;
                            if (classRow != null)
                            {
                                From Class = (From)classRow.DataBoundItem;
                                modificarFeature.Class = Class;
                            }
                            else
                            {
                                modificarFeature.Class = new From { Index = string.Empty, Name = string.Empty };
                            }

                            // Expertise Options
                            DataGridViewRow expertiseOptionsChooseRow = f.dgvExpertiseOptionsFromFeatureChoiceFeatureFromsFeature.CurrentRow;
                            if (expertiseOptionsChooseRow != null)
                            {
                                ExpertiseOptionFeature expertiseOptionFeature = new ExpertiseOptionFeature();
                                expertiseOptionFeature.Choose = int.Parse(f.tbExpertiseOptionChooseFeature.Text);
                                expertiseOptionFeature.From = ((ExpertiseOptionFromFeature[])expertiseOptionsChooseRow.DataBoundItem);
                                modificarFeature.FeatureSpecific = new FeatureSpecific { ExpertiseOption = expertiseOptionFeature };
                            }
                            else
                            {
                                modificarFeature.FeatureSpecific = new FeatureSpecific { ExpertiseOption = new ExpertiseOptionFeature() };
                            }

                            // Expertise Options Subfeature Options
                            DataGridViewRow expertiseOptionSubfeatureOptionsRow = f.dgvExpertiseOptionsSubfeaturesOptionsFromFeatures.CurrentRow;
                            if (expertiseOptionSubfeatureOptionsRow != null)
                            {
                                From[] expertiseOptionSubfeatureOptions = (From[])expertiseOptionSubfeatureOptionsRow.DataBoundItem;
                                modificarFeature.FeatureSpecific.SubfeatureOptions = new SubFeatureOptions { From = expertiseOptionSubfeatureOptions.ToArray() };
                            }
                            else
                            {
                                modificarFeature.FeatureSpecific.SubfeatureOptions = new SubFeatureOptions { From = new List<From>().ToArray() };
                            }

                            // Expertise Options From Feature Items
                            DataGridViewRow ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureIndex = f.dgvExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureIndex.CurrentRow;
                            DataGridViewRow ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureName = f.dgvExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureName.CurrentRow;
                            DataGridViewRow ExpertiseOptionsFromFeatureItemsFeatureArrayedFromIndexFeature = f.dgvExpertiseOptionsFromFeatureItemsFeatureArrayedFromIndexFeature.CurrentRow;
                            DataGridViewRow ExpertiseOptionsFromFeatureItemsFeatureArrayedFromNameFeature = f.dgvExpertiseOptionsFromFeatureItemsFeatureArrayedFromNameFeature.CurrentRow;

                            if (ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureIndex != null && ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureName != null)
                            {
                                ArrayedFrom arrayedFrom = new ArrayedFrom();
                                arrayedFrom.Index = new[] { ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureIndex.Cells[0].Value.ToString() };
                                arrayedFrom.Name = new[] { ExpertiseOptionsFromFeatureItemsFeatureItemsChoiceFeatureArrayedFromFeatureName.Cells[0].Value.ToString() };

                                ItemsFeature itemsFeature = new ItemsFeature();
                                itemsFeature.Choice = new ItemsChoiceFeature();
                                itemsFeature.Choice.Item = new ArrayedFrom[] { arrayedFrom };

                                ExpertiseOptionFromFeature expertiseOptionFromFeature = new ExpertiseOptionFromFeature();
                                expertiseOptionFromFeature.Items = itemsFeature;

                                modificarFeature.FeatureSpecific.ExpertiseOption.From = new[] { expertiseOptionFromFeature };
                            }
                            else if (ExpertiseOptionsFromFeatureItemsFeatureArrayedFromIndexFeature != null && ExpertiseOptionsFromFeatureItemsFeatureArrayedFromNameFeature != null)
                            {
                                ArrayedFrom arrayedFrom = new ArrayedFrom();
                                arrayedFrom.Index = new[] { ExpertiseOptionsFromFeatureItemsFeatureArrayedFromIndexFeature.Cells[0].Value.ToString() };
                                arrayedFrom.Name = new[] { ExpertiseOptionsFromFeatureItemsFeatureArrayedFromNameFeature.Cells[0].Value.ToString() };

                                ExpertiseOptionFromFeature expertiseOptionFromFeature = new ExpertiseOptionFromFeature();
                                expertiseOptionFromFeature.Items = new ItemsFeature();
                                expertiseOptionFromFeature.Items.Choice = new ItemsChoiceFeature();
                                expertiseOptionFromFeature.Items.Choice.Item = new ArrayedFrom[] { arrayedFrom };

                                modificarFeature.FeatureSpecific.ExpertiseOption.From = new[] { expertiseOptionFromFeature };
                            }
                            else
                            {
                                modificarFeature.FeatureSpecific.ExpertiseOption.From = new ExpertiseOptionFromFeature[] { new ExpertiseOptionFromFeature() };
                            }
                        }
                        // Insertar la feature en la base de datos
                        FeaturesRepository.UpdateFeature(modificarFeature);
                        MessageBox.Show("Has modificado Feature");
                        LoadDataFeatures();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtEliminarFeatures_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarFeatures.Text))
                {
                    string idBuscar = features.Where(a => a.Index.Equals(f.tbFiltrarFeatures.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        FeaturesRepository.DeleteFeature(idBuscar);
                        MessageBox.Show(f.tbFiltrarFeatures.Text.ToString() + " eliminado");
                        LoadDataFeatures();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        //Languages
        private void DgvLanguages_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = f.dgvLanguages.CurrentRow;
                if (row != null)
                {
                    Language language = LanguageRepository.GetLanguage(((Language)row.DataBoundItem).Id);
                    f.tbIndexLanguages.Text = language?.Index;
                    f.tbNameLanguages.Text = language?.Name;
                    f.rtbTypicalSpeakersLanguages.Text = language?.TypicalSpeakers?.FirstOrDefault();
                    f.tbDescriptionLanguages.Text = language?.Description;
                    f.tbScriptLanguages.Text = language?.Script;
                    f.tbTypeLanguages.Text = language?.Type;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtBuscarLanguages_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarLanguages.Text))
                {
                    string idBuscar = languages.Where(a => a.Index.Equals(f.tbFiltrarLanguages.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        Language language = LanguageRepository.GetLanguage(idBuscar);
                        f.tbIndexLanguages.Text = language?.Index;
                        f.tbNameLanguages.Text = language?.Name;
                        f.rtbTypicalSpeakersLanguages.Text = language?.TypicalSpeakers?.FirstOrDefault();
                        f.tbDescriptionLanguages.Text = language?.Description;
                        f.tbScriptLanguages.Text = language?.Script;
                        f.tbTypeLanguages.Text = language?.Type;
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtInsertarLanguages_Click(object? sender, EventArgs e)
        {
            try
            {
                Language languageInsertar = new Language();
                string index = f.tbIndexLanguages.Text;
                string name = f.tbNameLanguages.Text;
                string[] typicalSpeackers = new string[] { f.rtbTypicalSpeakersLanguages.Text };
                string description = f.tbDescriptionLanguages.Text;
                string script = f.tbScriptLanguages.Text;
                string type = f.tbTypeLanguages.Text;
                languageInsertar.Index = index;
                languageInsertar.Name = name;
                languageInsertar.TypicalSpeakers = typicalSpeackers;
                languageInsertar.Description = description;
                languageInsertar.Script = script;
                languageInsertar.Type = type;
                LanguageRepository.CreateLanguage(languageInsertar);
                LoadDataLanguages();
                MessageBox.Show("Has insertardo Language");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtEliminarLanguages_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarLanguages.Text))
                {
                    string idBuscar = languages.Where(a => a.Index.Equals(f.tbFiltrarLanguages.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        LanguageRepository.DeleteLanguage(idBuscar);
                        MessageBox.Show("Has eliminado " + f.tbFiltrarLanguages.Text.ToString());
                        LoadDataLanguages();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres eliminar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtModificarLanguages_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarLanguages.Text))
                {
                    string idBuscar = languages.Where(a => a.Index.Equals(f.tbFiltrarLanguages.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        Language languageModificar = new Language();
                        string index = f.tbIndexLanguages.Text;
                        string name = f.tbNameLanguages.Text;
                        string[] typicalSpeackers = new string[] { f.rtbTypicalSpeakersLanguages.Text };
                        string description = f.tbDescriptionLanguages.Text;
                        string script = f.tbScriptLanguages.Text;
                        string type = f.tbTypeLanguages.Text;
                        languageModificar.Id = idBuscar;
                        languageModificar.Index = index;
                        languageModificar.Name = name;
                        languageModificar.TypicalSpeakers = typicalSpeackers;
                        languageModificar.Description = description;
                        languageModificar.Script = script;
                        languageModificar.Type = type;
                        LanguageRepository.UpdateLanguage(languageModificar);
                        MessageBox.Show("Has modificado " + f.tbFiltrarLanguages.Text.ToString());
                        LoadDataLanguages();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres modificar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        //Levels
        private void DgvLevels_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = f.dgvLevels.CurrentRow;
                if (row != null)
                {
                    Level level = LevelRepository.GetLevel(((Level)row.DataBoundItem).Id);
                    f.tbIndexLevels.Text = level?.Index;
                    f.tbAbilityScoreBonusesLevels.Text = level?.AbilityScoreBonuses?.ToString();
                    f.tbLevelLevels.Text = level?.LevelN?.ToString();
                    f.tbProfBonusLevels.Text = level?.ProficiencyBonus?.ToString();
                    f.tbClassIndexLevels.Text = level?.Class?.Index;
                    f.tbClassNameLevels.Text = level?.Class?.Name;
                    f.tbSubclassIndexLevels.Text = level?.Subclass?.Index;
                    f.tbSubclassNameLevels.Text = level?.Subclass?.Name;
                    f.cbFeaturesIndexLevels.SelectedIndex = f.cbFeaturesIndexLevels.FindString(level?.Features.SelectMany(a => a.Index)?.FirstOrDefault());
                    f.cbFeaturesNameLevels.SelectedIndex = f.cbFeaturesNameLevels.FindString(level?.Features.SelectMany(a => a.Name)?.FirstOrDefault());

                    BuscarYSeleccionarClassSpecificLevel(level?.ClassSpecific);
                    BuscarYSeleccionarCreatingSpellSlots(level?.ClassSpecific);
                    BuscarYSeleccionarMartialArts(level?.ClassSpecific);
                    BuscarYSeleccionarSneakAttack(level?.ClassSpecific);
                    BuscarYSeleccionarSpellcasting(level?.Spellcasting);
                    BuscarYSeleccionarSubcategories(level?.Subcategories);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BuscarYSeleccionarClassSpecificLevel(ClassSpecificLevel classSpecific)
        {
            // Buscar el objeto Level que contiene el ClassSpecificLevel dado
            Level? level = levels?.FirstOrDefault(a =>
                a.ClassSpecific?.ActionSurge == classSpecific?.ActionSurge &&
                a.ClassSpecific?.ArcaneRecoveryLevel == classSpecific?.ArcaneRecoveryLevel &&
                a.ClassSpecific?.AuraRange == classSpecific?.AuraRange &&
                a.ClassSpecific?.BardicInspirationDie == classSpecific?.BardicInspirationDie &&
                a.ClassSpecific?.BrutalCriticalDie == classSpecific?.BrutalCriticalDie &&
                a.ClassSpecific?.ChannelDivinityCharges == classSpecific?.ChannelDivinityCharges &&
                CompareCreatingSpellSlots(a.ClassSpecific?.CreatingSpellSlots, classSpecific?.CreatingSpellSlots) &&
                a.ClassSpecific?.DestroyUndeadCr == classSpecific?.DestroyUndeadCr &&
                a.ClassSpecific?.ExtraAttacks == classSpecific?.ExtraAttacks &&
                a.ClassSpecific?.FavoredEnemies == classSpecific?.FavoredEnemies &&
                a.ClassSpecific?.FavoredTerrain == classSpecific?.FavoredTerrain &&
                a.ClassSpecific?.IndomitableUses == classSpecific?.IndomitableUses &&
                a.ClassSpecific?.InvocationsKnown == classSpecific?.InvocationsKnown &&
                a.ClassSpecific?.KiPoints == classSpecific?.KiPoints &&
                a.ClassSpecific?.MagicSecretsMax5 == classSpecific?.MagicSecretsMax5 &&
                a.ClassSpecific?.MagicSecretsMax7 == classSpecific?.MagicSecretsMax7 &&
                a.ClassSpecific?.MagicSecretsMax9 == classSpecific?.MagicSecretsMax9 &&
                a.ClassSpecific?.MartialArts?.DiceValues == classSpecific?.MartialArts?.DiceValues &&
                a.ClassSpecific?.MartialArts?.DiceCount == classSpecific?.MartialArts?.DiceCount &&
                a.ClassSpecific?.MetamagicKnown == classSpecific?.MetamagicKnown &&
                a.ClassSpecific?.MysticArcanumLevel6 == classSpecific?.MysticArcanumLevel6 &&
                a.ClassSpecific?.MysticArcanumLevel7 == classSpecific?.MysticArcanumLevel7 &&
                a.ClassSpecific?.MysticArcanumLevel8 == classSpecific?.MysticArcanumLevel8 &&
                a.ClassSpecific?.MysticArcanumLevel9 == classSpecific?.MysticArcanumLevel9 &&
                a.ClassSpecific?.RageCount == classSpecific?.RageCount &&
                a.ClassSpecific?.RageDamaageBonus == classSpecific?.RageDamaageBonus &&
                a.ClassSpecific?.SneakAttack?.DiceCount == classSpecific?.SneakAttack?.DiceCount &&
                a.ClassSpecific?.SneakAttack?.DiceValues == classSpecific?.SneakAttack?.DiceValues &&
                a.ClassSpecific?.SongOfRestDie == classSpecific?.SongOfRestDie &&
                a.ClassSpecific?.SorceryPoints == classSpecific?.SorceryPoints &&
                a.ClassSpecific?.UnarmoredMovement == classSpecific?.UnarmoredMovement &&
                a.ClassSpecific?.WildShapeFly == classSpecific?.WildShapeFly &&
                a.ClassSpecific?.WildShapeMaxCr == classSpecific?.WildShapeMaxCr &&
                a.ClassSpecific?.WildShapeSwim == classSpecific?.WildShapeSwim
            );

            if (level != null)
            {
                // Encontrado, ahora seleccionamos la fila en el DataGridView
                int rowIndex = levels.IndexOf(level);
                if (rowIndex != -1)
                {
                    // Si rowIndex es -1, significa que el objeto no se encuentra en la lista
                    f.dgvClassEspecificLevels.Rows[rowIndex].Selected = true;
                    f.dgvClassEspecificLevels.FirstDisplayedScrollingRowIndex = rowIndex; // Desplazamos el DataGridView a la fila seleccionada
                }
            }
            else
            {
                MessageBox.Show("El objeto ClassSpecificLevel no está contenido en ningún objeto Level.");
            }
        }
        private bool CompareCreatingSpellSlots(CreatingSpellSlotsLevel[]? a, CreatingSpellSlotsLevel[]? b)
        {
            if (a != null && b != null)
            {
                if (a == null && b == null)
                    return true;

                if (a == null || b == null || a.Length != b.Length)
                    return false;

                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i].SorceryPointCost != b[i].SorceryPointCost || a[i].SpellSlotLevel != b[i].SpellSlotLevel)
                        return false;
                }
            }
            return true;
        }
        private void BuscarYSeleccionarCreatingSpellSlots(ClassSpecificLevel classSpecific)
        {
            Level level = levels?.FirstOrDefault(a => CompareCreatingSpellSlots(a.ClassSpecific?.CreatingSpellSlots, classSpecific?.CreatingSpellSlots));
            if (level != null)
            {
                // Encontrado, ahora seleccionamos la fila en el DataGridView
                int rowIndex = levels.IndexOf(level);
                if (rowIndex != -1)
                {
                    // Si rowIndex es -1, significa que el objeto no se encuentra en la lista
                    f.dgvClassSpecificCreatingSpellSlotsLevels.Rows[rowIndex].Selected = true;
                    f.dgvClassSpecificCreatingSpellSlotsLevels.FirstDisplayedScrollingRowIndex = rowIndex; // Desplazamos el DataGridView a la fila seleccionada
                }
            }
            else
            {
                MessageBox.Show("El objeto CreatingSpellSlotsLevel no está contenido en ningún objeto Level.");
            }
        }
        private void BuscarYSeleccionarMartialArts(ClassSpecificLevel classSpecific)
        {
            // Buscar el objeto Level que contiene el ClassSpecificLevel dado
            Level? level = levels?.FirstOrDefault(a =>
                a.ClassSpecific?.ActionSurge == classSpecific?.ActionSurge &&
                a.ClassSpecific?.ArcaneRecoveryLevel == classSpecific?.ArcaneRecoveryLevel &&
                a.ClassSpecific?.AuraRange == classSpecific?.AuraRange &&
                a.ClassSpecific?.BardicInspirationDie == classSpecific?.BardicInspirationDie &&
                a.ClassSpecific?.BrutalCriticalDie == classSpecific?.BrutalCriticalDie &&
                a.ClassSpecific?.ChannelDivinityCharges == classSpecific?.ChannelDivinityCharges &&
                CompareCreatingSpellSlots(a.ClassSpecific?.CreatingSpellSlots, classSpecific?.CreatingSpellSlots) &&
                a.ClassSpecific?.DestroyUndeadCr == classSpecific?.DestroyUndeadCr &&
                a.ClassSpecific?.ExtraAttacks == classSpecific?.ExtraAttacks &&
                a.ClassSpecific?.FavoredEnemies == classSpecific?.FavoredEnemies &&
                a.ClassSpecific?.FavoredTerrain == classSpecific?.FavoredTerrain &&
                a.ClassSpecific?.IndomitableUses == classSpecific?.IndomitableUses &&
                a.ClassSpecific?.InvocationsKnown == classSpecific?.InvocationsKnown &&
                a.ClassSpecific?.KiPoints == classSpecific?.KiPoints &&
                a.ClassSpecific?.MagicSecretsMax5 == classSpecific?.MagicSecretsMax5 &&
                a.ClassSpecific?.MagicSecretsMax7 == classSpecific?.MagicSecretsMax7 &&
                a.ClassSpecific?.MagicSecretsMax9 == classSpecific?.MagicSecretsMax9 &&
                CompareMartialArts(a.ClassSpecific?.MartialArts, classSpecific?.MartialArts) &&
                a.ClassSpecific?.MetamagicKnown == classSpecific?.MetamagicKnown &&
                a.ClassSpecific?.MysticArcanumLevel6 == classSpecific?.MysticArcanumLevel6 &&
                a.ClassSpecific?.MysticArcanumLevel7 == classSpecific?.MysticArcanumLevel7 &&
                a.ClassSpecific?.MysticArcanumLevel8 == classSpecific?.MysticArcanumLevel8 &&
                a.ClassSpecific?.MysticArcanumLevel9 == classSpecific?.MysticArcanumLevel9 &&
                a.ClassSpecific?.RageCount == classSpecific?.RageCount &&
                a.ClassSpecific?.RageDamaageBonus == classSpecific?.RageDamaageBonus &&
                a.ClassSpecific?.SneakAttack?.DiceCount == classSpecific?.SneakAttack?.DiceCount &&
                a.ClassSpecific?.SneakAttack?.DiceValues == classSpecific?.SneakAttack?.DiceValues &&
                a.ClassSpecific?.SongOfRestDie == classSpecific?.SongOfRestDie &&
                a.ClassSpecific?.SorceryPoints == classSpecific?.SorceryPoints &&
                a.ClassSpecific?.UnarmoredMovement == classSpecific?.UnarmoredMovement &&
                a.ClassSpecific?.WildShapeFly == classSpecific?.WildShapeFly &&
                a.ClassSpecific?.WildShapeMaxCr == classSpecific?.WildShapeMaxCr &&
                a.ClassSpecific?.WildShapeSwim == classSpecific?.WildShapeSwim
            );

            if (level != null)
            {
                // Encontrado, ahora seleccionamos la fila en el DataGridView
                int rowIndex = levels.IndexOf(level);
                if (rowIndex != -1)
                {
                    // Si rowIndex es -1, significa que el objeto no se encuentra en la lista
                    f.dgvClassSpecificMartialArtsLevels.Rows[rowIndex].Selected = true;
                    f.dgvClassSpecificMartialArtsLevels.FirstDisplayedScrollingRowIndex = rowIndex; // Desplazamos el DataGridView a la fila seleccionada
                }
            }
            else
            {
                MessageBox.Show("El objeto MartialArts no está contenido en ningún objeto Level.");
            }
        }
        private bool CompareMartialArts(DiceCountValueCommon? a, DiceCountValueCommon? b)
        {
            if (a == null && b == null)
                return true;

            if (a == null || b == null)
                return false;

            return a.DiceCount == b.DiceCount && a.DiceValues == b.DiceValues;
        }
        private void BuscarYSeleccionarSneakAttack(ClassSpecificLevel classSpecific)
        {
            // Buscar el objeto Level que contiene el ClassSpecificLevel dado
            Level? level = levels?.FirstOrDefault(a =>
                a.ClassSpecific?.ActionSurge == classSpecific?.ActionSurge &&
                a.ClassSpecific?.ArcaneRecoveryLevel == classSpecific?.ArcaneRecoveryLevel &&
                a.ClassSpecific?.AuraRange == classSpecific?.AuraRange &&
                a.ClassSpecific?.BardicInspirationDie == classSpecific?.BardicInspirationDie &&
                a.ClassSpecific?.BrutalCriticalDie == classSpecific?.BrutalCriticalDie &&
                a.ClassSpecific?.ChannelDivinityCharges == classSpecific?.ChannelDivinityCharges &&
                CompareCreatingSpellSlots(a.ClassSpecific?.CreatingSpellSlots, classSpecific?.CreatingSpellSlots) &&
                a.ClassSpecific?.DestroyUndeadCr == classSpecific?.DestroyUndeadCr &&
                a.ClassSpecific?.ExtraAttacks == classSpecific?.ExtraAttacks &&
                a.ClassSpecific?.FavoredEnemies == classSpecific?.FavoredEnemies &&
                a.ClassSpecific?.FavoredTerrain == classSpecific?.FavoredTerrain &&
                a.ClassSpecific?.IndomitableUses == classSpecific?.IndomitableUses &&
                a.ClassSpecific?.InvocationsKnown == classSpecific?.InvocationsKnown &&
                a.ClassSpecific?.KiPoints == classSpecific?.KiPoints &&
                a.ClassSpecific?.MagicSecretsMax5 == classSpecific?.MagicSecretsMax5 &&
                a.ClassSpecific?.MagicSecretsMax7 == classSpecific?.MagicSecretsMax7 &&
                a.ClassSpecific?.MagicSecretsMax9 == classSpecific?.MagicSecretsMax9 &&
                CompareMartialArts(a.ClassSpecific?.MartialArts, classSpecific?.MartialArts) &&
                CompareSneakAttack(a.ClassSpecific?.SneakAttack, classSpecific?.SneakAttack) &&
                a.ClassSpecific?.MetamagicKnown == classSpecific?.MetamagicKnown &&
                a.ClassSpecific?.MysticArcanumLevel6 == classSpecific?.MysticArcanumLevel6 &&
                a.ClassSpecific?.MysticArcanumLevel7 == classSpecific?.MysticArcanumLevel7 &&
                a.ClassSpecific?.MysticArcanumLevel8 == classSpecific?.MysticArcanumLevel8 &&
                a.ClassSpecific?.MysticArcanumLevel9 == classSpecific?.MysticArcanumLevel9 &&
                a.ClassSpecific?.RageCount == classSpecific?.RageCount &&
                a.ClassSpecific?.RageDamaageBonus == classSpecific?.RageDamaageBonus &&
                a.ClassSpecific?.SongOfRestDie == classSpecific?.SongOfRestDie &&
                a.ClassSpecific?.SorceryPoints == classSpecific?.SorceryPoints &&
                a.ClassSpecific?.UnarmoredMovement == classSpecific?.UnarmoredMovement &&
                a.ClassSpecific?.WildShapeFly == classSpecific?.WildShapeFly &&
                a.ClassSpecific?.WildShapeMaxCr == classSpecific?.WildShapeMaxCr &&
                a.ClassSpecific?.WildShapeSwim == classSpecific?.WildShapeSwim
            );

            if (level != null)
            {
                // Encontrado, ahora seleccionamos la fila en el DataGridView
                int rowIndex = levels.IndexOf(level);
                if (rowIndex != -1)
                {
                    // Si rowIndex es -1, significa que el objeto no se encuentra en la lista
                    f.dgvClassSpecificSneakAttackLevels.Rows[rowIndex].Selected = true;
                    f.dgvClassSpecificSneakAttackLevels.FirstDisplayedScrollingRowIndex = rowIndex; // Desplazamos el DataGridView a la fila seleccionada
                }
            }
            else
            {
                MessageBox.Show("El objeto ClassSpecificLevel no está contenido en ningún objeto Level.");
            }
        }
        private bool CompareSneakAttack(DiceCountValueCommon? a, DiceCountValueCommon? b)
        {
            if (a == null && b == null)
                return true;

            if (a == null || b == null)
                return false;

            return a.DiceCount == b.DiceCount && a.DiceValues == b.DiceValues;
        }
        private void BuscarYSeleccionarSpellcasting(SpellcastingLevel spellcasting)
        {
            // Buscar el objeto Level que contiene el SpellcastingLevel dado
            Level? level = levels?.FirstOrDefault(a =>
                a.Spellcasting?.CantripsKnown == spellcasting?.CantripsKnown &&
                a.Spellcasting?.SpellSlotsLevel1 == spellcasting?.SpellSlotsLevel1 &&
                a.Spellcasting?.SpellSlotsLevel2 == spellcasting?.SpellSlotsLevel2 &&
                a.Spellcasting?.SpellSlotsLevel3 == spellcasting?.SpellSlotsLevel3 &&
                a.Spellcasting?.SpellSlotsLevel4 == spellcasting?.SpellSlotsLevel4 &&
                a.Spellcasting?.SpellSlotsLevel5 == spellcasting?.SpellSlotsLevel5 &&
                a.Spellcasting?.SpellSlotsLevel6 == spellcasting?.SpellSlotsLevel6 &&
                a.Spellcasting?.SpellSlotsLevel7 == spellcasting?.SpellSlotsLevel7 &&
                a.Spellcasting?.SpellSlotsLevel8 == spellcasting?.SpellSlotsLevel8 &&
                a.Spellcasting?.SpellSlotsLevel9 == spellcasting?.SpellSlotsLevel9 &&
                a.Spellcasting?.SpellsKnown == spellcasting?.SpellsKnown
            );

            if (level != null)
            {
                // Encontrado, ahora seleccionamos la fila en el DataGridView
                int rowIndex = levels.IndexOf(level);
                if (rowIndex != -1)
                {
                    // Si rowIndex es -1, significa que el objeto no se encuentra en la lista
                    f.dgvSpellcastingLevels.Rows[rowIndex].Selected = true;
                    f.dgvSpellcastingLevels.FirstDisplayedScrollingRowIndex = rowIndex; // Desplazamos el DataGridView a la fila seleccionada
                }
            }
            else
            {
                MessageBox.Show("El objeto Spellcasting no está contenido en ningún objeto Level.");
            }
        }
        private void BuscarYSeleccionarSubcategories(SubclassSpecificLevel Subcategories)
        {
            // Buscar el objeto Level que contiene el SpellcastingLevel dado
            Level? level = levels?.FirstOrDefault(a =>
                a.Subcategories?.AdditionalMagicalSecretsMaxLevel == Subcategories?.AdditionalMagicalSecretsMaxLevel &&
                a.Subcategories?.AuraRange == Subcategories?.AuraRange
            );

            if (level != null)
            {
                // Encontrado, ahora seleccionamos la fila en el DataGridView
                int rowIndex = levels.IndexOf(level);
                if (rowIndex != -1)
                {
                    // Si rowIndex es -1, significa que el objeto no se encuentra en la lista
                    f.dgvSubcategoriesLevels.Rows[rowIndex].Selected = true;
                    f.dgvSubcategoriesLevels.FirstDisplayedScrollingRowIndex = rowIndex; // Desplazamos el DataGridView a la fila seleccionada
                }
            }
            else
            {
                MessageBox.Show("El objeto Spellcasting no está contenido en ningún objeto Level.");
            }
        }
        private void BtBuscarLevels_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarLevels.Text))
                {
                    string idBuscar = levels.Where(a => a.Index.Equals(f.tbFiltrarLevels.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        Level level = LevelRepository.GetLevel(idBuscar);
                        f.tbIndexLevels.Text = level?.Index;
                        f.tbAbilityScoreBonusesLevels.Text = level?.AbilityScoreBonuses?.ToString();
                        f.tbLevelLevels.Text = level?.LevelN?.ToString();
                        f.tbProfBonusLevels.Text = level?.ProficiencyBonus?.ToString();
                        f.tbClassIndexLevels.Text = level?.Class?.Index;
                        f.tbClassNameLevels.Text = level?.Class?.Name;
                        f.tbSubclassIndexLevels.Text = level?.Subclass?.Index;
                        f.tbSubclassNameLevels.Text = level?.Subclass?.Name;
                        f.cbFeaturesIndexLevels.SelectedIndex = f.cbFeaturesIndexLevels.FindString(level?.Features.SelectMany(a => a.Index)?.FirstOrDefault());
                        f.cbFeaturesNameLevels.SelectedIndex = f.cbFeaturesNameLevels.FindString(level?.Features.SelectMany(a => a.Name)?.FirstOrDefault());

                        BuscarYSeleccionarClassSpecificLevel(level?.ClassSpecific);
                        BuscarYSeleccionarCreatingSpellSlots(level?.ClassSpecific);
                        BuscarYSeleccionarMartialArts(level?.ClassSpecific);
                        BuscarYSeleccionarSneakAttack(level?.ClassSpecific);
                        BuscarYSeleccionarSpellcasting(level?.Spellcasting);
                        BuscarYSeleccionarSubcategories(level?.Subcategories);
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtInsertarLevels_Click(object? sender, EventArgs e)
        {
            try
            {
                Level levelInsertar = new Level();

                string index = f.tbIndexLevels.Text;
                string level = f.tbLevelLevels.Text;
                string abylityScoreBonuses = f.tbAbilityScoreBonusesLevels.Text;
                string proficiencyBonus = f.tbProfBonusLevels.Text;
                string classIndex = f.tbClassIndexLevels.Text;
                string className = f.tbClassNameLevels.Text;

                if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(level))
                {
                    levelInsertar.Index = index;
                    levelInsertar.LevelN = int.Parse(level);

                    if (!string.IsNullOrEmpty(abylityScoreBonuses))
                    {
                        levelInsertar.AbilityScoreBonuses = int.Parse(abylityScoreBonuses);
                    }
                    else
                    {
                        levelInsertar.AbilityScoreBonuses = null;
                    }
                    if (!string.IsNullOrEmpty(proficiencyBonus))
                    {
                        levelInsertar.ProficiencyBonus = int.Parse(proficiencyBonus);
                    }
                    else
                    {
                        levelInsertar.ProficiencyBonus = null;
                    }
                    if (!string.IsNullOrEmpty(classIndex) && !string.IsNullOrEmpty(className))
                    {

                        From Class = new From();
                        Class.Index = classIndex;
                        Class.Name = className;
                        levelInsertar.Class = Class;
                    }
                    else
                    {
                        levelInsertar.Class.Index = string.Empty;
                        levelInsertar.Class.Name = string.Empty;
                    }


                    DataGridViewRow rowClassSpecific = f.dgvClassEspecificLevels.CurrentRow;
                    DataGridViewRow rowCreatingSpellSlotLevels = f.dgvClassSpecificCreatingSpellSlotsLevels.CurrentRow;
                    DataGridViewRow rowMartialArts = f.dgvClassSpecificMartialArtsLevels.CurrentRow;
                    DataGridViewRow rowSneakAttack = f.dgvClassSpecificSneakAttackLevels.CurrentRow;
                    DataGridViewRow rowSpellcasting = f.dgvSpellcastingLevels.CurrentRow;
                    DataGridViewRow rowSubcategories = f.dgvSubcategoriesLevels.CurrentRow;
                    string featuresIndex = (string)f.cbFeaturesIndexLevels.SelectedItem;
                    string featuresName = (string)f.cbFeaturesNameLevels.SelectedItem;

                    if (featuresIndex != null && featuresName != null)
                    {
                        List<ArrayedFrom> featuresList = new List<ArrayedFrom>();
                        List<string> featuresIndexString = new List<string>();
                        List<string> featuresNameString = new List<string>();
                        ArrayedFrom features = new ArrayedFrom();

                        featuresIndexString.Add(featuresIndex);
                        featuresNameString.Add(featuresName);
                        features.Index = featuresIndexString.ToArray();
                        features.Name = featuresNameString.ToArray();
                        featuresList.Add(features);
                        levelInsertar.Features = featuresList.ToArray();
                    }
                    if (rowClassSpecific != null)
                    {
                        levelInsertar.ClassSpecific = (ClassSpecificLevel)rowClassSpecific.DataBoundItem;
                    }
                    if (rowCreatingSpellSlotLevels != null)
                    {
                        List<CreatingSpellSlotsLevel> creatingSpellSlotsLevels = new List<CreatingSpellSlotsLevel>();
                        creatingSpellSlotsLevels.Add((CreatingSpellSlotsLevel)rowCreatingSpellSlotLevels.DataBoundItem);
                        levelInsertar.ClassSpecific.CreatingSpellSlots = creatingSpellSlotsLevels.ToArray();
                    }
                    if (rowMartialArts != null)
                    {
                        levelInsertar.ClassSpecific.MartialArts = (DiceCountValueCommon)rowMartialArts.DataBoundItem;
                    }
                    if (rowSneakAttack != null)
                    {
                        levelInsertar.ClassSpecific.SneakAttack = (DiceCountValueCommon)rowSneakAttack.DataBoundItem;
                    }
                    if (rowSpellcasting != null)
                    {
                        levelInsertar.Spellcasting = (SpellcastingLevel)rowSpellcasting.DataBoundItem;
                    }
                    if (rowSubcategories != null)
                    {
                        levelInsertar.Subcategories = (SubclassSpecificLevel)rowSubcategories.DataBoundItem;
                    }
                    LevelRepository.CreateLevel(levelInsertar);
                    MessageBox.Show("Has insertado Levels");
                    LoadDataLevels();
                }
                else
                {
                    MessageBox.Show("Debes escribir un index y level");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtEliminarLevels_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarLevels.Text))
                {
                    string idBuscar = levels.Where(a => a.Index.Equals(f.tbFiltrarLevels.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        LevelRepository.DeleteLevel(idBuscar);
                        MessageBox.Show("Has eliminado " + f.tbFiltrarLevels.Text.ToString());
                        LoadDataLevels();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres elininar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtModificarLevels_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarLevels.Text))
                {
                    string idBuscar = levels.Where(a => a.Index.Equals(f.tbFiltrarLevels.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        Level levelModificar = new Level();

                        string index = f.tbIndexLevels.Text;
                        string level = f.tbLevelLevels.Text;
                        string abylityScoreBonuses = f.tbAbilityScoreBonusesLevels.Text;
                        string proficiencyBonus = f.tbProfBonusLevels.Text;
                        string classIndex = f.tbClassIndexLevels.Text;
                        string className = f.tbClassNameLevels.Text;

                        if (!string.IsNullOrEmpty(index) && !string.IsNullOrEmpty(level) && !string.IsNullOrEmpty(abylityScoreBonuses) && !string.IsNullOrEmpty(proficiencyBonus))
                        {
                            levelModificar.Index = index;
                            levelModificar.LevelN = int.Parse(level);
                            levelModificar.AbilityScoreBonuses = int.Parse(abylityScoreBonuses);
                            levelModificar.ProficiencyBonus = int.Parse(proficiencyBonus);
                        }
                        else
                        {
                            MessageBox.Show("Debes escribir un index, level, abilityScoreBonuses y proficiencyBonus");
                        }
                        if (!string.IsNullOrEmpty(classIndex) && !string.IsNullOrEmpty(className))
                        {
                            From Class = new From();
                            Class.Index = classIndex;
                            Class.Name = className;
                            levelModificar.Class = Class;
                        }
                        else
                        {
                            levelModificar.Class.Index = string.Empty;
                            levelModificar.Class.Name = string.Empty;
                        }


                        DataGridViewRow rowClassSpecific = f.dgvClassEspecificLevels.CurrentRow;
                        DataGridViewRow rowCreatingSpellSlotLevels = f.dgvClassSpecificCreatingSpellSlotsLevels.CurrentRow;
                        DataGridViewRow rowMartialArts = f.dgvClassSpecificMartialArtsLevels.CurrentRow;
                        DataGridViewRow rowSneakAttack = f.dgvClassSpecificSneakAttackLevels.CurrentRow;
                        DataGridViewRow rowSpellcasting = f.dgvSpellcastingLevels.CurrentRow;
                        DataGridViewRow rowSubcategories = f.dgvSubcategoriesLevels.CurrentRow;
                        string featuresIndex = (string)f.cbFeaturesIndexLevels.SelectedItem;
                        string featuresName = (string)f.cbFeaturesNameLevels.SelectedItem;

                        if (featuresIndex != null && featuresName != null)
                        {
                            List<ArrayedFrom> featuresList = new List<ArrayedFrom>();
                            List<string> featuresIndexString = new List<string>();
                            List<string> featuresNameString = new List<string>();
                            ArrayedFrom features = new ArrayedFrom();

                            featuresIndexString.Add(featuresIndex);
                            featuresNameString.Add(featuresName);
                            features.Index = featuresIndexString.ToArray();
                            features.Name = featuresNameString.ToArray();
                            featuresList.Add(features);
                            levelModificar.Features = featuresList.ToArray();
                        }
                        if (rowClassSpecific != null)
                        {
                            levelModificar.ClassSpecific = (ClassSpecificLevel)rowClassSpecific.DataBoundItem;
                        }
                        if (rowCreatingSpellSlotLevels != null)
                        {
                            List<CreatingSpellSlotsLevel> creatingSpellSlotsLevels = new List<CreatingSpellSlotsLevel>();
                            creatingSpellSlotsLevels.Add((CreatingSpellSlotsLevel)rowCreatingSpellSlotLevels.DataBoundItem);
                            levelModificar.ClassSpecific.CreatingSpellSlots = creatingSpellSlotsLevels.ToArray();
                        }
                        if (rowMartialArts != null)
                        {
                            levelModificar.ClassSpecific.MartialArts = (DiceCountValueCommon)rowMartialArts.DataBoundItem;
                        }
                        if (rowSneakAttack != null)
                        {
                            levelModificar.ClassSpecific.SneakAttack = (DiceCountValueCommon)rowSneakAttack.DataBoundItem;
                        }
                        if (rowSpellcasting != null)
                        {
                            levelModificar.Spellcasting = (SpellcastingLevel)rowSpellcasting.DataBoundItem;
                        }
                        if (rowSubcategories != null)
                        {
                            levelModificar.Subcategories = (SubclassSpecificLevel)rowSubcategories.DataBoundItem;
                        }
                        LevelRepository.UpdateLevel(levelModificar);
                        MessageBox.Show("Has modificado Levels");
                        LoadDataLevels();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres modificar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        //MagicItem
        private void DgvMagicItems_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = f.dgvMagicItems.CurrentRow;
                if (row != null)
                {
                    MagicItem magicItem = MagicItemsRepository.GetMagicItem(((MagicItem)row.DataBoundItem).Id);
                    f.tbIndexMagicItems.Text = magicItem?.Index;
                    f.tbNameMagicItems.Text = magicItem?.Name;
                    f.tbEquipmentCategoryIndexMagicItems.Text = magicItem?.EquipmentCategory?.Index;
                    f.tbEquipmentCategoryNameMagicItems.Text = magicItem?.EquipmentCategory?.Name;
                    f.rtbDescriptionMagicItems.Text = magicItem?.Desc?.FirstOrDefault();

                    f.chbVariantMagicItems.Checked = (bool)(magicItem?.Variant);

                    f.cbRarityMagicItems.SelectedIndex = f.cbRarityMagicItems.FindString(magicItem?.Rarity?.Name);

                    if (magicItem?.Variants != null)
                    {
                        string firstVariantName = magicItem.Variants.Select(a => a.Name).FirstOrDefault();
                        if (firstVariantName != null)
                        {
                            f.cbVariantsMagicItems.SelectedIndex = f.cbVariantsMagicItems.FindString(firstVariantName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        private void BtBuscarMagicItems_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarMagicItems.Text))
                {
                    string idBuscar = magicItems.Where(a => a.Index.Equals(f.tbFiltrarMagicItems.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        MagicItem magicItem = MagicItemsRepository.GetMagicItem(idBuscar);
                        f.tbIndexMagicItems.Text = magicItem.Index;
                        f.tbNameMagicItems.Text = magicItem.Name;
                        f.tbEquipmentCategoryIndexMagicItems.Text = magicItem?.EquipmentCategory?.Index;
                        f.tbEquipmentCategoryNameMagicItems.Text = magicItem?.EquipmentCategory?.Name;
                        f.rtbDescriptionMagicItems.Text = magicItem?.Desc?.FirstOrDefault();

                        f.chbVariantMagicItems.Checked = (bool)(magicItem?.Variant);

                        f.cbRarityMagicItems.SelectedIndex = f.cbRarityMagicItems.FindString(magicItem?.Rarity?.Name);

                        f.cbVariantsMagicItems.SelectedIndex = f.cbVariantsMagicItems.FindString(magicItem?.Variants?.Select(a => a.Name).FirstOrDefault());
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtInsertarMagicItems_Click(object? sender, EventArgs e)
        {
            try
            {
                MagicItem magicItemInsertar = new MagicItem();
                magicItemInsertar.Name = f.tbNameMagicItems.Text;
                magicItemInsertar.Index = f.tbIndexMagicItems.Text;
                magicItemInsertar.Variant = f.chbVariantMagicItems.Checked;
                From equipmentCategory = new From();
                equipmentCategory.Index = f.tbEquipmentCategoryIndexMagicItems.Text;
                equipmentCategory.Name = f.tbEquipmentCategoryNameMagicItems.Text;
                magicItemInsertar.EquipmentCategory = equipmentCategory;
                magicItemInsertar.Rarity = (RarityMagicItem)f.cbRarityMagicItems.SelectedItem;
                magicItemInsertar.Desc = new string[] { f.rtbDescriptionMagicItems.Text };

                List<From> variantsList = new List<From>();
                variantsList.Add((From)f.cbVariantsMagicItems.SelectedItem);
                magicItemInsertar.Variants = variantsList.ToArray();

                MagicItemsRepository.CreateMagicItem(magicItemInsertar);
                LoadDataMagicItems();
                MessageBox.Show("Has insertado MagicItems");
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        private void BtEliminarMagicItems_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarMagicItems.Text))
                {
                    string idBuscar = magicItems.Where(a => a.Index.Equals(f.tbFiltrarMagicItems.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        MagicItemsRepository.DeleteMagicItems(idBuscar);
                        MessageBox.Show("Has eliminado " + f.tbFiltrarMagicItems.Text.ToString());
                        LoadDataMagicItems();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        private void BtModificarMagicItems_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarMagicItems.Text))
                {
                    string idBuscar = magicItems.Where(a => a.Index.Equals(f.tbFiltrarMagicItems.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        MagicItem magicItemModificar = new MagicItem();
                        magicItemModificar.Id = idBuscar;
                        magicItemModificar.Name = f.tbNameMagicItems.Text;
                        magicItemModificar.Index = f.tbIndexMagicItems.Text;
                        magicItemModificar.Variant = f.chbVariantMagicItems.Checked;
                        From equipmentCategory = new From();
                        equipmentCategory.Index = f.tbEquipmentCategoryIndexMagicItems.Text;
                        equipmentCategory.Name = f.tbEquipmentCategoryNameMagicItems.Text;
                        magicItemModificar.EquipmentCategory = equipmentCategory;
                        magicItemModificar.Rarity = (RarityMagicItem)f.cbRarityMagicItems.SelectedItem;
                        magicItemModificar.Desc = new string[] { f.rtbDescriptionMagicItems.Text };

                        List<From> variantsList = new List<From>();
                        variantsList.Add((From)f.cbVariantsMagicItems.SelectedItem);
                        magicItemModificar.Variants = variantsList.ToArray();
                        MagicItemsRepository.UpdateMagicItem(magicItemModificar);
                        MessageBox.Show("Has modificado " + f.tbFiltrarMagicItems.Text.ToString());
                        LoadDataMagicItems();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        //MagicSchools
        private void DgvMagicSchools_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = f.dgvMagicSchools.CurrentRow;
                if (row != null)
                {
                    MagicSchool magicSchool = MagicSchoolRepository.GetMagicSchool(((MagicSchool)row.DataBoundItem).Id);
                    f.tbIndexMagicSchools.Text = magicSchool?.Index;
                    f.tbNameMagicSchools.Text = magicSchool?.Name;
                    f.tbDescriptionMagicSchools.Text = magicSchool?.Description;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtBuscarMagicSchools_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarMagicSchools.Text))
                {
                    string idBuscar = magicSchools.Where(a => a.Index.Equals(f.tbFiltrarMagicSchools.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        MagicSchool magicSchool = MagicSchoolRepository.GetMagicSchool(idBuscar);
                        f.tbIndexMagicSchools.Text = magicSchool?.Index;
                        f.tbNameMagicSchools.Text = magicSchool?.Name;
                        f.tbDescriptionMagicSchools.Text = magicSchool?.Description;
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres modificar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        private void BtInsertarMagicSchools_Click(object? sender, EventArgs e)
        {
            try
            {
                MagicSchool magicSchoolInsertar = new MagicSchool();
                magicSchoolInsertar.Index = f.tbIndexMagicSchools.Text;
                magicSchoolInsertar.Name = f.tbNameMagicSchools.Text;
                magicSchoolInsertar.Description = f.tbDescriptionMagicSchools.Text;
                MagicSchoolRepository.CreateMagicSchool(magicSchoolInsertar);
                MessageBox.Show("Has insertado MagicSchool");
                LoadDataMagicSchools();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        private void BtModificarMagicSchools_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarMagicSchools.Text))
                {
                    string idBuscar = magicSchools.Where(a => a.Index.Equals(f.tbFiltrarMagicSchools.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        MagicSchool magicSchoolModificar = new MagicSchool();
                        magicSchoolModificar.Id = idBuscar;
                        magicSchoolModificar.Index = f.tbIndexMagicSchools.Text;
                        magicSchoolModificar.Name = f.tbNameMagicSchools.Text;
                        magicSchoolModificar.Description = f.tbDescriptionMagicSchools.Text;
                        MagicSchoolRepository.UpdateMagicSchoole(magicSchoolModificar);
                        MessageBox.Show("Has modificado MagicSchool");
                        LoadDataMagicSchools();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres modificar no puede estar vacío");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        private void BtEliminarMagicSchools_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarMagicSchools.Text))
                {
                    string idBuscar = magicSchools.Where(a => a.Index.Equals(f.tbFiltrarMagicSchools.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        MagicSchoolRepository.DeleteMagicSchool(idBuscar);
                        MessageBox.Show("Has eliminado " + f.tbFiltrarMagicSchools.Text);
                        LoadDataMagicSchools();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres eliminar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        //Proficiency
        private void DgvProficiency_SelectionChanged(object? sender, EventArgs e)
        {
            DataGridViewRow row = f.dgvProficiency.CurrentRow;
            if (row != null)
            {
                Proficiency proficiency = ProficiencyRepository.GetProficiency(((Proficiency)row.DataBoundItem).Id);
                if (proficiency != null)
                {
                    f.tbIndexProficiency.Text = proficiency?.Index;
                    f.tbNameProficiency.Text = proficiency?.Name;
                    f.tbTypeProficiency.Text = proficiency?.Type;

                    f.cbClassesProficiency.SelectedIndex = f.cbClassesProficiency.FindString(proficiency?.Classes?.FirstOrDefault()?.Name);

                    f.cbRacesProficiency.SelectedIndex = f.cbRacesProficiency.FindString(proficiency?.Races?.FirstOrDefault()?.Name);
                    f.cbReferenceProficiency.SelectedIndex = f.cbReferenceProficiency.FindString(proficiency?.Reference?.Name);
                }
            }
        }

        private void BtBuscarProficiency_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarProficiency.Text))
                {
                    string idBuscar = proficiencies.Where(a => a.Index.Equals(f.tbFiltrarProficiency.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        Proficiency proficiency = ProficiencyRepository.GetProficiency(idBuscar);
                        if (proficiency != null)
                        {
                            f.tbIndexProficiency.Text = proficiency?.Index;
                            f.tbNameProficiency.Text = proficiency?.Name;
                            f.tbTypeProficiency.Text = proficiency?.Type;

                            f.cbClassesProficiency.SelectedIndex = f.cbClassesProficiency.FindString(proficiency?.Classes?.FirstOrDefault()?.Name);

                            f.cbRacesProficiency.SelectedIndex = f.cbRacesProficiency.FindString(proficiency?.Races?.FirstOrDefault()?.Name);
                            f.cbReferenceProficiency.SelectedIndex = f.cbReferenceProficiency.FindString(proficiency?.Reference?.Name);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres buscar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        private void BtInsertarProficiency_Click(object? sender, EventArgs e)
        {
            try
            {
                Proficiency proficiencyInsertar = new Proficiency();
                proficiencyInsertar.Index = f.tbIndexProficiency.Text;
                proficiencyInsertar.Name = f.tbNameProficiency.Text;
                proficiencyInsertar.Type = f.tbTypeProficiency.Text;


                List<From> classesList = new List<From>();
                From classes = (From)f.cbClassesProficiency.SelectedItem;
                if (classes != null)
                {
                    classesList.Add(classes);
                    proficiencyInsertar.Classes = classesList.ToArray();
                }
                else
                {
                    From classeEmtpy = new From();
                    classeEmtpy.Index = string.Empty;
                    classeEmtpy.Name = string.Empty;
                    classesList.Add(classeEmtpy);
                    proficiencyInsertar.Classes = classesList.ToArray();
                }

                List<From> racesList = new List<From>();
                From races = (From)f.cbRacesProficiency.SelectedItem;
                if (races != null)
                {
                    racesList.Add(races);
                    proficiencyInsertar.Races = racesList.ToArray();
                }
                else
                {
                    From racesEmtpy = new From();
                    racesEmtpy.Index = string.Empty;
                    racesEmtpy.Name = string.Empty;
                    racesList.Add(racesEmtpy);
                    proficiencyInsertar.Races = racesList.ToArray();
                }

                proficiencyInsertar.Reference = (From)f.cbReferenceProficiency.SelectedItem;
                ProficiencyRepository.CreateProficiency(proficiencyInsertar);
                MessageBox.Show("Has insertado Proficiency");

                LoadDataProficiency();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
        private void BtEliminarProficiency_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarProficiency.Text))
                {
                    string idBuscar = proficiencies.Where(a => a.Index.Equals(f.tbFiltrarProficiency.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        ProficiencyRepository.DeleteProficiency(idBuscar);
                        MessageBox.Show("Has eliminado " + f.tbFiltrarProficiency.Text.ToString());
                        LoadDataProficiency();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres eliminar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }

        private void BtModificarProficiency_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(f.tbFiltrarProficiency.Text))
                {
                    string idBuscar = proficiencies?.Where(a => a.Index.Equals(f.tbFiltrarProficiency.Text.ToString())).Select(a => a.Id.ToLower().ToString()).FirstOrDefault();

                    if (idBuscar != null)
                    {
                        Proficiency proficiencyModificar = new Proficiency();

                        proficiencyModificar.Id = idBuscar;
                        proficiencyModificar.Index = f.tbIndexProficiency.Text;
                        proficiencyModificar.Name = f.tbNameProficiency.Text;
                        proficiencyModificar.Type = f.tbTypeProficiency.Text;

                        List<From> classesList = new List<From>();
                        From classes = (From)f.cbClassesProficiency.SelectedItem;
                        classesList.Add(classes);
                        proficiencyModificar.Classes = classesList.ToArray();

                        List<From> racesList = new List<From>();
                        From races = (From)f.cbRacesProficiency.SelectedItem;
                        racesList.Add(races);
                        proficiencyModificar.Races = racesList.ToArray();
                        proficiencyModificar.Reference = (From)f.cbReferenceProficiency.SelectedItem;

                        ProficiencyRepository.UpdateProficiency(proficiencyModificar);

                        MessageBox.Show("Has modificado " + f.tbFiltrarProficiency.Text.ToString());
                        LoadDataProficiency();
                    }
                    else
                    {
                        MessageBox.Show("No existe una referencia con ese index");
                    }
                }
                else
                {
                    MessageBox.Show("Lo que quieres modificar no puede estar vacío");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Extensions.GetaAllMessages(ex));
            }
        }
    }
}

