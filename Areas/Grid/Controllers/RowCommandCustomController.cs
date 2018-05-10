using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class RowCommandCustomController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/RowCommandCustom
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_RowCommand(string rowId, string rowText, int rowIndex, int columnIndex)
        {
            ShowNotify(String.Format("你点击了第 {0} 行，第 {1} 列，行ID：{2}，姓名：{3}",
                rowIndex + 1, columnIndex + 1, rowId, rowText));

            return UIHelper.Result();
        }

    }
}