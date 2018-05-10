using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Panel.Controllers
{
    public class ToolsCustomExpandController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Panel/ToolsCustomExpand
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click(bool collapsed)
        {
            ShowNotify(String.Format("面板处于{0}状态", collapsed ? "折叠" : "展开"));

            return UIHelper.Result();
        }

    }
}