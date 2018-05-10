using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.DropDownBox.Controllers
{
    public class GridSearchController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DropDownBox/GridSearch
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        #region BindGrid

        private void LoadData()
        {
            var recordCount = DataSourceUtil.GetTotalCount();

            // 1.设置总项数（特别注意：数据库分页初始化时，一定要设置总记录数RecordCount）
            ViewBag.Grid1RecordCount = recordCount;

            // 2.获取当前分页数据
            ViewBag.Grid1DataSource = DataSourceUtil.GetPagedDataTable(pageIndex: 0, pageSize: 5, recordCount: recordCount);

        }

        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ttbSearch_Trigger1Click(string[] Grid1_fields, int Grid1_pageIndex)
        {
            var ttbSearchBox = UIHelper.TwinTriggerBox("ttbSearch");

            ttbSearchBox.Text(String.Empty);
            ttbSearchBox.ShowTrigger1(false);

            ReBindGrid(Grid1_fields, Grid1_pageIndex, String.Empty);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_DoReBind(string[] Grid1_fields, int Grid1_pageIndex, string ttbSearch)
        {
            // 如果搜索文本存在，确保显示第一个触发器按钮（清空按钮）
            if (!String.IsNullOrEmpty(ttbSearch))
            {
                UIHelper.TwinTriggerBox("ttbSearch").ShowTrigger1(true);
            }

            ReBindGrid(Grid1_fields, Grid1_pageIndex, ttbSearch);

            return UIHelper.Result();
        }


        private void ReBindGrid(string[] Grid1_fields, int Grid1_pageIndex, string ttbSearch)
        {
            var grid1 = UIHelper.Grid("Grid1");

            var recordCount = DataSourceUtil.GetTotalCount(ttbSearch);

            // 1.设置总项数（数据库分页回发时，如果总记录数不变，可以不设置RecordCount）
            grid1.RecordCount(recordCount);

            // 2.获取当前分页数据
            var dataSource = DataSourceUtil.GetPagedDataTable(pageIndex: Grid1_pageIndex, pageSize: 5, recordCount: recordCount, searchKeyword: ttbSearch);
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

    }
}