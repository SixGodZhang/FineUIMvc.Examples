using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class CheckBoxListRadioController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/CheckBoxListRadio
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckBoxList1_Change(string selected)
        {
            ShowNotify(String.Format("列表一选中项的值：{0}", selected));

            return UIHelper.Result();
        }

    }
}