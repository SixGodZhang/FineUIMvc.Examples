using FineUIMvc.Examples.Areas.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DataModel.Controllers
{
    public class LoginController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DataModel/Login
        public ActionResult Index()
        {
            return View(new User());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnLogin_Click(FormCollection values)
        {
            var userName = values["UserName"];
            var password = values["Password"];

            if (userName == "admin" && password == "admin888")
            {
                ShowNotify("成功登录！", MessageBoxIcon.Success);
            }
            else
            {
                ShowNotify(String.Format("用户名（{0}）或密码（{1}）错误！",
                        HttpUtility.HtmlEncode(userName),
                        HttpUtility.HtmlEncode(password)), MessageBoxIcon.Error);
            }

            return UIHelper.Result();
        }


    }
}