using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSD.ComSciDep.Services.Interfaces;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSD.First.Controllers
{
    public class SpecialityController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SpecialityController(
            IMapper mapper,
            IUnitOfWork unitOfWork
          )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var specialityVievModel = new SpecialityVievModel()
            {
                Title = "İxtisaslar",
                SpecialityList = _unitOfWork.Repository<Specialty>().GetAll().ToList()
            };

            return View(specialityVievModel);
        }


        #region Create 


        #endregion
    }
}