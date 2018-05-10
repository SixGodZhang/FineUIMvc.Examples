using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Button.Controllers
{
    public class ButtonIconController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Button/ButtonIcon
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnCustomIcon_Click(string iconUrl)
        {
            var btnCustomIcon = UIHelper.Button("btnCustomIcon");

            if (iconUrl.EndsWith("1.png"))
            {
                btnCustomIcon.IconUrl("~/res/images/16/8.png");
            }
            else
            {
                btnCustomIcon.IconUrl("~/res/images/16/1.png");
            }

            return UIHelper.Result();
        }

    }
}