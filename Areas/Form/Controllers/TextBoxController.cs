using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class TextBoxController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/TextBox
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(string userName, string password)
        {
            UIHelper.Label("labResult").Text("用户名：" + userName + " 密码：" + password);

            return UIHelper.Result();
        }

    }
}