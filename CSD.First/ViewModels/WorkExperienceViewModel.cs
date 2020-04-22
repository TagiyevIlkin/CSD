using CSD.ComSciDep.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class WorkExperienceViewModel
    {
        public int Id { get; set; }
        [MaxLength(250, ErrorMessage = CsResultConst.Maxlength250),
            MinLength(3, ErrorMessage = CsResultConst.Minlength3),
            Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.CompanyName)]
        public string CompanyName { get; set; }

        [MaxLength(50, ErrorMessage = CsResultConst.Maxlength50),
           MinLength(3, ErrorMessage = CsResultConst.Minlength3),
           Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.WorkPosition)]
        public string Position { get; set; }

        [MaxLength(250, ErrorMessage = CsResultConst.Maxlength250),
         MinLength(3, ErrorMessage = CsResultConst.Minlength3),
         Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.JobResponsibilities)]
        public string JobResponsibilities { get; set; }

        [MaxLength(250, ErrorMessage = CsResultConst.Maxlength250),
        MinLength(3, ErrorMessage = CsResultConst.Minlength3),]
        [DisplayName(CsDisplayName.AdditionalInfo)]
        public string AdditionalInfo { get; set; }


        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.BeginTime)]
        public DateTime BeginDate { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName(CsDisplayName.EndTime)]
        public DateTime EndTme { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.FullName)]
        public int PersonelId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.CityOrDistrict)]
        public int CityId { get; set; }

        #region For Edit
        public string PreviousPersonName { get; set; }
        public int PreviousPersonId { get; set; }
        #endregion
    }
}
