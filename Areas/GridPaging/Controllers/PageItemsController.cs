using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridPaging.Controllers
{
    public class PageItemsController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridPaging/PageItems
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnClearData_Click()
        {
            UIHelper.Grid("Grid1").DataSource(null);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnRebindData_Click(string[] fields)
        {
            UIHelper.Grid("Grid1").DataSource(DataSourceUtil.GetDataTable2(), fields);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSelectAll_Click()
        {
            UIHelper.Grid("Grid1").SelectAllRows();

            return UIHelper.Result();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnClearSelect_Click()
        {
            UIHelper.Grid("Grid1").DeselectAllRows();

            return UIHelper.Result();
        }

    }
}