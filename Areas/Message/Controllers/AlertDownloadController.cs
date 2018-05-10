using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Message.Controllers
{
    public class AlertDownloadController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Message/AlertDownload
        public ActionResult Index()
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
            PageContext.RegisterStartupScript(Confirm.GetShowReference("操作成功！点击确定按钮开始下载文件，点取消按钮弹出对话框",
                    String.Empty,
                    MessageBoxIcon.Question,
                    "confirmOKCallback();",
                    "confirmCancelCallback();"));

            return UIHelper.Result();
        }

    }
}