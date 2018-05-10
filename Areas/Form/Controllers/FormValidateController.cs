using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class FormValidateController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/FormValidate
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnRegister_Click(string userName, string password)
        {
            var tbxUserName = UIHelper.TextBox("tbxUserName");

            if (userName == "admin")
            {
                tbxUserName.MarkInvalid(String.Format("{0} 是保留字，请另外选择！", userName));

                //// 用户名验证失败，则重新聚焦到用户名
                //tbxUserName.Focus(true, 200);
            }
            else
            {
                ShowNotify(String.Format("用户名：{0}<br/>密码：{1}", userName, password));
            }

            return UIHelper.Result();
        }

    }
}