using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.ThirdParty.Controllers
{
    public class My97FormatController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: ThirdParty/My97Format
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(string startValue, string endValue)
        {
            ShowNotify(String.Format("开始日期：{0}<br/>结束日期：{1}", startValue, endValue));

            return UIHelper.Result();
        }

    }
}