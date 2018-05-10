using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Other.Controllers
{
    public class ServerErrorController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Other/ServerError
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button5_Click()
        {
            throw new Exception("服务器异常错误！");
        }

    }
}