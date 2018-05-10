using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Other.Controllers
{
    public class AjaxLoadingController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Other/AjaxLoading
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click()
        {
            System.Threading.Thread.Sleep(1000);

            return UIHelper.Result();
        }

    }
}