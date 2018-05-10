using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Button.Controllers
{
    public class ButtonClickController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Button/ButtonClick
        public ActionResult Index()
        {
            ViewBag.btnClientClick2Script = Alert.GetShowInTopReference("通过ViewBag传递的客户端事件");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnServerClick_Click()
        {
            ShowNotify("这是服务器端事件");
            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnChangeClientClick2_Click()
        {
            UIHelper.Button("btnClientClick2").ClientClick(Alert.GetShowInTopReference("客户端事件已改变！"));

            return UIHelper.Result();
        }


    }
}