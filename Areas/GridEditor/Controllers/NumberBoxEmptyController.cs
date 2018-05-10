using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridEditor.Controllers
{
    public class NumberBoxEmptyController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridEditor/NumberBoxEmpty
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            ViewBag.Grid1DataSource = GetSourceData();
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

            UpdateDataRow("Year", rowDict, rowData);
            UpdateDataRow("XueFei", rowDict, rowData);
            UpdateDataRow("ZhusuFei", rowDict, rowData);
            UpdateDataRow("HuoshiFei", rowDict, rowData);
            UpdateDataRow("ShubenFei", rowDict, rowData);
        }

        private void UpdateDataRow(string columnName, Dictionary<string, object> rowDict, DataRow rowData)
        {
            if (rowDict.ContainsKey(columnName))
            {
                object value = rowDict[columnName];

                // 如果客户端值为空字符串，但是列类型不是字符串，则设置为空对象 DBNull.Value
                if(value is String && String.IsNullOrEmpty(value.ToString()) && !(rowData[columnName] is String)) {
                    rowData[columnName] = DBNull.Value;
                } else {
                    rowData[columnName] = value;
                }
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

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "GridEditor.NumberBoxEmpty";

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
            table.Columns.Add(new DataColumn("Year", typeof(int)));
            table.Columns.Add(new DataColumn("XueFei", typeof(int)));
            table.Columns.Add(new DataColumn("ZhusuFei", typeof(int)));
            table.Columns.Add(new DataColumn("HuoshiFei", typeof(int)));
            table.Columns.Add(new DataColumn("ShubenFei", typeof(int)));

            DataRow row = table.NewRow();
            row[0] = 101;
            row[1] = 2014;
            row[2] = 1000;
            row[3] = 3000;
            row[4] = 2000;
            row[5] = 1000;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 102;
            row[1] = 2015;
            row[2] = 1200;
            row[3] = 3200;
            row[4] = 2200;
            row[5] = 1200;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 103;
            row[1] = 2016;
            row[2] = 1500;
            row[3] = 3500;
            row[4] = 2500;
            row[5] = 1500;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 104;
            row[1] = 2017;
            row[2] = DBNull.Value;
            row[3] = DBNull.Value;
            row[4] = DBNull.Value;
            row[5] = DBNull.Value;
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 105;
            row[1] = 2018;
            row[2] = DBNull.Value;
            row[3] = DBNull.Value;
            row[4] = DBNull.Value;
            row[5] = DBNull.Value;
            table.Rows.Add(row);


            return table;
        }

        #endregion

    }
}