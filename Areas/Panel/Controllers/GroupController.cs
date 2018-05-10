using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Panel.Controllers
{
    public class GroupController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Panel/Group
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click(bool collapsed)
        {
            UIHelper.GroupPanel("GroupPanel2").Collapsed(!collapsed);

            return UIHelper.Result();
        }

    }
}