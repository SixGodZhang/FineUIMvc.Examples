using FineUIMvc.Examples.Areas.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DataModel.Controllers
{
    public class LoginModelController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DataModel/LoginModel
        public ActionResult Index()
        {
            return View(new User());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnLogin_Click([Bind(Include = "UserName,Password")]User user)
        {
            if (ModelState.IsValid)
            {
                if (user.UserName == "admin" && user.Password == "admin888")
                {
                    ShowNotify("成功登录！", MessageBoxIcon.Success);
                }
                else
                {
                    ShowNotify(String.Format("用户名（{0}）或密码（{1}）错误！",
                        HttpUtility.HtmlEncode(user.UserName),
                        HttpUtility.HtmlEncode(user.Password)), MessageBoxIcon.Error);
                }
            }

            return UIHelper.Result();
        }

    }
}