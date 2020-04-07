﻿using System;
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
            DepartmentPosition = new HashSet<DepartmentPosition>();
        }
        [Key]
        public int Id { get; set; }

        [MinLength(3), MaxLength(20), Required]
        public string Name { get; set; }

        public virtual ICollection<DepartmentPosition> DepartmentPosition { get; set; }

    }
}
