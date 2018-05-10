using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.DropDownBox.Controllers
{
    public class GridLayoutAlwaysDisplayDefaultValueController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DropDownBox/GridLayoutAlwaysDisplayDefaultValue
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
        public ActionResult ttbSearch_Trigger1Click(string[] Grid1_fields, int Grid1_pageIndex, string rblAtSchool)
        {
            var ttbSearchBox = UIHelper.TwinTriggerBox("ttbSearch");

            ttbSearchBox.Text(String.Empty);
            ttbSearchBox.ShowTrigger1(false);

            ReBindGrid(Grid1_fields, Grid1_pageIndex, String.Empty, rblAtSchool);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_DoReBind(string[] Grid1_fields, int Grid1_pageIndex, string ttbSearch, string rblAtSchool)
        {
            // 如果搜索文本存在，确保显示第一个触发器按钮（清空按钮）
            if (!String.IsNullOrEmpty(ttbSearch))
            {
                UIHelper.TwinTriggerBox("ttbSearch").ShowTrigger1(true);
            }

            ReBindGrid(Grid1_fields, Grid1_pageIndex, ttbSearch, rblAtSchool);

            return UIHelper.Result();
        }

        private void ReBindGrid(string[] Grid1_fields, int Grid1_pageIndex, string ttbSearch, string rblAtSchool)
        {
            var grid1 = UIHelper.Grid("Grid1");

            var recordCount = GetTotalCount(ttbSearch, rblAtSchool);

            // 1.设置总项数（数据库分页回发时，如果总记录数不变，可以不设置RecordCount）
            grid1.RecordCount(recordCount);

            // 2.获取当前分页数据
            var dataSource = GetPagedDataTable(pageIndex: Grid1_pageIndex,
                pageSize: 5, recordCount: recordCount,
                ttbSearch: ttbSearch, rblAtSchool: rblAtSchool);
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
            return GetTotalCount(String.Empty, "-1");
        }

        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount(string ttbSearch, string rblAtSchool)
        {
            return GetSource(ttbSearch, rblAtSchool).Rows.Count;
        }

        /// <summary>
        /// 模拟数据库分页（实际项目中请直接使用SQL语句返回分页数据！）
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize, int recordCount)
        {
            return GetPagedDataTable(pageIndex, pageSize, recordCount, String.Empty, "-1");
        }

        /// <summary>
        /// 模拟数据库分页（实际项目中请直接使用SQL语句返回分页数据！）
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize, int recordCount, string ttbSearch, string rblAtSchool)
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

            DataTable table = GetSource(ttbSearch, rblAtSchool);

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

        private DataTable GetSource(string ttbSearch, string rblAtSchool)
        {
            DataTable table2 = DataSourceUtil.GetDataTable2();

            DataView view2 = table2.DefaultView;

            List<string> filters = new List<string>();

            if (!String.IsNullOrEmpty(ttbSearch))
            {
                // RowFilter的用法：http://www.csharp-examples.net/dataview-rowfilter/
                filters.Add(String.Format("Name LIKE '*{0}*'", DataSourceUtil.EscapeLikeValue(ttbSearch)));
            }


            if (rblAtSchool != "-1")
            {
                filters.Add(String.Format("AtSchool = {0}", rblAtSchool));
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