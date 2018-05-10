using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridTree.Controllers
{
    public class ExpandRowsController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridTree/ExpandRows
        public ActionResult Index()
        {
            return View();
        }


    }
}