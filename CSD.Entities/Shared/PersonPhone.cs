using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("PersonPhone")]
    public class PersonPhone
    {
        [Key]
        public int Id { get; set; }

        public int PersonelId { get; set; }

        public int CountryId { get; set; }

        public int PhoneTypeId { get; set; }

        [StringLength(50), MinLength(3), Required]
        public string Number { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [ForeignKey("PhoneTypeId")]
        public virtual PhoneType PhoneType { get; set; }


        [ForeignKey("PersonelId")]
        public virtual Personel Personel { get; set; }
    }
}
