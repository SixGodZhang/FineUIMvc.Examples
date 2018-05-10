using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class FormValidateBlurController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/FormValidateBlur
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnRegister_Click(FormCollection values)
        {
            string userName = values["tbxUserName"];

            if (ValidateForm(userName))
            {
                ShowNotify(values);
            }

            return UIHelper.Result();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult tbxUserName_Blur(string userName)
        {
            if (ValidateForm(userName))
            {
                // 用户名失去焦点，并且用户名有效，则聚焦到下一个控件
                UIHelper.TextBox("tbxPassword").Focus(true);
            }

            return UIHelper.Result();
        }
        

        private bool ValidateForm(string userName)
        {
            var tbxUserName = UIHelper.TextBox("tbxUserName");

            if (userName == "admin")
            {
                tbxUserName.MarkInvalid(String.Format("{0} 是保留字，请另外选择！", userName));
                return false;
            }
            else
            {
                tbxUserName.ClearInvalid();
                return true;
            }
        }
 

    }
}