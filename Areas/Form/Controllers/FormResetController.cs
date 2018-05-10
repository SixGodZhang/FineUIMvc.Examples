using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class FormResetController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/FormReset
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmitForm1_Click(FormCollection values)
        {
            ShowNotify(values);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmitForm2_Click(FormCollection values)
        {
            ShowNotify(values);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmitAll_Click(FormCollection values)
        {
            ShowNotify(values);

            return UIHelper.Result();
        }
        
    }
}