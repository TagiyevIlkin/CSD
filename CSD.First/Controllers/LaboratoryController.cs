using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSD.First.Controllers
{
    public class LaboratoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LaboratoryController(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var labs = _unitOfWork.Repository<Laboratory>().GetAll();
            var labViewModelList = new List<LaboratoryViewModel>();
            foreach (var item in labs)
            {
                var lab = _mapper.Map<LaboratoryViewModel>(item);
                if (lab.PicturePath!=null)
                {
                    lab.PicturePath = lab.PicturePath.Substring(7);
                }
                labViewModelList.Add(lab);
            }

            return View(labViewModelList);
        }
    }
}