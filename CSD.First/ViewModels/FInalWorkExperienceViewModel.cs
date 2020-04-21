using CSD.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class FInalWorkExperienceViewModel
    {
        public WorkExperienceViewModel  WorkExperienceViewModel { get; set; }

        public ICollection<WorkExperience> WorkExperiencesForPerson { get; set; }
        public List<City> CityLIst { get; set; }
        public string CurrentPerson { get; set; }
    }
}
