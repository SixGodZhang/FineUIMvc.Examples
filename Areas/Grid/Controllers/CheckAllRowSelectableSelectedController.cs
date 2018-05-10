using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class CheckAllRowSelectableSelectedController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/CheckAllRowSelectableSelected
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click()
        {
			

            return UIHelper.Result();
        }

    }
}