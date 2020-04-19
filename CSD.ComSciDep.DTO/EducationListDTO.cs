using System;
using System.Collections.Generic;
using System.Text;

namespace CSD.ComSciDep.DTO
{
    public class EducationListDTO
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string EducationalInstitution { get; set; }
        public string Specialty { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public string EducationDegreeName { get; set; }
        public string CityName { get; set; }
        public string DocumentName { get; set; }
        public string PersonelFullName { get; set; }
        public string Faculty { get; set; }

    }
}
