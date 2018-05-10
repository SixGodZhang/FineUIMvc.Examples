using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Window.Controllers
{
    public class MaximizedController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Window/Maximized
        public ActionResult Index()
        {
            return View();
        }

    }
}