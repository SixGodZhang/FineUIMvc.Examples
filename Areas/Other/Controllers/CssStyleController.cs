using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Other.Controllers
{
    public class CssStyleController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Other/CssStyle
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click()
        {
            Random rd = new Random();
            string style = String.Format("font-size:1.5em;font-weight:bold;color:rgb({0},{1},{2});", rd.Next(256), rd.Next(256), rd.Next(256));

            UIHelper.Label("Label1").CssStyle(style);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button3_Click()
        {
            // 不能直接设置 CssStyle=String.Empty，客户端只会覆盖相同CSS属性的样式，而不会清空元素的 style 属性
            // 需要注册JavaScript脚本来清空元素的 style 属性
            PageContext.RegisterStartupScript("F.ui.Label1.el.attr('style','');");

            return UIHelper.Result();
        }

        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click(bool hasClassRed)
        {
            var label2 = UIHelper.Label("Label2");

            if (hasClassRed)
            {
                label2.RemoveCssClass("red");
                label2.AddCssClass("green");
            }
            else
            {
                label2.RemoveCssClass("green");
                label2.AddCssClass("red");
            }

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button4_Click()
        {
            var label2 = UIHelper.Label("Label2");
            label2.RemoveCssClass("red");
            label2.RemoveCssClass("green");

            return UIHelper.Result();
        }
    }
}