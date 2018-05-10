using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class FormValidateValidatorController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/FormValidateValidator
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnRegister_Click(string userName, string password)
        {
            ShowNotify(String.Format("用户名：{0}<br/>密码：{1}", userName, password));

            return UIHelper.Result();
        }

    }
}