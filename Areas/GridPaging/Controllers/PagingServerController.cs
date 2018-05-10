using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridPaging.Controllers
{
    public class PagingServerController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridPaging/Paging
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_PageIndexChanged(int pageIndex)
        {
            UIHelper.Grid("Grid1").LoadPageData(pageIndex);

            return UIHelper.Result();
        }

    }
}