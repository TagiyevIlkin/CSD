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


        #region SpecialitySubject

        public IActionResult ShowSubject(int Id)
        {
            FinalSpecialityViewModel finalSpecialityViewModel = new FinalSpecialityViewModel()
            {
                CreditList = _unitOfWork.Repository<Credit>().GetAll().ToList(),
                SemesterList = _unitOfWork.Repository<Semester>().GetAll().ToList(),
                SubjectList = _unitOfWork.Repository<Subject>().GetAll().ToList(),
                SpecialitySubjectsForSpeciality = _unitOfWork.Repository<SpecialitySubject>().FindAll(x => x.SpecialityId == Id).ToList(),
                CurrentSpeciality = _unitOfWork.Repository<Specialty>().GetById(Id).Major
            };
            return View(finalSpecialityViewModel);
        }


        #endregion
    }
}