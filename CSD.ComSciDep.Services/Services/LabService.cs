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
    public class LabService : ILabService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LabService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        LabListDTO labListDTO = new LabListDTO();
        public IQueryable<LabListDTO> GetLabList()
        {
            var labQuery = (
                from lab in _unitOfWork.Repository<Laboratory>().Query()
                select new LabListDTO()
                {
                    Id = lab.Id,
                    Name = lab.Name,
                    AdditionalInfo = lab.AdditionalInfo,
                    RoomNumber = lab.RoomNumber,
                    PicturePath = lab.PicturePath
                }
                );

            #region Substring wwwroot
            var labList = labQuery.ToList();
            List<LabListDTO> list2 = labList;

            for (int i = 0; i < labList.ToList().Count; i++)
            {
                if (labList[i].PicturePath != null)
                {
                    list2[i].PicturePath = labList[i].PicturePath.Substring(7);
                }
            }
            #endregion

            return list2.AsQueryable();
        }
    }
}
