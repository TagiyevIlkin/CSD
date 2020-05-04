using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSD.ComSciDep.Services.Interfaces;
using CSD.ComSciDep.Utility;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSD.First.Controllers
{
    [Authorize]
    public class SpecialitySubjectController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISpecialitySubjectService _specialitySubjectService;
        public SpecialitySubjectController(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ISpecialitySubjectService specialitySubjectService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _specialitySubjectService = specialitySubjectService;
        }



        #region SpecialitySubjectListForTable

        public IActionResult LoadDataForTable()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            // Skiping number of Rows count
            var start = Request.Form["start"].FirstOrDefault();
            // Paging Length 10,20
            var length = Request.Form["length"].FirstOrDefault();
            // Sort Column Name
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"]
                .FirstOrDefault();
            // Sort Column Direction ( asc ,desc)
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            // Search Value from (Search box)
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10,20,50,100)
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var model = _specialitySubjectService.GetSpecialitySubjectList();


            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m => m.Major == searchValue
                                         || (m.Major != null && m.Major.StartsWith(searchValue))
                                         || (m.Code != null && m.Code.StartsWith(searchValue)));
            }
            //total number of rows count 
            recordsTotal = model.Count();
            //Paging 
            var data = model.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        }

        #endregion


        public IActionResult Index()
        {
            return View();
        }

        #region Create SpecialitySubject
        [HttpGet]
        public IActionResult Create(int Id)
        {
            FinalSpecialitySubjectViewModel finalSpecialitySubjectViewModel = new FinalSpecialitySubjectViewModel()
            {
                CurrentSpeciality = _unitOfWork.Repository<Specialty>().GetById(Id).Major,
                SpecialitySubjectsForSpeciality = _unitOfWork.Repository<SpecialitySubject>().FindAll(x => x.SpecialityId == Id).ToList(),
                CreditList = _unitOfWork.Repository<Credit>().GetAll().ToList(),
                SemesterList = _unitOfWork.Repository<Semester>().GetAll().ToList(),
                SubjectList = _unitOfWork.Repository<Subject>().GetAll().ToList(),
                SpecialitySubjectViewModel = new SpecialitySubjectViewModel()
                {
                    SpecialityId = Id
                }


            };
            FillComboBox();
            return View(finalSpecialitySubjectViewModel);
        }

        [HttpPost]
        public JsonResult Create(FinalSpecialitySubjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_unitOfWork.Repository<SpecialitySubject>().Exist(x => x.SpecialityId == model.SpecialitySubjectViewModel.SpecialityId && x.SubjectId == model.SpecialitySubjectViewModel.SubjectId))
                {
                    var specialitySubject = _mapper.Map<SpecialitySubject>(model.SpecialitySubjectViewModel);
                    var result = _unitOfWork.Repository<SpecialitySubject>().Add(specialitySubject);

                    var subject = _unitOfWork.Repository<Subject>().GetById(specialitySubject.SubjectId).Name;
                    var credit = _unitOfWork.Repository<Credit>().GetById(specialitySubject.CreditId).Name;

                    if (result.IsSuccess)
                    {
                        return Json(new
                        {
                            status = 200,
                            Id=specialitySubject.Id,
                            message = CsResultConst.AddSuccess,
                            Subject = subject,
                            Credit = credit,
                            SemesterId=specialitySubject.SemesterId.ToString()
                        });
                    }
                    FillComboBox();
                    return Json(new
                    {
                        status = 406,
                        message = CsResultConst.Error
                    });
                }
                FillComboBox();
                return Json(new
                {
                    status = 201,
                    message = CsResultConst.AleadyExistedSubject
                });
            }
            FillComboBox();
            return Json(new
            {
                status = 400,
                message = CsResultConst.ModelNotValid
            });
        }
        #endregion


        #region Delete SpecialitySubject

        public async Task<IActionResult> Delete(int Id)
        {
            var specialitySubject = await _unitOfWork.Repository<SpecialitySubject>().GetByIdAsync(Id);
            if (specialitySubject == null) return NotFound();

            var result = await _unitOfWork.Repository<SpecialitySubject>().DeleteAsync(specialitySubject);

            if (result.IsSuccess)
            {
                return Json(new
                {
                    status = 200,
                    message = CsResultConst.DeleteSuccess
                });
            }
            return Json(new
            {
                status = 406,
                message = CsResultConst.Error
            });


        }

        public async Task<IActionResult> DeleteAll(int Id)
        {
            var specialitySubjectList = await _unitOfWork.Repository<SpecialitySubject>().FindAllAsync(x => x.SpecialityId == Id);
            if (specialitySubjectList.Count == 0)
            {
                return Json(new
                {
                    status = 202,
                    message = CsResultConst.NoAnySubject
                });
            }

            var result = await _unitOfWork.Repository<SpecialitySubject>().DeleteRangeAsync(specialitySubjectList);

            if (result.IsSuccess)
            {
                return Json(new
                {
                    status = 200,
                    message = CsResultConst.DeleteSuccess
                });
            }
            return Json(new
            {
                status = 406,
                message = CsResultConst.Error
            });
        }

        #endregion


        #region FillComboBox
        private void FillComboBox()
        {
            ViewBag.SubjectId = _unitOfWork.Repository<Subject>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.CreditId = _unitOfWork.Repository<Credit>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.SemesterId = _unitOfWork.Repository<Semester>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
        #endregion
    }
}