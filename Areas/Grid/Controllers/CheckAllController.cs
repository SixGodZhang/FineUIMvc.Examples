using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Grid.Controllers
{
    public class CheckAllController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Grid/CheckAll
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button2_Click()
        {
            UIHelper.Grid("Grid1").SelectedRowIndexArray(1, 5, 7);

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Button1_Click(JArray selected)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table class=\"result\"><tr><th>ID</th><th>Text</th><th>性别</th><th>专业</th></tr>");

            foreach (JArray item in selected)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>",
                    item[0], item[1], 
                    Convert.ToInt32(item[2].ToString()) == 1 ? "男" : "女",
                    item[3]);
            }

            sb.Append("</table>");

            ShowNotify(sb.ToString(), MessageBoxIcon.None);

            return UIHelper.Result();
        }


    }
}