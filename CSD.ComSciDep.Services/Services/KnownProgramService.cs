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
    public class KnownProgramService : IKnownProgramService
    {
        private IUnitOfWork _unitOfWork;
        public KnownProgramService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<KnownProgramListDTO> GetKnownProgramList()
        {

            var knownProgramList = (from knownProgram in _unitOfWork.Repository<KnownProgram>().Query()

                                    join person in _unitOfWork.Repository<Personel>().Query() on knownProgram.PersonelId equals person.Id
                                    into personList
                                    from personFialResult in personList.DefaultIfEmpty()

                                    join program in _unitOfWork.Repository<Program>().Query() on knownProgram.ProgramId equals program.Id
                                    into programList
                                    from finalProgramResult in programList.DefaultIfEmpty()

                                    join level in _unitOfWork.Repository<Level>().Query() on knownProgram.LevelId equals level.Id
                                    into levelList
                                    from finalLevelResult in levelList.DefaultIfEmpty()

                                    select new KnownProgramListDTO()
                                    {
                                        Id = knownProgram.Id,
                                        LevelName = finalLevelResult.Name,
                                        PersonFullName = personFialResult.Fullname,
                                        ProgramName = finalProgramResult.Name
                                    }



                                    );


            return knownProgramList;
        }
    }
}
