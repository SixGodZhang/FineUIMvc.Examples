﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.GridDataUrl.Controllers
{
    public class PagingSortingDatabaseController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridDataUrl/PagingSortingDatabase
        public ActionResult Index()
        {
            return View();
        }


    }
}