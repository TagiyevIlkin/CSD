using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSD.Entities.Shared
{
    [Table("Country")]
    public class Country
    {

        public Country()
        {
            City = new HashSet<City>();
            PersonPhone = new HashSet<PersonPhone>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(50), MinLength(3), Required]
        public string Name { get; set; }
        public string NumCode { get; set; }
        public string Phonecode { get; set; }

        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<PersonPhone> PersonPhone { get; set; }
    }
}
