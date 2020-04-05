using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("DocumetType")]

    public class DocumetType
    {
        public DocumetType()
        {
            PersonDocument = new HashSet<PersonDocument>();
        }
        [Key]
        public int Id { get; set; }

        [MinLength(3), MaxLength(10), Required]
        public string Name { get; set; }

        public virtual ICollection<PersonDocument>  PersonDocument { get; set; }
    }
}
