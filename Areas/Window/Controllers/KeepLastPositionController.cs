using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Window.Controllers
{
    public class KeepLastPositionController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Window/KeepLastPosition
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