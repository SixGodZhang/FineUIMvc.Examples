using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class SortingPagingDatabaseController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/SortingPagingDatabase
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        #region BindGrid

        private void LoadData()
        {
            string sortField = "Gender";
            string sortDirection = "ASC";

            var recordCount = DataSourceUtil.GetTotalCount();

            // 1.设置总项数（特别注意：数据库分页初始化时，一定要设置总记录数RecordCount）
            ViewBag.Grid1RecordCount = recordCount;

            // 2.获取当前分页数据
            ViewBag.Grid1DataSource = DataSourceUtil.GetPagedDataTable(pageIndex: 0, 
                pageSize: 5,
                recordCount: recordCount,
                sortField: sortField,
                sortDirection: sortDirection);

            ViewBag.Grid1SortField = sortField;
            ViewBag.Grid1SortDirection = sortDirection;
        }

        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_PageIndexChangedOrSort(string[] Grid1_fields, int Grid1_pageIndex, string Grid1_sortField, string Grid1_sortDirection)
        {
            var grid1 = UIHelper.Grid("Grid1");

            var recordCount = DataSourceUtil.GetTotalCount();

            // 1.设置总项数（数据库分页回发时，如果总记录数不变，可以不设置RecordCount）
            grid1.RecordCount(recordCount);

            // 2.获取当前分页数据
            var dataSource = DataSourceUtil.GetPagedDataTable(pageIndex: Grid1_pageIndex, pageSize: 5, recordCount: recordCount, sortField: Grid1_sortField, sortDirection: Grid1_sortDirection);
            grid1.DataSource(dataSource, Grid1_fields);

            return UIHelper.Result();
        }

    }
}