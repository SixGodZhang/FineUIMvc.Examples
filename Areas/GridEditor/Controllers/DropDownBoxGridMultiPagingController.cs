using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace FineUIMvc.Examples.Areas.GridEditor.Controllers
{
    public class DropDownBoxGridMultiPagingController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridEditor/DropDownBoxGridMultiPaging
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            ViewBag.Grid1DataSource = GetSourceData();

            DataTable hobbyTable = GetHobbyTable();

            ViewBag.Grid2DataSource = hobbyTable;

            string hobbyTableScript = String.Format("window.hobbyTable={0};", JsonConvert.SerializeObject(hobbyTable));
            ViewBag.hobbyTableScript = hobbyTableScript;
        }



        private DataTable GetHobbyTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Code", typeof(String)));
            table.Columns.Add(new DataColumn("Name", typeof(String)));

            DataRow row = null;

            row = table.NewRow();
            row[0] = "reading";
            row[1] = "读书";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "basketball";
            row[1] = "篮球";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "travel";
            row[1] = "旅游";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "movie";
            row[1] = "电影";
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = "music";
            row[1] = "音乐";
            table.Rows.Add(row);

            return table;
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
            UpdateDataRow("EntranceYear", rowDict, rowData);
            UpdateDataRow("EntranceDate", rowDict, rowData);
            UpdateDataRow("AtSchool", rowDict, rowData);
            UpdateDataRow("Hobby", rowDict, rowData);
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

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "GridEditor.DropDownBoxGridMultiPaging";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private DataTable GetSourceData()
        {
            if (Session[KEY_FOR_DATASOURCE_SESSION] == null)
            {
                Session[KEY_FOR_DATASOURCE_SESSION] = DataSourceUtil.GetDataTable();
            }
            return (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];
        }

        #endregion

    }
}