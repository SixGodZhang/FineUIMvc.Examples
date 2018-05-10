using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Toolbar.Controllers
{
    public class ToolbarFillController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Toolbar/ToolbarFill
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnHideFill1_Click(bool hidden)
        {
            var Button1 = UIHelper.Button("Button1");
            var ToolbarFill1 = UIHelper.ToolbarFill("ToolbarFill1");

            if (hidden)
            {
                Button1.Hidden(false);
                ToolbarFill1.Hidden(false);
            }
            else
            {
                Button1.Hidden(true);
                ToolbarFill1.Hidden(true);
            }

            return UIHelper.Result();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnHideFill2_Click(bool hidden)
        {
            var ToolbarFill5 = UIHelper.ToolbarFill("ToolbarFill5");
            
            if (hidden)
            {
                ToolbarFill5.Hidden(false);
            }
            else
            {
                ToolbarFill5.Hidden(true);
            }

            return UIHelper.Result();
        }

    }
}