using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class SortingClientPagingController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/SortingPaging
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            string sortField = "Gender";
            string sortDirection = "ASC";

            ViewBag.Grid1DataSource = GetSortedDataTable(sortField, sortDirection);

            ViewBag.Grid1SortField = sortField;
            ViewBag.Grid1SortDirection = sortDirection;
        }

        private DataTable GetSortedDataTable(string sortField, string sortDirection)
        {
            // 模拟数据排序
            DataTable table = DataSourceUtil.GetDataTable2();
            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);

            return view1.ToTable();
        }


    }
}