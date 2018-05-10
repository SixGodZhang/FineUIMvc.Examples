using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Tree.Controllers
{
    public class CheckBoxCheckedController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Tree/CheckBoxChecked
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
                    sb.AppendFormat("<li>{0}（{1}）</li>", checkedNode.Value<string>("text"), checkedNode.Value<string>("id"));
                }

                sb.Append("</ul>");
                
                labResult.Text(sb.ToString(), encodeText:false);
            }
            else
            {
                labResult.Text("没有复选框选中的节点");
            }


            return UIHelper.Result();
        }

    }
}