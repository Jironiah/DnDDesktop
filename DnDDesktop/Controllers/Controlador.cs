using DnDDesktop.Models;
using DnDDesktop.Models.Commons;
using DnDDesktop.Models.Repository;
using DnDDesktop.Views.ViewsPopup;

namespace DnDDesktop.Controllers
{
    public class Controlador
    {
        Form1 f = new Form1();
        AbilityScore_Skills abilityScore_Skills = new AbilityScore_Skills();

        AbilityScoreRepository abilityScoreRepository = new AbilityScoreRepository();
        AlignmentsRepository alignmentsRepository = new AlignmentsRepository();
        WeaponPropertiesRepository weaponPropertiesRepository = new WeaponPropertiesRepository();


        //Listas
        List<From> listaAbilityScoreSkills = new List<From>();
        public Controlador()
        {
            LoadData();
            InitListeners();
            Application.Run(f);
        }

        private void LoadData()
        {
            listaAbilityScoreSkills = abilityScoreRepository.GetAbilityScores().SelectMany(a => a.Skills).ToList();
            f.cbSkillsAbilityScore.DataSource = listaAbilityScoreSkills;
            f.cbSkillsAbilityScore.DisplayMember = "Name";
        }

        private void InitListeners()
        {
            //AbilityScore
            f.btInsertarAbilityScore.Click += BtInsertarAbilityScore_Click;
            f.cbSkillsAbilityScore.MouseUp += CbSkillsAbilityScore_MouseUp;
            f.btBuscarAbilityScore.Click += BtBuscarAbilityScore_Click;
            //Alignments
            f.btInsertarAlignments.Click += BtInsertarAlignments_Click;
            //WeaponProperties
            f.btInsertarWeaponProperties.Click += BtInsertarWeaponProperties_Click;
        }

        //AbilityScore
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CbSkillsAbilityScore_MouseUp(object sender, MouseEventArgs e)
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtBuscarAbilityScore_Click(object? sender, EventArgs e)
        {
            AbilityScore abilityScore = new AbilityScore();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        //Alignments
        private void BtInsertarAlignments_Click(object? sender, EventArgs e)
        {
            Alignment alignment = new Alignment();
            alignment.Index = f.tbIndexAlignments.Text.ToString();
            alignment.Name = f.tbNameAlignments.Text.ToString();
            alignment.Abbreviation = f.tbAbbreviationAlignments.Text.ToString();
            alignment.Description = f.rtbDescriptionAlignments.Text.ToString();

            alignmentsRepository.CreateAlignment(alignment);
            MessageBox.Show("Alignments introducido");
        }

        //WeaponProperties
        private void BtInsertarWeaponProperties_Click(object? sender, EventArgs e)
        {
            WeaponProperty weaponProperty = new WeaponProperty();
            weaponProperty.Index = f.tbIndexWeaponProperties.Text.ToString();
            weaponProperty.Name = f.tbNameWeaponProperties.Text.ToString();
            weaponProperty.Description = new string[] { f.rtbDescriptionWeaponProperties.Text };
            weaponPropertiesRepository.CreateWeaponProperty(weaponProperty);
        }

    }
}
