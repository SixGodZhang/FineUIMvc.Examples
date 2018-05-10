using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.IFrame.Controllers
{
    public class GridIFrameController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: IFrame/GridIFrame
        public ActionResult Index()
        {
            return View();
        }

        private void AutoBindGrid(string gridSourceKey, JArray gridFields)
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
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyCustomPostBack(string type, string gridSourceKey, JArray gridFields, JObject typeParams)
        {
            // 重新绑定表格数据（模拟）
            AutoBindGrid(gridSourceKey, gridFields);

            var ttbSearch = UIHelper.TwinTriggerBox("ttbSearch");
            if (type == "trigger1")
            {
                ttbSearch.Text(String.Empty);
                ttbSearch.ShowTrigger1(false);

                ShowNotify("取消检索关键词");
            }
            else if (type == "trigger2")
            {
                ttbSearch.ShowTrigger1(true);

                var triggerValue = typeParams.Value<string>("triggerValue");
                ShowNotify("检索关键词：" + triggerValue);
            }
            else if (type == "dropdownlist")
            {
                var ddlValue = typeParams.Value<string>("ddlValue");
                ShowNotify("检索下拉列表值：" + ddlValue);
            }
            else if (type == "windowclose")
            {
                ShowNotify("窗体关闭了！");
            }


            return UIHelper.Result();
        }

        

    }

}