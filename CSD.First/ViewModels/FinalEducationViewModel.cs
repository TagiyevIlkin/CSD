using CSD.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class FinalEducationViewModel
    {
        public EducationViewModel EducationViewModel { get; set; }
        public ICollection<Education> EducationsForPerson { get; set; }
        public List<City> CityLIst { get; set; }
        public List<Document> DocumentLIst { get; set; }
        public List<EducationDegree> EducationDegreeLIst { get; set; }
        public string CurrentPerson { get; set; }
    }
}
