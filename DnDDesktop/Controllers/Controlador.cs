using DnDDesktop.Models;
using DnDDesktop.Models.Commons;
using DnDDesktop.Models.Repository;
using DnDDesktop.Models.SubModels;
using System.Xml.Linq;
using System;
using Extensions = DnDDesktop.Models.Extensions;
using DnDDesktop.Models.Repository.DAOs;

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
        FeatsRepository FeatsRepository = new FeatsRepository();

        //Listas

        //AbilityScores
        List<From> listaAbilityScoreSkills = new List<From>();
        List<AbilityScore> abilityScores = new List<AbilityScore>();

        //Alignments
        List<Feats> alignments = new List<Feats>();

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
        private void InitListeners()
        {
            //AbilityScore
            f.btInsertarAbilityScore.Click += BtInsertarAbilityScore_Click;
            f.btInsertarAbilityScore.MouseUp += btInsertarAbilityScore_MouseUp;
            f.btBuscarAbilityScore.Click += BtBuscarAbilityScore_Click;
            f.btEliminarAbilityScore.Click += BtEliminarAbilityScore_Click;
            f.btModificarAbilityScore.Click += BtModificarAbilityScore_Click;
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
                Feats alignment = new Feats();
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
                        Feats newAlignments = alignmentsRepository.GetAlignment(idBuscar.ToString());
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

                Feats alignmentModificar = new Feats();

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
                Feats alig = (Feats)row.DataBoundItem;
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
                InfoClasses SpellCastingInfoName = (InfoClasses)f.dgvSpellCastingInfoNameClasses.CurrentRow.DataBoundItem;
                classeInsertar.Spellcasting = new SpellcastingClass
                {
                    Info = new InfoClasses[] { SpellCastingInfoName },
                    SpellcastingAbility = new From { Name = f.tbSpellCastingAbilityClasses.Text } // Asignación del SpellcastingAbility
                };

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

        //Feats
    }
}