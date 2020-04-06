using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class RegisterViewModel
    {

        public int Id { get; set; }

        [StringLength(50), MinLength(3), Required]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50), MinLength(3)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(50), MinLength(3)]
        public string Username { get; set; }

        [Required]
        [StringLength(50), MinLength(3)]
        public string Password { get; set; }

        public string Fullname
        {
            get { return $"{Firstname} {Lastname}"; }
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
