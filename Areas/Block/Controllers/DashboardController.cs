using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Block.Controllers
{
    public class DashboardController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Block/Dashboard
        public ActionResult Index()
        {
            return View();
        }

        
    }
}