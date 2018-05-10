using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Tree.Controllers
{
    public class TreeNodeExpandController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Tree/TreeNodeExpand
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tree1_NodeExpand(JObject nodeInfo)
        {
            UIHelper.Label("labResult").Text(String.Format("展开节点：{0}（{1}）", nodeInfo.Value<string>("id"), nodeInfo.Value<string>("text")));

            return UIHelper.Result();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tree1_NodeCollapse(JObject nodeInfo)
        {
            UIHelper.Label("labResult").Text(String.Format("折叠节点：{0}（{1}）", nodeInfo.Value<string>("id"), nodeInfo.Value<string>("text")));

            return UIHelper.Result();
        }

    }
}