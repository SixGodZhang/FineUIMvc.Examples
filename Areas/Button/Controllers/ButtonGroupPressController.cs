using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace FineUIMvc.Examples.Areas.Button.Controllers
{
    public class ButtonGroupPressController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Button/ButtonGroupPress
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ButtonGroup_PressChanged(JObject pressedInfo)
        {
            // 将传入的字符串转换为 JSON 对象
            // 数据样本：{"id":"ButtonGroup5","pressed":["按钮一","按钮二","按钮四"]}
            
            // 生成提示信息
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("分组 {0} 中按下的按钮：", pressedInfo["id"]);
            sb.Append("<ul>");
            foreach (string pressedText in pressedInfo["pressed"])
            {
                sb.AppendFormat("<li>{0}</li>", pressedText);
            }
            sb.Append("</ul>");

            ShowNotify(sb.ToString());

            return UIHelper.Result();
        }

    }
}