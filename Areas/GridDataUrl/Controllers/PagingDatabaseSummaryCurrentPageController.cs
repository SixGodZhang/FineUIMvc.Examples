using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class PagingDatabaseSummaryCurrentPageController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/PagingDatabaseSummaryCurrentPage
        public ActionResult Index()
        {
            return View();
        }


    }
}