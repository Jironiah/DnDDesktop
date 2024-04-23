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
            f.btInsertarClasses.MouseUp += BtInsertarClasses_MouseUp;
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
                f.dgvSpellCastingInfoNameClasses.DataSource = classes.Spellcasting?.Info.Select(a=>a.Name).ToList();
                f.rtbSpellCastingInfoDescClasses.Text = classes.Spellcasting?.Info.SelectMany(a=>a.Description).FirstOrDefault();
                f.cbStartingEquipmentClasses.DataSource = classes.StartingEquipment;
                f.cbStartingEquipmentOptionsClasses.DataSource = classes.StartingEquipmentOption;
                f.cbSubclassesClasses.DataSource = classes.Subclasses;

                f.cbProficienciesClasses.DisplayMember = "Name";
                f.cbSavingThrowsClasses.DisplayMember = "";
                f.cbStartingEquipmentClasses.DisplayMember = "";
                f.cbStartingEquipmentOptionsClasses.DisplayMember = "";
                f.cbSubclassesClasses.DisplayMember = "";
            }
        }

        private void BtModificarClasses_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtEliminarClasses_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtBuscarClasses_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtInsertarClasses_MouseUp(object? sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtInsertarClasses_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}