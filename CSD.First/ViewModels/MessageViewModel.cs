using CSD.ComSciDep.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class MessageViewModel
    {
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = CsResultConst.Minlength3),
        MaxLength(20, ErrorMessage = CsResultConst.Maxlength20),
        Required(ErrorMessage = CsResultConst.RequiredProperty), DisplayName(CsDisplayName.NameFM)]
        public string Name { get; set; }

        [MinLength(3, ErrorMessage = CsResultConst.Minlength3),
        MaxLength(20, ErrorMessage = CsResultConst.Maxlength20),
         Required(ErrorMessage = CsResultConst.RequiredProperty), DisplayName(CsDisplayName.SurnameFM)]
        public string Surname { get; set; }
        [Required(ErrorMessage = CsResultConst.RequiredProperty), DisplayName(CsDisplayName.Email)]
        [EmailAddress(ErrorMessage =CsResultConst.InvalidEmail)]
        public string Email { get; set; }

        [MinLength(3, ErrorMessage = CsResultConst.Minlength3),
         MaxLength(25, ErrorMessage = CsResultConst.Maxlength25),
          Required(ErrorMessage = CsResultConst.RequiredProperty), DisplayName(CsDisplayName.Title)]
        public string Title { get; set; }


        [MinLength(3, ErrorMessage = CsResultConst.Minlength3),
         MaxLength(500, ErrorMessage = CsResultConst.Maxlength500),
          Required(ErrorMessage = CsResultConst.RequiredProperty), DisplayName(CsDisplayName.Note)]
        public string Note { get; set; }
    }
}
