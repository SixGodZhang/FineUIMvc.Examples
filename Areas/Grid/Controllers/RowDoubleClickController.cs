using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class RowDoubleClickController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/RowDoubleClick
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_RowDblClick(string rowId, string rowText, int rowIndex, string columnText)
        {
            ShowNotify(String.Format("你双击了第 {0} 行，行ID：{1}，姓名：{2}，列：{3}",
                rowIndex + 1, rowId, rowText, columnText));

            return UIHelper.Result();
        }

    }
}