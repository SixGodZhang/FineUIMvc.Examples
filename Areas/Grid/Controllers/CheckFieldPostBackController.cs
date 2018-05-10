using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class CheckFieldPostBackController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/CheckFieldAutoPostBack
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_CheckFieldChanged(string rowId, string rowText, bool isChecked)
        {
            ShowNotify(String.Format("你点击了的行ID：{0}，姓名：{1}，是否在校：{2}", rowId, rowText, isChecked ? "是" : "否"));

            return UIHelper.Result();
        }

    }
}