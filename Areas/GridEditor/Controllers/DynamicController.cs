using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridEditor.Controllers
{
    public class DynamicController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridEditor/Dynamic
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private int _minYear = 2014;
        private int _maxYear = 2017;

        private void LoadData()
        {
            ViewBag.Grid1DataSource = GetSourceData();

            List<GridColumn> columns = new List<GridColumn>();
            columns.Add(new RowNumberField());
            // Name
            var nameField = new RenderField();
            nameField.Width = 100;
            nameField.ColumnID = "Name";
            nameField.DataField = "Name";
            nameField.HeaderText = "收费项目";
            nameField.ExpandUnusedSpace = true;
            columns.Add(nameField);
            // YearData
            var yearDataField = new RenderField();
            yearDataField.ColumnID = "YearData";
            yearDataField.DataField = "YearData";
            yearDataField.HeaderText = "年份数据（隐藏）";
            yearDataField.Hidden = true;
            columns.Add(yearDataField);
            // 年份列
            RenderField rf;
            for (int i = _minYear; i <= _maxYear; i++)
            {
                rf = new RenderField();
                rf.Width =120;
                rf.HeaderText = i + "年";
                rf.FieldType = FieldType.Int;
                rf.ColumnID = "Year_" + i;

                NumberBox nb = new NumberBox();
                nb.NoNegative = true;
                nb.ID = "Year_" + i + "_Editor";
                nb.Required = true;
                rf.Editor.Add(nb);

                columns.Add(rf);
            }

            // 合计列
            rf = new RenderField();
            rf.Width = 120;
            rf.HeaderText = "合计";
            rf.FieldType = FieldType.Int;
            rf.ColumnID = "TotalFee";
            columns.Add(rf);

            ViewBag.Grid1Columns = columns.ToArray();

            ViewBag.StartupScript = String.Format("window._MINYEAR={0};window._MAXYEAR={1};", _minYear, _maxYear);
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

            JObject yearData = new JObject();
            string rowDataFieldValue = rowData["YearData"].ToString();
            if (!String.IsNullOrEmpty(rowDataFieldValue))
            {
                yearData = JObject.Parse(rowDataFieldValue);
            }

            // 更新修改的值
            for (int i = _minYear; i <= _maxYear; i++)
            {
                if (rowDict.ContainsKey("Year_" + i))
                {
                    yearData[i.ToString()] = new JValue(rowDict["Year_" + i]);
                }
            }

            rowData["YearData"] = yearData.ToString(Newtonsoft.Json.Formatting.None);
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

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "GridEditor.Dynamic";

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
            table.Columns.Add(new DataColumn("Name", typeof(String)));
            table.Columns.Add(new DataColumn("YearData", typeof(String)));

            DataRow row = table.NewRow();
            row[0] = 101;
            row[1] = "学费";
            row[2] = "";
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 102;
            row[1] = "住宿费";
            row[2] = "";
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 103;
            row[1] = "伙食费";
            row[2] = "";
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 104;
            row[1] = "书本费";
            row[2] = "";
            table.Rows.Add(row);


            row = table.NewRow();
            row[0] = 105;
            row[1] = "网络费";
            row[2] = "";
            table.Rows.Add(row);


            return table;
        }


        #endregion

    }
}