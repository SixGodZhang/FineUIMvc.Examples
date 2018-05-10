using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Tree.Controllers
{
    public class TreeSelectMultiSelectableController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Tree/TreeSelectMultiSelectable
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGetSelectedValues_Click(JArray selectedNodes)
        {
            var labResult = UIHelper.Label("labResult");

            if (selectedNodes.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("选中的节点：");
                sb.Append("<ul>");

                foreach (JObject node in selectedNodes)
                {
                    sb.AppendFormat("<li>{0}（{1}）</li>", node.Value<string>("text"), node.Value<string>("id"));
                }

                sb.Append("</ul>");

                labResult.Text(sb.ToString(), encodeText: false);
            }
            else
            {
                labResult.Text("没有选中的节点");
            }


            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSelectOthers_Click(string selectedNodes)
        {
            UIHelper.Tree("Tree1").SelectedNodeIDArray(true, "Hefei", "Huangshan");

            return UIHelper.Result();
        }

    }
}