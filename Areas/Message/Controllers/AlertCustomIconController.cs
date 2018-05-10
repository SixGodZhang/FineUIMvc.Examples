using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Message.Controllers
{
    public class AlertCustomIconController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Message/AlertCustomIcon
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnHello_Click()
        {
            Alert alert = new Alert();
            alert.Message = "你好 FineUIMvc！";
            alert.Icon = Icon.Book;
            alert.Show();

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnHello2_Click()
        {
            Alert alert = new Alert();
            alert.Message = "你好 FineUIMvc！";
            alert.IconUrl = "~/res/images/success.png";
            alert.Target = Target.Top;
            alert.Show();

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnHello3_Click()
        {
            Alert alert = new Alert();
            alert.Message = "你好 FineUIMvc！";
            alert.IconFont = IconFont._Car;
            alert.Target = Target.Top;
            alert.Show();

            return UIHelper.Result();
        }

    }
}