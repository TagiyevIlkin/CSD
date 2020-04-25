using CSD.ComSciDep.DTO;
using CSD.ComSciDep.Services.Interfaces;
using CSD.Entities.Computer_Engineering;
using CSD.Entities.Shared;
using CSD.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSD.ComSciDep.Services.Services
{
    public class LanguageService : ILanguageService
    {
        private IUnitOfWork _unitOfWork;
        public LanguageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<LanguageListDTO> GetLanguageList()
        {
            var List = (
                from languageOfLevel in _unitOfWork.Repository<LevelOfLanguage>().Query()

                join person in _unitOfWork.Repository<Personel>().Query() on languageOfLevel.PersonelId equals person.Id
                into personList
                from personFialResult in personList.DefaultIfEmpty()

                join language in _unitOfWork.Repository<Language>().Query() on languageOfLevel.LanguageId equals language.Id
                into languageList
                from finalLanguageResult in languageList.DefaultIfEmpty()

                join level in _unitOfWork.Repository<Level>().Query() on languageOfLevel.LevelId equals level.Id
                into levelList
                from finalLevelResult in levelList.DefaultIfEmpty()

                select new LanguageListDTO()
                {
                    Id = languageOfLevel.Id,
                    LanguageName = finalLanguageResult.Name,
                    LevelName = finalLevelResult.Name,
                    PersonFullName = personFialResult.Fullname
                }

                );

            return List;
        }
    }
}
