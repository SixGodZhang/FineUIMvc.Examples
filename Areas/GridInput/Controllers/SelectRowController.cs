using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.GridInput.Controllers
{
    public class SelectRowController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridInput/SelectRow
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click(JArray inputs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class=\"result\"><tr><th>ID</th><th>姓名</th><th>用户输入值</th></tr>");

            foreach (JArray item in inputs)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",
                    item[0], item[1], item[2]);
            }

            sb.Append("</table>");

            ShowNotify(sb.ToString(), MessageBoxIcon.None);

            return UIHelper.Result();
        }

    }
}