using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Computer_Engineering
{
    [Table("Program")]
    public class Program
    {
        public Program()
        {
            KnownProgram = new HashSet<KnownProgram>();
        }
        [Key]
        public int Id { get; set; }
        [MinLength(1), MaxLength(15), Required]
        public string Name { get; set; }
        public virtual ICollection<KnownProgram> KnownProgram { get; set; }

    }
}
