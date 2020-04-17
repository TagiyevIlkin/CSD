using AutoMapper;
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

        }
    }
}
