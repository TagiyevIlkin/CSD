using CSD.Entities.Computer_Engineering;
using CSD.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class FinalLanguageViewModel
    {
        public LanguageViewModel  LanguageViewModel { get; set; }
        public ICollection<LevelOfLanguage> LanguagesForPerson   { get; set; }
        public string  CurrentPerson { get; set; }
        public List<Language>  LanguageList { get; set; }
        public List<Level>  LevelList { get; set; }
    }
}
