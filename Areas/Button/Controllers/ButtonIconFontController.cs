using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FineUIMvc.Examples.Areas.Button.Controllers
{
    public class ButtonIconFontController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Button/ButtonIconFont
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnCustomIconFont_Click(string iconFont)
        {
            var btnCustomIconFont = UIHelper.Button("btnCustomIconFont");

            if (iconFont == "volume-up")
            {
                btnCustomIconFont.IconFont(IconFont._VolumeDown);
            }
            else if (iconFont == "volume-down")
            {
                btnCustomIconFont.IconFont(IconFont._VolumeOff);
            }
            else
            {
                btnCustomIconFont.IconFont(IconFont._VolumeUp);
            }

            return UIHelper.Result();
        }
    }
}