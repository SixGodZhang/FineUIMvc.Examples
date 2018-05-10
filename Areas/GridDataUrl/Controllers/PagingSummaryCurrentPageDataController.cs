using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class PagingSummaryCurrentPageDataController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/PagingSummaryCurrentPageData
        public ActionResult Index()
        {
            JArray ja = new JArray();
            DataTable source = DataSourceUtil.GetDataTable2();
            foreach (DataRow row in source.Rows)
            {
                int fee = (int)row["Fee"];
                int donate = (int)row["Donate"];

                JObject jo = new JObject();
                jo.Add("Id", (int)row["Id"]);
                jo.Add("Name", row["Name"].ToString());
                jo.Add("Gender", (int)row["Gender"]);
                jo.Add("EntranceYear", (int)row["EntranceYear"]);
                jo.Add("AtSchool", (bool)row["AtSchool"]);
                jo.Add("Major", row["Major"].ToString());
                jo.Add("Fee", fee);
                jo.Add("Donate", donate);

                ja.Add(jo);
            }

            return Content(ja.ToString(Newtonsoft.Json.Formatting.None));
        }


    }
}