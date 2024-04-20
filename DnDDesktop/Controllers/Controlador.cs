using DnDDesktop.Models;
using DnDDesktop.Models.Commons;
using DnDDesktop.Models.Repository;

namespace DnDDesktop.Controllers
{
    public class Controlador
    {
        Form1 f = new Form1();
        AbilityScoreRepository rAbilityScore = new AbilityScoreRepository();

        public Controlador()
        {
            LoadData();
            InitListeners();
            Application.Run(f);
        }

        private void LoadData()
        {
            f.cbSkillsAbilityScore.DataSource = rAbilityScore.GetAbilityScores().SelectMany(a => a.Skills).ToArray();
            f.cbSkillsAbilityScore.DisplayMember = "Name";
        }

        private void InitListeners()
        {
            f.btInsertarAbilityScore.Click += BtInsertarAbilityScore_Click;
        }

        private void BtInsertarAbilityScore_Click(object? sender, EventArgs e)
        {
            AbilityScore score = new AbilityScore();
            score.Index = f.tbIndexAbilityScore.Text.ToString();
            score.Name = f.tbNameAbilityScore.Text.ToString();
            score.FullName = f.tbFullNameAbilityScore.Text.ToString();
            score.Description = new string[] { f.rtbDescriptionAbilityScore.Text };
            From selectedSkill = (From)f.cbSkillsAbilityScore.SelectedItem;

            if (selectedSkill != null)
            {
                score.Skills = new From[] { selectedSkill };
            }

            rAbilityScore.CreateAbilityScore(score);
        }

    }
}
