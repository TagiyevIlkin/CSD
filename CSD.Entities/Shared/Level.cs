using CSD.Entities.Computer_Engineering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("Level")]
    public class Level
    {
        public Level()
        {
            KnownProgram = new HashSet<KnownProgram>();
            LevelOfLanguage = new HashSet<LevelOfLanguage>();
        }
        [Key]
        public int Id { get; set; }

        [MinLength(3), MaxLength(10), Required]
        public string Name { get; set; }

        public virtual ICollection<KnownProgram> KnownProgram { get; set; }
        public virtual ICollection<LevelOfLanguage> LevelOfLanguage { get; set; }

    }
}
