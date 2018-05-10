using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Other.Controllers
{
    public class JSErrorController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Other/JSError
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button4_Click()
        {
            PageContext.RegisterStartupScript("test();");

            return UIHelper.Result();
        }

    }
}