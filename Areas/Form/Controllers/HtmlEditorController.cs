using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class HtmlEditorController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/HtmlEditor
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click(string content)
        {
            // 为了防止出现错误：从客户端中检测到有潜在危险的 Request.Form 值
            // 在客户端对 HtmlEditor1 的内容进行了编码，所以这样需要先解码
            UIHelper.TextArea("TextArea1").Text(HttpUtility.HtmlDecode(content));

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click(string content)
        {
            UIHelper.HtmlEditor("HtmlEditor1").Text(content);

            return UIHelper.Result();
        }

    }
}