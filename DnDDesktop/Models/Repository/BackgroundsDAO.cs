using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDesktop.Models.Repository
{
    public class BackgroundsDAO
    {
        public string index { get; set; }
        public string name { get; set; }
        public int? bondsChoose { get; set; }
        public string[] bondsFrom { get; set; }
        public string featureName { get; set; }
        public string[] featureDesc { get; set; }
        public int? flawsChoose { get; set; }
        public string[] flawsFrom { get; set; }
        public IdealsBackground? ideals { get; set; }
        public int? languageOptions { get; set; }
        public int? personalityTraitsChoose { get; set; }
        public string[] personalityTraitsFrom { get; set; }
        public From startingEquipmentEquipment { get; set; }
        public int? startingEquipmentQuantity { get; set; }
        public int? startingEquipmentOptionsChoose { get; set; }
        public FromBackground startingEquipmentOptionsFrom { get; set; }
        public string startingEquipmentOptionsType { get; set; }
        public string startingProficienciesName { get; set; }
        public string startingProficienciesIndex { get; set; }

        public BackgroundsDAO()
        {

        }

        public BackgroundsDAO(Background background)
        {
            this.index = background.Index;
            this.name = background.Name;
            this.bondsChoose = background.Bonds.Choose;
            this.bondsFrom = background.Bonds.From;
            this.featureName = background.Feature.Name;
            this.featureDesc = background.Feature.Description;
            this.flawsChoose = background.Flaws.Choose;
            this.flawsFrom = background.Flaws.From;
            this.ideals = background.Ideals;
            this.languageOptions = background.LanguageOptions;
            this.personalityTraitsChoose = background.PersonalityTraits.Choose;
            this.personalityTraitsFrom = background.PersonalityTraits.From;
            this.startingEquipmentQuantity = background.StartingEquipment.Select(a => a.Quantity).FirstOrDefault();
            this.startingEquipmentEquipment = background.StartingEquipment.Select(a => a.Equipment).FirstOrDefault();
            this.startingEquipmentOptionsChoose = background.StartingEquipmentOption.Select(a => a.Choose).FirstOrDefault();
            this.startingEquipmentOptionsFrom = background.StartingEquipmentOption.Select(a => a.From).FirstOrDefault();
            this.startingEquipmentOptionsType = background.StartingEquipmentOption.Select(a => a.Type).FirstOrDefault();
            this.startingProficienciesName = background.StartingProficiencies.Select(a => a.Name).FirstOrDefault();
            this.startingProficienciesIndex = background.StartingProficiencies.Select(a => a.Index).FirstOrDefault();
        }
    }

}
