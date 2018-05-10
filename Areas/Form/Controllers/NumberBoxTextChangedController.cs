using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class NumberBoxTextChangedController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/NumberBoxTextChanged
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NumberBox3_TextChanged(string text)
        {
            ShowNotify("数字输入框的值（NumberBox3_TextChanged）：" + text);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(string text)
        {
            ShowNotify("数字输入框的值（btnSubmit_Click）：" + text);

            return UIHelper.Result();
        }


    }
}