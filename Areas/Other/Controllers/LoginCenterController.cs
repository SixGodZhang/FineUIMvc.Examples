using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Other.Controllers
{
    public class LoginCenterController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Other/LoginCenter
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnLogin_Click(FormCollection values)
        {
            if (values["tbxUserName"] == "admin" && values["tbxPassword"] == "admin")
            {
                ShowNotify("成功登录！", MessageBoxIcon.Success);
            }
            else
            {
                ShowNotify("用户名或密码错误！", MessageBoxIcon.Error);
            }

            return UIHelper.Result();
        }

    }
}