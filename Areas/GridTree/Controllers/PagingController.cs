using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridTree.Controllers
{
    public class PagingController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridTree/Paging
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
            ViewBag.Grid1DataSource = GetPagedDataTable(pageIndex: 0, pageSize: 2, recordCount: recordCount);

        }

        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount()
        {
            DataTable source = DataSourceUtil.GetTreeDataTable();

            return GetTopNodeTable(source).Rows.Count;
        }

        private DataTable GetTopNodeTable(DataTable source)
        {
            DataTable topTable = source.Clone();

            foreach (DataRow row in source.Rows)
            {
                int parentId = Convert.ToInt32(row["ParentId"]);

                if (parentId == -1)
                {
                    topTable.ImportRow(row);
                }
            }

            return topTable;
        }

        /// <summary>
        /// 模拟数据库分页（实际项目中请直接使用SQL语句返回分页数据！）
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize, int recordCount)
        {
            DataTable source = DataSourceUtil.GetTreeDataTable();
            DataTable topTable = GetTopNodeTable(source);

            DataTable paged = source.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > recordCount)
            {
                rowend = recordCount;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                DataRow topTableRow = topTable.Rows[i];
                paged.ImportRow(topTableRow);

                ImportCurrentPageTable(source, paged, Convert.ToInt32(topTableRow["Id"]));
            }

            return paged;
        }

        // 递归查找需要的行
        private void ImportCurrentPageTable(DataTable source, DataTable paged, int rowId)
        {
            foreach (DataRow row in source.Rows)
            {
                int parentRowId = Convert.ToInt32(row["ParentId"]);

                if (rowId == parentRowId)
                {
                    paged.ImportRow(row);

                    ImportCurrentPageTable(source, paged, Convert.ToInt32(row["Id"]));
                }
            }
        }

        #endregion


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_PageIndexChanged(string[] Grid1_fields, int Grid1_pageIndex)
        {
            var grid1 = UIHelper.Grid("Grid1");

            var recordCount = GetTotalCount();

            // 1.设置总项数（数据库分页回发时，如果总记录数不变，可以不设置RecordCount）
            grid1.RecordCount(recordCount);

            // 2.获取当前分页数据
            var dataSource = GetPagedDataTable(pageIndex: Grid1_pageIndex, pageSize: 2, recordCount: recordCount);
            grid1.DataSource(dataSource, Grid1_fields);

            return UIHelper.Result();
        }

    }
}