using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Other.Controllers
{
    public class CustomPostbackController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Other/CustomPostback
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TextBox1_ENTER(string text1)
        {
            var textBox2 = UIHelper.TextBox("TextBox2");

            textBox2.Text(text1);
            textBox2.Focus(true);

            return UIHelper.Result();
        }

    }
}