﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class FormController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/Form
        public ActionResult Index()
        {
            return View();
        }


    }
}