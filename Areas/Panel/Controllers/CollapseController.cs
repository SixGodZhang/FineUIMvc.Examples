using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Panel.Controllers
{
    public class CollapseController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Panel/Collapse
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Panel1_CollapseExpand(bool collapsed)
        {
            ShowNotify(String.Format("面板一处于{0}状态", !collapsed ? "展开" : "折叠"));

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Panel2_CollapseExpand(bool collapsed)
        {
            ShowNotify(String.Format("面板二处于{0}状态", !collapsed ? "展开" : "折叠"));

            return UIHelper.Result();
        }

    }
}