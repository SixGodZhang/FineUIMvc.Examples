using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class LargeData10000LocationController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/LargeData10000Location
        public ActionResult Index()
        {
            return View();
        }


    }
}