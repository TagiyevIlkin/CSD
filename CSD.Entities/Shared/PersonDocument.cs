using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("PersonDocument")]
    public class PersonDocument
    {
        [Key]
        public int Id { get; set; }

        [MinLength(2), MaxLength(100), Required]
        public string Name { get; set; }

        public string Path { get; set; }
        public int DocumentTypeId { get; set; }
        public int PersonelId { get; set; }
        [ForeignKey("DocumentTypeId")]
        public virtual DocumetType DocumetType { get; set; }

        [ForeignKey("PersonelId")]
        public virtual Personel Personel { get; set; }


    }
}
