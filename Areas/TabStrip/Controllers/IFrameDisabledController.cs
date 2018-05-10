using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.TabStrip.Controllers
{
    public class IFrameDisabledController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: TabStrip/IFrameDisabled
        public ActionResult Index()
        {
            return View();
        }

        // GET: TabStrip/IFrameDisabled/Tab1
        public ActionResult Tab1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(FormCollection values)
        {
            

            ShowNotify(values);

            return UIHelper.Result();
        }

    }
}