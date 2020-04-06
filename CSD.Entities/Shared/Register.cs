using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("Register")]
    public class Register
    {
        [Key]
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

        [EmailAddress]
        public string Email { get; set; }

    }
}
