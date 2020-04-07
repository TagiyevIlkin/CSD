using System;
using System.Collections.Generic;
using System.Text;

namespace CSD.ComSciDep.DTO
{
    public class PersonListDTO
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Fullname { get; set; }

        public bool Status { get; set; }
        public string Birthdate { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string FamilyStatus { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string Lastname { get; set; }
        public string FinCode { get; set; }
        public string Residence { get; set; }
        public string SerialNumber { get; set; }
        public string Number { get; set; }
    }
}
