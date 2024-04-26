using DnDDesktop.Models.Commons;
using DnDDesktop.Models.SubModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDesktop.Models.Repository.DAOs
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
            index = background.Index;
            name = background.Name;
            bondsChoose = background.Bonds.Choose;
            bondsFrom = background.Bonds.From;
            featureName = background.Feature.Name;
            featureDesc = background.Feature.Description;
            flawsChoose = background.Flaws.Choose;
            flawsFrom = background.Flaws.From;
            ideals = background.Ideals;
            languageOptions = background.LanguageOptions;
            personalityTraitsChoose = background.PersonalityTraits.Choose;
            personalityTraitsFrom = background.PersonalityTraits.From;
            startingEquipmentQuantity = background.StartingEquipment.Select(a => a.Quantity).FirstOrDefault();
            startingEquipmentEquipment = background.StartingEquipment.Select(a => a.Equipment).FirstOrDefault();
            startingEquipmentOptionsChoose = background.StartingEquipmentOption.Select(a => a.Choose).FirstOrDefault();
            startingEquipmentOptionsFrom = background.StartingEquipmentOption.Select(a => a.From).FirstOrDefault();
            startingEquipmentOptionsType = background.StartingEquipmentOption.Select(a => a.Type).FirstOrDefault();
            startingProficienciesName = background.StartingProficiencies.Select(a => a.Name).FirstOrDefault();
            startingProficienciesIndex = background.StartingProficiencies.Select(a => a.Index).FirstOrDefault();
        }
    }

}
