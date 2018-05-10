using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Other.Controllers
{
    public class ClientValidateController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Other/ClientValidate
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnRegister_Click(FormCollection values)
        {
            Alert.Show("表单验证通过！");

            return UIHelper.Result();
        }

    }
}