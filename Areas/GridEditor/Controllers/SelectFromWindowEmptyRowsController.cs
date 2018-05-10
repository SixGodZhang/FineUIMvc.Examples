using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridEditor.Controllers
{
    public class SelectFromWindowEmptyRowsController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridEditor/SelectFromWindowEmptyRows
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
        public ActionResult btnSubmit_Click(string[] fields, JArray mergedData)
        {
            // 复制原始表格的结构
            DataTable newTable = GetSourceData().Clone();
            DataRow newRow;
            foreach (JObject mergedRow in mergedData)
            {
                string status = mergedRow.Value<string>("status");
                int rowIndex = mergedRow.Value<int>("index");
                JObject values = mergedRow.Value<JObject>("values");

                 // 用户名不为空，才保存到数据库
                string userName = values.Value<string>("Name");
                if (!String.IsNullOrEmpty(userName))
                {
                    newRow = newTable.NewRow();
                    newRow[0] = rowIndex; // 将行标识符设置为行索引号，实际项目中这个应该是数据库中的自增长主键，无需设置
                    newRow[1] = userName;
                    newRow[2] = GetDBNullOrTypeValue<int>(values, "EntranceYear");
                    newRow[3] = GetDBNullOrTypeValue<bool>(values, "AtSchool");
                    newRow[4] = values.Value<string>("Major");
                    newRow[5] = GetDBNullOrTypeValue<int>(values, "Gender");
                    newRow[6] = values.Value<string>("EntranceDate");
                    newTable.Rows.Add(newRow);
                }
            }
            Session[KEY_FOR_DATASOURCE_SESSION] = newTable;

            UIHelper.Grid("Grid1").DataSource(newTable, fields);
            UIHelper.Label("labResult").Text(String.Format("用户修改的数据：<pre>{0}</pre>", mergedData.ToString(Newtonsoft.Json.Formatting.Indented)), false);

            ShowNotify("数据保存成功！（表格数据已重新绑定）");

            return UIHelper.Result();
        }


        /// <summary>
        /// 返回空值（DBNull.Value），或者属性的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private object GetDBNullOrTypeValue<T>(JObject values, string propertyName)
        {
            if (String.IsNullOrEmpty(values.Value<string>(propertyName)))
            {
                return DBNull.Value;
            }
            else
            {
                return values.Value<T>(propertyName);
            }
        }

        #region UpdateDataRow

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "GridEditor.SelectFromWindowEmptyRows";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private DataTable GetSourceData()
        {
            if (Session[KEY_FOR_DATASOURCE_SESSION] == null)
            {
                Session[KEY_FOR_DATASOURCE_SESSION] = GetSimpleDataTable();
            }
            return (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];
        }

        /// <summary>
        /// 获取模拟表格（简单表格）
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSimpleDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Name", typeof(String)));
            table.Columns.Add(new DataColumn("EntranceYear", typeof(int)));
            table.Columns.Add(new DataColumn("AtSchool", typeof(bool)));
            table.Columns.Add(new DataColumn("Major", typeof(String)));
            table.Columns.Add(new DataColumn("Gender", typeof(int)));
            table.Columns.Add(new DataColumn("EntranceDate", typeof(String)));

            return table;
        }

        #endregion

    }
}