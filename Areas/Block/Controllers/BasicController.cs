﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Block.Controllers
{
    public class BasicController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Block/Basic
        public ActionResult Index()
        {
            return View();
        }

        
    }
}