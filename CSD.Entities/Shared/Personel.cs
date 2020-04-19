using CSD.Entities.Computer_Engineering;
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
            PersonDocument = new HashSet<PersonDocument>();
            Education = new HashSet<Education>();
            WorkExperience = new HashSet<WorkExperience>();
            KnownProgram = new HashSet<KnownProgram>();
            LevelOfLanguage = new HashSet<LevelOfLanguage>();
            UserApp = new HashSet<UserApp>();
            DepartmentPosition = new HashSet<DepartmentPosition>();
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
        public virtual ICollection<Education> Education { get; set; }
        public virtual ICollection<WorkExperience> WorkExperience { get; set; }
        public virtual ICollection<KnownProgram> KnownProgram { get; set; }
        public virtual ICollection<PersonDocument> PersonDocument { get; set; }
        public virtual ICollection<LevelOfLanguage> LevelOfLanguage { get; set; }
        public virtual ICollection<UserApp> UserApp { get; set; }
        public virtual ICollection<DepartmentPosition> DepartmentPosition { get; set; }

    }
}
