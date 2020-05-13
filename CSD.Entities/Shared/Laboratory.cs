using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("Laboratory")]
    public class Laboratory
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2), MaxLength(100), Required]
        public string Name { get; set; }

        [MaxLength(4), Required]
        public string RoomNumber { get; set; }

        public string PicturePath { get; set; }
        public string PictureName { get; set; }

        [MinLength(3), MaxLength(250)]
        public string AdditionalInfo { get; set; }
    }
}
