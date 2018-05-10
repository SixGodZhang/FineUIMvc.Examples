using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Button.Controllers
{
    public class ButtonCustomController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Button/ButtonCustom
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click()
        {
            ShowNotify("点击了普通按钮");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click()
        {
            ShowNotify("点击了自定义按钮");

            return UIHelper.Result();
        }

    }
}