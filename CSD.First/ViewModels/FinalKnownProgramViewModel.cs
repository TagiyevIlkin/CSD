using CSD.Entities.Computer_Engineering;
using CSD.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class FinalKnownProgramViewModel
    {
        public KnownProgramViewModel  KnownProgramViewModel { get; set; }
        public ICollection<KnownProgram>  KnownProgramsForPerson { get; set; }
        public string CurrentPerson { get; set; }
        public List<CSD.Entities.Computer_Engineering.Program> ProgramList { get; set; }
        public List<Level> LevelList { get; set; }
    }
}
