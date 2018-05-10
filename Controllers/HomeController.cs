using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace FineUIMvc.Examples.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            LoadData();

            return View("Index");
        }

        // GET: Themes
        public ActionResult Themes()
        {
            return View();
        }

        // GET: Loading
        public ActionResult Loading()
        {
            return View();
        }

        // GET: Source
        public ActionResult Source()
        {
            return View();
        }

        // GET: SourceFile
        public ActionResult SourceFile()
        {
            return View();
        }

        // GET: Home/IPMAC
        public ActionResult IPMAC()
        {
            return View();
        }

        // GET: Home/Test
        public ActionResult Test()
        {
            return View();
        }

        // GET: Home/Test1
        public ActionResult Test1()
        {
            return View();
        }

        #region LoadData

        private string _cookieMenuStyle = "tree";
        private bool _cookieShowOnlyBase = false;
        private string _cookieMenuMode = "normal";
        private string _cookieLang = "zh_CN";
        private string _cookieSearchText = "";
        // 示例数
        private int _examplesCount = 0;

        private void LoadData()
        {
            HttpCookie cookie = null;

            // 从Cookie中读取 - 是否仅显示基础版示例
            cookie = Request.Cookies["ShowOnlyBase"];
            if (cookie != null)
            {
                _cookieShowOnlyBase = Convert.ToBoolean(cookie.Value);
            }
            else
            {
                // // 如果没有记录Cookie，则基础版默认仅显示基础版示例
                // if (Constants.IS_BASE)
                // {
                // _cookieShowOnlyBase = true;
                // }
            }


            // 如果是FineUIMvc（基础版），或者用户选择仅显示基础版示例
            if (_cookieShowOnlyBase || Constants.IS_BASE)
            {
                // 基础版不支持紧凑模式，大字体模式，大间距模式，智能树菜单
                _cookieMenuStyle = "plaintree";
                _cookieMenuMode = "normal";
            }
            else
            {
                // 从Cookie中读取 - 左侧菜单类型
                cookie = Request.Cookies["MenuStyle"];
                if (cookie != null)
                {
                    _cookieMenuStyle = cookie.Value;
                }

                // 从Cookie中读取 - 显示模式
                cookie = Request.Cookies["MenuMode"];
                if (cookie != null)
                {
                    _cookieMenuMode = cookie.Value;
                }
            }


            // 从Cookie中读取 - 语言
            cookie = Request.Cookies["Language"];
            if (cookie != null)
            {
                _cookieLang = cookie.Value;
            }


            // 从Cookie中读取 - 搜索文本
            cookie = Request.Cookies["SearchText"];
            if (cookie != null)
            {
                _cookieSearchText = HttpUtility.UrlDecode(cookie.Value);
            }

            LoadTreeMenuData();

            ViewBag.CookieMenuStyle = _cookieMenuStyle;
            ViewBag.CookieShowOnlyBase = _cookieShowOnlyBase;
            ViewBag.CookieIsBase = Constants.IS_BASE;
            ViewBag.CookieMenuMode = _cookieMenuMode;
            ViewBag.CookieLang = _cookieLang;
            ViewBag.CookieSearchText = _cookieSearchText;

            ViewBag.ProductVersion = GlobalConfig.ProductVersion;
            ViewBag.OnlineUserCount = GetOnlineUserCount();
            ViewBag.ExamplesCount = _examplesCount.ToString();
        }

        private void LoadTreeMenuData()
        {
            string xmlPath = Server.MapPath("~/res/menu.xml");

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
            ViewBag.TreeMenuNodes = nodes.ToArray();
        }

        private int ResolveXmlNodeList(IList<TreeNode> nodes, XmlNodeList xmlNodes)
        {
            // nodes 中渲染到页面上的节点个数
            int nodeVisibleCount = 0;

            foreach (XmlNode xmlNode in xmlNodes)
            {
                if (xmlNode.NodeType != XmlNodeType.Element)
                {
                    continue;
                }

                TreeNode node = new TreeNode();

                // 是否叶子节点
                bool isLeaf = xmlNode.ChildNodes.Count == 0;

                bool currentNodeIsVisible = true;

                string nodeText = "";
                bool nodeIsCorp = false;

                XmlAttribute textAttr = xmlNode.Attributes["Text"];
                if (textAttr != null)
                {
                    nodeText = textAttr.Value;
                }

                // 是否企业版
                XmlAttribute isCorpAttr = xmlNode.Attributes["IsCorp"];
                if (isCorpAttr != null)
                {
                    nodeIsCorp = isCorpAttr.Value.ToLower() == "true";
                }


                int childVisibleCount = 0;
                if (isLeaf)
                {
                    // 仅显示基础版示例
                    if (_cookieShowOnlyBase && nodeIsCorp)
                    {
                        currentNodeIsVisible = false;
                    }

                    // 存在搜索文本
                    if (!String.IsNullOrEmpty(_cookieSearchText))
                    {
                        if (!nodeText.Contains(_cookieSearchText))
                        {
                            currentNodeIsVisible = false;
                        }
                    }
                }
                else
                {
                    // 递归
                    childVisibleCount = ResolveXmlNodeList(node.Nodes, xmlNode.ChildNodes);

                    if (childVisibleCount == 0)
                    {
                        currentNodeIsVisible = false;
                    }
                    else
                    {
                        // 存在搜索文本
                        if (!String.IsNullOrEmpty(_cookieSearchText))
                        {
                            // 展开节点
                            node.Expanded = true;
                        }
                    }
                }

                if (currentNodeIsVisible)
                {
                    foreach (XmlAttribute attribute in xmlNode.Attributes)
                    {
                        string name = attribute.Name;
                        string value = attribute.Value;

                        if (name == "Text")
                        {
                            // Text需要特殊处理
                            if (isLeaf)
                            {
                                // 设置节点的提示信息
                                node.ToolTip = nodeText;
                            }

                            // 存在 IsCorp=True 属性，则改变 Text 的值
                            if (nodeIsCorp)
                            {
                                node.IconFont = IconFont._Enterprise;
                                //nodeText += "&nbsp;<span class=\"iscorp\">Corp.</span>";
                            }

                            node.Text = nodeText;
                        }
                        else
                        {
                            node.SetPropertyValue(name, value);
                        }
                    }

                    nodes.Add(node);

                    // 本子节点显示
                    nodeVisibleCount++;

                    // 示例数只计算叶子节点
                    if (isLeaf)
                    {
                        _examplesCount++;
                    }

                }

            }

            return nodeVisibleCount;
        }


        #endregion


        private int GetOnlineUserCount()
        {
            return Convert.ToInt32(HttpContext.Application["OnlineUserCount"]);
        }

        public ActionResult Button2_Click()
        {
            return RedirectToAction("IPMAC");
        }
    }
}