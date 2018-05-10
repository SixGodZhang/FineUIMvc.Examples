using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.ThirdParty.Controllers
{
    public class ColorPickerController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: ThirdParty/ColorPicker
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(string dateValue, string textValue)
        {
            ShowNotify(String.Format("日期一：{0}<br/>颜色值：{1}", dateValue, textValue));

            return UIHelper.Result();
        }

    }
}