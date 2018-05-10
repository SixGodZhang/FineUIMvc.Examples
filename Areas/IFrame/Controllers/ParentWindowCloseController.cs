using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.IFrame.Controllers
{
    public class ParentWindowCloseController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: IFrame/ParentWindowClose
        public ActionResult Index()
        {
            return View();
        }

        // GET: IFrame/ParentWindowClose/IFrameWindow1
        public ActionResult IFrameWindow1()
        {
            return View();
        }

        // GET: IFrame/ParentWindowClose/IFrameWindow2
        public ActionResult IFrameWindow2()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IFrameWindow1_Window1_Close()
        {
            // IFrameWindow1 -> labResult
            UIHelper.Label("labResult").Text(DateTime.Now.ToLongTimeString());

            // 调用父页面定义的函数 updateLabelResult
            PageContext.RegisterStartupScript("parent.updateLabelResult();");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IFrameWindow2_Button1_Click()
        {
            ActiveWindow.HidePostBack();

            return UIHelper.Result();
        }

    }
}