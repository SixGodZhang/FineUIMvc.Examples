using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Tree.Controllers
{
    public class TreeSelectController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Tree/TreeSelect
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnGetSelectedNode_Click(JObject selectedNode)
        {
            var labResult = UIHelper.Label("labResult");

            if (selectedNode.Count > 0)
            {
                labResult.Text(String.Format("选中的节点：{0}（{1}）", selectedNode.Value<string>("text"), selectedNode.Value<string>("id")));
            }
            else
            {
                labResult.Text("没有选中节点");
            }

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult btnSelectHefei_Click(string selectedNode)
        {
            UIHelper.Tree("Tree1").SelectedNodeID("Hefei");

            return UIHelper.Result();
        }
    }
}