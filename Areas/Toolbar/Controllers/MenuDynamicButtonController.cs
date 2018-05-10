using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Toolbar.Controllers
{
    public class MenuDynamicButtonController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Toolbar/MenuDynamicButton
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnDynamic_Click(int count)
        {
            ShowNotify("工具栏中的按钮数：" + count);

            return UIHelper.Result();
        }


    }
}