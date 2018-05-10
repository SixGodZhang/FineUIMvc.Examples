using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FineUIMvc.Examples.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnLogin_Click(string tbxUserName, string tbxPassword)
        {
            if (tbxUserName == "admin" && tbxPassword == "admin")
            {
                FormsAuthentication.RedirectFromLoginPage(tbxUserName, false);
            }
            else
            {
                ShowNotify("用户名或密码错误！", MessageBoxIcon.Error);
            }

            return UIHelper.Result();
        }
    }
}