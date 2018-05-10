using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridPaging.Controllers
{
    public class PageItemsRowExpanderController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridPaging/PageItemsRowExpander
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnShowRowExpanders_Click(bool expanded)
        {
            var grid1 = UIHelper.Grid("Grid1");
            if (expanded)
            {
                grid1.CollapseRowExpanders();
            }
            else
            {
                grid1.ExpandRowExpanders();
            }

            return UIHelper.Result();
        }

    }
}