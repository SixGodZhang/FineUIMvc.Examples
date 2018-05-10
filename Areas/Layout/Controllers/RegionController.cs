using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Layout.Controllers
{
    public class RegionController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Layout/Region
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button4_Click()
        {
            var panelLeftRegion = UIHelper.Panel("panelLeftRegion");

            string newtitle = String.Format("左侧面板（有提示信息） - 更新时间：{0}", DateTime.Now.ToLongTimeString());
            panelLeftRegion.Title(newtitle);
            panelLeftRegion.TitleToolTip(newtitle);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnHideBottomRegion_Click(bool hidden)
        {
            var panelBottomRegion = UIHelper.Panel("panelBottomRegion");

            panelBottomRegion.Hidden(!hidden);

            return UIHelper.Result();
        }

    }
}