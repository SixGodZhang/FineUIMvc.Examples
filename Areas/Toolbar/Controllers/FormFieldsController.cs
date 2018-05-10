using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Toolbar.Controllers
{
    public class FormFieldsController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Toolbar/FormFields
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnClearDate_Click(string checkedValue)
        {
            UIHelper.DatePicker("dpStartDate").Reset();
            UIHelper.DatePicker("dpEndDate").Reset();

            UIHelper.Grid("Grid1").DataSource(null);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSearch_Click(string[] Grid1_fields)
        {
            UIHelper.Grid("Grid1").DataSource(DataSourceUtil.GetDataTable(), Grid1_fields);

            return UIHelper.Result();
        }
        
       
    }
}