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
    public class WorkExperienceService : IWorkExperienceService
    {

        private IUnitOfWork _unitOfWork;
        public WorkExperienceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<WorkExperienceListDTO> GetWorkExperienceList()
        {
            var workExperienceList = (

                 from workExperience in _unitOfWork.Repository<WorkExperience>().Query()
                 join

                  person in _unitOfWork.Repository<Personel>().Query() on workExperience.PersonelId equals person.Id
                 into personList
                 from personFialResult in personList.DefaultIfEmpty()
                 join city in _unitOfWork.Repository<City>().Query() on workExperience.CityId equals city.Id
               into cityList
                 from cityFinalResult in cityList.DefaultIfEmpty()
                 select new WorkExperienceListDTO()
                 {
                     Id = workExperience.Id,
                     BeginDate = workExperience.BeginDate.ToString("dd/MM/yyyy"),
                     EndTime = workExperience.EndTme.ToString("dd/MM/yyyy"),
                     CompanyName = workExperience.CompanyName,
                     JobResponsibilities = workExperience.JobResponsibilities,
                     Position = workExperience.Position,
                     PersonFullName = personFialResult.Fullname,
                     AdditionalInfo = workExperience.AdditionalInfo,
                     CityName = cityFinalResult.Name
                 }

                );


            return workExperienceList;
        }
    }
}

