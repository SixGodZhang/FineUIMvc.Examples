using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class GroupFieldComplexController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/GroupFieldComplex
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            ViewBag.Grid1DataSource = GetDataTable();

        }

        private DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("Guid", typeof(Guid)));
            table.Columns.Add(new DataColumn("Year", typeof(int)));
            table.Columns.Add(new DataColumn("HSData", typeof(int)));
            table.Columns.Add(new DataColumn("HFData", typeof(int)));
            table.Columns.Add(new DataColumn("HF_SHData", typeof(int)));
            table.Columns.Add(new DataColumn("HF_BHData", typeof(int)));
            table.Columns.Add(new DataColumn("LHData", typeof(int)));
            table.Columns.Add(new DataColumn("ZMDData", typeof(int)));
            table.Columns.Add(new DataColumn("ZMD_SPData", typeof(int)));
            table.Columns.Add(new DataColumn("ZMD_XPData", typeof(int)));
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
                row[9] = rd.Next(1000, 9999);
                row[10] = rd.Next(1000, 9999);
                row[11] = DateTime.Parse(String.Format("{0}-09-01", year));

                table.Rows.Add(row);
            }

            return table;
        }
        

    }
}