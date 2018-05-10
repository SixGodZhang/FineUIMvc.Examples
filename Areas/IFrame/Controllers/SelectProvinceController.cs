using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.IFrame.Controllers
{
    public class SelectProvinceController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: IFrame/SelectProvince
        public ActionResult Index()
        {
            return View();
        }

        // GET: IFrame/SelectProvince/IFrameWindow
        public ActionResult IFrameWindow()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Window1_Close()
        {
            ShowNotify("触发了 Window1 的关闭事件！");

            return UIHelper.Result();
        }

    }
}