using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("Specialty")]
    public class Specialty
    {
        [Key]
        public int Id { get; set; }
        [Required,MinLength(3),MaxLength(50)]
        public string  Major { get; set; }
        [Required, MinLength(3), MaxLength(10)]
        public string  Code { get; set; }
    }
}
