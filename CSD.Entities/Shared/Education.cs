using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("Education")]
    public class Education
    {
        [Key]
        public int Id { get; set; }

        public bool Status { get; set; }

        [MaxLength(100), MinLength(3), Required]
        public string EducationalInstitution { get; set; }

        [MaxLength(60), MinLength(3), Required]
        public string Specialty { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        public DateTime BeginTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        [MaxLength(100), MinLength(3), Required]
        public string Faculty { get; set; }
        public int EducationDegreeId { get; set; }

        public int CityId { get; set; }
        public int DocumentId { get; set; }
        public int PersonelId { get; set; }

        [ForeignKey("EducationDegreeId")]
        public virtual EducationDegree EducationDegree { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [ForeignKey("DocumentId")]
        public virtual Document Document { get; set; }

        [ForeignKey("PersonelId")]
        public virtual Personel Personel { get; set; }


    }
}
