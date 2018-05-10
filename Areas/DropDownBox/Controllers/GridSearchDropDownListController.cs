using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.DropDownBox.Controllers
{
    public class GridSearchDropDownListController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DropDownBox/GridSearchDropDownList
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        #region BindGrid

        private void LoadData()
        {
            var recordCount = GetTotalCount();

            // 1.设置总项数（特别注意：数据库分页初始化时，一定要设置总记录数RecordCount）
            ViewBag.Grid1RecordCount = recordCount;

            // 2.获取当前分页数据
            ViewBag.Grid1DataSource = GetPagedDataTable(pageIndex: 0, pageSize: 5, recordCount: recordCount);

        }

        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_DoReBind(string[] Grid1_fields, int Grid1_pageIndex, string ddlAtSchool, JArray Grid1_filteredData)
        {
            ReBindGrid(Grid1_fields, Grid1_pageIndex, ddlAtSchool, Grid1_filteredData);

            return UIHelper.Result();
        }

        private void ReBindGrid(string[] Grid1_fields, int Grid1_pageIndex, string ddlAtSchool, JArray filteredData)
        {
            var grid1 = UIHelper.Grid("Grid1");

            var recordCount = GetTotalCount(ddlAtSchool, filteredData);

            // 1.设置总项数（数据库分页回发时，如果总记录数不变，可以不设置RecordCount）
            grid1.RecordCount(recordCount);

            // 2.获取当前分页数据
            var dataSource = GetPagedDataTable(pageIndex: Grid1_pageIndex,
                pageSize: 5, recordCount: recordCount,
                ddlAtSchool: ddlAtSchool, filteredData: filteredData);
            grid1.DataSource(dataSource, Grid1_fields);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGetSelection_Click(string[] DropDownBox1, string DropDownBox1_text)
        {
            var labResult = UIHelper.Label("labResult");
            if (DropDownBox1.Length > 0)
            {
                labResult.Text(String.Format("下拉框文本：{0}（值：{1}）", DropDownBox1_text, String.Join(",", DropDownBox1)));
            }
            else
            {
                labResult.Text("下拉框为空");
            }

            return UIHelper.Result();
        }

        #region Data

        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount()
        {
            return GetTotalCount("-1", null);
        }

        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount(string ddlAtSchool, JArray filteredData)
        {
            return GetSource(ddlAtSchool, filteredData).Rows.Count;
        }

        /// <summary>
        /// 模拟数据库分页（实际项目中请直接使用SQL语句返回分页数据！）
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize, int recordCount)
        {
            return GetPagedDataTable(pageIndex, pageSize, recordCount, "-1", null);
        }

        /// <summary>
        /// 模拟数据库分页（实际项目中请直接使用SQL语句返回分页数据！）
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize, int recordCount, string ddlAtSchool, JArray filteredData)
        {
            //// 对传入的 pageIndex 进行有效性验证//////////////
            int pageCount = recordCount / pageSize;
            if (recordCount % pageSize != 0)
            {
                pageCount++;
            }
            if (pageIndex > pageCount - 1)
            {
                pageIndex = pageCount - 1;
            }
            if (pageIndex < 0)
            {
                pageIndex = 0;
            }
            ///////////////////////////////////////////////

            DataTable table = GetSource(ddlAtSchool, filteredData);

            DataTable paged = table.Clone();
            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > table.Rows.Count)
            {
                rowend = table.Rows.Count;
            }
            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(table.Rows[i]);
            }

            return paged;
        }

        private DataTable GetSource(string ddlAtSchool, JArray filteredData)
        {
            DataTable table2 = DataSourceUtil.GetDataTable2();

            DataView view2 = table2.DefaultView;

            List<string> filters = new List<string>();

            // 表格工具栏中的下拉列表过滤项
            if (ddlAtSchool != "-1")
            {
                filters.Add(String.Format("AtSchool = {0}", ddlAtSchool));
            }

            // 表头菜单的过滤项
            if (filteredData != null && filteredData.Count > 0)
            {
                foreach (JObject filteredObj in filteredData)
                {
                    // 本过滤项是[所学专业]列的过滤项
                    string columnID = filteredObj.Value<string>("column");

                    if (columnID == "Major")
                    {
                        JObject item = filteredObj.Value<JObject>("item");
                        string itemOperator = item.Value<string>("operator");
                        string itemValue = item.Value<string>("value");

                        if (!String.IsNullOrEmpty(itemValue))
                        {
                            string escapedValue = DataSourceUtil.EscapeLikeValue(itemValue);
                            if (itemOperator == "equal")
                            {
                                filters.Add(String.Format("Major = '{0}'", escapedValue));
                            }
                            else if (itemOperator == "contain")
                            {
                                filters.Add(String.Format("Major LIKE '*{0}*'", escapedValue));
                            }
                            else if (itemOperator == "start")
                            {
                                filters.Add(String.Format("Major LIKE '{0}*'", escapedValue));
                            }
                            else if (itemOperator == "end")
                            {
                                filters.Add(String.Format("Major LIKE '*{0}'", escapedValue));
                            }
                        }
                    }
                }
            }

            if (filters.Count > 0)
            {
                // RowFilter的用法：http://www.csharp-examples.net/dataview-rowfilter/
                view2.RowFilter = String.Join(" AND ", filters.ToArray());
            }

            return view2.ToTable();
        }

        #endregion
    }
}