using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.IFrame.Controllers
{
    public class WindowController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: IFrame/Window
        public ActionResult Index()
        {
            return View();
        }

        // GET: IFrame/Window/IFrameWindow
        public ActionResult IFrameWindow()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnClosePostBack_Click()
        {
            // 首先保存数据

            // 然后关闭本窗体
            var panel1 = UIHelper.Panel("Panel1");
            PageContext.RegisterStartupScript(panel1.GetClearDirtyReference() + ActiveWindow.GetHideReference());

            return UIHelper.Result();
        }

    }
}