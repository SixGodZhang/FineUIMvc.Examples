using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Window.Controllers
{
    public class ToolbarController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Window/Toolbar
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnClose_Click()
        {
            UIHelper.Window("Window1").Hidden(true);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnChangeText_Click()
        {
            PageContext.RegisterStartupScript(String.Format("$('#mylabel').html('{0}')", "这是修改后的值！" + DateTime.Now.ToLongTimeString()));
            
            return UIHelper.Result();
        }

        
    }
}