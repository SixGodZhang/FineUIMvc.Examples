using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.IFrame.Controllers
{
    public class ButtonIFrameController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: IFrame/ButtonIFrame
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Window1_Close()
        {
            ShowNotify("Window1 被关闭了！");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Window2_Close()
        {
            ShowNotify("Window2 被关闭了！");

            return UIHelper.Result();
        }

    }
}