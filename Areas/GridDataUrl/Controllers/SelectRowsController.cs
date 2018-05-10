using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class SelectRowsController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/SelectRows
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click()
        {
            UIHelper.Grid("Grid1").SelectedRowIDArray("102", "106", "108");

            return UIHelper.Result();
        }

    }
}