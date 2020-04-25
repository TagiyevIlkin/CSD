using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSD.ComSciDep.Services.Interfaces;
using CSD.ComSciDep.Utility;
using CSD.Entities.Computer_Engineering;
using CSD.Entities.Shared;
using CSD.First.ViewModels;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace CSD.First.Controllers
{
    public class KnownProgramController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKnownProgramService _knownProgramService;
        public KnownProgramController(IConfiguration configuration,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IKnownProgramService knownProgramService)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _knownProgramService = knownProgramService;
        }

        #region LanguageListForTable

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

            var model = _knownProgramService.GetKnownProgramList();


            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m => m.PersonFullName == searchValue
                                         || (m.PersonFullName != null && m.PersonFullName.StartsWith(searchValue))
                                         || (m.PersonFullName != null && m.PersonFullName.StartsWith(searchValue)));
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

        #region Create KnownProgram

        [HttpGet]
        public IActionResult Create(int Id)
        {
            FinalKnownProgramViewModel finalKnownProgramViewModel = new FinalKnownProgramViewModel()
            {
                KnownProgramsForPerson = _unitOfWork.Repository<KnownProgram>().FindAll(x => x.PersonelId == Id),
                ProgramList = _unitOfWork.Repository<CSD.Entities.Computer_Engineering.Program>().GetAll().ToList(),
                LevelList = _unitOfWork.Repository<Level>().GetAll().ToList(),
                CurrentPerson = _unitOfWork.Repository<Personel>().GetById(Id).Fullname,
                KnownProgramViewModel = new KnownProgramViewModel()
                {
                    PersonelId = Id
                }


            };
            FillComboBox();
            return View(finalKnownProgramViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public JsonResult Create(FinalKnownProgramViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (!_unitOfWork.Repository<KnownProgram>().Exist(x => x.ProgramId == model.KnownProgramViewModel.ProgramId && x.PersonelId == model.KnownProgramViewModel.PersonelId))
                {
                    var program = _mapper.Map<KnownProgram>(model.KnownProgramViewModel);
                    var result = _unitOfWork.Repository<KnownProgram>().Add(program);

                    string addedProgram = _unitOfWork.Repository<CSD.Entities.Computer_Engineering.Program>().GetById(program.ProgramId).Name;
                    string level = _unitOfWork.Repository<Level>().GetById(program.LevelId).Name;

                    if (result.IsSuccess)
                    {
                        return Json(new
                        {
                            status = 200,
                            message = CsResultConst.AddSuccess,
                            Id = program.Id,
                            Program = addedProgram,
                            Level = level
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
                    message = CsResultConst.AleadyExistedKnownProgram
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

        #region Edit KnownProgram

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var knownProgram = _unitOfWork.Repository<KnownProgram>().GetById(Id);
            if (knownProgram == null) return NotFound();
            var knownProgramViewModel = _mapper.Map<KnownProgramViewModel>(knownProgram);
            knownProgramViewModel.PreviousPersonFullName = _unitOfWork.Repository<Personel>().GetById(knownProgram.PersonelId).Fullname;
            knownProgramViewModel.PreviousPersonId = knownProgram.PersonelId;
            knownProgramViewModel.PreviousProgramId = knownProgram.ProgramId;
            FillComboBox();
            return View(knownProgramViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public JsonResult Edit(KnownProgramViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.PersonelId == model.PreviousPersonId && model.ProgramId == model.PreviousProgramId)
                {
                    var knownProgram = _mapper.Map<KnownProgram>(model);
                    var result = _unitOfWork.Repository<KnownProgram>().Update(knownProgram);

                    if (result.IsSuccess)
                    {
                        return Json(new
                        {
                            status = 200,
                            message = CsResultConst.EditSuccess
                        });
                    }
                }

                if (!_unitOfWork.Repository<KnownProgram>().Exist(x => x.ProgramId == model.ProgramId && x.PersonelId == model.PersonelId))
                {
                    var knownProgram = _mapper.Map<KnownProgram>(model);
                    var result = _unitOfWork.Repository<KnownProgram>().Update(knownProgram);

                    if (result.IsSuccess)
                    {
                        return Json(new
                        {
                            status = 200,
                            message = CsResultConst.EditSuccess
                        });
                    }
                }
                FillComboBox();
                return Json(new
                {
                    status = 201,
                    message = CsResultConst.AleadyExistedKnownProgram
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

        #region Delete KnownProgram
        public async Task<IActionResult> Delete(int Id)
        {
            var program = await _unitOfWork.Repository<KnownProgram>().GetByIdAsync(Id);
            if (program == null) return NotFound();
            var result = await _unitOfWork.Repository<KnownProgram>().DeleteAsync(program);

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
            ViewBag.ProgramId = _unitOfWork.Repository<CSD.Entities.Computer_Engineering.Program>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.LevelId = _unitOfWork.Repository<Level>().Query().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
        #endregion
    }
}