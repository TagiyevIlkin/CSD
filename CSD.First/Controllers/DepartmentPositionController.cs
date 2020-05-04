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
using Microsoft.Extensions.Configuration;
using static CSD.Utility.Enum;

namespace CSD.First.Controllers
{
    [Authorize]

    public class DepartmentPositionController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentPositionService _departmentPositionService;
        public DepartmentPositionController(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IDepartmentPositionService departmentPositionService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _departmentPositionService = departmentPositionService;
        }





        #region DepartmetPositionListForTable

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

            var model = _departmentPositionService.GetDepartmentPositionList();


            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m => m.PersonName == searchValue
                                         || (m.PersonName != null && m.PersonName.StartsWith(searchValue))
                                         || (m.PositionName != null && m.PositionName.StartsWith(searchValue)));
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


        #region Create DepartmentPosition


        [HttpGet]
        public IActionResult Create()
        {
            FillComboBox();
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public JsonResult Create(DepartmentPositionViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_unitOfWork.Repository<DepartmentPosition>().Exist(x => x.PersonelId == model.PersonelId))
                {
                    if (!_unitOfWork.Repository<DepartmentPosition>().Exist(x=>x.PositionId==(int)EPosition.DepartmentChief))
                    {
                        var departmentPosition = _mapper.Map<DepartmentPosition>(model);
                        var result = _unitOfWork.Repository<DepartmentPosition>().Add(departmentPosition);
                        if (result.IsSuccess)
                        {
                            return Json(new
                            {
                                status = 200,
                                message = CsResultConst.AddSuccess
                            });
                        }
                        return Json(new
                        {
                            status = 406,
                            message = CsResultConst.Error
                        });
                    }
                    return Json(new
                    {
                        status = 202,
                        message = CsResultConst.AleadyExistedDepartmentChief
                    });
                }
                return Json(new
                {
                    status = 201,
                    message = CsResultConst.AleadyExistedPersonPosition
                });
            }
            return Json(new
            {
                status = 404,
                message = CsResultConst.ModelNotValid
            });
        }

        #endregion

        #region Edit DepartmentPosition

        public IActionResult Edit(int Id)
        {
            var departmentPosition = _unitOfWork.Repository<DepartmentPosition>().GetById(Id);
            if (departmentPosition == null) return NotFound();
            FillComboBox();
            var departmentPositionViewModel = _mapper.Map<DepartmentPositionViewModel>(departmentPosition);
            departmentPositionViewModel.PreviousPersonelId = departmentPosition.PersonelId;
            departmentPositionViewModel.PreviousPersonelFullName = _unitOfWork.Repository<Personel>().GetById(departmentPosition.PersonelId).Fullname;
            return View(departmentPositionViewModel);

        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public JsonResult Edit(DepartmentPositionViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (model.PreviousPersonelId==model.PersonelId)
                {
                    var departmentposition = _mapper.Map<DepartmentPosition>(model);

                    var resilt = _unitOfWork.Repository<DepartmentPosition>().Update(departmentposition);
                    if (resilt.IsSuccess)
                    {
                        return Json(new
                        {
                            status = 200,
                            message = CsResultConst.EditSuccess
                        });
                    }
                }

                if (!(_unitOfWork.Repository<DepartmentPosition>().Exist(x=>x.PersonelId==model.PersonelId && 
                _unitOfWork.Repository<DepartmentPosition>().Exist(m=>m.PositionId!=model.PreviousPersonelId))))
                {
                    var departmentposition= _mapper.Map<DepartmentPosition>(model);

                    var resilt = _unitOfWork.Repository<DepartmentPosition>().Update(departmentposition);
                    if (resilt.IsSuccess)
                    {
                        return Json(new
                        {
                            status = 200,
                            message = CsResultConst.EditSuccess
                        });
                    }

                    return Json(new
                    {
                        status = 406,
                        message = CsResultConst.Error
                    });
                }

                return Json(new
                {
                    status = 201,
                    message = CsResultConst.AleadyExistedPersonPosition
                });

            }

            return Json(new
            {
                status = 404,
                message = CsResultConst.ModelNotValid
            });

        }
        #endregion

        #region Delete DepartmentPosition
        public async Task<IActionResult> Delete(int Id)
        {
            var departmentPosition = _unitOfWork.Repository<DepartmentPosition>().GetById(Id);
            if (departmentPosition == null) return NotFound();

            var result = await _unitOfWork.Repository<DepartmentPosition>().DeleteAsync(departmentPosition);
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
            ViewBag.AcademicDegreeId = _unitOfWork.Repository<AcademicDegree>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.PositionId = _unitOfWork.Repository<Position>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
        #endregion
    }
}