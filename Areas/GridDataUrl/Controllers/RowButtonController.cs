using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class RowButtonController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/RowButton
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_CustomEvent(string eventType, int rowIndex, string rowId, string rowText)
        {
            string eventTypeStr = String.Empty;
            if (eventType == "edit")
            {
                eventTypeStr = "编辑";
            }
            else if (eventType == "delete")
            {
                eventTypeStr = "删除";
            }

            ShowNotify(String.Format("你点击了第 {0} 行的 {3} 按钮，行ID：{1}，姓名：{2}", rowIndex + 1, rowId, rowText, eventTypeStr));

            return UIHelper.Result();
        }

    }
}