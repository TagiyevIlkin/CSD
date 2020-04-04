using CSD.Entities.Computer_Engineering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("Language")]
    public class Language
    {
        public Language()
        {
            LevelOfLanguage = new HashSet<LevelOfLanguage>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(50), MinLength(3), Required]
        public string Name { get; set; }

        public virtual ICollection<LevelOfLanguage> LevelOfLanguage { get; set; }
    }
}
