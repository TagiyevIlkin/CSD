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
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<PersonListDTO> GetUserPersonList()
        {

            var userPersonList = (from person in _unitOfWork.Repository<Personel>().Query()
                                  join user in _unitOfWork.Repository<UserApp>().Query() on person.Id equals user.PersonelId
                                      into list1
                                  from l1 in list1.DefaultIfEmpty()
                                  join personPhone in _unitOfWork.Repository<PersonPhone>().Query()
                                          .GroupBy(p => p.PersonelId)
                                          .Select(p => new { PersonelId = p.Key, Number = String.Join("   ", p.Select(y => y.Number)) })
                                      on person.Id equals personPhone.PersonelId
                                      into list2
                                  from l2 in list2.DefaultIfEmpty()
                                  select new PersonListDTO
                                  {
                                      Id = person.Id,
                                      Status = l1.Status,
                                      UserName = l1.UserName,
                                      UserId = l1.Id,
                                      Birthdate = person.Birthdate.ToString("dd/MM/yyyy"),
                                      City = person.City.Name,
                                      Gender = person.Gender.Type,
                                      FamilyStatus = person.FamilyStatus.Name,
                                      Email = person.Email,
                                      FatherName = person.FatherName,
                                      FirstName = person.FatherName,
                                      Fullname = person.Fullname,
                                      Lastname = person.Lastname,
                                      FinCode = person.FinCode,
                                      Residence = person.Residence,
                                      SerialNumber = person.SerialNumber,
                                      PersonelId = person.Id,
                                      Number = l2.Number,

                                  }).OrderByDescending(x => x.Id);

            return userPersonList;
        }

    }
}
