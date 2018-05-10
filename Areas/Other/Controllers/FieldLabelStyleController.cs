using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Other.Controllers
{
    public class FieldLabelStyleController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Other/FieldLabelStyle
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSwitchClass_Click(bool hasClassRed)
        {
            var tbxUserName = UIHelper.TextBox("tbxUserName");
            var tbxPassword = UIHelper.TextBox("tbxPassword");

            if (hasClassRed)
            {
                tbxUserName.RemoveCssClass("red");
                tbxPassword.RemoveCssClass("red");

                tbxUserName.AddCssClass("blue");
                tbxPassword.AddCssClass("blue");
            }
            else
            {
                tbxUserName.RemoveCssClass("blue");
                tbxPassword.RemoveCssClass("blue");

                tbxUserName.AddCssClass("red");
                tbxPassword.AddCssClass("red");
            }

            return UIHelper.Result();
        }

    }
}