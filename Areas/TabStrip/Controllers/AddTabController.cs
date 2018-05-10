using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.TabStrip.Controllers
{
    public class AddTabController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: TabStrip/AddTab
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnAddTab3_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab("dynamic_tab3", "http://fineui.com/version_pro/", "专业版（服务器）", IconHelper.GetIconUrl(Icon.Application), true);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnAddTab4_Click()
        {
            UIHelper.TabStrip("TabStrip1").AddTab("dynamic_tab4", "http://fineui.com/version/", "开源版（服务器）", IconHelper.GetIconUrl(Icon.ApplicationAdd), true);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnRemoveTab3_Click()
        {
            UIHelper.TabStrip("TabStrip1").RemoveTab("dynamic_tab3");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnRemoveTab4_Click()
        {
            UIHelper.TabStrip("TabStrip1").RemoveTab("dynamic_tab4");

            return UIHelper.Result();
        }
    }
}