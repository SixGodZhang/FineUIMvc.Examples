using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Toolbar.Controllers
{
    public class MenuIconController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Toolbar/MenuIcon
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click(string icon)
        {
            var MenuHyperLink1 = UIHelper.MenuHyperLink("MenuHyperLink1");

            if (icon.EndsWith("accept.png"))
            {
                MenuHyperLink1.Icon(Icon.None);
            }
            else
            {
                MenuHyperLink1.Icon(Icon.Accept);
            }

            return UIHelper.Result();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click(string icon)
        {
            var MenuHyperLink1 = UIHelper.MenuHyperLink("MenuHyperLink2");

            if (icon.EndsWith("accept.png"))
            {
                MenuHyperLink1.Icon(Icon.Application);
            }
            else
            {
                MenuHyperLink1.Icon(Icon.Accept);
            }

            return UIHelper.Result();
        }

    }
}