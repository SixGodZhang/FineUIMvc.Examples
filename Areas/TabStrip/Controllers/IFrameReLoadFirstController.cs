using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.TabStrip.Controllers
{
    public class IFrameReLoadFirstController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: TabStrip/IFrameReLoadFirst
        public ActionResult Index()
        {
            return View();
        }

        // GET: TabStrip/IFrameReLoadFirst/EmptyPage
        public ActionResult EmptyPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSubmit_Click(FormCollection values)
        {
            

            ShowNotify(values);

            return UIHelper.Result();
        }

    }
}