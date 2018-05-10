using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class TimePickerClearIconController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/TimePickerClearIcon
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(FormCollection values)
        {
            var result = String.Format("日期：{0}  时间：{1}",
                values["DatePicker1"],
                values["TimePicker1"]);

            UIHelper.Label("labResult").Text(result);

            return UIHelper.Result();
        }

    }
}