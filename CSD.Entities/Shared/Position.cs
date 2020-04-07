using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("Position")]
    public class Position
    {
        public Position()
        {
            DepartmentPosition = new HashSet<DepartmentPosition>();
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection< DepartmentPosition> DepartmentPosition { get; set; }
    }
}
