using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.TabStrip.Controllers
{
    public class TabStripController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: TabStrip/TabStrip
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click()
        {
            ShowNotify("你点击了位于第二个标签中的一个按钮！");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button3_Click(int activeIndex)
        {
            int nextIndex = activeIndex + 1;

            if (nextIndex >= 3)
            {
                nextIndex = 0;
            }

            UIHelper.TabStrip("TabStrip1").ActiveTabIndex(nextIndex);

            return UIHelper.Result();
        }

    }
}