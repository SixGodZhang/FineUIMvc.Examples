using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Message.Controllers
{
    public class ConfirmButtonsController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Message/ConfirmButtons
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmOK()
        {
            ShowNotify("你点击了[直接退出]按钮！");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmCancel()
        {
            ShowNotify("你点击了[不退出]按钮！");

            return UIHelper.Result();
        }

    }
}