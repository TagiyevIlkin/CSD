using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("Gender")]
    public class Gender
    {
        public Gender()
        {
            Personel = new HashSet<Personel>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(10), MinLength(3), Required]
        public string Type { get; set; }

        public virtual ICollection<Personel> Personel { get; set; }
    }
}
