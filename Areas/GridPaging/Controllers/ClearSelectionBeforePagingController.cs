using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridPaging.Controllers
{
    public class ClearSelectionBeforePagingController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridPaging/ClearSelectionBeforePaging
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