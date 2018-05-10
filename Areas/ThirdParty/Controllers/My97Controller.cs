using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.ThirdParty.Controllers
{
    public class My97Controller : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: ThirdParty/My97
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(string dateValue, string boxValue)
        {
            ShowNotify(String.Format("日期一：{0}<br/>日期和时间：{1}", dateValue, boxValue));

            return UIHelper.Result();
        }

    }
}