using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridTree.Controllers
{
    public class GridTreeController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridTree/GridTree
        public ActionResult Index()
        {
            return View();
        }


    }
}