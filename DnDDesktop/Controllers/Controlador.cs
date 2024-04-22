using DnDDesktop.Models;
using DnDDesktop.Models.Commons;
using DnDDesktop.Models.Repository;

namespace DnDDesktop.Controllers
{
    public class Controlador
    {
        Form1 f = new Form1();
        AbilityScoreRepository rAbilityScore = new AbilityScoreRepository();
        AlignmentsRepository alignmentsRepository = new AlignmentsRepository();

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
            f.btInsertarAlignments.Click += BtInsertarAlignments_Click;
        }

        //AbilityScore
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

        private void BtInsertarAlignments_Click(object? sender, EventArgs e)
        {
            Alignment alignment = new Alignment();
            alignment.Index = f.tbIndexAlignments.Text.ToString();
            alignment.Name = f.tbNameAlignments.Text.ToString();
            alignment.Abbreviation = f.tbAbbreviationAlignments.Text.ToString();
            alignment.Description = f.rtbDescriptionAlignments.Text.ToString();

            alignmentsRepository.CreateAlignment(alignment);
        }

    }
}
