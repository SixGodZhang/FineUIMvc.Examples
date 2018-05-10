using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.TabStrip.Controllers
{
    public class CloseMenuController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: TabStrip/CloseMenu
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnShowInServer_Click()
        {
            UIHelper.Tab("Tab3").Show();

            return UIHelper.Result();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnHideInServer_Click()
        {
            UIHelper.Tab("Tab3").Hide();

            return UIHelper.Result();
        }

    }
}