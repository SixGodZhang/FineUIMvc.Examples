using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridOther.Controllers
{
    public class NewTabHideRefreshController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridOther/NewTabHideRefresh
        public ActionResult Index()
        {
            return View();
        }

        // GET: GridOther/NewTabHideRefresh/Window
        public ActionResult Window()
        {
            return View();
        }


    }
}