using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static CSD.Utility.Enum;

namespace CSD.First.Controllers
{
    public class AboutController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AboutController(
            IMapper mapper,
            IUnitOfWork unitOfWork
           )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var departmentPosition = _unitOfWork.Repository<DepartmentPosition>().Find(x => x.PositionId == (int)EPosition.DepartmentChief);
            var aboutViewModel = new AboutViewModel()
            {
                AssistantCount = _unitOfWork.Repository<DepartmentPosition>().FindAll(x => x.AcademicDegreeId == (int)EAcademicDegree.Assistant).Count(),
                DocentCount = _unitOfWork.Repository<DepartmentPosition>().FindAll(x => x.AcademicDegreeId == (int)EAcademicDegree.Docent).Count(),
                HeadTeacherCount = _unitOfWork.Repository<DepartmentPosition>().FindAll(x => x.AcademicDegreeId == (int)EAcademicDegree.HeadTeacher).Count(),
                ProfessorCount = _unitOfWork.Repository<DepartmentPosition>().FindAll(x => x.AcademicDegreeId == (int)EAcademicDegree.Professor).Count(),
                TeachingAssistant = _unitOfWork.Repository<DepartmentPosition>().FindAll(x => x.AcademicDegreeId == (int)EAcademicDegree.TeacherAssistant).Count(),
                DepartmentChief = _unitOfWork.Repository<Personel>().Find(x => x.Id == departmentPosition.PersonelId).Fullname,
                DepartmentChiefAcademicDegree = _unitOfWork.Repository<AcademicDegree>().GetById(departmentPosition.AcademicDegreeId).Name
            };


            return View(aboutViewModel);
        }
    }
}