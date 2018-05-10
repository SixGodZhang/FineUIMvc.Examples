using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Editor.Controllers
{
    public class CKEditorTabStripController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Editor/CKEditorTabStrip
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click(string text1, string text2)
        {
            ShowNotify(String.Format("编辑器一：{0}<br/>编辑器二：{1}", text1, text2));

            return UIHelper.Result();
        }

    }
}