using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSD.ComSciDep.DTO
{
    public class UserForComboBoxDTO
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50), MinLength(3), Required]
        public string Username { get; set; }
    }
}
