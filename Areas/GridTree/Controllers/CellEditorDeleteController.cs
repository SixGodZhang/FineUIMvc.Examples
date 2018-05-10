using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridTree.Controllers
{
    public class CellEditorDeleteController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridTree/CellEditorDelete
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
                string rowId = modifiedRow.Value<string>("id");

                if (status == "modified")
                {
                    UpdateDataRow(modifiedRow, Convert.ToInt32(rowId), source);
                }
                else if (status == "deleted")
                {
                    DeleteRowByID(source, Convert.ToInt32(rowId));
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
            UpdateDataRow("Type", rowDict, rowData);
            UpdateDataRow("Size", rowDict, rowData);
            UpdateDataRow("ModifyDate", rowDict, rowData);
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

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "GridTree.CellEditorDelete";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private DataTable GetSourceData()
        {
            if (Session[KEY_FOR_DATASOURCE_SESSION] == null)
            {
                Session[KEY_FOR_DATASOURCE_SESSION] = DataSourceUtil.GetTreeDataTable();
            }
            return (DataTable)Session[KEY_FOR_DATASOURCE_SESSION];
        }

        // 根据行ID来获取行数据
        private DataRow FindRowByID(int rowID)
        {
            DataTable table = GetSourceData();
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["Id"]) == rowID)
                {
                    return row;
                }
            }
            return null;
        }


        // 根据行ParentID来获取行数据
        private DataTable FindRowByParentID(DataTable table, int rowParentID)
        {
            DataTable result = table.Clone();
            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["ParentId"]) == rowParentID)
                {
                    result.ImportRow(row);
                }
            }
            return result;
        }

        // 根据行ID来删除行数据（同时递归删除所有子节点）
        private void DeleteRowByIDInternal(DataTable table, int rowID)
        {
            DataRow found = FindRowByID(rowID);
            if (found != null)
            {
                // 删除本行
                table.Rows.Remove(found);

                // 查找并删除所有子项
                DataTable children = FindRowByParentID(table, rowID);
                foreach (DataRow row in children.Rows)
                {
                    DeleteRowByIDInternal(table, Convert.ToInt32(row["Id"]));
                }
            }
        }


        // 根据行ID来删除行数据（同时递归删除所有子节点）
        private void DeleteRowByID(DataTable source, int rowID)
        {
            DeleteRowByIDInternal(source, rowID);
        }

        #endregion

    }
}