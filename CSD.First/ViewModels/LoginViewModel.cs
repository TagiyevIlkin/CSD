using CSD.ComSciDep.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName(CsDisplayName.UserName)]
        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        public string Username { get; set; }

        [DisplayName(CsDisplayName.Password)]
        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
