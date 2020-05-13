using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3),MaxLength(100),Required]
        public string Name { get; set; }

        [MinLength(3), MaxLength(500), Required]
        public string AboutEvent { get; set; }

        [MinLength(3), MaxLength(100), Required]
        public string Location { get; set; }

        [MinLength(3), MaxLength(500)]
        public string AdditionalInfo { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime BeginTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
    }
}
