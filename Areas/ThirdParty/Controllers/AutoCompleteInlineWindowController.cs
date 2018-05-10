using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.ThirdParty.Controllers
{
    public class AutoCompleteInlineWindowController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: ThirdParty/AutoCompleteInlineWindow
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click(string TextBox1)
        {
            ShowNotify(String.Format("用户输入值：{0}", TextBox1));

            return UIHelper.Result();
        }

    }
}