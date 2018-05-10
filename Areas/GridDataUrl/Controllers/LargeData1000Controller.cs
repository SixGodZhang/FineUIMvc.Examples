using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class LargeData1000Controller : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/LargeData1000
        public ActionResult Index()
        {
            return View();
        }


    }
}