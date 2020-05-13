using CSD.ComSciDep.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class LaboratoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [MinLength(2, ErrorMessage = CsResultConst.Minlength2),
         MaxLength(100, ErrorMessage = CsResultConst.Maxlength100)]
        [DisplayName(CsDisplayName.Name)]
        public string Name { get; set; }

        [MaxLength(4, ErrorMessage = CsResultConst.Maxlength4)]
        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.RoomNumber)]
        public string RoomNumber { get; set; }

        public string PicturePath { get; set; }
        public string PictureName { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Picture)]
        public IFormFile  Picture { get; set; }


        [MinLength(3, ErrorMessage = CsResultConst.Minlength3),
          MaxLength(250, ErrorMessage = CsResultConst.Maxlength250)]
        [DisplayName(CsDisplayName.AdditionalInfo)]
        public string AdditionalInfo { get; set; }
    }
}
