using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Message.Controllers
{
    public class NotifyAddTabController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Message/NotifyAddTab
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnOperation1_Click()
        {
            // 随机生成通知对话框的客户端ID
            string notifyId = Guid.NewGuid().ToString();

            Notify n = new Notify();
            n.ID = notifyId;
            n.Message = "<div class=\"addtabcontainer\"><a href=\"javascript:openExampleHello('" + notifyId + "');\">向父页面添加选项卡</a></div>";
            n.MessageBoxIcon = MessageBoxIcon.None;
            n.PositionX = Position.Right;
            n.PositionY = Position.Bottom;
            n.DisplayMilliseconds = 0;
            n.ShowHeader = false;

            n.Show();

            return UIHelper.Result();
        }

    }
}