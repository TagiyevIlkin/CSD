using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("FamilyStatus")]
    public class FamilyStatus
    {
        public FamilyStatus()
        {
            Personel = new HashSet<Personel>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(50), MinLength(3), Required]
        public string Name { get; set; }

        public virtual ICollection<Personel> Personel { get; set; }
    }
}
