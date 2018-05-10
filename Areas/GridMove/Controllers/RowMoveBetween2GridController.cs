using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Text;


namespace FineUIMvc.Examples.Areas.GridMove.Controllers
{
    public class RowMoveBetween2GridController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: GridMove/RowMoveBetween2Grid
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnCheckSelected_Click(JArray columnNames)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (JObject item in columnNames)
            {
                sb.AppendFormat("<li>ID:{0}&nbsp;&nbsp;&nbsp;&nbsp;Name:{1}</li>", item.Value<string>("id"), item.Value<string>("name"));
            }
            sb.Append("</ul>");

            ShowNotify("已选择列表：" + sb.ToString(), MessageBoxIcon.None);

            return UIHelper.Result();
        }

    }
}