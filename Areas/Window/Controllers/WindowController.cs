using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Window.Controllers
{
    public class WindowController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Window/Window
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Window1_Close()
        {
            Alert.Show("触发了窗体的关闭事件！");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnShowInServer_Click()
        {
            UIHelper.Window("Window1").Show();

            return UIHelper.Result();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnHideInServer_Click()
        {
            UIHelper.Window("Window1").Hide();

            return UIHelper.Result();
        }

    }
}