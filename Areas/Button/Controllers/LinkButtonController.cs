using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Button.Controllers
{
    public class LinkButtonController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Button/LinkButton
        public ActionResult Index()
        {
            ViewBag.LinkButton2Script = Alert.GetShowInTopReference("这是在服务器端生成的客户端事件");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkButton3_Click()
        {
            ShowNotify("这是服务器端事件");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnChangeEnable_Click(bool enabled)
        {
            UIHelper.LinkButton("LinkButton1").Enabled(!enabled);
            
            return UIHelper.Result();
        }
        
    }
}