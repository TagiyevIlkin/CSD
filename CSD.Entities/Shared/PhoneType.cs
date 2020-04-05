using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("PhoneType")]
    public class PhoneType
    {
        public PhoneType()
        {
            PersonPhone = new HashSet<PersonPhone>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(50), MinLength(3), Required]
        public string Type { get; set; }
        public virtual ICollection<PersonPhone> PersonPhone { get; set; }
    }
}
