using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("DepartmentPosition")]
    public class DepartmentPosition
    {
        [Key]
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public int PositionId { get; set; }
        public int AcademicDegreeId { get; set; }
        [ForeignKey("PersonelId")]
        public virtual Personel Personel { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }

        [ForeignKey("AcademicDegreeId")]
        public virtual AcademicDegree AcademicDegree { get; set; }
    }
}
