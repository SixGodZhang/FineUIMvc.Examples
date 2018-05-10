using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class ChangeDataUrlDatabasePagingController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/ChangeDataUrlDatabasePaging
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click(string gridSourceKey)
        {
            var grid1 = UIHelper.Grid("Grid1");

            // 重置为第一页
            grid1.PageIndex(0);

            if (gridSourceKey == "source1")
            {
                grid1.Attribute("data-source-key", "source2");
                grid1.DataUrl(Url.Content("~/GridDataUrl/PagingDatabaseData?data2=true"));
            }
            else
            {
                grid1.Attribute("data-source-key", "source1");
                grid1.DataUrl(Url.Content("~/GridDataUrl/PagingDatabaseData"));
            }

            return UIHelper.Result();
        }

    }
}