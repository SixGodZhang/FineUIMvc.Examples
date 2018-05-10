using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Button.Controllers
{
    public class ButtonController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Button/Button
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnEnable_Click()
        {
            ShowNotify("你点击了刚刚启用的按钮");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnChangeEnable_Click()
        {
            var btnEnable = UIHelper.Button("btnEnable");

            btnEnable.Enabled(true);
            btnEnable.Text("本按钮已经启用（点击弹出对话框）");
            

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnChangePressed_Click(bool pressed)
        {
            UIHelper.Button("btnPressed").Pressed(!pressed);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnTooltip_Click()
        {
            UIHelper.Button("btnTooltip").ToolTip("这是改变后的提示信息");

            return UIHelper.Result();
        }

    }
}