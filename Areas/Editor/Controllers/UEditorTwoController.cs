using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Editor.Controllers
{
    public class UEditorTwoController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Editor/UEditorTwo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click(string title, string text1, string text2)
        {
            if (String.IsNullOrEmpty(text1))
            {
                ShowNotify("文章正文不能为空！");
            }
            else
            {
                ShowNotify(String.Format("文章标题：{0}<br/>文章正文：{1}<br/>文章摘要：{2}", title, text1, text2));
            }

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click(string text1)
        {
            Regex regex = new Regex(@"<[^>]+>|</[^>]+>");
            string content = regex.Replace(text1, "");
            if (content.Length > 100)
            {
                content = content.Substring(0, 97) + "...";
            }

            UIHelper.HtmlEditor("HtmlEditor2").Text(content);

            return UIHelper.Result();
        }
    }
}