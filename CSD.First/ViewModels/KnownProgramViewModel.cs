using CSD.ComSciDep.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class KnownProgramViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Program)]
        public int ProgramId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Level)]
        public int LevelId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.FullName)]
        public int PersonelId { get; set; }


        #region For edit
        public int PreviousPersonId { get; set; }
        public int PreviousProgramId { get; set; }
        public string PreviousPersonFullName { get; set; }
        #endregion
    }
}
