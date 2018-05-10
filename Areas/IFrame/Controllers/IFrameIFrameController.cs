using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.IFrame.Controllers
{
    public class IFrameIFrameController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: IFrame/IFrameIFrame
        public ActionResult Index()
        {
            return View();
        }

        // GET: IFrame/IFrameIFrame/IFrameWindow
        public ActionResult IFrameWindow()
        {
            return View();
        }

        // GET: IFrame/IFrameIFrame/IFrameWindow2
        public ActionResult IFrameWindow2()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Window1_Close()
        {
            UIHelper.Label("labResult").Text("Window1 关闭了，时间：" + DateTime.Now.ToLongTimeString());

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Window2_Close()
        {
            UIHelper.Label("labResult").Text("Window2 关闭了，时间：" + DateTime.Now.ToLongTimeString());

            return UIHelper.Result();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Window3_Close()
        {
            UIHelper.Label("labResult").Text("Window3 关闭了，时间：" + DateTime.Now.ToLongTimeString());

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Window4_Close()
        {
            UIHelper.Label("labResult").Text("Window4 关闭了，时间：" + DateTime.Now.ToLongTimeString());

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnCloseServer_Click()
        {
            ActiveWindow.HidePostBack();

            return UIHelper.Result();
        }

    }
}