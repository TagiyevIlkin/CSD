using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Computer_Engineering
{
    [Table("Proqrams")]
    public class Proqrams
    {
        [Key]
        public int Id { get; set; }
        [MinLength(1),MaxLength(15),Required]
        public string Name { get; set; }
    }
}
