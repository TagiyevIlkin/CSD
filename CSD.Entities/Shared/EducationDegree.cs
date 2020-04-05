using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("EducationDegree")]
    public class EducationDegree
    {
        public EducationDegree()
        {
            Education = new HashSet<Education>();
        }
        [Key]
        public int Id { get; set; }
        [MinLength(3),MaxLength(15),Required]
        public string Name { get; set; }

        public virtual ICollection<Education>  Education { get; set; }
    }
}
