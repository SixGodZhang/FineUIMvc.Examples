using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace FineUIMvc.Examples.Areas.Toolbar.Controllers
{
    public class MenuDynamicController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Toolbar/MenuDynamic
        public ActionResult Index()
        {
            LoadData();

            return View();
        }


        private void LoadData()
        {
            List<ControlBase> items = new List<ControlBase>();

            XmlDocument doc = LoadXml("~/Areas/Toolbar/Content/menu.xml");

            // 根节点的子节点们
            XmlNodeList nodes = doc.DocumentElement.ChildNodes;
            foreach (XmlNode node in nodes)
            {
                FineUIMvc.Button btn = new FineUIMvc.Button();
                btn.Text = node.Attributes["text"].Value;
                items.Add(btn);

                // 如果此节点没有子节点
                if (node.ChildNodes.Count == 0)
                {
                    XmlAttribute attrURL = node.Attributes["navigateurl"];
                    if (attrURL != null)
                    {
                        btn.OnClientClick = String.Format("window.open('{0}','_blank')", attrURL.Value);
                    }
                }
                else
                {
                    ResolveMenu(btn, node.ChildNodes);
                }
            }

            ViewBag.ToolbarItems = items.ToArray();
        }

        private void ResolveMenu(ControlBase btn, XmlNodeList nodes)
        {
            PropertyInfo menuInfo = btn.GetType().GetProperty("Menu");
            Menu menu = menuInfo.GetValue(btn, null) as Menu;

            foreach (XmlNode node in nodes)
            {
                XmlAttribute attrURL = node.Attributes["navigateurl"];
                if (attrURL != null)
                {
                    FineUIMvc.MenuHyperLink lnk = new FineUIMvc.MenuHyperLink();
                    lnk.Text = node.Attributes["text"].Value;
                    lnk.NavigateUrl = attrURL.Value;
                    lnk.Target = "_blank";

                    menu.Items.Add(lnk);

                    if (node.ChildNodes.Count > 0)
                    {
                        ResolveMenu(lnk, node.ChildNodes);
                    }
                }
            }
        }

        

        //private XmlDocument LoadXml()
        //{
        //    // 加载XML配置文件
        //    string xmlPath = Server.MapPath("~/Areas/Toolbar/Content/menu.xml");
        //    string xmlContent = String.Empty;
        //    using (StreamReader sr = new StreamReader(xmlPath))
        //    {
        //        xmlContent = sr.ReadToEnd();
        //    }
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xmlContent);

        //    return doc;
        //}


    }
}