using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class TriggerBoxController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/TriggerBox
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnCloseWindow_Click(string content)
        {
            UIHelper.Window("Window1").Hide();
            UIHelper.TriggerBox("TriggerBox1").Text("弹出窗口被关闭了");

            return UIHelper.Result();
        }

    }
}