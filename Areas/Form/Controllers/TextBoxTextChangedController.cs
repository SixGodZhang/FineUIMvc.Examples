using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class TextBoxTextChangedController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/TextBoxTextChanged
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TextBox1_TextChanged(string text)
        {
            UIHelper.Label("labResult1").Text("文本框一：" + text);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TextBox2_Blur(string text)
        {
            UIHelper.Label("labResult2").Text("文本框二：" + text);

            return UIHelper.Result();
        }

    }
}