using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridOther.Controllers
{
    public class EmptyTextFewColumnsController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridOther/EmptyTextFewColumns
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click(string[] fields, string source)
        {
            var grid1 = UIHelper.Grid("Grid1");

            if (source == "source1")
            {
                grid1.DataSource(DataSourceUtil.GetDataTable(), fields);
                grid1.Attribute("data-source-key", "source2");
            }
            else
            {
                grid1.DataSource(null);
                grid1.Attribute("data-source-key", "source1");
            }

            return UIHelper.Result();
        }


    }
}