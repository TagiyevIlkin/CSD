using AutoMapper;
using CSD.Entities.Computer_Engineering;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSD.First.Helper
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<Personel, PersonViewModel>().ReverseMap();
            CreateMap<DepartmentPosition, DepartmentPositionViewModel>().ReverseMap();
            CreateMap<Education, EducationViewModel>().ReverseMap();
            CreateMap<WorkExperience, WorkExperienceViewModel>().ReverseMap();
            CreateMap<LevelOfLanguage, LanguageViewModel>().ReverseMap();
            CreateMap<KnownProgram, KnownProgramViewModel>().ReverseMap();
            CreateMap<PersonDocument, PersonDocumentViewModel>().ReverseMap();
            CreateMap<PersonDocument, PersonDocumentViewModelForEdit>().ReverseMap();
            CreateMap<SpecialitySubject, SpecialitySubjectViewModel>().ReverseMap();

        }
    }
}
