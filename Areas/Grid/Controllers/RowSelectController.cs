using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class RowSelectController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/RowSelect
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_RowSelect(string rowId, string rowText, int rowIndex, string columnText, bool isDeselect)
        {
            string typeName = isDeselect ? "取消选中" : "选中";

            ShowNotify(String.Format("你" + typeName + "了第 {0} 行，行ID：{1}，姓名：{2}，列：{3}",
                rowIndex + 1, rowId, rowText, columnText));

            return UIHelper.Result();
        }

    }
}