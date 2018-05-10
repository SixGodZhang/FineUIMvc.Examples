using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Button.Controllers
{
    public class ButtonGroupChangeTextController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Button/ButtonGroupChangeText
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnChangeButtonText_Click(string text)
        {
            UIHelper.Button("Button4").Text(text.Length == 3 ? "按钮四（" + DateTime.Now.ToString() + "）" : "按钮四");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnShowHideButton_Click(bool hidden)
        {
            UIHelper.Button("Button4").Hidden(!hidden);

            return UIHelper.Result();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnChangeButtonText2_Click(string text)
        {
            UIHelper.Button("Button8").Text(text.Length == 3 ? "按钮八（" + DateTime.Now.ToString() + "）" : "按钮八");

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnShowHideButton2_Click(bool hidden)
        {
            UIHelper.Button("Button8").Hidden(!hidden);

            return UIHelper.Result();
        }

    }
}