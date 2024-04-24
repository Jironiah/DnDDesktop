using DnDDesktop.Models;
using DnDDesktop.Models.Commons;
using DnDDesktop.Models.Repository;
using DnDDesktop.Models.SubModels;

namespace DnDDesktop.Controllers
{
    public class Controlador
    {
        Form1 f = new Form1();

        AbilityScoreRepository abilityScoreRepository = new AbilityScoreRepository();
        AlignmentsRepository alignmentsRepository = new AlignmentsRepository();
        WeaponPropertiesRepository weaponPropertiesRepository = new WeaponPropertiesRepository();
        ClassesRepository classesRepository = new ClassesRepository();

        //Listas

        //AbilityScores
        List<From> listaAbilityScoreSkills = new List<From>();
        List<AbilityScore> abilityScores = new List<AbilityScore>();

        //Alignments
        List<Alignment> alignments = new List<Alignment>();

        //WeaponProperties
        List<WeaponProperty> weapons = new List<WeaponProperty>();


        //Classes
        List<Classes> classes = new List<Classes>();
        List<MultiClassing> listaclassesMultiClassings = new List<MultiClassing>();
        List<From> listaclassesProficiencies = new List<From>();
        List<ProficiencyChoiceClasses> listaclassesProficiencyChoice = new List<ProficiencyChoiceClasses>();
        List<From> listaclassesSavingThrows = new List<From>();
        List<SpellcastingClass> listaclassesSpellcasting = new List<SpellcastingClass>();
        List<StartingEquipmentClasses> listaclassesStartingEquipment = new List<StartingEquipmentClasses>();
        List<StartingEquipmentOptionClasses> listaclassesStartingEquipmentOption = new List<StartingEquipmentOptionClasses>();
        List<From> listaclassesSubclasses = new List<From>();

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
            listaclassesMultiClassings = classesRepository.GetClasses().Select(a => a.MultiClassing).ToList();
            listaclassesProficiencies = classesRepository.GetClasses().SelectMany(a => a.Proficiencies).ToList();
            listaclassesProficiencyChoice = classesRepository.GetClasses().SelectMany(a => a.ProficienciesChoices).ToList();
            listaclassesSavingThrows = classesRepository.GetClasses().SelectMany(a => a.SavingThrows).ToList();
            listaclassesSpellcasting = classesRepository.GetClasses().Select(a => a.Spellcasting).ToList();
            listaclassesStartingEquipment = classesRepository.GetClasses().SelectMany(a => a.StartingEquipment).ToList();
            listaclassesStartingEquipmentOption = classesRepository.GetClasses().SelectMany(a => a.StartingEquipmentOption).ToList();
            listaclassesSubclasses = classesRepository.GetClasses().SelectMany(a => a.Subclasses).ToList();
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
                Alignment alignment = new Alignment();
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
                        Alignment newAlignments = alignmentsRepository.GetAlignment(idBuscar.ToString());
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

                Alignment alignmentModificar = new Alignment();

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
                Alignment alig = (Alignment)row.DataBoundItem;
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



        //private void BtInsertarClasses_Click(object? sender, EventArgs e)
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
        //            ClassesMultiClassingDAO MultiClassingPrerequisites = (ClassesMultiClassingDAO)rowMultiClassingPrerequisitesClasses.DataBoundItem;//Esta clase es DTO
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
        //            abScore.Name = MultiClassingPrerequisites.name;
        //            abScore.Index = MultiClassingPrerequisites.index;
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
        //            optionItemClasses.Add(optionItemClass);
        //            startingEquipmentOptionClasses = StartingEquipmentOptionsChooseDesc;
        //            startingEquipmentOptionClasses.From.Add(optionItemClasses.ToArray());

        //            classeInsertar.Index = f.tbIndexClasses.Text;
        //            classeInsertar.Name = f.tbNameClasses.Text;
        //            classeInsertar.HitDie = int.Parse(f.tbHitDieClasses.Text);
        //            //classeInsertar.Spellcasting.SpellcastingAbility.Name = f.tbSpellCastingAbilityClasses.Text;
        //            classeInsertar.Spellcasting.Info = spellcastingClass.Info;

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
    }
}