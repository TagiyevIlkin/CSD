using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CSD.First.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //#region PersonListForTable

        //public IActionResult LoadDataForTable()
        //{
        //    var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
        //    // Skiping number of Rows count
        //    var start = Request.Form["start"].FirstOrDefault();
        //    // Paging Length 10,20
        //    var length = Request.Form["length"].FirstOrDefault();
        //    // Sort Column Name
        //    var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"]
        //        .FirstOrDefault();
        //    // Sort Column Direction ( asc ,desc)
        //    var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        //    // Search Value from (Search box)
        //    var searchValue = Request.Form["search[value]"].FirstOrDefault();

        //    //Paging Size (10,20,50,100)
        //    int pageSize = length != null ? Convert.ToInt32(length) : 0;
        //    int skip = start != null ? Convert.ToInt32(start) : 0;
        //    int recordsTotal = 0;

        //    var model = _userService.GetUserPersonList();


        //    if (!string.IsNullOrEmpty(searchValue))
        //    {
        //        model = model.Where(m => m.Fullname == searchValue
        //                                 || (m.Fullname != null && m.Fullname.StartsWith(searchValue))
        //                                 || (m.UserName != null && m.UserName.StartsWith(searchValue)));
        //    }


        //    //total number of rows count 
        //    recordsTotal = model.Count();
        //    //Paging 
        //    var data = model.Skip(skip).Take(pageSize).ToList();
        //    //Returning Json Data
        //    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        //}

        //#endregion



    }
}