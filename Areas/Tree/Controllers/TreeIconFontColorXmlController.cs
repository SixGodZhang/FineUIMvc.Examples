using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace FineUIMvc.Examples.Areas.Tree.Controllers
{
    public class TreeIconFontColorXmlController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Tree/TreeIconFontColorXml
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        // 需要添加到页面上的CSS
        Dictionary<string, string> dynamicCssDic = new Dictionary<string, string>();

        private void LoadData()
        {
            string xmlPath = Server.MapPath("~/Areas/Tree/Content/tree_iconfont_randomcolor.xml");

            string xmlContent = String.Empty;
            using (StreamReader sr = new StreamReader(xmlPath))
            {
                xmlContent = sr.ReadToEnd();
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmlContent);

            
            IList<TreeNode> nodes = new List<TreeNode>();
            ResolveXmlNodeList(nodes, xdoc.DocumentElement.ChildNodes);

            // 视图数据
            ViewBag.Tree1Nodes = nodes.ToArray();

            // 需要动态添加的CSS样式
            StringBuilder cssSB = new StringBuilder();
            foreach (string css in dynamicCssDic.Keys)
            {
                cssSB.AppendFormat("{0}\r\n", dynamicCssDic[css]);
            }
            // 视图数据
            ViewBag.DynamicCSS = cssSB.ToString();
        }

        private void ResolveXmlNodeList(IList<TreeNode> nodes, XmlNodeList xmlNodes)
        {
            foreach (XmlNode xmlNode in xmlNodes)
            {
                if (xmlNode.NodeType == XmlNodeType.Element)
                {
                    TreeNode node = new TreeNode();
                    nodes.Add(node);


                    foreach (XmlAttribute attribute in xmlNode.Attributes)
                    {
                        string name = attribute.Name;
                        string value = attribute.Value;

                        if (name == "IconFontColor")
                        {
                            // 规范化后的 CSS 名称
                            string normalizedCssName = "tn_color_" + value.Replace('#', '_');
                            
                            // 动态添加 CSS
                            if (!dynamicCssDic.ContainsKey(normalizedCssName))
                            {
                                dynamicCssDic[normalizedCssName] = String.Format(".{0} .f-tree-folder,.{0} .f-tree-cell-text{{color:{1};}}", normalizedCssName, value);
                            }


                            node.CssClass = normalizedCssName;
                        }
                        else
                        {
                            node.SetPropertyValue(name, value);
                        }
                    }

                    if (xmlNode.ChildNodes.Count > 0)
                    {
                        ResolveXmlNodeList(node.Nodes, xmlNode.ChildNodes);
                    }
                }
            }
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

    }
}