using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class IFrameController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/IFrame
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Window1_Close()
        {
            Alert.Show("触发了窗体的关闭事件！");
			
            return UIHelper.Result();
        }

    }
}