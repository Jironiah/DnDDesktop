using DnDDesktop.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDesktop.Models.Repository
{
    public class ClassesMultiClassingDAO
    {
        public string index { get; set; }
        public string name { get; set; }
        public int? minimum_score { get; set; }

        public ClassesMultiClassingDAO()
        {

        }
        public ClassesMultiClassingDAO(Prerequisites p)
        {
            this.index = p.AbilityScore.Index;
            this.name = p.AbilityScore.Name;
            this.minimum_score = p.MinimumScore;
        }
    }


}
