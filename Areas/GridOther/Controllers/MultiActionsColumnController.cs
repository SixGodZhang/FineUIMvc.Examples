using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridOther.Controllers
{
    public class MultiActionsColumnController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridOther/MultiActionsColumn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Window1_Close()
        {
            Alert.Show("触发了窗体的关闭事件！");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_CustomDelete(int rowIndex, string rowId, string rowText)
        {
            ShowNotify(String.Format("你点击了第 {0} 行的删除按钮，行ID：{1}，姓名：{2}", rowIndex + 1, rowId, rowText));

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_CustomEdit(int rowIndex, string rowId, string rowText)
        {
            ShowNotify(String.Format("你点击了第 {0} 行的编辑按钮，行ID：{1}，姓名：{2}", rowIndex + 1, rowId, rowText));

            return UIHelper.Result();
        }
        

    }
}