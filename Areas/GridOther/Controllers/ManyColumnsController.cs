using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridOther.Controllers
{
    public class ManyColumnsController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridOther/ManyColumns
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        private void LoadData()
        {
            DataTable table = DataSourceUtil.GetDataTable();

            int newtableID = 101;
            DataTable newtable = table.Clone();
            for (int i = 0; i <= 2; i++)
            {
                foreach (DataRow row in table.Rows)
                {
                    row["Id"] = newtableID;
                    newtable.ImportRow(row);

                    newtableID++;
                }
            }

            ViewBag.Grid1DataSource = newtable;
        }



    }
}