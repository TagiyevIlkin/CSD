using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("Certificate")]
    public class Certificate
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3), MaxLength(50), Required]
        public string Name { get; set; }

        public int PersonelId { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime ReceivedTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ExpiredTime { get; set; }

        [ForeignKey("PersonelId")]
        public virtual Personel Personel { get; set; }
    }
}
