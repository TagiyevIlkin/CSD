using CSD.ComSciDep.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = CsResultConst.Minlength3),
         MaxLength(100, ErrorMessage = CsResultConst.Maxlength100),
         Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Name)]
        public string Name { get; set; }

        [MinLength(3, ErrorMessage = CsResultConst.Minlength3),
          MaxLength(500, ErrorMessage = CsResultConst.Maxlength500),
          Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.About)]
        public string AboutEvent { get; set; }


        [MinLength(3, ErrorMessage = CsResultConst.Minlength3),
          MaxLength(100, ErrorMessage = CsResultConst.Maxlength100),
          Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Location)]
        public string Location { get; set; }

        [MinLength(3, ErrorMessage = CsResultConst.Minlength3),
          MaxLength(500, ErrorMessage = CsResultConst.Maxlength500)]
        [DisplayName(CsDisplayName.AdditionalInfo)]
        public string AdditionalInfo { get; set; }



        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Date)]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.BeginTimeFE)]
        [DataType(DataType.Time)]
        public DateTime BeginTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.EndTimeFE)]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
    }
}
