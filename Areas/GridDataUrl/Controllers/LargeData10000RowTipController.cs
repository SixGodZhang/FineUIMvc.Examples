using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class LargeData10000RowTipController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/LargeData10000RowTip
        public ActionResult Index()
        {
            return View();
        }


    }
}