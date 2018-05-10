using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class TwinTriggerBoxController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/TwinTriggerBox
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TwinTriggerBox1_Trigger2Click(string text)
        {
            // 点击 TwinTriggerBox 的搜索按钮
            var TwinTriggerBox1 = UIHelper.TwinTriggerBox("TwinTriggerBox1");

            if (!String.IsNullOrEmpty(text))
            {
                // 执行搜索动作
                ShowNotify(String.Format("在关键词“{0}”中搜索", text));

                TwinTriggerBox1.ShowTrigger1(true);
            }
            else
            {
                ShowNotify("请输入你要搜索的关键词！");
            }

            return UIHelper.Result();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TwinTriggerBox1_Trigger1Click(string content)
        {
            // 点击 TwinTriggerBox 的取消按钮
            var TwinTriggerBox1 = UIHelper.TwinTriggerBox("TwinTriggerBox1");

            ShowNotify("取消搜索！");

            // 执行清空动作
            TwinTriggerBox1.Text("");
            TwinTriggerBox1.ShowTrigger1(false);

            return UIHelper.Result();
        }

        
    }
}