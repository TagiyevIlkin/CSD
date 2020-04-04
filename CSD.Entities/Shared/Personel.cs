using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    [Table("Personel")]
    public class Personel
    {
        public Personel()
        {
            PersonPhone = new HashSet<PersonPhone>();
        }
        [Key]
        public int Id { get; set; }

      
        [StringLength(50), MinLength(3), Required]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50), MinLength(3)]
        public string Lastname { get; set; }


        [Required]
        [StringLength(50), MinLength(3)]
        public string FatherName { get; set; }

        public string Fullname
        {
            get { return $"{Firstname} {Lastname} {FatherName}"; }
        }

        public DateTime Birthdate { get; set; }

        [Required]
        [StringLength(100), MinLength(3)]
        public string Residence { get; set; }

        [DataType(DataType.PostalCode)]
        public string FinCode { get; set; }

        [DataType(DataType.PostalCode)]
        public string SerialNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int CityId { get; set; }

        public int GenderId { get; set; }

        public int FamilyStatusId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }
        [ForeignKey("FamilyStatusId")]
        public virtual FamilyStatus FamilyStatus { get; set; }



        public virtual ICollection<PersonPhone> PersonPhone { get; set; }

    }
}
