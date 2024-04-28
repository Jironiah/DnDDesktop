using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDesktop.Models.Repository.DAOs
{
    public class FeaturesDAO
    {
        public string id { get; set; }
        public string index { get; set; }
        public string name { get; set; }
        public int? level { get; set; }
        public string parentName { get; set; }
        public string subclassName { get; set; }
        public string prerequisitesFeature { get; set; }
        public int? prerequisitesLevel { get; set; }
        public string prerequisitesSpell { get; set; }
        public string prerequisitesType { get; set; }

        public FeaturesDAO()
        {
        }
        public FeaturesDAO(Feature feature)
        {
            this.id = feature.Id;
            this.index = feature.Index;
            this.name = feature.Name;
            this.level = feature?.level;
            this.parentName = feature?.Parent?.Name;
            this.subclassName = feature?.Subclass?.Name;
            this.prerequisitesFeature = feature?.PrerequisiteFeatures?.Select(a => a.feature)?.FirstOrDefault();
            this.prerequisitesLevel = feature?.PrerequisiteFeatures?.Select(a => a.level)?.FirstOrDefault();
            this.prerequisitesSpell = feature?.PrerequisiteFeatures?.Select(a => a.Spell)?.FirstOrDefault();
            this.prerequisitesType = feature?.PrerequisiteFeatures?.Select(a => a.Type)?.FirstOrDefault();
        }
    }
}
