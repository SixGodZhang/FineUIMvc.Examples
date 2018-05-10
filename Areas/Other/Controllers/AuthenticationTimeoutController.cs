using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Other.Controllers
{
    public class AuthenticationTimeoutController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Other/AuthenticationTimeout
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click()
        {
            Response.Redirect(Url.Content("~/?ReturnUrl=%2fOther%2fAuthenticationTimeout"));

            return UIHelper.Result();
        }

    }
}