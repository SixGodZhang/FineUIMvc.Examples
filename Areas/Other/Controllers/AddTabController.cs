using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Other.Controllers
{
    public class AddTabController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Other/AddTab
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button3_Click()
        {
            PageContext.RegisterStartupScript("closeActiveTab();");

            return UIHelper.Result();
        }

    }
}