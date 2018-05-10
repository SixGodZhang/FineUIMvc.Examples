using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class LabelController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/Label
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnChangeEnable_Click(bool enabled)
        {
            UIHelper.Label("Label3").Enabled(!enabled);

            return UIHelper.Result();
        }

    }
}