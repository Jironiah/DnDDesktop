using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDesktop.Models.Repository.DAOs
{
    public class SkillDAO
    {
        public string id { get; set; }
        public string index { get; set; }
        public string name { get; set; }
        public string abilityScoreName { get; set; }

        public SkillDAO() { }
        public SkillDAO(Skill skill)
        {
            this.id = skill.Id;
            this.index = skill.Index;
            this.name = skill.Name;
            this.abilityScoreName = skill?.AbilityScore?.Name;
        }
    }
}
