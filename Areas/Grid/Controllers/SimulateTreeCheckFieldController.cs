using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class SimulateTreeCheckFieldController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/SimulateTreeCheckField
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        #region LoadData

        private void LoadData()
        {
            ViewBag.Grid1DataSource = IniGrid();
        }

        private static DataTable IniGrid()
        {
            DataTable table = new DataTable();
            DataColumn column1 = new DataColumn("Id", typeof(int));
            DataColumn column2 = new DataColumn("Name", typeof(String));
            DataColumn column3 = new DataColumn("Group", typeof(String));
            DataColumn column4 = new DataColumn("TreeLevel", typeof(int));
            DataColumn column5 = new DataColumn("IsChecked", typeof(bool));
            table.Columns.Add(column1);
            table.Columns.Add(column2);
            table.Columns.Add(column3);
            table.Columns.Add(column4);
            table.Columns.Add(column5);

            DataRow row = table.NewRow();
            row[0] = 101;
            row[1] = "中国";
            row[2] = "1";
            row[3] = 0;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 102;
            row[1] = "河南省";
            row[2] = "2";
            row[3] = 1;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 103;
            row[1] = "驻马店市";
            row[2] = "3";
            row[3] = 2;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 104;
            row[1] = "漯河市";
            row[2] = "3";
            row[3] = 2;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 105;
            row[1] = "安徽省";
            row[2] = "2";
            row[3] = 1;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 106;
            row[1] = "合肥市";
            row[2] = "3";
            row[3] = 2;
            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 107;
            row[1] = "黄山市";
            row[2] = "3";
            row[3] = 2;
            table.Rows.Add(row);


            return table;
        }

        #endregion

    }
}