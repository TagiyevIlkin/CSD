using CSD.ComSciDep.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class DepartmentPositionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.FullName)]
        
        public int PersonelId { get; set; }
        public int PreviousPersonelId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Position)]
        public int PositionId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.AcademicDegree)]
        public int AcademicDegreeId { get; set; }
    }
}
