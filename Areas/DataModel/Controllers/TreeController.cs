using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace FineUIMvc.Examples.Areas.DataModel.Controllers
{
    public class TreeController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: DataModel/Tree
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGetCheckedValues_Click(JArray checkedNodes)
        {
            var labResult = UIHelper.Label("labResult");

            if (checkedNodes.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("复选框选中的节点：");
                sb.Append("<ul>");

                foreach (JObject checkedNode in checkedNodes)
                {
                    sb.AppendFormat("<li>{0}（{1}）</li>", checkedNode.Value<string>("NodeText"), checkedNode.Value<string>("NodeId"));
                }

                sb.Append("</ul>");

                labResult.Text(sb.ToString(), encodeText: false);
            }
            else
            {
                labResult.Text("没有复选框选中的节点");
            }


            return UIHelper.Result();
        }
    }
}