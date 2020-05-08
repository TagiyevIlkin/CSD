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

namespace CSD.First.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INoteService _noteService;
        public NoteController(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            INoteService noteService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _noteService = noteService;
        }


        #region NoteListForTable

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

            var model = _noteService.GetNoteList();


            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m => m.Name == searchValue
                                         || (m.Name != null && m.Name.StartsWith(searchValue))
                                         || (m.Title != null && m.Title.StartsWith(searchValue)));
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


        #region Show Message
        [HttpGet]
        public IActionResult Show(int Id)
        {
            var model = _unitOfWork.Repository<Message>().GetById(Id);
            if (model == null) return NotFound();
            var messageViewModel = _mapper.Map<MessageViewModel>(model);
            return PartialView("_Show", messageViewModel);
        }
        #endregion

        #region Delete Message
        public async Task<IActionResult> Delete(int Id)
        {
            var message = await _unitOfWork.Repository<Message>().GetByIdAsync(Id);
            if (message == null) return NotFound();
            var result = await _unitOfWork.Repository<Message>().DeleteAsync(message);
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
    }
}