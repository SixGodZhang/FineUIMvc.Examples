using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.TabStrip.Controllers
{
    public class IFrameAddTabController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: TabStrip/IFrameAddTab
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab("tab1_iframe", "http://fineui.com/version_pro/", "专业版示例", true);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab("tab1_iframe", "http://fineui.com/version/", "开源版示例", true);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button3_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab("tab2_iframe", "http://fineui.com/bbs/", "论坛首页", true);

            return UIHelper.Result();
        }

    }
}