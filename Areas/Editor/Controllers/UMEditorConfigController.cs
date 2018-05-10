using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Editor.Controllers
{
    public class UMEditorConfigController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Editor/UMEditorConfig
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                ShowNotify("编辑器内容为空！");
            }
            else
            {
                ShowNotify(text);
            }

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click()
        {
            UIHelper.HtmlEditor("HtmlEditor1").Text("<p><strong>FineUIMvc</strong> - 基于 jQuery 的专业 ASP.NET MVC 控件库。</p>");

            return UIHelper.Result();
        }

    }
}