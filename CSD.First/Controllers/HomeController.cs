using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static CSD.Utility.Enum;

namespace CSD.First.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(
            IMapper mapper,
            IUnitOfWork unitOfWork
           )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult About()
        {
            var departmentPosition = _unitOfWork.Repository<DepartmentPosition>().Find(x => x.PositionId == (int)EPosition.DepartmentChief);
            var aboutViewModel = new AboutViewModel()
            {
                AssistantCount = _unitOfWork.Repository<DepartmentPosition>().FindAll(x => x.AcademicDegreeId == (int)EAcademicDegree.Assistant).Count(),
                DocentCount = _unitOfWork.Repository<DepartmentPosition>().FindAll(x => x.AcademicDegreeId == (int)EAcademicDegree.Docent).Count(),
                HeadTeacherCount = _unitOfWork.Repository<DepartmentPosition>().FindAll(x => x.AcademicDegreeId == (int)EAcademicDegree.HeadTeacher).Count(),
                ProfessorCount = _unitOfWork.Repository<DepartmentPosition>().FindAll(x => x.AcademicDegreeId == (int)EAcademicDegree.Professor).Count(),
                TeachingAssistant = _unitOfWork.Repository<DepartmentPosition>().FindAll(x => x.AcademicDegreeId == (int)EAcademicDegree.TeacherAssistant).Count(),
                DepartmentChief=_unitOfWork.Repository<Personel>().Find(x=>x.Id==departmentPosition.PersonelId).Fullname,
                DepartmentChiefAcademicDegree= _unitOfWork.Repository<AcademicDegree>().GetById(departmentPosition.AcademicDegreeId).Name
            };


            return View(aboutViewModel);
        }
    }
}