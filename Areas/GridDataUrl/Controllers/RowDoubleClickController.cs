using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class RowDoubleClickController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/RowDoubleClick
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_RowDblClick(int rowIndex, string rowId, string rowText)
        {
            ShowNotify(String.Format("你双击了第 {0} 行，行ID：{1}，姓名：{2}", rowIndex + 1, rowId, rowText));

            return UIHelper.Result();
        }

    }
}