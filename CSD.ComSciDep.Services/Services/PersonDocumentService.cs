
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
    public class PersonDocumentService : IPersonDocumentService
    {
        private IUnitOfWork _unitOfWork;
        public PersonDocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<PersonDocumentListDTO> GetPersonDocumentList()
        {
            var personDocumentList = (from personDocument in _unitOfWork.Repository<PersonDocument>().Query()

                                      join person in _unitOfWork.Repository<Personel>().Query() on personDocument.PersonelId equals person.Id
                                      into personList
                                      from personFialResult in personList.DefaultIfEmpty()

                                      join documentType in _unitOfWork.Repository<DocumetType>().Query() on personDocument.DocumentTypeId equals documentType.Id
                                      into documentTypeList
                                      from finalDocumentTypeResult in documentTypeList.DefaultIfEmpty()

                                      select new PersonDocumentListDTO()
                                      {
                                          Id=personDocument.Id,
                                          Name=personDocument.Name,
                                          Path=personDocument.Path,
                                          DocumentTypeName = finalDocumentTypeResult.Name,
                                          PersonFullName=personFialResult.Fullname
                                      }

                                      );

            return personDocumentList;
        }
    }
}
