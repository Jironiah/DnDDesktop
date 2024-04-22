using DnDDesktop.Models;
using DnDDesktop.Models.Commons;
using DnDDesktop.Models.Repository;

namespace DnDDesktop.Controllers
{
    public class Controlador
    {
        Form1 f = new Form1();
        AbilityScoreRepository abilityScoreRepository = new AbilityScoreRepository();
        AlignmentsRepository alignmentsRepository = new AlignmentsRepository();
        WeaponPropertiesRepository weaponPropertiesRepository = new WeaponPropertiesRepository();

        public Controlador()
        {
            LoadData();
            InitListeners();
            Application.Run(f);
        }

        private void LoadData()
        {
            //AbilityScore
            f.cbSkillsAbilityScore.DataSource = abilityScoreRepository.GetAbilityScores().SelectMany(a => a.Skills).ToArray();
            f.cbSkillsAbilityScore.DisplayMember = "Name";
        }

        private void InitListeners()
        {
            //AbilityScore
            f.btInsertarAbilityScore.Click += BtInsertarAbilityScore_Click;
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

                if (index == "" && name == "" && fullName == "" && description.Length < 0)
                {
                    score.Index = index;
                    score.Name = name;
                    score.FullName = fullName;
                    score.Description = description;
                    if(selectedSkill != null) 
                    { 
                        score.Skills = new From[] { selectedSkill };
                    }
                }
                else
                {
                    MessageBox.Show("No puedes dejar espacios vacíos");
                }
                abilityScoreRepository.CreateAbilityScore(score);
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
