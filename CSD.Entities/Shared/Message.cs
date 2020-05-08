using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3), MaxLength(20), Required]
        public string Name { get; set; }
        [MinLength(3), MaxLength(20), Required]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(3), MaxLength(25), Required]
        public string Title { get; set; }
        [MaxLength(500), MinLength(3), Required]
        public string Note { get; set; }
    }
}
