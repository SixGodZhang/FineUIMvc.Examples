using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FineUIMvc.Examples.Areas.Tree.Controllers
{
    public class TreeNodeClickController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Tree/TreeNodeClick
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Tree1_NodeClick(string nodeId, string nodeText)
        {
            UIHelper.Label("labResult").Text(String.Format("你点击了树节点：{0}（{1}）", nodeId, nodeText));

            return UIHelper.Result();
        }

    }
}