using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Toolbar.Controllers
{
    public class ToolbarIFrameController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Toolbar/ToolbarIFrame
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button3_Click()
        {
            PageContext.RegisterStartupScript(String.Format("updateIFrameUrl('{0}');", Url.Content("~/Basic/Login")));

            return UIHelper.Result();
        }
        
    }
}