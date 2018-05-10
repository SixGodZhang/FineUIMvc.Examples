using FineUIMvc.Examples.Areas.DataModel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.DataModel.Controllers
{
    public class UICompareController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DataModel/UICompare
        public ActionResult Index()
        {
            var model = new UICompareModel();
            model.StartDate = DateTime.Now;
            model.Number1 = 30;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click([Bind(Include = "StartDate,EndDate,Password,ConfirmPassword,Number1,Number2")]UICompareModel compareModel)
        {
            if (ModelState.IsValid)
            {
                ShowNotify(String.Format("用户提交的数据：<br/><pre>{0}</pre>", JsonConvert.SerializeObject(compareModel, Formatting.Indented)));
            }

            return UIHelper.Result();
        }

    }
}