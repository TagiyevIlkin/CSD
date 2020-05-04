using CSD.ComSciDep.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class SpecialitySubjectViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Specialty)]
        public int SpecialityId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Subject)]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Credit)]
        public int CreditId { get; set; }
        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Semester)]
        public int SemesterId { get; set; }

    }
}
