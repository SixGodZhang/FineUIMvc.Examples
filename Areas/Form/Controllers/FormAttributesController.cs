using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class FormAttributesController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/FormAttributes
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnChangeTip1_Click()
        {
            UIHelper.Label("Label1").ToolTip("改变后的提示信息（ToolTip）");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnChangeTip2_Click()
        {
            UIHelper.Label("Label2").Attribute("data-qtip", "改变后的提示信息（Attributes）");

            return UIHelper.Result();
        }

    }
}