using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Panel.Controllers
{
    public class DisabledController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Panel/Disabled
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click(bool disabled)
        {
            UIHelper.Panel("Panel1").Disabled(!disabled);

            return UIHelper.Result();
        }

    }
}