using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Message.Controllers
{
    public class ConfirmCancelController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Message/ConfirmCancel
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnOperation1_Click()
        {
            ShowNotify("执行了操作一！");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnOperation2_Click()
        {
            ShowNotify("执行了操作二！");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnOperation3_Click(string opType)
        {
            if (opType == "cancel")
            {
                ShowNotify("取消执行操作三！");
            }
            else
            {
                ShowNotify("执行了操作三！");
            }

            return UIHelper.Result();
        }
    }
}