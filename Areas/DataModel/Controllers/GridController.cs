using FineUIMvc.Examples.Areas.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DataModel.Controllers
{
    public class GridController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DataModel/Grid
        public ActionResult Index()
        {
            return View(StudentHelper.GetSimpleStudentList());
        }


    }
}