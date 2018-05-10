using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridOther.Controllers
{
    public class HideColumnController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridOther/HideColumn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button3_Click(bool genderHidden)
        {
            var grid1 = UIHelper.Grid("Grid1");
            if (genderHidden)
            {
                grid1.ShowColumn("Gender");
            }
            else
            {
                grid1.HideColumn("Gender");
            }

            return UIHelper.Result();
        }

    }
}