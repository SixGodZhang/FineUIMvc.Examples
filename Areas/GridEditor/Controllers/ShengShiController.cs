using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridEditor.Controllers
{
    public class ShengShiController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridEditor/ShengShi
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            ViewBag.Grid1DataSource = GetSourceData();

            ViewBag.StartupScript = String.Format("window._SHI={0};", DataSourceUtil.SHI_JSON.ToString());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(string[] Grid1_fields, JArray Grid1_modifiedData)
        {
            DataTable source = GetSourceData();

            foreach (JObject modifiedRow in Grid1_modifiedData)
            {
                string status = modifiedRow.Value<string>("status");
                int rowId = Convert.ToInt32(modifiedRow.Value<string>("id"));

                if (status == "modified")
                {
                    UpdateDataRow(modifiedRow, rowId, source);
                }
            }

            UIHelper.Grid("Grid1").DataSource(source, Grid1_fields);
            UIHelper.Label("labResult").Text(String.Format("用户修改的数据：<pre>{0}</pre>", Grid1_modifiedData.ToString(Newtonsoft.Json.Formatting.Indented)), false);

            ShowNotify("数据保存成功！（表格数据已重新绑定）");

            return UIHelper.Result();
        }

        #region UpdateDataRow

        private void UpdateDataRow(JObject modifiedRow, int rowId, DataTable source)
        {
            Dictionary<string, object> rowDict = modifiedRow.Value<JObject>("values").ToObject<Dictionary<string, object>>();
            DataRow rowData = FindRowByID(source, rowId);

            UpdateDataRow("Name", rowDict, rowData);
            UpdateDataRow("Gender", rowDict, rowData);
            UpdateDataRow("Sheng", rowDict, rowData);
            UpdateDataRow("Shi", rowDict, rowData);
        }

        private void UpdateDataRow(string columnName, Dictionary<string, object> rowDict, DataRow rowData)
        {
            if (rowDict.ContainsKey(columnName))
            {
                rowData[columnName] = rowDict[columnName];
            }
        }

        private DataRow FindRowByID(DataTable table, int rowId)
        {
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["Id"]) == rowId)
                {
                    return row;
                }
            }
            return null;
        }

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "GridEditor.ShengShi";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private DataTable GetSourceData()
        {
            if (Session[KEY_FOR_DATASOURCE_SESSION] == null)
            {
                Session[KEY_FOR_DATASOURCE_SESSION] = GetDataTable();
            }
            return (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];
        }

        public static DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Name", typeof(string)));
            table.Columns.Add(new DataColumn("Gender", typeof(int)));
            table.Columns.Add(new DataColumn("Sheng", typeof(string)));
            table.Columns.Add(new DataColumn("Shi", typeof(string)));

            DataRow row = table.NewRow();
            row[0] = 101;
            row[1] = "张萍萍";
            row[2] = 0;
            row[3] = "河南";
            row[4] = "驻马店市";
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 102;
            row[1] = "陈飞";
            row[2] = 1;
            row[3] = "安徽";
            row[4] = "合肥市";
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 103;
            row[1] = "董婷婷";
            row[2] = 0;
            row[3] = "北京";
            row[4] = "北京市";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 104;
            row[1] = "刘国";
            row[2] = 0;
            row[3] = "";
            row[4] = "";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 105;
            row[1] = "康颖颖";
            row[2] = 0;
            row[3] = "";
            row[4] = "";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 106;
            row[1] = "彭博";
            row[2] = 1;
            row[3] = "";
            row[4] = "";
            table.Rows.Add(row);


            return table;
        }

        #endregion

    }
}