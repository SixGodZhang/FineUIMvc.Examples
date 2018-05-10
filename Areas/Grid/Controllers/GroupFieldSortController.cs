using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class GroupFieldSortController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/GroupFieldSort
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            string sortField = "HZData1";
            string sortDirection = "ASC";

            ViewBag.Grid1SortField = sortField;
            ViewBag.Grid1SortDirection = sortDirection;

            ViewBag.Grid1DataSource = GetSortedDataTable(sortField, sortDirection);

        }


        private DataTable GetSortedDataTable(string sortField, string sortDirection)
        {
            DataTable table = GetDataTable();

            DataView view1 = table.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);

            return view1.Table;
        }


        private DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Guid", typeof(Guid)));
            table.Columns.Add(new DataColumn("Year", typeof(int)));
            table.Columns.Add(new DataColumn("HZData1", typeof(int)));
            table.Columns.Add(new DataColumn("HZData2", typeof(int)));
            table.Columns.Add(new DataColumn("HLData1", typeof(int)));
            table.Columns.Add(new DataColumn("HLData2", typeof(int)));
            table.Columns.Add(new DataColumn("AHData1", typeof(int)));
            table.Columns.Add(new DataColumn("AHData2", typeof(int)));
            table.Columns.Add(new DataColumn("LogTime", typeof(DateTime)));


            DataRow row;

            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int year = 2000 + i;

                row = table.NewRow();
                row[0] = 100 + i;
                row[1] = Guid.NewGuid();
                row[2] = year;
                row[3] = rd.Next(1000, 9999);
                row[4] = rd.Next(1000, 9999);
                row[5] = rd.Next(1000, 9999);
                row[6] = rd.Next(1000, 9999);
                row[7] = rd.Next(1000, 9999);
                row[8] = rd.Next(1000, 9999);
                row[9] = DateTime.Parse(String.Format("{0}-09-01", year));

                table.Rows.Add(row);
            }

            return table;
        }


    }
}