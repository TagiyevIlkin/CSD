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
    public class PersonFeaturesService : IPersonFeaturesService
    {
        private IUnitOfWork _unitOfWork;
        public PersonFeaturesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<PersonListDTOForFeatures> GetPersonFutureList()
        {
            var personFeaturesList = (from person in _unitOfWork.Repository<Personel>().Query()

                                      select new PersonListDTOForFeatures()
                                      {
                                          Id = person.Id,
                                          PersonFullName = person.Fullname
                                      });

            return personFeaturesList;
        }
    }
}
