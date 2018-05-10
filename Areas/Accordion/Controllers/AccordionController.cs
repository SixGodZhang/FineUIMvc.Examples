using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Accordion.Controllers
{
    public class AccordionController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Accordion/Accordion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click(int activeIndex)
        {
            ShowNotify(String.Format("当前展开的是第 {0} 个面板", activeIndex + 1));

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click(int activeIndex)
        {
            int nextIndex = activeIndex + 1;

            if (nextIndex >= 3)
            {
                nextIndex = 0;
            }

            UIHelper.Accordion("Accordion1").ActivePaneIndex(nextIndex);

            return UIHelper.Result();
        }
    }
}