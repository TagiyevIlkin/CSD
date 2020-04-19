using System;
using System.Collections.Generic;
using System.Text;

namespace CSD.ComSciDep.DTO
{
    public class WorkExperienceListDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public string Position { get; set; }

        public string JobResponsibilities { get; set; }

        public string BeginDate { get; set; }

        public string EndTime { get; set; }

        public string PersonFullName { get; set; }
        public string AdditionalInfo { get; set; }
        public string CityName { get; set; }


    }
}
