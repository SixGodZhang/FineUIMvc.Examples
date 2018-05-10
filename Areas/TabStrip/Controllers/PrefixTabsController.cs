using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.TabStrip.Controllers
{
    public class PrefixTabsController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: TabStrip/PrefixTabs
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab("tab1_iframe", "http://fineui.com/version_pro/", "专业版（这是很长的标题文本）", true);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab("tab2_iframe", "http://fineui.com/version/", "开源版（这是很长的标题文本）", true);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button3_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab("tab3_iframe", "http://fineui.com/", "官网首页（这是很长的标题文本）", true);

            return UIHelper.Result();
        }

    }
}