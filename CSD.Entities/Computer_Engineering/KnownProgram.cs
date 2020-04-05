using CSD.Entities.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Computer_Engineering
{
    [Table("KnownProgram")]
    public class KnownProgram
    {
        [Key]
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public int LevelId { get; set; }
        public int PersonelId { get; set; }

        [ForeignKey("ProgramId")]
        public virtual Program Proqram { get; set; }

        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }

        [ForeignKey("PersonelId")]
        public virtual Personel Personel { get; set; }
    }
}
