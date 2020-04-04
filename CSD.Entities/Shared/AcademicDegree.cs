using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("AcademicDegree")]
    public class AcademicDegree
    {
        public AcademicDegree()
        {
            Personel = new HashSet<Personel>();
        }
        [Key]
        public int Id { get; set; }

        [MinLength(3),MaxLength(20),Required]
        public string  Name { get; set; }

        public virtual ICollection<Personel> Personel { get; set; }
    }
}
