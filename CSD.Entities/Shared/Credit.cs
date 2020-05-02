using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("Credit")]
    public class Credit
    {
        public Credit()
        {
            SpecialitySubject = new HashSet<SpecialitySubject>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SpecialitySubject> SpecialitySubject { get; set; }

    }
}
