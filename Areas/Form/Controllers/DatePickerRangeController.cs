using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class DatePickerRangeController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/DatePickerRange
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(string date)
        {
            UIHelper.Label("labResult").Text(String.Format("选择的日期：{0}", date));

            return UIHelper.Result();
        }

    }
}