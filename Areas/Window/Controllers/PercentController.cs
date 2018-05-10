using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Window.Controllers
{
    public class PercentController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Window/Percent
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(FormCollection values)
        {
			ShowNotify(values);

            return UIHelper.Result();
        }

    }
}