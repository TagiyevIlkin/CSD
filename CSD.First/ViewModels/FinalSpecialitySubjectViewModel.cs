using CSD.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.ViewModels
{
    public class FinalSpecialitySubjectViewModel
    {
        public List<SpecialitySubject> SpecialitySubjectsForSpeciality { get; set; }
        public SpecialitySubjectViewModel SpecialitySubjectViewModel { get; set; }
        public string CurrentSpeciality { get; set; }
        public List<Subject> SubjectList { get; set; }
        public List<Semester>  SemesterList { get; set; }
        public List<Credit>  CreditList { get; set; }
    }
}
