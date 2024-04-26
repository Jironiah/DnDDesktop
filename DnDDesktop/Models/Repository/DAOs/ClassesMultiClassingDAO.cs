using DnDDesktop.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDesktop.Models.Repository.DAOs
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
            index = p.AbilityScore.Index;
            name = p.AbilityScore.Name;
            minimum_score = p.MinimumScore;
        }
    }


}
