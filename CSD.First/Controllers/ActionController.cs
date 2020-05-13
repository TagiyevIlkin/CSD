using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSD.ComSciDep.Services.Interfaces;
using CSD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSD.First.Controllers
{
    public class ActionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IActionService _actionService;
        public ActionController(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IActionService actionService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _actionService = actionService;
        }


        #region ActionListForTable

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

            var model = _actionService.GetActionList();

            if (!string.IsNullOrEmpty(searchValue))
            {
                model = model.Where(m => m.Name == searchValue
                                         || (m.Name != null && m.Name.StartsWith(searchValue))
                                         || (m.BeginTime != null && m.BeginTime.StartsWith(searchValue)));
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


        #region Create Action
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        #endregion
    }
}