using CSD.ComSciDep.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class EducationViewModel
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        [MaxLength(100,ErrorMessage =CsResultConst.Maxlength100), 
        MinLength(3,ErrorMessage =CsResultConst.Minlength3), 
        Required(ErrorMessage =CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.EducationalInstitution)]
        public string EducationalInstitution { get; set; }

        [MaxLength(100, ErrorMessage = CsResultConst.Maxlength100),
         MinLength(3, ErrorMessage = CsResultConst.Minlength3),
         Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Faculty)]
        public string Faculty { get; set; }

        [MaxLength(50, ErrorMessage = CsResultConst.Maxlength50),
        MinLength(3, ErrorMessage = CsResultConst.Minlength3), 
        Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Specialty)]
        public string Specialty { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.BeginTime)]
        public DateTime BeginTime { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName(CsDisplayName.EndTime)]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.EducationDegree)]
        public int EducationDegreeId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.CityOrDistrict)]
        public int CityId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Document)]
        public int DocumentId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.FullName)]
        public int PersonelId { get; set; }

        #region For edit
        public int PreviousPersonId { get; set; }
        public string PreviousPersonFullName { get; set; }
        #endregion
    }
}
