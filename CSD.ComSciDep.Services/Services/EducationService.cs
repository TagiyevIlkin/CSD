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
    public class EducationService : IEducationService
    {
        private IUnitOfWork _unitOfWork;
        public EducationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<EducationListDTO> GetEducationLists()
        {
            var educationList = (

                from education in _unitOfWork.Repository<Education>().Query()
                join

                 person in _unitOfWork.Repository<Personel>().Query() on education.PersonelId equals person.Id
                into personList
                from personFialResult in personList.DefaultIfEmpty()

                join educationDegree in _unitOfWork.Repository<EducationDegree>().Query() on education.EducationDegreeId equals educationDegree.Id
                into educatinDegreeList
                from educationDegreeFinalResult in educatinDegreeList.DefaultIfEmpty()

                join city in _unitOfWork.Repository<City>().Query() on education.CityId equals city.Id
                into cityList
                from cityFinalResult in cityList.DefaultIfEmpty()

                join document in _unitOfWork.Repository<Document>().Query() on education.DocumentId equals document.Id
                into documentList
                from documentFinalResult in documentList.DefaultIfEmpty()

                select new EducationListDTO()
                {
                    Id = education.Id,
                    BeginTime = education.BeginTime.ToString("dd/MM/yyyy"),
                    EndTime = education.EndTime.ToString("dd/MM/yyyy"),
                    EducationalInstitution = education.EducationalInstitution,
                    Specialty = education.Specialty,
                    Status = education.Status,
                    CityName = cityFinalResult.Name,
                    DocumentName = documentFinalResult.Name,
                    EducationDegreeName = educationDegreeFinalResult.Name,
                    PersonelFullName = personFialResult.Fullname,
                    Faculty=education.Faculty
                }

                );

            return educationList;
        }
    }
}
