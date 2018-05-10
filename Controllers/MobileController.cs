using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace FineUIMvc.Examples.Controllers
{
    public class MobileController : BaseMobileController
    {
        // GET: Mobile/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Mobile/Main
        public ActionResult Main()
        {
            LoadData();

            return View();
        }

        
        private void LoadData()
        {
            XmlDocument doc = LoadXml("~/res/menu.xml");
            XmlNode mobileRootNode = doc.SelectSingleNode("/Tree/TreeNode[@Text=\"移动控件\"]");

            JArray menuSource = new JArray();
            // 一级菜单
            foreach (XmlNode node in mobileRootNode.ChildNodes)
            {
                string menuText = node.Attributes["Text"].Value;

                if (menuText == "移动首页")
                {
                    continue; // 不添加本项
                }

                JObject menu = new JObject();
                menu.Add("text", menuText);

                ResolveXmlNode(node, menu);

                menuSource.Add(menu);
            }


            // 移动菜单数据源
            ViewBag.StartupScript = String.Format("window.MENUSOURCE = {0};", menuSource.ToString());

            
            //List<DataListItem> items = new List<DataListItem>();
            //foreach (JObject item in menuSource)
            //{
            //    DataListItem listItem = new DataListItem(); 
            //    string text = item.Value<string>("text");
            //    listItem.Text = String.Format("<div class=\"item-text\">{0}</div>", text);
            //    listItem.NavigateUrl = "javascript:;";
            //    listItem.ShowArrow = true;

            //    items.Add(listItem);
            //}
            //// 顶层菜单
            //ViewBag.DataList1Items = items.ToArray();
            
        
        }

        private void ResolveXmlNode(XmlNode node, JObject parentMenu)
        {
            // 二级菜单
            JArray subMenus = new JArray();
            foreach (XmlNode subnode in node.ChildNodes)
            {
                JObject subMenu = new JObject();
                string subMenuText = subnode.Attributes["Text"].Value;

                if (subnode.HasChildNodes)
                {
                    subMenu.Add("text", subMenuText);

                    ResolveXmlNode(subnode, subMenu);
                }
                else
                {
                    string subMenuNavigateUrl = subnode.Attributes["NavigateUrl"].Value;

                    subMenu.Add("text", subMenuText);
                    subMenu.Add("navigateUrl", Url.Content(subMenuNavigateUrl.Replace("Mobile/?file=", "")));
                }

                subMenus.Add(subMenu);
            }

            parentMenu.Add("children", subMenus);
        }
    }
}