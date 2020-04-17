using CSD.ComSciDep.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [StringLength(50), MinLength(3, ErrorMessage = CsResultConst.Minlength3)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [StringLength(50,ErrorMessage =CsResultConst.Maxlength50), MinLength(3,ErrorMessage =CsResultConst.Minlength3)]
        public string Lastname { get; set; }


        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [StringLength(50, ErrorMessage = CsResultConst.Maxlength50), MinLength(3, ErrorMessage = (CsResultConst.Minlength3))]
        public string FatherName { get; set; }

        public string Fullname
        {
            get { return $"{Firstname} {Lastname} {FatherName}"; }
        }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [StringLength(100), MinLength(3,ErrorMessage =CsResultConst.RequiredProperty)]
        public string Residence { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [StringLength(7, ErrorMessage = CsResultConst.MaxlengthPinCode)]
        [MinLength(7, ErrorMessage = CsResultConst.MinlengthPinCode)]
        [DataType(DataType.PostalCode)]
        public string FinCode { get; set; }



        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        [DataType(DataType.PostalCode)]
        [StringLength(10, ErrorMessage = CsResultConst.MaxlengthSerialNumber)]
        [MinLength(10, ErrorMessage = CsResultConst.MinlengthSerialNumber)]
        public string SerialNumber { get; set; }


        [EmailAddress(ErrorMessage = CsResultConst.InvalidEmail)]
        public string Email { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        public int CityId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        public int GenderId { get; set; }

        [Required(ErrorMessage = CsResultConst.RequiredProperty)]
        public int FamilyStatusId { get; set; }

        [Phone]
        [StringLength(50), MinLength(10, ErrorMessage = CsResultConst.Minlength10)]
        public string Mobile { get; set; }

        [Phone]
        [StringLength(50), MinLength(10, ErrorMessage = CsResultConst.Minlength10)]
        public string Home { get; set; }


        [Phone]
        [StringLength(50), MinLength(10,ErrorMessage =CsResultConst.Minlength10)]
        public string Work { get; set; }
    }
}
