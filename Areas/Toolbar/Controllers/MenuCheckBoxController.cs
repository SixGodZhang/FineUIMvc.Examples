using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Toolbar.Controllers
{
    public class MenuCheckBoxController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Toolbar/MenuCheckBox
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MenuLang_CheckedChanged(string checkedValue)
        {
            UIHelper.Label("labLangResult").Text("你选择的语言：" + checkedValue);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MenuSite_CheckedChanged(string checkedValue)
        {
            UIHelper.Label("labSiteResult").Text("你选择的站点：" + checkedValue);

            return UIHelper.Result();
        }

    }
}