using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class HeaderChangeTextWidthController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/HeaderWrap
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click()
        {
            PageContext.RegisterStartupScript(String.Format("changeColumnTitleAndWidth('入学年份（已修改）', 200);"));

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click()
        {
            PageContext.RegisterStartupScript(String.Format("changeColumnTitleAndWidth('入学年份', 120);"));

            return UIHelper.Result();
        }

    }
}