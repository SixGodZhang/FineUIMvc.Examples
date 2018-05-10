using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridMove.Controllers
{
    public class ColumnMoveGroupFieldController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridMove/ColumnMoveGroupField
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        #region LoadData

        private void LoadData()
        {
            ViewBag.Grid1DataSource = GetDataTable();

            ViewBag.Grid1ColumnIDS = GetSavedColumns();
        }

        protected DataTable GetDataTable()
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
        #endregion

        #region Data

        private static readonly string KEY_FOR_DATASOURCE_SESSION = "GridMove.ColumnMoveGroupField";

        // 模拟在服务器端保存数据
        // 特别注意：在真实的开发环境中，不要在Session放置大量数据，否则会严重影响服务器性能
        private JArray GetSavedColumns()
        {
            if (Session[KEY_FOR_DATASOURCE_SESSION] == null)
            {
                //[{
                //    "columnId": "Year"
                //}, {
                //    "columnId": "Anhui",
                //    "columns": [{
                //        "columnId": "Hefei",
                //        "columns": [{
                //            "columnId": "AHData1"
                //        }, {
                //            "columnId": "AHData2"
                //        }]
                //    }]
                //}, {
                //    "columnId": "Henan",
                //    "columns": [{
                //        "columnId": "Zhumadian",
                //        "columns": [{
                //            "columnId": "HZData1"
                //        }, {
                //            "columnId": "HZData2"
                //        }]
                //    }, {
                //        "columnId": "Luohe",
                //        "columns": [{
                //            "columnId": "HLData1"
                //        }, {
                //            "columnId": "HLData2"
                //        }]
                //    }]
                //}, {
                //    "columnId": "LogTime"
                //}]
                Session[KEY_FOR_DATASOURCE_SESSION] = JArray.Parse("[{\"columnId\":\"Year\"},{\"columnId\":\"Anhui\",\"columns\":[{\"columnId\":\"Hefei\",\"columns\":[{\"columnId\":\"AHData1\"},{\"columnId\":\"AHData2\"}]}]},{\"columnId\":\"Henan\",\"columns\":[{\"columnId\":\"Zhumadian\",\"columns\":[{\"columnId\":\"HZData1\"},{\"columnId\":\"HZData2\"}]},{\"columnId\":\"Luohe\",\"columns\":[{\"columnId\":\"HLData1\"},{\"columnId\":\"HLData2\"}]}]},{\"columnId\":\"LogTime\"}]");
            }
            return (JArray)Session[KEY_FOR_DATASOURCE_SESSION];
        }

        
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Grid1_ColumnMove(JArray columnIds)
        {
            // 模拟操作数据库中的数据
            Session[KEY_FOR_DATASOURCE_SESSION] = columnIds;

            return UIHelper.Result();
        }
    }
}