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
    public class ActionService : IActionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<ActionListDTO> GetActionList()
        {
            var actionList = (
                from action in _unitOfWork.Repository<Event>().Query()
                select new ActionListDTO()
                {
                    Id=action.Id,
                    Name=action.Name,
                    Date=action.Date.ToString("dd/MM/yyy"),
                    AboutEvent=action.AboutEvent,
                    AdditionalInfo=action.AdditionalInfo,
                    Location=action.Location,
                    BeginTime=action.BeginTime.ToString("0:HH:mm"),
                    EndTime=action.EndTime.ToString("0:HH:mm")
                }

                );

            return actionList;
        }
    }
}
