using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.FormLayout.Controllers
{
    public class LayoutCheckOutController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: FormLayout/LayoutCheckOut
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult cbxSameAsContactAddress_CheckedChanged(bool isChecked)
        {
            UIHelper.TextBox("tbxBillingAddress").Enabled(!isChecked);
            UIHelper.TextBox("tbxBillingProvince").Enabled(!isChecked);
            UIHelper.TextBox("tbxBillingCity").Enabled(!isChecked);
            UIHelper.TextBox("tbxBillingPostCode").Enabled(!isChecked);

            return UIHelper.Result();
        }

    }
}