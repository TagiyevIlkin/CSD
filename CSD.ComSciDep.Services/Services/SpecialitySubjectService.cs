using CSD.ComSciDep.DTO;
using CSD.ComSciDep.Services.Interfaces;
using CSD.Entities.Shared;
using CSD.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static CSD.Utility.Enum;

namespace CSD.ComSciDep.Services.Services
{
    public class SpecialitySubjectService : ISpecialitySubjectService
    {
        private IUnitOfWork _unitOfWork;
        public SpecialitySubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<SpecialitySubjectListDTO> GetSpecialitySubjectList()
        {
            var list = (

                from speciality in _unitOfWork.Repository<Specialty>().Query()
                select new SpecialitySubjectListDTO()
                {
                    Id = speciality.Id,
                    Code = speciality.Code,
                    Major = speciality.Major,
                }

                );

            return list;
        }
    }
}
