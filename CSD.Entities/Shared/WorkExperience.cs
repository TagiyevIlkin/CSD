using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{

    [Table("WorkExperience")]
    public class WorkExperience
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3), MaxLength(250), Required]
        public string CompanyName { get; set; }

        [MinLength(3), MaxLength(60), Required]
        public string Position { get; set; }

        [MinLength(3), MaxLength(500), Required]
        public string JobResponsibilities { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime BeginDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndTme { get; set; }

        public int PersonelId { get; set; }


        [ForeignKey("PersonelId")]
        public virtual Personel Personel { get; set; }

    }
}
