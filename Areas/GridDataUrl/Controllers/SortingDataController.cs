using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class SortingDataController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/SortingData
        public ActionResult Index(string sortField, string sortDirection, bool? data2)
        {
            JArray ja = new JArray();

            DataTable source = null;
            if (data2.HasValue && data2.Value)
            {
                source = DataSourceUtil.GetDataTable2();
            }
            else
            {
                source = DataSourceUtil.GetDataTable();
            }
            
            DataView view1 = source.DefaultView;
            view1.Sort = String.Format("{0} {1}", sortField, sortDirection);

            DataTable sortedTable = view1.ToTable();

            foreach (DataRow row in sortedTable.Rows)
            {
                JObject jo = new JObject();
                jo.Add("Id", (int)row["Id"]);
                jo.Add("Name", row["Name"].ToString());
                jo.Add("Gender", (int)row["Gender"]);
                jo.Add("EntranceYear", (int)row["EntranceYear"]);
                jo.Add("AtSchool", (bool)row["AtSchool"]);
                jo.Add("Major", row["Major"].ToString());
                jo.Add("Group", (int)row["Group"]);

                ja.Add(jo);
            }

            return Content(ja.ToString(Newtonsoft.Json.Formatting.None));
        }

    }
}