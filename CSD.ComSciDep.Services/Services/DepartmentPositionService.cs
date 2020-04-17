using CSD.ComSciDep.DTO;
using CSD.ComSciDep.Services.Interfaces;
using CSD.Entities.Shared;
using CSD.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSD.ComSciDep.Services.Services
{
    public class DepartmentPositionService : IDepartmentPositionService
    {
        public IUnitOfWork _unitOfWork;
        public DepartmentPositionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<DepartmentPositionListDTO> GetDepartmentPositionList()
        {
            var departmentPositionList = (from departmentPosition in _unitOfWork.Repository<DepartmentPosition>().Query()
                                          join person in _unitOfWork.Repository<Personel>().Query() on departmentPosition.PersonelId equals person.Id
                                          into personList
                                          from personFinalResult in personList.DefaultIfEmpty()

                                          join position in _unitOfWork.Repository<Position>().Query() on departmentPosition.PositionId equals position.Id
                                          into positionList
                                          from positionFinalResult in positionList
                                          join academicDegree in _unitOfWork.Repository<AcademicDegree>().Query() on departmentPosition.AcademicDegreeId equals academicDegree.Id
                                          into academicList
                                          from academicFinalResult in academicList

                                          select new DepartmentPositionListDTO
                                          {
                                              Id = departmentPosition.Id,
                                              PositionName = positionFinalResult.Name,
                                              AcademicDegreeName = academicFinalResult.Name,
                                              PersonName = personFinalResult.Fullname
                                          }

                                          );


            return departmentPositionList;
        }
    }
}
