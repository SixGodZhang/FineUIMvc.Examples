using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class RedStarPositionController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/RedStarPosition
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnLogin_Click(FormCollection values)
        {
            ShowNotify(values);

            return UIHelper.Result();
        }

    }
}