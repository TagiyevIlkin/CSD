using CSD.ComSciDep.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class PersonelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage =CsResultConst.RequiredProperty)]
        [MaxLength(50,ErrorMessage =CsResultConst.Maxlength50), MinLength(3,ErrorMessage =CsResultConst.Minlength3)]
        [DisplayName(CsDisplayName.Name)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [MaxLength(50, ErrorMessage = CsResultConst.Maxlength50), MinLength(3, ErrorMessage = CsResultConst.Minlength3)]
        [DisplayName(CsDisplayName.Surname)]
        public string Lastname { get; set; }


        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [MaxLength(50, ErrorMessage = CsResultConst.Maxlength50), MinLength(3, ErrorMessage = CsResultConst.Minlength3)]
        [DisplayName(CsDisplayName.FatherName)]
        public string FatherName { get; set; }

        public string Fullname
        {
            get { return $"{Firstname} {Lastname} {FatherName}"; }
        }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Birthdate)]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [MaxLength(50, ErrorMessage = CsResultConst.Maxlength100), MinLength(3, ErrorMessage = CsResultConst.Minlength3)]
        [DisplayName(CsDisplayName.Residence)]
        public string Residence { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.FinCode)]
        [DataType(DataType.PostalCode)]
        public string FinCode { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.SerialNumber)]
        [DataType(DataType.PostalCode)]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [EmailAddress]
        [DisplayName(CsDisplayName.Email)]
        public string Email { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.BirthPlace)]
        public int CityId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.Gencer)]
        public int GenderId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DisplayName(CsDisplayName.FamilyStatus)]
        public int FamilyStatusId { get; set; }
    }
}
