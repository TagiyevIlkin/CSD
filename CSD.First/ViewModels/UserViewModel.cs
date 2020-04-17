using CSD.ComSciDep.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public int PersonelId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [StringLength(50)]
        [MinLength(3, ErrorMessage = CsResultConst.Minlength3)]
        [DisplayName(CsDisplayName.UserName)]
        public string Username { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [StringLength(50)]
        [MinLength(6, ErrorMessage = CsResultConst.MinlengthLogin)]
        [DisplayName(CsDisplayName.Password)]
        public string Password { get; set; }

        [StringLength(50)]
        [MinLength(6, ErrorMessage = CsResultConst.MinlengthLogin)]
        public string PasswordEdit { get; set; }

        public IEnumerable<string> GetRoles { get; set; }

        public bool Status { get; set; }
    }
}
