using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("City")]
    public class City
    {
        public City()
        {
            Personel = new HashSet<Personel>();
        }
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }

        [StringLength(50), MinLength(3), Required]
        public string Name { get; set; }
        public bool Status { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Personel>  Personel { get; set; }
    }
}
