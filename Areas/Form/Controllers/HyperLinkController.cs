using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Form.Controllers
{
    public class HyperLinkController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Form/HyperLink
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnChangeEnable_Click(bool enabled)
        {
            var HyperLink2 = UIHelper.HyperLink("HyperLink2");

            if (!enabled)
            {
                HyperLink2.Enabled(true);
                HyperLink2.OnClientClick(Alert.GetShowInParentReference("这是链接的客户端提示"));
            }
            else
            {
                HyperLink2.Enabled(false);
                HyperLink2.OnClientClick("");
            }

            return UIHelper.Result();
        }

    }
}