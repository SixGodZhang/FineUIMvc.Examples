using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Message.Controllers
{
    public class AlertDownloadHideIFrameController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Message/AlertDownloadHideIFrame
        public ActionResult Index()
        {
            return View();
        }

        // GET: Message/AlertDownloadHideIFrame/IFrameWindow
        public ActionResult IFrameWindow()
        {
            return View();
        }

        // GET: Message/AlertDownload/DownloadTextFile
        public ActionResult DownloadTextFile()
        {
            return File(Encoding.UTF8.GetBytes("这是下载文件的内容！"), "text/plain", "alert_download.txt");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmCancel()
        {
            ShowNotify("点击了取消按钮！");

            return UIHelper.Result();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnOperation_Click()
        {
            // 不要在这里调用F.confirm，因为当前页面要被关闭，因此F.confirm的回调函数不能正确执行
            PageContext.RegisterStartupScript(ActiveWindow.GetHideReference() + "parent.showConfirm();");

            return UIHelper.Result();
        }

    }
}