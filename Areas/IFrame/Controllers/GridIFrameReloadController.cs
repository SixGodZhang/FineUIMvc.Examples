using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.IFrame.Controllers
{
    public class GridIFrameReloadController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: IFrame/GridIFrameReload
        public ActionResult Index()
        {
            return View();
        }

        // GET: IFrame/GridIFrameReload/IFrameWindow
        public ActionResult IFrameWindow()
        {
            return View();
        }


        private void AutoBindGrid(string gridSourceKey, JArray gridFields, string typeParams)
        {
            var grid1 = UIHelper.Grid("Grid1");

            DataTable source = null;
            if (gridSourceKey == "table1")
            {
                source = DataSourceUtil.GetDataTable2();
                gridSourceKey = "table2";
            }
            else
            {
                source = DataSourceUtil.GetDataTable();
                gridSourceKey = "table1";
            }

            grid1.DataSource(source, gridFields);
            grid1.Attribute("data-source-key", gridSourceKey);
            grid1.Title("表格 - 回发参数：" + typeParams);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyCustomPostBack(string type, string gridSourceKey, JArray gridFields, string typeParams)
        {
            // 重新绑定表格数据（模拟）
            AutoBindGrid(gridSourceKey, gridFields, typeParams);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnUpdateParentGrid_Click()
        {
            // 1. 这里放置保存窗体中数据的逻辑

            // 2. 不关闭窗体，直接回发父窗体
            string scripts = String.Format("F.getActiveWindow().window.doCustomPostBack('{0}');", "参数 - " + DateTime.Now.Millisecond);
            PageContext.RegisterStartupScript(scripts);
            

            return UIHelper.Result();
        }

    }
}