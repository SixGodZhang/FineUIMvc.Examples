using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace FineUIMvc.Examples.Areas.Accordion.Controllers
{
    public class TreeController : FineUIMvc.Examples.Controllers.BaseController
    {
        // GET: Accordion/Tree
        public ActionResult Index()
        {
            LoadData();

            return View();
        }

        // GET: Accordion/Tree/DefaultPage
        public ActionResult DefaultPage()
        {
            return View();
        }

        private void LoadData()
        {
            string xmlPath = Server.MapPath("~/res/menu.xml");

            string xmlContent = String.Empty;
            using (StreamReader sr = new StreamReader(xmlPath))
            {
                xmlContent = sr.ReadToEnd();
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmlContent);

            ViewBag.Tree1DataSource = xdoc;
        }


    }
}