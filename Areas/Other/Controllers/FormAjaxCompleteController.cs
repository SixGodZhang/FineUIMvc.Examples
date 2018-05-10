using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Other.Controllers
{
    public class FormAjaxCompleteController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Other/FormAjaxComplete
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult onForm1Submit(FormCollection values)
        {
            // 为了观察前台动画，后台休眠 1 秒钟
            System.Threading.Thread.Sleep(1000);

            ShowNotify(values);

            return UIHelper.Result();
        }


    }
}