using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridPaging.Controllers
{
    public class PagingController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridPaging/Paging
        public ActionResult Index()
        {
            return View();
        }

    }
}