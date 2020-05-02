using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("SpecialitySubject")]
    public class SpecialitySubject
    {
        [Key]
        public int Id { get; set; }
        public int SpecialityId { get; set; }
        public int SubjectId { get; set; }
        public int CreditId { get; set; }
        public int SemesterId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        [ForeignKey("CreditId")]
        public virtual Credit Credit { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }

        [ForeignKey("SpecialityId")]
        public virtual Specialty Specialty { get; set; }

        

    }
}
