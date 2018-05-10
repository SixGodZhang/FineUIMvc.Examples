using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class TreeGridDataController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/TreeGridData
        public ActionResult Index()
        {
            JArray ja = new JArray();

            DataTable source = DataSourceUtil.GetTreeDataTable();
            foreach (DataRow row in source.Rows)
            {
                JObject jo = new JObject();
                jo.Add("ParentId", (int)row["ParentId"]);
                jo.Add("Id", (int)row["Id"]);
                jo.Add("Name", row["Name"].ToString());
                jo.Add("Type", row["Type"].ToString());
                jo.Add("ModifyDate", (DateTime)row["ModifyDate"]);

                object fileSize = row["Size"];
                if (fileSize == DBNull.Value)
                {
                    jo.Add("Size", "");
                }
                else
                {
                    jo.Add("Size", (int)fileSize);
                }

                ja.Add(jo);
            }

            return Content(ja.ToString(Newtonsoft.Json.Formatting.None));
        }


    }
}